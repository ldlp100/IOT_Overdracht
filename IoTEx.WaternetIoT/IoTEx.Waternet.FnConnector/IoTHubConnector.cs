using IoTEx.WaternetIoT.Model.Device;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Common.Exceptions;
using Microsoft.Azure.Devices;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoTEx.WaternetIoT.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace IoTEx.Waternet.FnConnector
{
    internal class IoTHubConnector
    {
        private readonly ILogger<IoTHubConnector> _logger;
        private IoTDBContext _dbContext;
        private IConfiguration _configuration;
        public IoTHubConnector(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            _configuration = configuration;
            _logger = loggerFactory.CreateLogger<IoTHubConnector>();
        }
        public enum IOT_DEVICEEnum { IOTDEV_UNDEFINED, IOTDEV_KERLINK_LORAWAN, IOTDEV_NBIOT_T_MOBILE, IOTDEV_SIGFOX, IOTDEV_UDP_APN_TMOBILE_NBIOT }

        static string iotHubDeviceConnectionString = "";
        //"HostName=WATERNET-IOT-DEMO-IOTHUB.azure-devices.net;DeviceId={DEVICE_ID};SharedAccessKey={SHARED_KEY}";

        static string iotHubRegisterConnectionString = "";
        //"HostName=WATERNET-IOT-DEMO-IOTHUB.azure-devices.net;SharedAccessKeyName=registryReadWrite;SharedAccessKey=d6nFB2rBnsKKnErjkA4jKWr1qqMGemGR1t2G2yAPF9w=";

        static Dictionary<string, string> deviceKeyDict;
        private static RegistryManager registryManager;

        private static bool RegisterDevice(string deviceId, ILogger log)
        {
            iotHubRegisterConnectionString = Environment.GetEnvironmentVariable("IOTEX_IOTHUB_CONN");
            iotHubDeviceConnectionString = Environment.GetEnvironmentVariable("IOTEX_IOTHUB_DEVICE_CONN");
            //'HostName=iot-hub-p-waternet-iothub.azure-devices.net;DeviceId=IOTDEV_KERLINK_LORAWAN;SharedAccessKey=XA2Z8irfuabLpmFzlvNh8YNQB5j9Q9MiosvhAtEAq+0='

            if (string.IsNullOrEmpty(iotHubRegisterConnectionString))
            {
                log.LogError("'IOTEX_IOTHUB_CONN' environment variable not defined");
                return false;
            }
            if (string.IsNullOrEmpty(iotHubDeviceConnectionString))
            {
                log.LogError("'IOTEX_IOTHUB_DEVICE_CONN' parameter not defined");
                return false;
            }
            if (registryManager == null)
                registryManager = RegistryManager.CreateFromConnectionString(iotHubRegisterConnectionString);

            //Check if Key exist in the Key Dictionnary
            if (deviceKeyDict == null)
            {
                deviceKeyDict = new Dictionary<string, string>();
            }
            if (!deviceKeyDict.ContainsKey(deviceId))
            {
                if (!deviceKeyDict.ContainsKey(deviceId))
                    AddDeviceAsync(deviceId).Wait();
            }
            return true;
        }
        private async static Task AddDeviceAsync(string deviceId)
        {
            Device device;
            try
            {
                
                device = await registryManager.AddDeviceAsync(new Device(deviceId));
                Console.WriteLine($"New device '{deviceId}' registered:");
            }
            catch (DeviceAlreadyExistsException)
            {
                Console.WriteLine($"Device '{deviceId}' already existing device:");
                device = await registryManager.GetDeviceAsync(deviceId);
                Console.WriteLine($"device key:{device.Authentication.SymmetricKey.PrimaryKey}");
            }
            deviceKeyDict.Add(deviceId, device.Authentication.SymmetricKey.PrimaryKey);

        }

        private static string GetConnectionStringForDevice(string deviceId, ILogger log)
        {
            string key = deviceKeyDict[deviceId];
            string deviceConn = iotHubDeviceConnectionString.Replace("{DEVICE_ID}", deviceId).Replace("{SHARED_KEY}", key);
            log.LogInformation("Device Connection String:" + deviceConn);
            return deviceConn;
        }
        /// <summary>
        /// Send IotMessage to the IoTHub
        /// </summary>
        /// <param name="message"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        //public static async Task<int> SendDeviceToCloudMessageAsync(IoTDeviceMessage message, ILogger log)
        //{
        //    DeviceClient deviceClient = null;
        //    try
        //    {

        //        System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();

        //        string jsonMessage = JsonConvert.SerializeObject(message);
        //        log.LogInformation("Json Message Decrypted:" + jsonMessage);

        //        RegisterDevice(message.DeviceID, log);
        //        //log.Info("Register Devices (" + sw.ElapsedMilliseconds + "msec)");
        //        deviceClient = DeviceClient.CreateFromConnectionString(GetConnectionStringForDevice(message.DeviceID));

        //        //log.Info("Create Client (" + sw.ElapsedMilliseconds + "msec)");
        //        var messageIotHub = new Microsoft.Azure.Devices.Client.Message(Encoding.UTF8.GetBytes(jsonMessage));

        //        await deviceClient.SendEventAsync(messageIotHub);
        //        //log.Info("Message Sent (" + sw.ElapsedMilliseconds + "msec)");
        //        return 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        log.LogError("Message Id: " + message.MUID + "-Error Sending Message to IoT Hub with error:" + ex.Message, ex);
        //        return -1;
        //    }
        //    finally
        //    {
        //        if (deviceClient != null)
        //            deviceClient.CloseAsync().Wait();
        //    }
        //}

        /// <summary>
        /// TAke the information from the callback function and send it directly to the IotHub. 
        /// </summary>
        /// <param name="device"></param>
        /// <param name="jsonMessage"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        public static async Task<int> SendIoTMessageFromDeviceToCloudAsync(IOT_DEVICEEnum device, string jsonMessage, ILogger log)
        {
            DeviceClient deviceClient = null;
            try
            {
                if (RegisterDevice(device.ToString(), log))
                {
                    deviceClient = DeviceClient.CreateFromConnectionString(GetConnectionStringForDevice(device.ToString(), log));
                    if (deviceClient == null)
                    {
                        log.LogError($"{device.ToString()}-DEVICE NOT FOUND");
                        return -1;
                    }
                    log.LogInformation($"message = {jsonMessage}");
                    var messageIotHub = new Microsoft.Azure.Devices.Client.Message(Encoding.UTF8.GetBytes(jsonMessage));
                    await deviceClient.SendEventAsync(messageIotHub);
                    return 0;
                }
                else
                {
                    log.LogError($"{device.ToString()}-DEVICE NOT FOUND");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                log.LogError("Message Cannot send message to IoTHub Device '" + device.ToString() + "'! Error:" + ex.Message, ex);
                return -1;
            }
            finally
            {
                if (deviceClient != null)
                    deviceClient.CloseAsync().Wait();
            }
        }
    }
}
