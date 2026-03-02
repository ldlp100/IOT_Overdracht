using Newtonsoft.Json;


namespace IoTEx.WaternetIoT.Model.DTOs
{
    public class DeviceDefinitionMeasurementDTO
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string id { get; set; }
        public string name { get; set; }
        [JsonProperty("desc", NullValueHandling = NullValueHandling.Ignore)]
        public string description { get; set; }
        [JsonProperty("unit", NullValueHandling = NullValueHandling.Ignore)]
        public string unit { get; set; }
        [JsonProperty("unitLabel", NullValueHandling = NullValueHandling.Ignore)]
        public string unitLabel { get; set; }
        [JsonProperty("minSensor", NullValueHandling = NullValueHandling.Ignore)]
        public double? minSensor { get; set; }
        [JsonProperty("maxSensor", NullValueHandling = NullValueHandling.Ignore)]
        public double? maxSensor { get; set; }
        [JsonProperty("minMst", NullValueHandling = NullValueHandling.Ignore)]
        public double? minMeasurement { get; set; }
        [JsonProperty("maxMst", NullValueHandling = NullValueHandling.Ignore)]
        public double? maxMeasurement { get; set; }
        [JsonProperty("offsetValue", NullValueHandling = NullValueHandling.Ignore)]
        public double? offsetValue { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string updatedById { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string updatedByName { get; set; }
    }
}
