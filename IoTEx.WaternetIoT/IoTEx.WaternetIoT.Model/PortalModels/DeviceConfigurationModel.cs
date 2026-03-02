using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_DEVICE2CONFIGURATION")]
    public class DeviceConfigurationModel : BaseModel
    {
        
        [Column("CONFIG_ID")]
        public Guid DeviceTypeFirmwareConfigurationId { get; set; }
        [ForeignKey("DeviceTypeFirmwareConfigurationId")]
        public virtual DeviceTypeFirmwareConfigurationModel DeviceTypeFirmwareConfiguration { get; set; }

        [Column("DEVICE_ID")]
        public Guid? DeviceId { get; set; }
        [ForeignKey("DeviceId")]
        public virtual DeviceModel Device { get; set; }
        [Column("VALUE")]
        public string? Value { get; set; }

    }

    
}