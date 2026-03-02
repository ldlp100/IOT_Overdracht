

namespace IoTEx.WaternetIoT.Model.DTOs
{

    public class DeviceDefinitionSettingsDTO
    {

        public string? Version { get; set; }
        //public List<DeviceDefinitionInfoDTO> info { get; set; }
        public List<DeviceDefinitionMeasurementDTO> measurements { get; set; }
        public List<DeviceDefinitionStateDTO> states { get; set; }
        public List<DeviceDefinitionAlertDTO> alerts { get; set; }
        public List<DeviceDefinitionProcessCodeDTO> processCodes { get; set; }
        public List<DeviceDefinitionConfigurationDTO> configurations { get; set; }
        
        public List<DeviceDefinitionExtraInfoDTO> infos { get; set; }
        public DeviceDefinitionSettingsDTO()
        {
            //info = new List<DeviceDefinitionInfoDTO>();
            measurements = new List<DeviceDefinitionMeasurementDTO>();
            states = new List<DeviceDefinitionStateDTO>();
            alerts = new List<DeviceDefinitionAlertDTO>();
            processCodes = new List<DeviceDefinitionProcessCodeDTO>();
            configurations = new List<DeviceDefinitionConfigurationDTO>();            
            infos = new List<DeviceDefinitionExtraInfoDTO>();
        }
        


    }
}