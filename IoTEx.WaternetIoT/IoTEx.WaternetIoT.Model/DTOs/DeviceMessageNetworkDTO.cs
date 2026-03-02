using Newtonsoft.Json;
using System;

namespace IoTEx.WaternetIoT.Model.DTOs
{
    
    public class DeviceMessageNetworkDTO
    {
        public double snr { get; set; }
        public string station { get; set; }
        public double rssi { get; set; }
        public int sequence { get; set; }
        public int sf { get; set; }
        public DateTime date { get; set; }
        public int cnt { get; set; }

    }
}
