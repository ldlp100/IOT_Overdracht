

namespace IoTEx.WaternetIoT.Model.DTOs
{
    public class DeviceDefinitionPublishedDTO
    {

        public string DeviceId { get; set; }     
        public string NetworkId { get; set; }
        public sbyte IsActive { get; set; }        
        public string JSON  { get; set; }
        public DateTime Published { get; set; }

    }
    
}
