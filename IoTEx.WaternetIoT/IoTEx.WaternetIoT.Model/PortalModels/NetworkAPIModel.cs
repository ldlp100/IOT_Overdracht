using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_NETWORK_API")]
    public class NetworkAPIModel : BaseModel
    {        
        [Column("NAME")]
        public string? Name { get; set; }
        [Column("DESCR")]
        public string? Description { get; set; }
        [Column("IS_LORA")]
        public bool IsLORA { get; set; }
        [Column("IS_SIGFOX")]
        public bool IsSigFox { get; set; }
        [Column("IS_LTM")]
        public bool IsLTM { get; set; }
        [Column("IS_NBIOT")]
        public bool IsNBIoT { get; set; }
    }
}