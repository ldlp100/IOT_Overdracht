using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_DEVTYPE2NETWORK_API")]
    public class DeviceType2NetworkAPIModel : BaseModel
    {
        [Column("DEVICETYPE_ID")]
        public Guid DeviceTypeId { get; set; }
        public virtual DeviceTypeModel DeviceType { get; set; }

        [Column("NETWORK_API_ID")]
        public Guid NetworkAPIId { get; set; }
        public virtual NetworkAPIModel NetworkAPI { get; set; }

    }
}