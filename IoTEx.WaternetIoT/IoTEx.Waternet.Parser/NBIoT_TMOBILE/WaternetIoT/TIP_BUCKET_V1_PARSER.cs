using System;
using System.Collections.Generic;
using System.Text;
using IoTEx.WaternetIoT.Model.DTOs;
using IoTEx.WaternetIoT.Model.DTOs.API;
using Newtonsoft.Json;

namespace IoTEx.Waternet.Parser
{
    public class TIP_BUCKET_V1_PARSER : IOT_DEVICE_GENERIC_V2_PARSER
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
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "MultiplierMM", description = "This multiplier is multiply pulse counter by the number of mm rain per pulse", symbol = "bucket_mm", value = "1", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_double });
            return configs;
        }
        public override void Definition()
        {
            int sensorType = (int)SENSOR_TYPE_ENUM.SENSOR_PULSE;
            IoTDataDefineMemberExt(0, sensorType, 1, "Counter", 2, "", 1, 5);
            IoTDataDefineMemberExt(0, sensorType, 2, "Delta", 2, "", 1, 5);
        }
        public override void AddPostEvent(DeviceMessageDTO message, DeviceDefinitionDTO deviceInfo)
        {
            object multiplierMM = 0;
            GetValueConfigurationItem(deviceInfo, "MultiplierMM", ref multiplierMM);

            string eventName = IOT.METADATA.TIP_BUCKET_V1.MEASUREMENT.COUNTER.LAST.GetType().Name + ".LAST";
            List<DeviceMessageEventDTO> telemetries = message.events.FindAll(o => o.type == DeviceMessageEventDTO.DeviceEventType.MEASUREMENT && o.name == eventName);
            foreach (DeviceMessageEventDTO telemetry in telemetries)
            {

                double correctedValue = telemetry.value * (double) multiplierMM;
                SetMeasurement(message, (DateTime)telemetry.received, telemetry.EDUID,
                    IOT.METADATA.TIP_BUCKET_V1.MEASUREMENT.COUNTER_MM.LAST,
                    correctedValue, deviceInfo);
            }

            eventName = IOT.METADATA.TIP_BUCKET_V1.MEASUREMENT.DELTA.LAST.GetType().Name + ".LAST";
            telemetries = message.events.FindAll(o => o.type == DeviceMessageEventDTO.DeviceEventType.MEASUREMENT && o.name == eventName);
            foreach (DeviceMessageEventDTO telemetry in telemetries)
            {

                double correctedValue = telemetry.value * (double)multiplierMM;
                SetMeasurement(message, (DateTime)telemetry.received, telemetry.EDUID,
                    IOT.METADATA.TIP_BUCKET_V1.MEASUREMENT.DELTA_MM.LAST,
                    correctedValue, deviceInfo);
            }

        }
    }
}


