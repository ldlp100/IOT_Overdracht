using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_DEVICETYPE")]
    public class DeviceTypeModel : BaseModel
    {
        [Column("NAME")]
        public string? Name { get; set; }
        [Column("DESCR")]
        public string? Description { get; set; }

        [Column("SUPPLIER_ID")]
        public Guid SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual SupplierModel Supplier { get; set; }

        
    }
}