using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_DEV2OUTPUT")]
    public class DeviceOutputModel : BaseModel
    {        
        [Column("DEVICE_ID")]
        public Guid DeviceId { get; set; }
        public virtual DeviceModel Device { get; set; }

        [Column("EVT_STATE_TYPE_ID")]
        public Guid? EventStateTypeId { get; set; }
        public virtual DeviceTypeFirmwareEventStateTypeModel EventStateType { get; set; }

        [Column("EVT_MEAS_TYPE_ID")]
        public Guid? MeasurementTypeId { get; set; }
        public virtual DeviceTypeFirmwareMeasurementTypeModel MeasurementType { get; set; }

        [Column("UNIT_TYPE_ID")]
        public Guid? UnitTypeId { get; set; }
        public virtual UnitTypeModel UnitType { get; set; }

        [Column("PC")]
        public String? PC { get; set; }

        [Column("IS_ALERT")]
        public bool IsAlert { get; set; }
    }
}