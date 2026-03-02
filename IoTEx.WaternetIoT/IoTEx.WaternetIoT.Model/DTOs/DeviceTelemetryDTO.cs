using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTEx.WaternetIoT.Model.DTOs
{
    //public class DeviceTelemetryDTO
    //{
    //    [JsonProperty(PropertyName = "T_EN")]
    //    public string T_EN { get; set; }
    //    [JsonProperty(PropertyName = "T_ED")]
    //    public DateTime T_ED { get; set; }
    //    [JsonProperty(PropertyName = "T_EV")]
    //    public float T_EV { get; set; }
    //}
    public class DeviceTelemetryDTO
    {
        public Guid Id { get; set; }
        public Guid MsgId { get; set; }
        public string? Name { get; set; }
        public double Value { get; set; }
        public string? Unit { get; set; }
        public bool IsAlert { get; set; }
        public DateTime? Received { get; set; }
        public string? AssetUID { get; set; }
        public string? NetworkId { get; set; }
        public string? DeviceName { get; set; }
        public string DeviceId { get; set; }
        public double DevicePosLong { get; set; }
        public double DevicePosLat { get; set; }
        public string DeviceTypeId { get; set; }
        public string? DeviceTypeName { get; set; }
        public string? DeviceBatchId { get; set; }
        public string? DeviceBatchName { get; set; }
        public string? PC { get; set; }
        public string? PCValue { get; set; }
        public string? PCUnit { get; set; }
        public string? ProjectId { get; set; }
    }
}
