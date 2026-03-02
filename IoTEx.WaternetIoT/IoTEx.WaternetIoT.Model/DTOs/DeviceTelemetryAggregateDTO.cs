using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTEx.WaternetIoT.Model.DTOs
{
    public class DeviceTelemetryAggregateDTO
    {
        public DateTime WindowDT { get; set; }
        public string Name { get; set; }
        public Int64 Count { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Sum { get; set; }
        public double Avg { get; set; }
        public double StdDev { get; set; }
        public double Pct90 { get; set; }
        public long WindowIdx { get; set; }

    }
}
