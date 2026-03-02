using System;
using System.Collections.Generic;
using System.Text;
using IoTEx.Waternet.Common;
using IoTEx.WaternetIoT.Data.Model;
using IoTEx.WaternetIoT.Model.DTOs;
using IoTEx.WaternetIoT.Model.DTOs.API;
using Newtonsoft.Json;


namespace IoTEx.Waternet.Parser
{
    public class NBIOTUMB100_V1_PARSER : BaseParser
    {
        public override string Version
        {
            get { return "1.0.0"; }
        }
        public override APIResultDTO<string> GenerateConfigureDeviceMessage(List<DeviceDefinitionConfigurationDTO> configs)
        {
            return new APIResultDTO<string>() { IsOk = false, Error = "NO CONFIGURATION MESSAGE DEFINED" };
        }
        public override List<DeviceDefinitionConfigurationDTO> GetDeviceTypeConfigurationItems()
        {
            return new List<DeviceDefinitionConfigurationDTO>();
        }
        public override DeviceMessageDTO ParseIncomingDeviceMessage(DeviceMessageDTO message, string payload, PayLoadEncryptionEnum enc, DeviceDefinitionDTO deviceInfo)
        {
            //"{\"TY\":\"UMB-100\",\"BA\":\"3.33\",\"BR\":\"1005.5\",\"TM\":\"1552408203\",\"RA1\":\"0\",\"RA2\":\"0\",\"RA3\":\"0\",\"RA4\":\"0\",\"RA5\":\"0\"}"

            byte[] buffer = Function.HexStringToByteArray(payload);
            string payloadStr = Encoding.UTF8.GetString(buffer);
            dynamic data = JsonConvert.DeserializeObject(payloadStr);
            
            if (data != null)
            {
                if (data.RA4 != null)
                {
                    SetState(message, message.rcvDateTime, "", GetObjectEnum(typeof(IOT.METADATA.NBIOTUMB100_V1.STATE.PRECIPITATION_TYPE), Convert.ToDouble(data.RA4)), deviceInfo);
                    
                }
                if (data.RA1!=null)
                {
                    SetMeasurement(message, message.rcvDateTime, "", IOT.METADATA.NBIOTUMB100_V1.MEASUREMENT.PRECIPITATION.ABSOLUTE, Convert.ToDouble(data.RA1), deviceInfo);
                    
                }
                if (data.RA2 != null)
                {
                    SetMeasurement(message, message.rcvDateTime, "", IOT.METADATA.NBIOTUMB100_V1.MEASUREMENT.PRECIPITATION.DELTA, Convert.ToDouble(data.RA2), deviceInfo);
                    
                }
                if (data.RA3 != null)
                {
                    SetMeasurement(message, message.rcvDateTime, "", IOT.METADATA.NBIOTUMB100_V1.MEASUREMENT.PRECIPITATION_PER_HOUR.SUM, Convert.ToDouble(data.RA3), deviceInfo);
                    
                }
                if (data.BR != null)
                {
                    SetMeasurement(message, message.rcvDateTime, "", IOT.METADATA.NBIOTUMB100_V1.MEASUREMENT.AIR_PRESSURE.ACTUAL, Convert.ToDouble(data.BR), deviceInfo);                    
                }

            }
            return message;
        }
        
        
    }

}
