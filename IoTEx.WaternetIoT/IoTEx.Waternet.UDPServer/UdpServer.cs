
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
//using Serilog.Extensions.Logging;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IoT.UDPServer
{
    public class UDPListener
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;
        private const int listenPort = 30001;
        public static IConfigurationRoot configuration;

        private async void StartListener()
        {
            
            int listenPort = int.Parse(configuration["ListeningUDPPort"]);
            _logger.LogInformation($"Configuration file listening UDP port: {listenPort}");
            UdpClient updServer = new UdpClient(listenPort);
            
            _logger.LogInformation($"UPP Sever listening on port {listenPort}");
            try
            {
                while (true)
                {
                    try
                    {
                        IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);
                        byte[] bytes = updServer.Receive(ref groupEP);
                        _logger.LogDebug($"Received broadcast from {groupEP.Address.ToString()} :");
                        _logger.LogDebug($" {Encoding.ASCII.GetString(bytes, 0, bytes.Length)}");

                        string data = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                        PostMessageOnIoTHub(data);

                        string acknowledge = "796573";//YES    
                        byte[] AcknowledgeSTR = Encoding.ASCII.GetBytes(acknowledge);
                        updServer.Send(AcknowledgeSTR, AcknowledgeSTR.Length, groupEP);
                        _logger.LogDebug($"Sending data back to  {groupEP.Address.ToString()}: {acknowledge}");
                    }
                    catch(Exception e)
                    {
                        _logger.LogCritical(e.Message + "\r\n" + e.StackTrace);
                    }
                }
            }
            catch (SocketException e)
            {
                _logger.LogCritical(e.Message + "\r\n" + e.StackTrace);
            }
            finally
            {
                updServer.Close();
            }
        }
        public UDPListener(ILogger<UDPListener> logger)
        {
            _logger = logger;
        }
        private static void ConfigureServices(IServiceCollection services, bool logFile)
        {
            if (logFile)
            {
                var service = services.AddLogging(configure =>
                {
                    configure.AddConfiguration(configuration.GetSection("Logging"))
                    .AddSerilog(new LoggerConfiguration().WriteTo.File("log.txt").CreateLogger())
                    .AddConsole();
                })
                .AddTransient<UDPListener>().AddTransient<HTTPServer>();
            }
            else
            {
                var service = services.AddLogging(configure =>
                {
                    configure.AddConfiguration(configuration.GetSection("Logging"))
                    .AddConsole();
                })
                .AddTransient<UDPListener>().AddTransient<HTTPServer>();
            }
        }
        
        private string MakePayload(string data, string address)
        {
            string IMEI = "1234567";
            string IMSI = "ABCDEFG";
            long dateTime = ToUnixTime(DateTime.UtcNow);
            float latitude = 54.3f;
            float longitude = 4.5f;
            float radius = 3.2f;
            string content = "{" +
                "\"imei\":\"IMEI:" + IMEI + "\"," +
                "\"imsi\":\"" + IMSI + "\"," +
                "\"timestamp\":" + dateTime + "," +
                "\"payload\":\"" + data + "\"," +
                "\"longitude\":\"" + longitude + "\"," +
                "\"latitude\":\"" + latitude + "\"," +
                "\"radius\":\"" + radius + "\"," +
                "\"ip\":\"" + address + "\"," +

                "}}";
            return content;
        }
        public static long ToUnixTime(DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((date.ToUniversalTime() - epoch).TotalSeconds);
        }
        private async Task<int> PostMessageOnIoTHub(string payload)
        {
            try
            {

                DateTime dateTime = DateTime.Now;
                
                string imei = payload.Substring(0, 15);
                string messagePayload = payload.Substring(15);

                _logger.LogInformation($"{dateTime.ToLongTimeString()}-Message from device with imei:'{imei}' length: {payload.Length-15}");

                string jsonMessage = $"{{\"payload\": {{ \"imei\":\"{imei}\", \"payload\":\"{messagePayload}\"}}}}";
                _logger.LogInformation($"{dateTime.ToLongTimeString()}-Message:\r\n {jsonMessage}");
                
                string iotHubDeviceConnectionString = "";
                string iotHubRegisterConnectionString = "";
                switch (imei)
                {
                    default:
                        _logger.LogInformation($"IMEI: {imei} => NEW IOTHUB");
                        iotHubDeviceConnectionString = configuration.GetValue<string>("AzureIotHubDeviceConnectionStringNEW");
                        iotHubRegisterConnectionString = configuration.GetValue<string>("AzureIotHubRegisterConnectionStringNEW");
                        break;
                   
                }
                _logger.LogInformation($"{dateTime.ToLongTimeString()}-iotHubDeviceConnectionString:'{iotHubDeviceConnectionString}'");
                _logger.LogInformation($"{dateTime.ToLongTimeString()}-iotHubRegisterConnectionString:'{iotHubRegisterConnectionString}'");

                int result = await IoTHubConnector.SendIoTMessageFromDeviceToCloudAsync(imei, iotHubRegisterConnectionString, iotHubDeviceConnectionString, IoTHubConnector.IOT_DEVICEEnum.IOTDEV_UDP_APN_TMOBILE_NBIOT, jsonMessage, _logger);
                
                return 0;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected Error processing data: '{payload}'");
                return 1;
            }
            
        }
        private async void PostHTTPToServer(string data, string address)
        {
            try
            {
                _logger.LogInformation("Sending request to IoTHub");
                using (var httpClient = new HttpClient())
                {
                  
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


                    string jSonData = MakePayload(data, address);
                    using (var response =
                        await httpClient.PostAsync(configuration["IoTServerUri"], new StringContent(jSonData, Encoding.UTF8, "application/json")))
                    {
                        using (var content = response.Content)
                        {
                            var result = await content.ReadAsStringAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("");
            }
        }
        
        
        

        protected static byte[] HexToBytes(string hex)
        {

            var len = hex.Length / 2;

            byte[] arr = new byte[len];
            int charIndex = 0;
            for (int i = 0; i < len; i++)
            {
                int hi = HexVal(hex[charIndex++]),
                    lo = HexVal(hex[charIndex++]);
                arr[i] = (byte)((hi << 4) | lo);
            }
            return arr;
        }
        protected static int HexVal(char c)
        {
            if (c >= '0' && c <= '9') return c - '0';
            if (c >= 'a' && c <= 'f') return c - 'a' + 10;
            if (c >= 'A' && c <= 'F') return c - 'A' + 10;
            return ThrowArgOutOfRange(nameof(c));
        }
        protected static int ThrowArgOutOfRange(string argName) =>
            throw new ArgumentOutOfRangeException(argName);


        public static void Main(string[] args)
        {

            configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .AddCommandLine(args)
            .Build();

            bool runLocal = configuration.GetValue<bool>("RunLocal");

            var serviceCollection = new ServiceCollection();
            bool LogFile = false;
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "--logfile")
                    LogFile = true;
            }
            ConfigureServices(serviceCollection, LogFile);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            if (!runLocal)
            {
                var probe = serviceProvider.GetService<HTTPServer>();
                probe.Start();
            }
            var listener = serviceProvider.GetService<UDPListener>();
            listener.PostMessageOnIoTHub("3555237606826190BA419050E140020A404140001000D00000001010000D72B9344000004010000AEB13D4101000101000092C5D0440266010100002C0603660101000078050403010100002101040306010000B79A8C45040310010000F4020403110100000C050301010000D6000503060100002F3C0D49050310010000930305031101000012").Wait();
            //listener.PostMessageOnIoTHub("000000000000001").Wait();
            if (!runLocal) { 
                listener.StartListener();
            }
        }
    }
}
