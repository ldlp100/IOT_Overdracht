using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_DEVICETYPEFIRMWARE_STATE_TYPE")]
    public class DeviceTypeFirmwareEventStateTypeModel : BaseModel
    {
        //public bool isNew { get; set; }
        [Column("FIRMWARE_ID")]
        public Guid? DeviceTypeFirmwareId { get; set; }
        public virtual DeviceTypeFirmwareModel DeviceTypeFirmware { get; set; }

        [Column("EVT_STATE_TYPE_ID")]
        public Guid? EventStateTypeId { get; set; }
        public virtual EventStateTypeModel EventStateType { get; set; }

        [Column("NAME")]
        public String? Name { get; set; }
        [Column("DESCR")]
        public String? Description { get; set; }

        [Column("IS_ALERT")]
        public bool IsAlert { get; set; }

        public virtual ICollection<DeviceTypeEventState2SubStateTypeModel> SubStates { get; set; }

    }
}