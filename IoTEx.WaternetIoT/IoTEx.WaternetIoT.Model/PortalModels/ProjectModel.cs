using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_GROUP")]
    public class ProjectModel : BaseModel
    {
        public enum AccessEnum { Private=0, Organization=1, Public=2}
        [Column("NAME")]
        public string? Name { get; set; }
        [Column("TARGETDB")]
        public string? TargetDBString { get; set; }

        [Column("DESCR")]
        public string? Description { get; set; }

        [Column("LAT")]
        public double Latitude { get; set; }
        [Column("LNG")]
        public double Longitude { get; set; }
        [Column("ISACTIVE")]
        public bool IsActive { get; set; }
        //[Column("ISPROJECT")]
        //public bool IsProject { get; set; }
        [Column("ACCESS_LEVEL")]
        public AccessEnum AccessLevel { get; set; }
        [Column("BEG_DATE")]
        public DateTime? BeginDate { get; set; }
        [Column("END_DATE")]
        public DateTime? EndDate { get; set; }

        //[Column("PARENT_GROUP_ID")]
        //public Guid? ParentGroupId { get; set; }

        //[ForeignKey("ParentGroupId")]
        //public virtual ProjectModel ParentGroup { get; set; }

        [Column("TARGETDB_ID")]
        public Guid? TargetDBId { get; set; }

        public virtual TargetDBModel TargetDB { get; set; }

    }
}