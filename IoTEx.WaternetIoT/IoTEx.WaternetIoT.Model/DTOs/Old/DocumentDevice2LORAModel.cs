using Newtonsoft.Json;
using System;

namespace IoTEx.WaternetIoT.Model.DTOModels.Old
{
    public class DocumentDevice2LORAModel
    {
        [JsonProperty(PropertyName = "deveui")]
        public string deveui { get; set; }
        [JsonProperty(PropertyName = "deviceId")]
        public string deviceId { get; set; }
    }
}
