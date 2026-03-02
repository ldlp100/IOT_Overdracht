using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_SUB_EVT_STATE_TYPE")]
    public class SubEventStateTypeModel : BaseModel
    {        
        [Column("NAME")]
        public string? Name { get; set; }
        [Column("DESCR")]
        public string? Description { get; set; }

        [Column("EVT_STATE_ID")]
        public Guid? EventStateTypeId { get; set; }

        [ForeignKey("EventStateTypeId")]
        public virtual EventStateTypeModel EventStateType { get; set; }

        [Column("IS_RELEASED")]
        public bool IsReleased { get; set; }

        [Column("IS_UPDATED")]
        public bool IsUpdated { get; set; }

        [Column("START_DT")]
        public DateTime? StartDate { get; set; }

        [Column("END_DT")]
        public DateTime? EndDate { get; set; }

        [Column("VALUE")]
        public int Value { get; set; }

    }
}