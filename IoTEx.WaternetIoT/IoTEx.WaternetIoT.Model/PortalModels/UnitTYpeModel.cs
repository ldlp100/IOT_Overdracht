using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_UNIT_TYPE")]
    public class UnitTypeModel : BaseModel
    {        
        [Column("NAME")]
        public string? Name { get; set; }

        [Column("DESCR")]
        public string? Description { get; set; }

        [Column("LABEL")]
        public string? Label { get; set; }

    }
}