using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoTEx.WaternetIoT.Model.ViewModels
{

    public class TelemetryViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public double Value { get; set; }
        public string? Unit { get; set; }
        public bool isAlert { get; set; }
        public DateTime Received { get; set; }
        public string? AssetUID { get; set; }
        public string? IMEI { get; set; }
        public string? DeviceName { get; set; }
        public Guid DeviceId { get; set; }
        public double DevicePosLong { get; set; }
        public double DevicePosLat { get; set; }
        public Guid DeviceTypeId { get; set; }
        public string? DeviceTypeName { get; set; }
        public Guid? DeviceBatchId { get; set; }
        public string? DeviceBatchName { get; set; }
        public string? PC { get; set; }
        public string? PCValue { get; set; }
        public string? PCUnit { get; set; }
        public string? ProjectName { get; set; }
    }


}