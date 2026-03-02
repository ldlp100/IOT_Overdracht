using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_DEV2CALIB")]
    public class DeviceCalibrationModel : BaseModel
    {        
        [Column("DEVICE_ID")]
        public Guid DeviceId { get; set; }
        public virtual DeviceModel Device { get; set; }

        [Column("DEV2TYPEMEASUREMENT_ID")]
        public Guid? DeviceTypeFirmware2MeasurementTypeId { get; set; }
        public virtual DeviceTypeFirmwareMeasurementTypeModel DeviceTypeFirmware2MeasurementType { get; set; }

        [Column("MIN_MEAS")]
        public double? MinMeas { get; set; }
        [Column("MAX_MEAS")]
        public double? MaxMeas { get; set; }
        [Column("OFFSET_MEAS")]
        public double? OffsetValue { get; set; }

        [Column("MIN_SENSOR")]
        public double? MinReal { get; set; }
        [Column("MAX_SENSOR")]
        public double? MaxReal { get; set; }

    }
}