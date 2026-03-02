using System;
using System.Collections.Generic;
using System.Text;
using IoTEx.WaternetIoT.Data.Model;
using IoTEx.WaternetIoT.Model.DTOs;
using IoTEx.WaternetIoT.Model.DTOs.API;
using Newtonsoft.Json;

namespace IoTEx.Waternet.Parser
{
    public class PONZELL_CTV_V1_PARSER : IOT_DEVICE_GENERIC_V1_PARSER
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
        public override void Definition()
        {
            IoTDataDefineMember(1, 1, "Temperature", 2, "oC", 0, 0);
            IoTDataDefineMember(1, 2, "Conductivity CTZ", 2, "mS/cm", 0, 0);
            IoTDataDefineMember(1, 3, "Salinity", 2, "g/Kg", 0, 0);

        }
        public override void AddPostEvent(DeviceMessageDTO message, DeviceDefinitionDTO deviceInfo)
        {
            for (int i = message.events.Count ; i > 0; i--)
            {
                if (message.events[i-1].type == DeviceMessageEventDTO.DeviceEventType.MEASUREMENT &&
                     (message.events[i-1].name == "TEMPERATURE.AVG" || message.events[i-1].name == "CONDUCTIVITY.AVG" || message.events[i-1].name == "SALINITY.AVG"))
                {
                    if (message.events[i-1].value > 100)
                    {
                        message.events.RemoveAt(i-1);
                    }
                }
            }

        }
    }
}


