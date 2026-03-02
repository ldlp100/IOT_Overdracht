using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_MEAS_TYPE")]
    public class MeasurementTypeModel : BaseModel
    {
        
        [Column("NAME")]
        public string? Name { get; set; }
        [Column("DESCR")]
        public string? Description { get; set; }
        [Column("UNIT_ID")]
        public Guid UnitTypeId { get; set; }
        [ForeignKey("UnitTypeId")]
        public virtual UnitTypeModel UnitType { get; set; }
    }
}