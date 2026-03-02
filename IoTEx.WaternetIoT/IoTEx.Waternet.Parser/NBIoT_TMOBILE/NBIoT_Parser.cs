using System;
using System.Collections.Generic;
using System.Text;
//using Waternet.IoT.Model.Communication;
using Newtonsoft.Json;
//using static Waternet.IoT.Model.Device.IoTDeviceMessage;
//using Waternet.IoT.Model.Device;
using System.IO;
using IoTEx.WaternetIoT.Data.Model;
using IoTEx.WaternetIoT.Model.DTOs;

namespace IoTEx.Waternet.Parser.NBIoT_TMOBILE
{
    public class NBIoTParser
    {
        
        public static DeviceMessageDTO Parse(DeviceMessageDTO deviceMessage, dynamic data, PayLoadEncryptionEnum enc, DeviceDefinitionDTO deviceInfo)
        {

            NBIoTMessageModelV1 messageComm = ParseComm(deviceMessage, data);
            
            deviceMessage.networkType = NetworkTypeEnum.NBIoT_TMOBILE;
            string payload = null;
            for (int i = 0; i < data.reports.Count; i++)
            {
                if ($"IMEI:{deviceMessage.deviceNetworkId}"== data.reports[i].serialNumber.ToString())
                {
                    payload = data.reports[i].value;
                    if (!string.IsNullOrEmpty(payload))
                    {
                        deviceMessage = ParseMessage(deviceMessage, enc, payload, deviceInfo);
                    }
                }
            }
            
            for (int i = 0; i < data.registrations.Count; i++)
            {
                if ($"IMEI:{deviceMessage.deviceNetworkId}" == data.registrations[i].serialNumber.ToString())
                {
                    payload = data.registrations[i].deviceProps["uplinkMsg/0/data"];
                }
                if (!string.IsNullOrEmpty(payload))
                {
                    deviceMessage = ParseMessage(deviceMessage, enc, payload, deviceInfo);
                }
            }
            
                
            

            return deviceMessage;

        }

        private static NBIoTMessageModelV1 ParseComm(DeviceMessageDTO message, dynamic data)
        {
            NBIoTMessageModelV1 messageComm = new NBIoTMessageModelV1();
            message.networkInfo = new DeviceMessageNetworkDTO();    
            return messageComm;
        }


        public static DeviceMessageDTO ParseMessage(DeviceMessageDTO message, PayLoadEncryptionEnum enc, string encPayload, DeviceDefinitionDTO deviceInfo)
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
