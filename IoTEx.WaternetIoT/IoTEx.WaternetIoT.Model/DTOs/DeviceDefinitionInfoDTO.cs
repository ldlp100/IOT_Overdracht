
namespace IoTEx.WaternetIoT.Model.DTOs
{

    public class DeviceDefinitionInfoDTO
    {
        public string serialNr { get; set; }
        public string harwareVersion { get; set; }

        public string deviceBatchId { get; set; }
        public string deviceBatchName { get; set; }
        public string deviceTypeId { get; set; }
        public string deviceTypeName { get; set; }
        public string deviceParserId { get; set; }
        public string deviceParserName { get; set; }
        public string deviceFirmwareId { get; set; }
        public string deviceFirmwareName { get; set; }
        public string deviceParserClassName { get; set; }
        public string deviceImageURL { get; set; }
        public string deviceTypeImageURL { get; set; }
        public List<DeviceDefinitionAttachmentDTO> attachments { get; set; }
    }
}
