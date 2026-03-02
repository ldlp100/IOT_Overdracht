using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_SUPPLIER")]
    public class SupplierModel : BaseModel
    {        
        [Column("NAME")]
        public string? Name { get; set; }

        [Column("DESCR")]
        public string? Description { get; set; }

        [Column("TELNUMBER")]
        public string? TelNumber { get; set; }


    }
}