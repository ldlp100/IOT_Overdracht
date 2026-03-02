using System;
using System.Collections.Generic;
using System.Text;
using IoTEx.WaternetIoT.Data.Model;
using IoTEx.WaternetIoT.Model.DTOs;
using IoTEx.WaternetIoT.Model.DTOs.API;
using Newtonsoft.Json;

namespace IoTEx.Waternet.Parser
{
    public class LEIDUIN_WARMTEWISSELAAR_V2_PARSER : IOT_DEVICE_GENERIC_V2_PARSER
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
            List<DeviceDefinitionConfigurationDTO> configs = new List<DeviceDefinitionConfigurationDTO>();
;
            return configs;
        }
        public override void Definition()
        {
            //MEASUREMENT
                        

            IoTDataDefineMemberExt(0, 0, 1, "Sensor1-Pressure", (int)IOT_EVENT.MEASUREMENT, "mbar", 0, 0);
            IoTDataDefineMemberExt(0, 0, 4, "Device-Temperature", (int)IOT_EVENT.MEASUREMENT, "oC", 0, 0);
            IoTDataDefineMemberExt(1, 0, 1, "Sensor2-Pressure", (int)IOT_EVENT.MEASUREMENT, "mbar", 0, 0);            
            IoTDataDefineMemberExt(2, 102, 1, "Sensor1-Temperature", (int)IOT_EVENT.MEASUREMENT, "oC", 10, 0);
            IoTDataDefineMemberExt(3, 102, 1, "Sensor2-Temperature", (int)IOT_EVENT.MEASUREMENT, "oC", 10, 0);
            IoTDataDefineMemberExt(4, 3, 1, "Meter1-FlowSpeed", (int)IOT_EVENT.MEASUREMENT, "m/s", 10, 0);
            IoTDataDefineMemberExt(4, 3, 6, "Meter1-ForwardFlowVolume", (int)IOT_EVENT.MEASUREMENT, "m3", 0, 0);
            IoTDataDefineMemberExt(4, 3, 16, "Meter1-Pressure", (int)IOT_EVENT.MEASUREMENT, "Bar", 11, 0);
            IoTDataDefineMemberExt(4, 3, 17, "Meter1-Temperature", (int)IOT_EVENT.MEASUREMENT, "oC", 17, 0);
            IoTDataDefineMemberExt(5, 3, 1, "Meter2-FlowSpeed", (int)IOT_EVENT.MEASUREMENT, "m/s", 10, 0);
            IoTDataDefineMemberExt(5, 3, 6, "Meter2-ForwardFlowVolume", (int)IOT_EVENT.MEASUREMENT, "m3", 0, 0);
            IoTDataDefineMemberExt(5, 3, 16, "Meter2-Pressure", (int)IOT_EVENT.MEASUREMENT, "Bar", 11, 0);
            IoTDataDefineMemberExt(5, 3, 17, "Meter2-Temperature", (int)IOT_EVENT.MEASUREMENT, "oC", 17, 0);

        }
        public override void AddPostEvent(DeviceMessageDTO message, DeviceDefinitionDTO deviceInfo)
        {
            
           
        }
    }

}


