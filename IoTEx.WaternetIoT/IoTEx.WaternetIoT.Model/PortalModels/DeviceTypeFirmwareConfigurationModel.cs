using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_DEVICETYPEFIRMWARE2CONFIGURATION")]
    public class DeviceTypeFirmwareConfigurationModel : BaseModel
    {
        public enum ConfigurationRole { IoTWorker =0, TechnicalWorker=1, DomainWorker=2 }
        public enum ConfigurationTypeEnum { type_string, type_bool, type_int16, type_date, type_uint16, type_float, type_uint8, type_int8, type_double }
        [Column("NAME")]
        public string? Name { get; set; }
        [Column("DESCR")]
        public string? Description { get; set; }
        [Column("SYMBOL")]
        public string? Symbol { get; set; }
        [Column("MIN_VAL")]
        public double? MinValue { get; set; }
        [Column("MAX_VAL")]
        public double? MaxValue { get; set; }
        [Column("MIN_LENGTH")]
        public double? MinLength { get; set; }
        [Column("MAX_LENGTH")]
        public double? MaxLength { get; set; }
        [Column("TYPENAME")]
        public string? TypeName { get; set; }
        [Column("CATEGORIES")]
        public string? Categories { get; set; }
        [Column("REGEX")]
        public string? RegEx { get; set; }
        

        [Column("DVALUE")]
        public string? DefaultValue { get; set; }
        [Column("ROLE")]
        public ConfigurationRole Role { get; set; }

        //public bool isNew { get; set; }

        [Column("FIRMWARE_ID")]
        public Guid DeviceTypeFirmwareId { get; set; }
        [ForeignKey("DeviceTypeFirmwareId")]
        public virtual DeviceTypeFirmwareModel DeviceTypeFirmware { get; set; }

        


    }

    
}