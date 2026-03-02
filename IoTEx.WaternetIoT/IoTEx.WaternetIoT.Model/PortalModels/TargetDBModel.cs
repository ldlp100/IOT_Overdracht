using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_TARGETDB")]
    public class TargetDBModel : BaseModel
    {
        
        [Column("NAME")]
        public string? Name { get; set; }

        [Column("DESCR")]
        public string? Description { get; set; }

        [Column("CONNECTION_STRING")] 
        public string? ConnectionString { get; set; }
    }
}