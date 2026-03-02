using Newtonsoft.Json;
using System;

namespace IoTEx.WaternetIoT.Model.DTOModels.Old
{

    public class MessageBaseModel
    {
        public enum DocumentType { DEVICE, LORA_DEVICE, NBIOT_DEVICE, SIGFOX_DEVICE, TELEMETRY, DEVICE_ARCHIVE, TELEMETRY_ERROR }
        public string id { get; set; }
        public DateTime created { get; set; }
        public string version { get; set; }

    }
}
