using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_USER2GROUP")]
    public class User2ProjectModel : BaseModel
    {
        [Column("USER_ID")]
        public Guid UserId { get; set; }
        public virtual AppUserModel User { get; set; }

        [Column("GROUP_ID")]
        public Guid ProjectId { get; set; }
        public virtual ProjectModel Project { get; set; }

        [Column("ROLE")]
        public AppUserModel.RoleEnum Role { get; set; }

    }
}