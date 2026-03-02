using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_NETWORK_API_SETTING")]
    public class NetworkAPISettingModel : BaseModel
    {        
        [Column("NAME")]
        public string? Name { get; set; }
        [Column("DESCR")]
        public string? Description { get; set; }
        [Column("VAL")]
        public string? Value { get; set; }
        [Column("IS_SECRET")]
        public bool IsSecret { get; set; }
        [Column("SECRET_VAL")]
        public string? SecretId { get; set; }
        [Column("IS_DEVICE_INFO")]
        public bool IsDeviceInfo { get; set; }
        
        [Column("NET_API_ID")]
        public Guid NetworkAPIId { get; set; }
        [ForeignKey("NetworkAPIId")]
        public virtual NetworkAPIModel NetworkAPI { get; set; }

    }
}