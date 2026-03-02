using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class DeviceMessageViewModel
    {
        public Guid Id { get; set; }
        public DateTime Received { get; set; }
        public string DeviceId { get; set; }
        public string NetworkId { get; set; }
        public string Content { get; set; }
        public DeviceMessageViewModel()
        {
        }

    }
}