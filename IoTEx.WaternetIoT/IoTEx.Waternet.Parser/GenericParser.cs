using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using IoTEx.WaternetIoT.Model.DTOs.API;
using IoTEx.WaternetIoT.Data.Model;
using IoTEx.WaternetIoT.Model.DTOs;

namespace IoTEx.Waternet.Parser
{

    public class GenericParser
    {
        /// <summary>
        /// PArse unique Device ID to retrieve Device Info.
        /// </summary>
        /// <param name="network"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public string[] ParseNetworkId(NetworkTypeEnum network, dynamic data)
        {

            switch (network)
            {
                case NetworkTypeEnum.LORAWAN_KERLINK:
                    string[] loraIds = new string[1];
                    loraIds[0] = data.endDevice.devEui.ToString().ToUpper();
                    return loraIds;
                case NetworkTypeEnum.SIGFOX:
                    
                    string rawSigfoxId = data.deviceId;
                    string leadingSigfoxId = new String('0', 8- rawSigfoxId.Length) + rawSigfoxId;
                    string[] sigfoxIds = new string[1];
                    sigfoxIds[0] = leadingSigfoxId.ToUpper();
                    return sigfoxIds;
                case NetworkTypeEnum.NBIoT_TMOBILE:
                    
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    for (int i = 0; i < data.reports.Count; i++)
                    {
                        string IMEI = data.reports[i].serialNumber.ToString().Replace("IMEI:", "");
                        if (!dic.ContainsKey(IMEI))
                            dic.Add(IMEI, IMEI);
                    }
                    for (int i = 0; i < data.registrations.Count; i++)
                    {
                        string IMEI = data.registrations[i].serialNumber.ToString().Replace("IMEI:", "");
                        if (!dic.ContainsKey(IMEI))
                            dic.Add(IMEI, IMEI);
                    }
                    return dic.Keys.ToArray();
                case NetworkTypeEnum.IOTDEV_UDP_APN_TMOBILE_NBIOT:
                    //return the first 64
                    string[] IMEIs = new string[1];
                    IMEIs[0] = data.imei.ToString();
                    return IMEIs;
                default:
                    return new string[0];
                    
            }            
        }
        /// <summary>
        /// Entry method to parse the info based on the information
        /// </summary>
        /// <param name="deviceMessage"></param>
        /// <param name="enc"></param>
        /// <param name="data"></param>
        /// <param name="deviceInfo"></param>
        /// <returns></returns>
        public DeviceMessageDTO ParseMessage(DeviceMessageDTO deviceMessage,
                                        PayLoadEncryptionEnum enc, 
                                        dynamic data, DeviceDefinitionDTO deviceInfo)
        {

            switch (deviceMessage.networkType)
            {
                case NetworkTypeEnum.LORAWAN_KERLINK:
                    return LORA.LORAKerlinkParserV3_0.Parse(deviceMessage, data, enc, deviceInfo);
                case NetworkTypeEnum.NBIoT_TMOBILE:
                    return NBIoT_TMOBILE.NBIoTParser.Parse(deviceMessage, data, enc, deviceInfo);
                case NetworkTypeEnum.IOTDEV_UDP_APN_TMOBILE_NBIOT:
                    return NBIoT_TMOBILE.UDP_NBIoT_Parser.Parse(deviceMessage, data, enc, deviceInfo);
                default:
                    return new DeviceMessageDTO() { deviceId = IOT.DEVICE.DEVICETYPE.NOT_DEFINED.ToString(),
                                                    id = Guid.NewGuid(),
                                                    rcvDateTime = DateTime.UtcNow,
                                                    networkType = NetworkTypeEnum.NOT_DEFINED,
                                                    networkInfo = null,
                                                    deviceType = IOT.DEVICE.DEVICETYPE.NOT_DEFINED.ToString() };
            }
                       
        }
        
        public DeviceDefinitionSettingsDTO GetDeviceMetaDataDefinition(string className)
        {
            IBaseParser parser = (IBaseParser)System.Reflection.Assembly.GetAssembly(typeof(IBaseParser)).CreateInstance("IoTEx.Waternet.Parser." + className);


            if (parser != null)
            {
                DeviceDefinitionSettingsDTO metaData = parser.GetDeviceMetaDataDefinition();
                return metaData;
            }
            return null;
        }
        public APIResultDTO<string> GenerateConfigureDeviceMessage(string className, List<DeviceDefinitionConfigurationDTO> configs)
        {
            IBaseParser parser = (IBaseParser)System.Reflection.Assembly.GetAssembly(typeof(IBaseParser)).CreateInstance("IoTEx.Waternet.Parser." + className);

            if (parser != null)
            {
                APIResultDTO<string> message = parser.GenerateConfigureDeviceMessage(configs);
                return message;
            }
            return null;
        }
        public bool ClassExists(string className)
        {
            IBaseParser parser = (IBaseParser)System.Reflection.Assembly.GetAssembly(typeof(IBaseParser)).CreateInstance("IoTEx.Waternet.Parser." + className);

            return (parser != null);
        }
    }
}
