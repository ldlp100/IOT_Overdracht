using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_APP_CONFIG")]
    public class AppConfigurationModel : BaseModel
    {        
        [Column("NAME")]
        public string Name { get; set; }

        [Column("DESCR")]
        public string? Description { get; set; }

        [Column("VALUE")]
        public string? Value { get; set; }

        [Column("IS_DELET")]
        public bool IsDeletable { get; set; }
        [Column("IS_MODIF")]
        public bool IsModifiable { get; set; }
    }
}