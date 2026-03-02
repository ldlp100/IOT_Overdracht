using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoTEx.WaternetIoT.Model.PortalModels
{
    public class DeviceTelemetryModel : BaseModel
    {
        public Guid id { get; set; }    
        public DateTime Received { get; set; }
    }
}