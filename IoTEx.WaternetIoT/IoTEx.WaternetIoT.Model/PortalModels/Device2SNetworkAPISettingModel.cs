using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_DEVICE2NETAPISETTING")]
    public class Device2SNetworkAPISettingModel : BaseModel
    {
        
        [Column("SETTING_ID")]
        public Guid SettingId { get; set; }
        [ForeignKey("SettingId")]
        public virtual NetworkAPISettingModel Setting { get; set; }

        [Column("DEVICE_ID")]
        public Guid? DeviceId { get; set; }
        [ForeignKey("DeviceId")]
        public virtual DeviceModel Device { get; set; }
        [Column("VALUE")]
        public string? Value { get; set; }

    }

    
}