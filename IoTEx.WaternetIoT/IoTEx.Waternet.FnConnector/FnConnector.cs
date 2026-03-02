using IoTEx.WaternetIoT.DAL;
using IoTEx.WaternetIoT.Model.DTOs.API;
using IoTEx.Waternet.Parser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;
using IoTEx.WaternetIoT.Model.PortalModels;
using IoTEx.WaternetIoT.Model.ViewModels;
using IoTEx.WaternetIoT.Model.DTOs;
using Azure.Messaging.EventHubs;

namespace IoTEx.Waternet.FnConnector
{
    public class FnConnector
    {
        private readonly ILogger<FnConnector> _logger;
        private IoTDBContext _IoTDBContext;
        private IConfiguration _configuration;
        private IKustoService _kustoService;
        public FnConnector(ILoggerFactory loggerFactory, IoTDBContext dbContext, IConfiguration configuration, IKustoService kustoService)
        {
            _configuration = configuration;
            _IoTDBContext = dbContext;
            _logger = loggerFactory.CreateLogger<FnConnector>();
            _kustoService = kustoService;
        }

        /// <summary>
        /// This function gets called by all the externe Callback application
        /// </summary>
        /// <param name="req"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        [Function("GetDeviceTypeMetaData")]
        public ActionResult GetDeviceTypeMetaData(
                    [HttpTrigger(AuthorizationLevel.Admin, "get", "post", Route = null)] HttpRequest req)
        {
            _logger.LogInformation("Calls 'GetDeviceTypeConfigurationItems'...");

            APIResultDTO<DeviceDefinitionSettingsDTO> result = new APIResultDTO<DeviceDefinitionSettingsDTO>();

            string className = req.Query["className"];
            if (string.IsNullOrEmpty(className))
            {
                result.Error = "'className' parameters cannot be found in querystring";
                _logger.LogError(result.Error);
            }
            else
            {
                GenericParser parser = new GenericParser();
                result.Value = parser.GetDeviceMetaDataDefinition(className);
                result.IsOk = true;
                if (result.Value == null)
                {
                    result.Error = "className '" + className + "' cannot be found for method GetDeviceTypeConfigurationItems";
                    _logger.LogError(result.Error);
                }
            }
            return (ActionResult)new OkObjectResult(result);

        }
        [Function("GenerateConfigureDeviceMessage")]
        public ActionResult GenerateConfigureDeviceMessage(
                    [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
        {
            _logger.LogInformation("Calls 'GenerateConfigureDeviceMessage'...");

            APIResultDTO<string> result = new APIResultDTO<string>();

            string className = req.Query["className"];
            if (string.IsNullOrEmpty(className))
            {
                result.Error = "'className' parameters cannot be found in querystring";
                _logger.LogError(result.Error);
            }
            else
            {
                GenericParser parser = new GenericParser();
                if (!parser.ClassExists(className))
                {
                    result.Error = "className '" + className + "' cannot be found for method GetDeviceTypeConfigurationItems";
                    _logger.LogError(result.Error);
                }
                else
                {
                    try
                    {
                        string payLoad = new StreamReader(req.Body).ReadToEnd();
                        List<DeviceDefinitionConfigurationDTO> configs = JsonConvert.DeserializeObject<List<DeviceDefinitionConfigurationDTO>>(payLoad);
                        result = parser.GenerateConfigureDeviceMessage(className, configs);
                    }
                    catch (Exception ex)
                    {
                        result.Error = "Cannot serialize the item configurations!";
                    }
                }
            }
            return (ActionResult)new OkObjectResult(result);

        }

        /// <summary>
        /// THsi function gets called by all the externe Callback application and stored message in IoT Hub.
        /// </summary>
        /// <param name="req"></param>
        /// <param name="_logger"></param>
        /// <returns></returns>
        [Function("ProcessIoTMessage")]
        public async Task<ActionResult> ProcessIoTMessage(
                    [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
        {
            StreamReader stream = new StreamReader(req.Body);
            string jsonMessage = await stream.ReadToEndAsync();
            if (string.IsNullOrEmpty(jsonMessage))
            {
                _logger.LogError("Body is Empty!");
                return (ActionResult)new OkObjectResult("Body is Empty");
            }

            string deviceStr = req.Query["device"];

            IoTHubConnector.IOT_DEVICEEnum IoTDevice;
            if (!Enum.TryParse<IoTHubConnector.IOT_DEVICEEnum>(deviceStr, out IoTDevice))
            {
                IoTDevice = IoTHubConnector.IOT_DEVICEEnum.IOTDEV_UNDEFINED;
                _logger.LogError("DEVICE_NOT_RECOGNIZED:" + deviceStr);
            }
            
            //To avoid conflict of properties with standard ASA propoerties
            jsonMessage = "{ \"payload\":" + jsonMessage + "}";
            _logger.LogInformation(IoTDevice.ToString() + "-MESSAGE RECEIVED:\n" + jsonMessage);
            try
            {
                int result = await IoTHubConnector.SendIoTMessageFromDeviceToCloudAsync(IoTDevice, jsonMessage, _logger);
                return (ActionResult)new OkObjectResult(result);
            }
            catch(Exception ex)
            {
                return (ActionResult)new OkObjectResult(ex.Message);
            }
        }


        private async Task<int> InternalProcessIoTMessage(EventData evt)
        {
            string deviceId = evt.SystemProperties.Where(x => x.Key == "iothub-connection-device-id").FirstOrDefault().Value.ToString();
            dynamic message = JsonConvert.DeserializeObject(evt.EventBody.ToString());
            string networkStr = "";
            string payload = "";
            string iotHubDeviceId = "";
            NetworkTypeEnum network = NetworkTypeEnum.NOT_DEFINED;
            try
            {
                //iotHubDeviceId = message.IoTHub.ConnectionDeviceId;
                network = DefineNetworkTypeBasedOnHubDeviceId(deviceId, _logger);
                var payloadArr = message.payload;
                payload = JsonConvert.SerializeObject(payloadArr);
                _logger.LogInformation("Device =" + iotHubDeviceId + "\nNetwork =" + network.ToString());
                _logger.LogInformation("Payload =" + payload);


                List<DeviceMessageDTO> messages = await ProcessParsingIoTMessage(iotHubDeviceId, network, payload, DateTime.UtcNow, _logger,
                                                PayLoadEncryptionEnum.HEX);
                if (messages.Count == 0)
                    return 0;

                return messages.Count;

            }
            catch (Exception ex)
            {
                await SaveTelemetryError(iotHubDeviceId, "", DeviceMessageErrorDTO.ErrorTypeEnum.UNKNOWN, payload, network);
                _logger.LogError("Error with message from NETWORK:" + networkStr + "\nError:\n" + ex.Message + " with Payload:\n" + payload);
            }
            
            return 0;
        }

        [Function(nameof(ProcessIoTMessageFromEventHub))]
        //[EventHubOutput("IOTEX_IOTHUB_CONN")]
        public async Task<string> ProcessIoTMessageFromEventHub(
         [EventHubTrigger("iot-hub-p-waternet-iothub",Connection = "IOTEX_IOTHUB_EVENT_HUB", ConsumerGroup = "iotexv2.connector")] EventData[] events, ILogger log)
        {

            _logger.LogInformation($"Number of messages={events.Length}");
            int count = 0;
            for (var i = 0; i < events.Length; i++)
            {
                count+= await InternalProcessIoTMessage(events[i]);
            }
            return $"{events.Length}";
        }

        /// <summary>
        /// This function Get called by the Streaming Analytic as output and is managing the initiation to the parsing internal function
        /// </summary>
        /// <param name="req"></param>
        /// <param name="_logger"></param>
        /// <returns></returns>
        [Function("ParseIoTMessage")]
        public async Task<ActionResult> ParseIoTMessage(
                    [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
        {

            

            string messageInput = await new StreamReader(req.Body).ReadToEndAsync(); 
            dynamic dataArray = JsonConvert.DeserializeObject(messageInput);
            _logger.LogInformation("MESSAGE Input=" + messageInput);
            _logger.LogInformation("Number of messages=" + (int)dataArray.Count);

            for (var i = 0; i < dataArray.Count; i++)
            {
                string networkStr = "";
                string payload = "";
                string iotHubDeviceId = "";
                NetworkTypeEnum network = NetworkTypeEnum.NOT_DEFINED;
                try
                {
                    iotHubDeviceId = dataArray[i].IoTHub.ConnectionDeviceId;
                    network = DefineNetworkTypeBasedOnHubDeviceId(iotHubDeviceId, _logger);
                    var payloadArr = dataArray[i].payload;
                    payload = JsonConvert.SerializeObject(payloadArr);
                    _logger.LogInformation("Device[" + i + "] =" + iotHubDeviceId + "\nNetwork[" + i + "] =" + network.ToString());
                    _logger.LogInformation("Payload[" + i + "] =" + payload);

                    
                    List<DeviceMessageDTO> messages = await ProcessParsingIoTMessage(iotHubDeviceId, network, payload, DateTime.UtcNow, _logger, 
                                                    PayLoadEncryptionEnum.HEX);
                    if (messages.Count == 0)
                        return (ActionResult)new OkObjectResult(0);

                    return (ActionResult)new OkObjectResult(messages);

                }
                catch (Exception ex)
                {
                    await SaveTelemetryError(iotHubDeviceId, "", DeviceMessageErrorDTO.ErrorTypeEnum.UNKNOWN, payload, network);
                    _logger.LogError("Error with message from NETWORK:" + networkStr + "\nError:\n" + ex.Message + " with Payload:\n" + payload);
                }
            }
            return (ActionResult)new OkObjectResult(0);

        }

        [Function("ParseIoTErrorMessage")]
        public async Task<ActionResult> ParseIoTErrorMessage(
                    [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
        {

            string messageInput = new StreamReader(req.Body).ReadToEnd();
            dynamic dataArray = JsonConvert.DeserializeObject(messageInput);
            _logger.LogInformation("MESSAGE Input=" + messageInput);
            _logger.LogInformation("Number of messages=" + (int)dataArray.Count);

            for (var i = 0; i < dataArray.Count; i++)
            {
                string networkStr = "";
                string payload = "";
                string iotHubDeviceId = "";
                NetworkTypeEnum network = NetworkTypeEnum.NOT_DEFINED;
                try
                {
                    iotHubDeviceId = dataArray[i].iotHubDeviceId;
                    network = DefineNetworkTypeBasedOnHubDeviceId(iotHubDeviceId, _logger);
                    payload = dataArray[i].payload;

                    _logger.LogInformation("Device[" + i + "] =" + iotHubDeviceId + "\nNetwork[" + i + "] =" + network.ToString());
                    _logger.LogInformation("Payload[" + i + "] =" + payload);
                    DateTime date = DateTime.Now;

                    List<DeviceMessageDTO> messages = await ProcessParsingIoTMessage(iotHubDeviceId, network, payload, 
                                                                    date, _logger, PayLoadEncryptionEnum.HEX , true);
                    if (messages.Count == 0)
                        return (ActionResult)new OkObjectResult(0);

                    return (ActionResult)new OkObjectResult(messages);

                }
                catch (Exception ex)
                {

                    _logger.LogError("Error with message from NETWORK:" + networkStr + "\nError:\n" + ex.Message + " with Payload:\n" + payload);
                }
            }
            return (ActionResult)new OkObjectResult(0);

        }




        public async Task<List<DeviceMessageDTO>> ProcessParsingIoTMessage(string iotHubDeviceId, NetworkTypeEnum network, 
                                                    string payLoad, DateTime date,
                                                    ILogger log, PayLoadEncryptionEnum enc = PayLoadEncryptionEnum.HEX,
                                                    bool isErrorMessage = false)
        {

            List<DeviceMessageDTO> docTelemetries = new List<DeviceMessageDTO>();
            Stopwatch sw = Stopwatch.StartNew();



            dynamic data = JsonConvert.DeserializeObject(payLoad);

            //Find NetworkId in Parser
            Parser.GenericParser parser = new Parser.GenericParser();
            string[] networkArrId = parser.ParseNetworkId(network, data);

            for (int i = 0; i < networkArrId.Length; i++)
            {
                string networkId = networkArrId[i];

                if (string.IsNullOrEmpty(networkId))
                {
                    await SaveTelemetryError(iotHubDeviceId, networkId, DeviceMessageErrorDTO.ErrorTypeEnum.NETWORKID_NOT_FOUND_IN_MESSAGE,
                                                    payLoad, network);
                    return docTelemetries;
                }

                DeviceDefinitionPublishedDTO publishDoc = _kustoService.GetDeviceByNetworkId(networkId);
                if (publishDoc == null)
                {
                    log.LogError("Device not found in data cluster:" + " (" + networkId + ") For Network:" + network.ToString() +
                                " (" + sw.ElapsedMilliseconds + "msec) With Payload:" + payLoad);

                    await SaveTelemetryError(iotHubDeviceId, networkId, DeviceMessageErrorDTO.ErrorTypeEnum.DEVICE_NOT_FOUND, payLoad, network);
                    return docTelemetries;

                }
                DeviceDefinitionDTO deviceDefinition = JsonConvert.DeserializeObject<DeviceDefinitionDTO>(publishDoc.JSON);

                if (deviceDefinition == null)
                {
                    log.LogError("Device not found in connector:" + " (" + networkId + ") For Network:" + network.ToString() +
                                " (" + sw.ElapsedMilliseconds + "msec) With Payload:" + payLoad);

                    await SaveTelemetryError(iotHubDeviceId, networkId, DeviceMessageErrorDTO.ErrorTypeEnum.DEVICE_NOT_FOUND, payLoad, network);
                    return docTelemetries;
                }

                if (deviceDefinition.isActive)
                {

                    DeviceMessageDTO deviceMessage = new DeviceMessageDTO();
                    docTelemetries.Add(deviceMessage);
                    deviceMessage.id = Guid.NewGuid();
                    deviceMessage.configId = deviceDefinition.id;
                    deviceMessage.rcvDateTime = date;
                    deviceMessage.networkType = network;
                    deviceMessage.deviceNetworkId = networkId;
                    deviceMessage.latitude = deviceDefinition.location.latitude;
                    deviceMessage.longitude = deviceDefinition.location.longitude;
                    deviceMessage.assetUID = deviceDefinition.assetUID;
                    deviceMessage.deviceSerialNr = deviceDefinition.info.serialNr;
                    deviceMessage.deviceId = deviceDefinition.deviceId;
                    deviceMessage.deviceType = deviceDefinition.info.deviceTypeName;

                    log.LogInformation("Message Id: " + deviceMessage.id +
                        " Generated from Device Found with Network Id: " + networkId + " on " +
                        "Network:" + deviceMessage.networkType.ToString() + " of " +
                        "DeviceType:" + deviceMessage.deviceType + " with " +
                        "Payload:\n" + payLoad);

                    //PARSE PAYLOAD
                    deviceMessage = parser.ParseMessage(deviceMessage, enc, data, deviceDefinition);

                    if (deviceMessage.events.Count == 0)
                    {
                        log.LogError("Error with Message Id: " + deviceMessage.id + "- No Event Find in message!");
                        if (!isErrorMessage)
                            await SaveTelemetryError(iotHubDeviceId, networkId, DeviceMessageErrorDTO.ErrorTypeEnum.NO_EVENTS_FOUND, payLoad, network);
                        return docTelemetries;
                    }

                    if (deviceDefinition.isTraced)
                    {
                        //Add payload to message for debugging
                        deviceMessage.originalMessage = payLoad;
                    }

                    //Manipulate the output
                    ProcessEventsCalibration(deviceMessage, deviceDefinition);
                    
                    //Save To API DB
                    SaveLastMessageReceivedDateTimeToPortal(deviceMessage.deviceId, deviceMessage.rcvDateTime);

                    //Store Message to Kusto
                    SaveMessage(deviceMessage);
                    log.LogInformation("Message Id: " + deviceMessage.id + "-Store in Kusto " + " (" + sw.ElapsedMilliseconds + "msec)");
                    
                    sw.Restart();
                    SaveTelemetry(deviceDefinition, deviceMessage);
                    log.LogInformation("Message Id: " + deviceMessage.id + "-Store in Kusto " + " (" + sw.ElapsedMilliseconds + "msec)");

                    
                    if (deviceMessage.events.Where(x => String.IsNullOrEmpty(x.pc)).Count() > 0)
                    {
                        sw.Restart();
                        await FnPIMS.InternSendInfoToPIM(deviceMessage, log);
                        log.LogInformation("Message Id: " + deviceMessage.id + "-Send to PIMS " + " (" + sw.ElapsedMilliseconds + "msec)");
                    }

                    foreach (DeviceDefinitionProjectDTO project in deviceDefinition.projects)
                    {
                        if (string.IsNullOrEmpty(project.targetDB))
                        {
                            //SAVE TO SPECIFIC Database
                            //SaveTelemetry(deviceDefinition,deviceMessage, project.targetDB);
                        }
                    }


                }
                else
                {
                    log.LogInformation($"Message received but device '{deviceDefinition.deviceId}' with networkId={networkId} is not active!");
                }
            }
            
            log.LogInformation($"{docTelemetries.Count} Telemetry object(s) found in Message.");
            
            return docTelemetries;

        }
        private void SaveTelemetry(DeviceDefinitionDTO definition, DeviceMessageDTO deviceMessage, string targetDB="")
        {
            foreach (DeviceMessageEventDTO evt in deviceMessage.events)
            {
                DeviceTelemetryDTO view = new DeviceTelemetryDTO();
                view.Id = Guid.NewGuid();
                view.MsgId = deviceMessage.id;
                view.AssetUID = definition.assetUID;
                view.DeviceBatchId = definition.info.deviceBatchId;
                view.DeviceBatchName = definition.info.deviceBatchName;
                view.DeviceId = deviceMessage.deviceId;
                view.DeviceName = definition.deviceName;
                view.DevicePosLat = definition.location.latitude;
                view.DevicePosLong = definition.location.longitude;
                view.DeviceTypeId = definition.info.deviceTypeId;
                view.DeviceTypeName = definition.info.deviceTypeName;
                
                view.NetworkId = deviceMessage.deviceNetworkId;
                view.IsAlert = (evt.type== DeviceMessageEventDTO.DeviceEventType.ALERT);
                view.Unit = evt.unit;
                view.Value = evt.value;
                view.Name = evt.name;
                view.PC = evt.pc;
                view.PCUnit = evt.pcUnit;
                view.PCValue = evt.pcValue;
                view.Received = evt.received;
                
                _kustoService.InsertTelemetry(view,targetDB);
            }
        }
        private void SaveMessage(DeviceMessageDTO deviceMessage)
        {
            DeviceMessageViewModel view = new DeviceMessageViewModel();
            view.Id = deviceMessage.id;
            view.Received = deviceMessage.rcvDateTime;
            view.DeviceId = deviceMessage.deviceId;
            view.NetworkId = deviceMessage.deviceNetworkId;
            view.Content = JsonConvert.SerializeObject(deviceMessage);           
             _kustoService.InsertMessage(view);

        }
        private void SaveLastMessageReceivedDateTimeToPortal(string deviceIDStr, DateTime rcvDate)
        {
            Guid deviceId = new Guid(deviceIDStr);
            DeviceModel device = _IoTDBContext.Devices
                .FirstOrDefault(x => x.Id == deviceId);
            if (device != null)
            {
                device.LastMessage = rcvDate;
                _IoTDBContext.Devices.Update(device);
                _IoTDBContext.SaveChanges();
            }
        }

        /// <summary>
        /// Save Message to External DB.
        /// </summary>
        /// <param name="telemetry"></param>
        /// <param name="deviceInfo"></param>
        /// <returns></returns>
        
        private async Task SaveTelemetryError(string iotHubDeviceId, string networkId, DeviceMessageErrorDTO.ErrorTypeEnum errorType, string payload, 
                                                NetworkTypeEnum network)
        {
            

            DeviceMessageErrorDTO doc = new DeviceMessageErrorDTO()
            {
                iotHubDeviceId = iotHubDeviceId,
                errorType = errorType.ToString(),
                payload = payload,
                network = network.ToString(),
                networkId = networkId
            };

            
            
        }

        private void ProcessEventsCalibration(DeviceMessageDTO telemetry, DeviceDefinitionDTO deviceInfo)
        {
            foreach (DeviceDefinitionMeasurementDTO calibration in deviceInfo.settings.measurements)
            {
                List<DeviceMessageEventDTO> events = telemetry.events.FindAll(e => e.name == calibration.name);

                foreach (DeviceMessageEventDTO evt in events)
                {
                    double endValue = evt.value;
                    //adjust the range
                    if (calibration.minMeasurement != null && calibration.maxMeasurement != null &&
                                            calibration.minSensor != null && calibration.maxSensor != null)
                    {
                        double rangeSensor = calibration.maxSensor ?? 0 - calibration.minSensor ?? 0;
                        double rangeMeasurement = calibration.maxMeasurement ?? 0 - calibration.minMeasurement ?? 0;
                        double pctSensor = (evt.value - calibration.minSensor ?? 0) / rangeSensor;
                        endValue = calibration.minMeasurement ?? 0 + pctSensor * rangeMeasurement;
                    }

                    //adjust the offset
                    if (calibration.offsetValue != null)
                    {
                        endValue += calibration.offsetValue ?? 0;
                    }
                    evt.value = endValue;
                }
            }
        }

        private NetworkTypeEnum DefineNetworkTypeBasedOnHubDeviceId(string deviceId, ILogger log)
        {
            NetworkTypeEnum network = NetworkTypeEnum.NOT_DEFINED;
            IoTHubConnector.IOT_DEVICEEnum IoTDevice = IoTHubConnector.IOT_DEVICEEnum.IOTDEV_UNDEFINED;

            if (!Enum.TryParse<IoTHubConnector.IOT_DEVICEEnum>(deviceId, out IoTDevice))
            {
                log.LogError("DEVICE_NOT_RECOGNIZED:" + deviceId);
                return NetworkTypeEnum.NOT_DEFINED;
            }
            switch (IoTDevice)
            {
                case IoTHubConnector.IOT_DEVICEEnum.IOTDEV_UNDEFINED:
                    network = NetworkTypeEnum.NOT_DEFINED;
                    break;
                case IoTHubConnector.IOT_DEVICEEnum.IOTDEV_KERLINK_LORAWAN:
                    network = NetworkTypeEnum.LORAWAN_KERLINK;
                    break;
                case IoTHubConnector.IOT_DEVICEEnum.IOTDEV_NBIOT_T_MOBILE:
                    network = NetworkTypeEnum.NBIoT_TMOBILE;
                    break;
                case IoTHubConnector.IOT_DEVICEEnum.IOTDEV_UDP_APN_TMOBILE_NBIOT:
                    network = NetworkTypeEnum.IOTDEV_UDP_APN_TMOBILE_NBIOT;
                    break;
                case IoTHubConnector.IOT_DEVICEEnum.IOTDEV_SIGFOX:
                    network = NetworkTypeEnum.SIGFOX;
                    break;
                default:
                    break;
            }
            return network;

        }
        private IoTHubConnector.IOT_DEVICEEnum ConvertNetworkToDevice(string networkStr, ILogger log)
        {
            IoTHubConnector.IOT_DEVICEEnum IoTDevice = IoTHubConnector.IOT_DEVICEEnum.IOTDEV_UNDEFINED;
            NetworkTypeEnum network = NetworkTypeEnum.NOT_DEFINED;

            if (!Enum.TryParse<NetworkTypeEnum>(networkStr, out network))
            {
                log.LogError("NETWORK_NOT_RECOGNIZED:" + networkStr);
                return IoTDevice;
            }

            switch (network)
            {
                case NetworkTypeEnum.LORAWAN_KERLINK:
                    IoTDevice = IoTHubConnector.IOT_DEVICEEnum.IOTDEV_KERLINK_LORAWAN;
                    break;
                case NetworkTypeEnum.SIGFOX:
                    IoTDevice = IoTHubConnector.IOT_DEVICEEnum.IOTDEV_SIGFOX;
                    break;
                case NetworkTypeEnum.NBIoT_TMOBILE:
                    IoTDevice = IoTHubConnector.IOT_DEVICEEnum.IOTDEV_NBIOT_T_MOBILE;
                    break;
                default:
                    IoTDevice = IoTHubConnector.IOT_DEVICEEnum.IOTDEV_UNDEFINED;
                    break;
            }
            return IoTDevice;

        }
    }
}
