using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using IoTEx.WaternetIoT.Data.Model;
using IoTEx.WaternetIoT.Model.DTOs;

namespace IoTEx.Waternet.Parser.NBIoT_TMOBILE
{
    public class UDP_NBIoT_Parser
    {
        
        public static DeviceMessageDTO Parse(DeviceMessageDTO deviceMessage, dynamic data, PayLoadEncryptionEnum enc, DeviceDefinitionDTO deviceInfo)
        {

            NBIoTMessageModelV1 messageComm = ParseComm(deviceMessage, data);
            
            deviceMessage.networkType = NetworkTypeEnum.IOTDEV_UDP_APN_TMOBILE_NBIOT;
            string payload = data.payload;
            if (!string.IsNullOrEmpty(payload))
            {
                deviceMessage = ParseMessage(deviceMessage, enc, payload, deviceInfo);
            }

            return deviceMessage;

        }

        private static NBIoTMessageModelV1 ParseComm(DeviceMessageDTO message, dynamic data)
        {
            NBIoTMessageModelV1 messageComm = new NBIoTMessageModelV1();            
            message.networkInfo = new DeviceMessageNetworkDTO();            
            return messageComm;
        }

        
        public static DeviceMessageDTO ParseMessage(DeviceMessageDTO message, PayLoadEncryptionEnum enc,  string encPayload, DeviceDefinitionDTO deviceInfo)
        {

            try
            {
                IBaseParser parser = (IBaseParser)System.Reflection.Assembly.GetAssembly(typeof(IBaseParser)).CreateInstance("IoTEx.Waternet.Parser." + deviceInfo.info.deviceParserClassName);
                                
                if (parser != null)
                    parser.ParseIncomingDeviceMessage(message, encPayload, enc, deviceInfo);


            }
            catch (Exception ex)
            {
                
            }
            return message;
        }
        
    }
}
