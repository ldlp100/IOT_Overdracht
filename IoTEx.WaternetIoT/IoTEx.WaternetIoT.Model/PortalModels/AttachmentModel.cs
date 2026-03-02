using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_ATT")]
    public class AttachmentModel : BaseModel
    {
        public enum AttachmentTypeEnum { OBJ_PHOTO=1, PHOTO = 2, OBJ_VIDEO = 3,VIDEO=4, USER_MANUAL=5, INSTALLATION_MANUAL=6 , SYSTEM_DOCUMENT=7, DOCUMENT=8 }
        public enum ObjectTypeEnum{ PROJECT=1, DEVICETYPE=2, DEVICE = 3 , FIRMWARE=4}
        [Column("NAME")]
        public string Name { get; set; }

        [Column("DESC")]
        public string? Description { get; set; }

        [Column("URL")]
        public string? URL { get; set; }

        [Column("OBJECT_ID")]
        public Guid ObjectId { get; set; }

        [Column("OBJECT_TYPE_ID")]
        public ObjectTypeEnum ObjectType { get; set; }

        [Column("ATTACH_TYPE")]
        public AttachmentTypeEnum AttachmentType { get; set; }

        [Column("SIZE")]
        public int Size { get; set; }

    }
    
}