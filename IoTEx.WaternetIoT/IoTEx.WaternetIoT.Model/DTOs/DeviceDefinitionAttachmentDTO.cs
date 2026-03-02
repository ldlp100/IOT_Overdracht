using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace IoTEx.WaternetIoT.Model.DTOs
{

    public class DeviceDefinitionAttachmentDTO
    {
        public string url { get; set; }
        public string name { get; set; }
        public string objectType { get; set; }
        public string attachType { get; set; }
    }
}
