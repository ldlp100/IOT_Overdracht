using System;
using System.Collections.Generic;
using System.Text;
using IoTEx.WaternetIoT.Data.Model;
using IoTEx.WaternetIoT.Model.DTOs;
using IoTEx.WaternetIoT.Model.DTOs.API;
using Newtonsoft.Json;


namespace IoTEx.Waternet.Parser
{
    public class KROHNE_WATERFLUX3070_V1_PARSER : IOT_DEVICE_GENERIC_V1_PARSER
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
            configs.Add(new DeviceDefinitionConfigurationDTO()
            {
                name = "SensorNAPLevel",
                description = "NAP height of the Pressure Sensor in mm",
                symbol = "nap=",
                value = "0",
                type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_double
            });
            return configs;
        }
        public override void Definition()
        {
            //MEASUREMENT
            int sensorType = (int)SENSOR_TYPE_ENUM.SENSOR_KROHNE_WATERFLUX_3070;
            IoTDataDefineMember(sensorType, 1, "FlowSpeed", 2, "m/s", 10, 0);
            IoTDataDefineMember(sensorType, 2, "VolumeFlow", 2, "m3/hr", 10, 0);
            //IoTDataDefineMember(sensorType, 3, "Counter1", 2, "m3", 10, 5);
            //IoTDataDefineMember(sensorType, 4, "Counter2", 2, "m3", 10, 5);
            IoTDataDefineMember(sensorType, 5, "TotalFlowVolume", 2, "m3",0, 5);
            IoTDataDefineMember(sensorType, 6, "ForwardFlowVolume", 2, "m3", 0, 5);
            IoTDataDefineMember(sensorType, 7, "ReverseFlowVolume", 2, "m3", 0, 5);
            //IoTDataDefineMember(sensorType, 8, "Pressure", 2, "mbar", 17, 0);
            IoTDataDefineMember(sensorType, 9, "PressureAlarmState", 1, "mbar", 17, 5);
            IoTDataDefineMember(sensorType, 10, "TemperatureAlarmStat", 1, "", 17, 5);
            IoTDataDefineMember(sensorType, 11, "ErrorWarningState", 0, "", 17, 5);
            IoTDataDefineMember(sensorType, 12, "BatteryType", 0, "", 17, 5);
            IoTDataDefineMember(sensorType, 13, "BatteryCapacity", 2, "Ah", 10, 5);
            IoTDataDefineMember(sensorType, 14, "BatteryLeft", 2, "Ah", 10, 5);
            IoTDataDefineMember(sensorType, 15, "CurrentFlowDirection", 0, "", 17, 5);
            IoTDataDefineMember(sensorType, 16, "Pressure", 2, "Bar",11,0);
            IoTDataDefineMember(sensorType, 17, "Temperature", 2, "oC", 17, 0);

            


        }
        public override void AddPostEvent(DeviceMessageDTO message, DeviceDefinitionDTO deviceInfo)
        {
            
            object sensorNAPLevel = 0;
            GetValueConfigurationItem(deviceInfo, "SensorNAPLevel", ref sensorNAPLevel);


            string eventName = IOT.METADATA.KROHNE_WATERFLUX3070_V1.MEASUREMENT.PRESSURE.AVG.GetType().Name + ".AVG";
            List<DeviceMessageEventDTO> telemetries = message.events.FindAll(o => o.type == DeviceMessageEventDTO.DeviceEventType.MEASUREMENT && o.name == eventName);
            foreach (DeviceMessageEventDTO telemetry in telemetries)
            {
                telemetry.value = (telemetry.value);

                double correctedValue = telemetry.value - ((double)sensorNAPLevel)/10;

                SetMeasurement(message, (DateTime)telemetry.received, telemetry.EDUID,
                    IOT.METADATA.KROHNE_WATERFLUX3070_V1.MEASUREMENT.NAP_CORRECTED_PRESSURE.AVG,
                    correctedValue, deviceInfo);

            }
        }
    }

}


