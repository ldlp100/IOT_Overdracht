using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_DEVICETYPEFIRMWARE2MEASUREMENT")]
    public class DeviceTypeFirmwareMeasurementTypeModel : BaseModel
    {
        
        //public bool isNew { get; set; }
        [Column("FIRMWARE_ID")]
        public Guid DeviceTypeFirmwareId { get; set; }
        public virtual DeviceTypeFirmwareModel DeviceTypeFirmware { get; set; }

        [Column("MEAS_TYPE_ID")]
        public Guid? MeasurementTypeId { get; set; }
        public virtual MeasurementTypeModel MeasurementType { get; set; }

        [Column("NAME")]
        public String? Name { get; set; }
        [Column("DESCR")]
        public String? Description { get; set; }

        [Column("UNIT_TYPE_ID")]
        public Guid? UnitTypeId { get; set; }
        public virtual UnitTypeModel UnitType { get; set; }

        [Column("MIN_MEAS")]
        public double? MinMeas { get; set; }
        [Column("MAX_MEAS")]
        public double? MaxMeas { get; set; }
        [Column("OFFSET_MEAS")]
        public double? OffsetValue { get; set; }

        [Column("MIN_SENSOR")]
        public double? MinSensor { get; set; }
        [Column("MAX_SENSOR")]
        public double? MaxSensor { get; set; }
        [Column("UNIT")]
        public string? Unit { get; set; }
    }
}