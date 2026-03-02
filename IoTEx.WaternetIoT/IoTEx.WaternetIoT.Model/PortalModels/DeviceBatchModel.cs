using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_BATCH_DEVICE")]
    public class DeviceBatchModel : BaseModel
    {
        
        [Column("NAME")]
        public string? Name { get; set; }
        
        [Column("ISREGISTERED")]
        public bool IsRegistered { get; set; }
                
        [Column("DEVICE_TYPE_ID")]
        public Guid DeviceTypeId { get; set; }
        [ForeignKey("DeviceTypeId")]
        public virtual DeviceTypeModel? DeviceType { get; set; }

        [Column("GROUP_ID")]
        public Guid? GroupId { get; set; }
        [ForeignKey("GroupId")]
        public virtual ProjectModel? Group { get; set; }

        

    }

    
}