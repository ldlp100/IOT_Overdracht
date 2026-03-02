
namespace IoTEx.WaternetIoT.Model.DTOs
{
    public class DeviceDefinitionStateDTO
    {
        
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<DeviceDefinitionSubStateDTO> values { get; set; }
        public string updatedById { get; set; }
        public string updatedByName { get; set; }
    }
}
