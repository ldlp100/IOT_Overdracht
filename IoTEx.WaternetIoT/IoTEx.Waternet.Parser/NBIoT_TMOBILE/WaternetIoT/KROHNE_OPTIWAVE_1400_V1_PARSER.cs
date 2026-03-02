using System;
using System.Collections.Generic;
using System.Text;
using IoTEx.WaternetIoT.Data.Model;
using IoTEx.WaternetIoT.Model.DTOs;
using IoTEx.WaternetIoT.Model.DTOs.API;
using Newtonsoft.Json;

namespace IoTEx.Waternet.Parser
{
    public class KROHNE_OPTIWAVE_1400_V1_PARSER : IOT_DEVICE_GENERIC_V2_PARSER
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
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "SensorMinRange", description = "Minimal Range", symbol = "smin=", value = "200", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_double });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "SensorMaxRange", description = "Maximal Range", symbol = "smax=", value = "3000", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_double });
            return configs;
        }
        public override void Definition()
        {
            //MEASUREMENT
            int sensorType = (int)SENSOR_TYPE_ENUM.SENSOR_ANALOG_4_20MA;
            IoTDataDefineMemberExt(0,sensorType, 1, "Current", 2, "mA", (int)IOT_FORMAT_ENUM.IOT_FLOAT, 5);
           
        }
        public override void AddPostEvent(DeviceMessageDTO message, DeviceDefinitionDTO deviceInfo)
        {
            
            object sensorMin = 0;
            GetValueConfigurationItem(deviceInfo, "SensorMinRange", ref sensorMin);
            object sensorMax = 0;
            GetValueConfigurationItem(deviceInfo, "SensorMaxRange", ref sensorMax);

            string eventName = IOT.METADATA.KROHNE_OPTIWAVE_1400_V1.MEASUREMENT.CURRENT.LAST.GetType().Name + ".LAST";
            List<DeviceMessageEventDTO> telemetries = message.events.FindAll(o => o.type == DeviceMessageEventDTO.DeviceEventType.MEASUREMENT && o.name == eventName);
            foreach (DeviceMessageEventDTO telemetry in telemetries)
            {
                if (telemetry.value <= 4)
                {
                    SetAlert(message, (DateTime)telemetry.received, telemetry.EDUID,
                        IOT.METADATA.KROHNE_OPTIWAVE_1400_V1.ALERT.ERROR_WARNING_ALERTS.SENSOR_ERROR,deviceInfo);
                }
                else
                {
                    try
                    {
                        double smin = (double)sensorMin;
                        double smax = (double)sensorMax;
                        if (smin > smax)
                        {
                            throw(new Exception());
                        }
                        double correctedValue = ((telemetry.value - 4) / 16 * (smax - smin)) + smin;
                        SetMeasurement(message, (DateTime)telemetry.received, telemetry.EDUID,
                            IOT.METADATA.KROHNE_OPTIWAVE_1400_V1.MEASUREMENT.DISTANCE.LAST,
                            correctedValue, deviceInfo);

                    }
                    catch(Exception ex)
                    {
                        SetAlert(message, (DateTime)telemetry.received, telemetry.EDUID,
                        IOT.METADATA.KROHNE_OPTIWAVE_1400_V1.ALERT.ERROR_WARNING_ALERTS.CONFIG_ERROR, deviceInfo);
                    }                    
                }
            }
        }
    }

}


