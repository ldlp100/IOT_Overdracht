using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE")]
    public class DeviceTypeEventState2SubStateTypeModel : BaseModel
    {
        public bool isNew { get; set; }
        [Column("NAME")]
        public string Name { get; set; }
        [Column("DESCR")]
        public string? Description { get; set; }

        [Column("EVT_STATE_ID")]
        public Guid DeviceTypeEventStateTypeId { get; set; }

        [ForeignKey("DeviceTypeEventStateTypeId")]
        public virtual DeviceTypeFirmwareEventStateTypeModel DeviceTypeFirmwareEventStateType { get; set; }

        [Column("IS_RELEASED")]
        public bool IsReleased { get; set; }

        [Column("IS_UPDATED")]
        public bool IsUpdated { get; set; }

        [Column("START_DT")]
        public DateTime? StartDate { get; set; }

        [Column("END_DT")]
        public DateTime? EndDate { get; set; }

        [Column("VALUE")]
        public double Value { get; set; }

    }
}