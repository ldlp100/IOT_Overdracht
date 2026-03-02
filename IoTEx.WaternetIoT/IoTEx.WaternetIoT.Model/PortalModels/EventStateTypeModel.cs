using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_EVENT_STATE_TYPE")]
    public class EventStateTypeModel : BaseModel
    {        
        [Column("NAME")]
        public string? Name { get; set; }

        [Column("DESCR")]
        public string? Description { get; set; }

        [Column("IS_STATE")]
        public bool IsState { get; set; }

        [Column("IS_RELEASE")]
        public bool IsReleased { get; set; }

        [Column("IS_UPDATED")]
        public bool IsUpdated { get; set; }

        [Column("DERIVED_STATE_ID")]
        public Guid? DerivedStateId { get; set; }
        
        [ForeignKey("DerivedStateId")]
        public virtual EventStateTypeModel DerivedState { get; set; }
        
        public virtual ICollection<SubEventStateTypeModel> SubEventStateTypes { get; set; }
        
    }
}