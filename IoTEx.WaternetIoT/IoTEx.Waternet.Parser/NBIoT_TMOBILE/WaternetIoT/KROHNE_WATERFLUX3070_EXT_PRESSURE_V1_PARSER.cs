using System;
using System.Collections.Generic;
using System.Text;
using IoTEx.WaternetIoT.Data.Model;
using IoTEx.WaternetIoT.Model.DTOs;
using IoTEx.WaternetIoT.Model.DTOs.API;
using Newtonsoft.Json;


namespace IoTEx.Waternet.Parser
{
    public class KROHNE_WATERFLUX3070_EXT_PRESSURE_V1_PARSER : IOT_DEVICE_GENERIC_V1_PARSER
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
            configs.Add(new DeviceDefinitionConfigurationDTO()
            {
                name = "AirPressureCorrection",
                description = "Positive value Air Correction in Bar",
                symbol = "aircorrection=",
                value = "1.013",
                type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_double
            });


            return configs;
        }
        public override void Definition()
        {
            //MEASUREMENT
            //int sensorType = (int)SENSOR_TYPE_ENUM.SENSOR_KROHNE_WATERFLUX_3070_EXT_PRESSURE;
            IoTDataDefineMemberExt(0, 3, 1, "FlowSpeed", 2, "m/s", 10, 0);
            IoTDataDefineMemberExt(0, 3, 2, "VolumeFlow", 2, "m3/s", 10, 0);
            IoTDataDefineMemberExt(0, 3, 5, "TotalFlowVolume", 2, "m3", 0, 5);
            IoTDataDefineMemberExt(0, 3, 6, "ForwardFlowVolume", 2, "m3", 0, 5);
            IoTDataDefineMemberExt(0, 3, 7, "ReverseFlowVolume", 2, "m3", 0, 5);
            IoTDataDefineMemberExt(0, 3, 11, "ErrorWarningState", 0, "", 17, 5);
            IoTDataDefineMemberExt(0, 3, 12, "BatteryType", 0, "", 17, 5);
            IoTDataDefineMemberExt(0, 3, 13, "BatteryCapacity", 2, "Ah", 10, 5);
            IoTDataDefineMemberExt(0, 3, 14, "BatteryLeft", 2, "Ah", 10, 5);
            IoTDataDefineMemberExt(0, 3, 15, "CurrentFlowDirection", 0, "", 17, 5);
            IoTDataDefineMemberExt(1, 0, 1, "Pressure", 2, "mbar", 0, 0);
            IoTDataDefineMemberExt(1, 0, 2, "Temperature", 2, "oC", 0, 0);
            //IoTDataDefineMemberExt(1, 0, 3, "DevicePressure", 2, "mbar", 0, 0);
            //IoTDataDefineMemberExt(1, 0, 4, "DeviceTemperature", 2, "oC", 0, 0);
            //IoTDataDefineMemberExt(1, 0, 5, "DeltaPressure", 2, "mbar", 0, 0);




        }
        public override void AddPostEvent(DeviceMessageDTO message, DeviceDefinitionDTO deviceInfo)
        {
            object airPressureCorrection = 0;
            GetValueConfigurationItem(deviceInfo, "AirPressureCorrection", ref airPressureCorrection);
            object sensorNAPLevel = 0;
            GetValueConfigurationItem(deviceInfo, "SensorNAPLevel", ref sensorNAPLevel);


            string eventName = IOT.METADATA.KROHNE_WATERFLUX3070_V1.MEASUREMENT.PRESSURE.AVG.GetType().Name + ".AVG";
            List<DeviceMessageEventDTO> telemetries = message.events.FindAll(o => o.type == DeviceMessageEventDTO.DeviceEventType.MEASUREMENT && o.name == eventName);
            foreach (DeviceMessageEventDTO telemetry in telemetries)
            {
                telemetry.value = (telemetry.value / 1000) - (double) airPressureCorrection;

                double correctedValue = telemetry.value - ((double)sensorNAPLevel)/10;
                SetMeasurement(message, (DateTime)telemetry.received, telemetry.EDUID, 
                    IOT.METADATA.KROHNE_WATERFLUX3070_V1.MEASUREMENT.NAP_CORRECTED_PRESSURE.AVG, 
                    correctedValue, deviceInfo);
            
            }

        }
    }

}


