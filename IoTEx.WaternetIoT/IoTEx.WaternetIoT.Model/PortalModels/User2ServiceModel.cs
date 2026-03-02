using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_USER2SERVICE")]
    public class User2ServiceModel : BaseModel
    {
        [Column("USER_ID")]
        public Guid UserId { get; set; }
        public virtual AppUserModel User { get; set; }

        [Column("SERVICE_ID")]
        public Guid ServiceId { get; set; }
        public virtual ServiceModel Service { get; set; }
    }
}