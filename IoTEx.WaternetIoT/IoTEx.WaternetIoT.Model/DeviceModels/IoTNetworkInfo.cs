using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTEx.WaternetIoT.Model.Device
{
    public class IoTNetworkInfo
    {
        [JsonProperty("SNR", NullValueHandling = NullValueHandling.Ignore)]
        public double SNR { get; set; }
        [JsonProperty("STA", NullValueHandling = NullValueHandling.Ignore)]
        public string Station { get; set; }
        [JsonProperty("RSSI", NullValueHandling = NullValueHandling.Ignore)]
        public double RSSI { get; set; }
        [JsonProperty("SEQ", NullValueHandling = NullValueHandling.Ignore)]
        public int Sequence { get; set; }
        [JsonProperty("SF", NullValueHandling = NullValueHandling.Ignore)]
        public int SF { get; set; }
        [JsonProperty("DT", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime DT { get; set; }
        [JsonProperty("CNT", NullValueHandling = NullValueHandling.Ignore)]
        public int CNT { get; set; }
        

    }
}
