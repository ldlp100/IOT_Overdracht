using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_DEVICE2GROUP")]
    public class Device2ProjectModel : BaseModel
    {
        [Column("DEVICE_ID")]
        public Guid? DeviceId { get; set; }
        public virtual DeviceModel Device { get; set; }

        [Column("GROUP_ID")]
        public Guid? ProjectId { get; set; }
        public virtual ProjectModel Project { get; set; }

    }
}