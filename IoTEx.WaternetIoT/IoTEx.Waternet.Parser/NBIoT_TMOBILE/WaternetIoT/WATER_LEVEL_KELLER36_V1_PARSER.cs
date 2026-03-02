using System;
using System.Collections.Generic;
using System.Text;
using IoTEx.WaternetIoT.Data.Model;
using IoTEx.WaternetIoT.Model.DTOs;
using IoTEx.WaternetIoT.Model.DTOs.API;
using Newtonsoft.Json;


namespace IoTEx.Waternet.Parser
{
    public class WATER_LEVEL_KELLER36_V1_PARSER : IOT_DEVICE_GENERIC_V1_PARSER
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
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "SensorLevelRef", description = "Reference Level of the Sensor Pressure in mm", symbol = "lv=", value = "0", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_double });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "Density", description = "Density Liquid in kg/m3", symbol = "dens=", value = "1000", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_double });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "ZeroHeightCorrection", description = "Correction pressure height(in mm) to get zero level ", symbol = "zhc=", value = "0", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_double });
            return configs;
        }
        public override void Definition()
        {
            IoTDataDefineMember((int)SENSOR_TYPE_ENUM.SENSOR_KELLER_XW36, 1, "ExtPressure",(int)IOT_EVENT.MEASUREMENT, "mbar",(int)IOT_FORMAT_ENUM.IOT_FLOAT, 0);
            IoTDataDefineMember((int)SENSOR_TYPE_ENUM.SENSOR_KELLER_XW36, 2, "Temperature", (int)IOT_EVENT.MEASUREMENT, "oC", (int)IOT_FORMAT_ENUM.IOT_FLOAT, 0);
            IoTDataDefineMember((int)SENSOR_TYPE_ENUM.SENSOR_KELLER_XW36, 3, "InternalPressure", (int)IOT_EVENT.MEASUREMENT, "mbar", (int)IOT_FORMAT_ENUM.IOT_FLOAT, 0);
            IoTDataDefineMember((int)SENSOR_TYPE_ENUM.SENSOR_KELLER_XW36, 4, "InternalTemperature", (int)IOT_EVENT.MEASUREMENT,  "oC",(int)IOT_FORMAT_ENUM.IOT_FLOAT, 0);
            IoTDataDefineMember((int)SENSOR_TYPE_ENUM.SENSOR_KELLER_XW36, 5, "DeltaPressure", (int)IOT_EVENT.MEASUREMENT,  "mbar", (int)IOT_FORMAT_ENUM.IOT_FLOAT, 0);
        }
        
        public override void AddPostEvent(DeviceMessageDTO message, DeviceDefinitionDTO deviceInfo)
        {
            object SensorLevelRef=0;
            GetValueConfigurationItem(deviceInfo, "SensorLevelRef",ref SensorLevelRef);
            object Density = 0;
            GetValueConfigurationItem(deviceInfo, "Density", ref Density);
            object ZeroHeightCorrection = 0;
            GetValueConfigurationItem(deviceInfo, "ZeroHeightCorrection", ref ZeroHeightCorrection);

            //Look For Delta Pressure 
            string eventName = IOT.METADATA.WATER_LEVEL_KELLER36_V1.MEASUREMENT.DELTA_PRESSURE.AVG.GetType().Name + ".AVG";
            List<DeviceMessageEventDTO> telemetries = message.events.FindAll(o => o.type == DeviceMessageEventDTO.DeviceEventType.MEASUREMENT && o.name  == eventName);
            foreach (DeviceMessageEventDTO telemetry in telemetries)
            {
                double level =(double)ZeroHeightCorrection+(double)SensorLevelRef + telemetry.value*10.20*1000/ (double)Density;
                SetMeasurement(message, (DateTime)telemetry.received, telemetry.EDUID, IOT.METADATA.WATER_LEVEL_KELLER36_V1.MEASUREMENT.LEVEL.AVG, level, deviceInfo);
            }
                
            
        }
    }

}


