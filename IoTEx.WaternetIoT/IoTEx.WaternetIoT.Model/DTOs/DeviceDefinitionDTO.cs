

namespace IoTEx.WaternetIoT.Model.DTOs
{

    public class DeviceDefinitionDTO
    {

        public string id { get; set; }
        public string deviceId { get; set; }
        public string deviceName { get; set; }
        public string assetUID { get; set; }
        public bool isTraced { get; set; }
        public bool isActive { get; set; }
        public DeviceDefinitionInfoDTO info { get; set; }
        public DeviceDefinitionLocationDTO location { get; set; }        
        public DeviceDefinitionNetworkInfoDTO network { get; set; }
        public List<DeviceDefinitionProjectDTO> projects { get; set; }
        public DateTime publishedDate { get; set; }
        public DateTime? installedDate { get; set; }
        public int publishedCounter { get; set; }
        public string publishedByUserId { get; set; }
        public string publishedByUsername { get; set; }
        public DeviceDefinitionSettingsDTO settings  { get; set; }

    }
    
    
    
    
    
}
