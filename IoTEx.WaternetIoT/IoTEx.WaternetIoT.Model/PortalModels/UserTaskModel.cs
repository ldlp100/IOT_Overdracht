using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_USER_TASK")]
    public class UserTaskModel : BaseModel
    {
        public enum TaskTypeEnum { DATA_EXTRACT=0 }
        public enum TaskStateEnum { INITIATED=0, RUNNING=1, COMPLETED=2, CANCELLED=3,FAILED=4 }
        [Column("NAME")]
        public string? Name { get; set; }
        [Column("TOKEN")]
        public Guid Token { get; set; }
        [Column("DES")]
        public string? Description { get; set; }
        [Column("DEVICE_ID")]
        public Guid? DeviceId { get; set; }
        [Column("GROUP_ID")]
        public Guid? GroupId { get; set; }

        [Column("TASK_TYPE")]
        public TaskTypeEnum TaskType { get; set; }

        [Column("START_DT")]
        public DateTime? StartDate { get; set; }

        [Column("END_DT")]
        public DateTime? EndDate { get; set; }

        [Column("STATE")]
        public TaskStateEnum State { get; set; }

        [Column("PROGRESS")]
        public int Progress { get; set; }
        [Column("MESSAGE")]
        public string? Message { get; set; }

        [Column("HREF")]
        public string? HREF { get; set; }

        [Column("USER_ID")]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual AppUserModel User { get; set; }

    }
}