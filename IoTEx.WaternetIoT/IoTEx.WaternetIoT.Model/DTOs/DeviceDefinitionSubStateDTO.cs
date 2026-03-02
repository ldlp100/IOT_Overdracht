using Newtonsoft.Json;


namespace IoTEx.WaternetIoT.Model.DTOs
{
    public class DeviceDefinitionSubStateDTO
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string name { get; set; }
        public double value { get; set; }
        [JsonProperty("desc", NullValueHandling = NullValueHandling.Ignore)]
        public string description { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string updatedById { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string updatedByName { get; set; }
    }
}
