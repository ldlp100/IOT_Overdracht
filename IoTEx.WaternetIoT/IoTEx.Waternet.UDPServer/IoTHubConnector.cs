using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Common.Exceptions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IoT.UDPServer
{
    public class IoTHubConnector
    {
        public enum IOT_DEVICEEnum { IOTDEV_UNDEFINED, IOTDEV_KERLINK_LORAWAN, IOTDEV_NBIOT_T_MOBILE, IOTDEV_SIGFOX, IOTDEV_UDP_APN_TMOBILE_NBIOT }

     
        static Dictionary<string, string> deviceKeyDict;
        private static RegistryManager registryManager;

        private async static Task<string> RegisterDevice(string iotHubRegisterConnectionString, string iotHubDeviceConnectionString, string deviceId, ILogger log)
        {
           

            if (string.IsNullOrEmpty(iotHubRegisterConnectionString))
                log.LogError("'AzureIotHubRegisterConnectionString' parameter not defined");
            if (string.IsNullOrEmpty(iotHubDeviceConnectionString))
                log.LogError("'AzureIotHubDeviceConnectionString' parameter not defined");

            registryManager = RegistryManager.CreateFromConnectionString(iotHubRegisterConnectionString);

            return await AddDeviceAsync(deviceId);
        }
        private async static Task<string> AddDeviceAsync(string deviceId)
        {
            Device device;
            try
            {
                Console.WriteLine("New device:");
                device = await registryManager.AddDeviceAsync(new Device(deviceId));
            }
            catch (DeviceAlreadyExistsException)
            {
                Console.WriteLine("Already existing device:");
                device = await registryManager.GetDeviceAsync(deviceId);
            }
            
            return device.Authentication.SymmetricKey.PrimaryKey;
        }

        private static string GetConnectionStringForDevice(string iotHubDeviceConnectionString, string deviceId, string deviceKey)
        {
            
            string deviceConn = iotHubDeviceConnectionString.Replace("{DEVICE_ID}", deviceId).Replace("{SHARED_KEY}", deviceKey);
            return deviceConn;
        }
        
        /// <summary>
        /// Take the information from the callback function and send it directly to the IotHub. 
        /// </summary>
        /// <param name="device"></param>
        /// <param name="jsonMessage"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        public static async Task<int> SendIoTMessageFromDeviceToCloudAsync(string imei, string iotHubRegisterConnectionString, string iotHubDeviceConnectionString, 
                                        IOT_DEVICEEnum device, string jsonMessage, ILogger log)
        {
            DeviceClient deviceClient = null;
            try
            {
                string deviceKey = await RegisterDevice(iotHubRegisterConnectionString,iotHubDeviceConnectionString, device.ToString(), log);
                string deviceConnectionString = GetConnectionStringForDevice(iotHubDeviceConnectionString, device.ToString(), deviceKey);
                log.LogInformation("Device Connection String: " + deviceConnectionString);
                deviceClient = DeviceClient.CreateFromConnectionString(deviceConnectionString);
                log.LogInformation($"Start sending data for {imei}");
                var messageIotHub = new Microsoft.Azure.Devices.Client.Message(Encoding.UTF8.GetBytes(jsonMessage));
                await deviceClient.SendEventAsync(messageIotHub);
                log.LogInformation($"Message sent succesfully to IotHub for device with imei:'{imei}' length: {jsonMessage.Length}");
                return 0;
            }
            catch (Exception ex)
            {
                log.LogError($"Message Cannot send message for imei:{imei} to IoTHub Device '" + device.ToString() + "'! Error:" + ex.Message, ex);
                if (ex.InnerException!=null)
                    log.LogError("Message Cannot send message  for imei:{imei} to IoTHub Device '" + device.ToString() + "'! Error:" + ex.InnerException.Message, ex);
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
