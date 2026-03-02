using System;
using System.Collections.Generic;
using System.Text;
using IoTEx.WaternetIoT.Data.Model;
using IoTEx.WaternetIoT.Model.DTOs;
using IoTEx.WaternetIoT.Model.DTOs.API;
using Newtonsoft.Json;

namespace IoTEx.Waternet.Parser
{
    public class AQUATROLL600_V1_PARSER : IOT_DEVICE_GENERIC_V1_PARSER
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
            IoTDataDefineMember(2, 1, "Temperature", 2, "oC", 0, 0);
            IoTDataDefineMember(2, 3, "Depth", 2, "feet", 0, 0);
            IoTDataDefineMember(2, 5, "ActualConductivity", 2, "uS/cm", 0, 0);
            IoTDataDefineMember(2, 6, "SpecialConductivity", 2, "uS/cm", 0, 0);
            IoTDataDefineMember(2, 7, "Resistivity", 2, "ohm-cm", 0, 0);
            IoTDataDefineMember(2, 8, "Salinity", 2, "PSU", 0, 0);
            IoTDataDefineMember(2, 9, "TotalDissolvedSolidsppt", 2, "ppt", 0, 0);
            IoTDataDefineMember(2, 10, "DensityOfWater", 2, "g/cm3", 0, 0);
            IoTDataDefineMember(2, 11, "BarometricPressure", 2, "mmHg", 0, 0);
            IoTDataDefineMember(2, 23, "TotalSuspendedSolidsmg/L", 2, "mg/L", 0, 0);
            IoTDataDefineMember(2, 24, "ExternalVoltage", 2, "Volts", 0, 0);
            IoTDataDefineMember(2, 29, "NitrateNO3-Concentramg/L", 2, "mg/L", 0, 0);
            IoTDataDefineMember(2, 30, "NitrateNO3-mV", 2, "mV", 0, 0);
        }
       

    }

}


