using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_DEVICETYPE_FIRMWARE")]
    public class DeviceTypeFirmwareModel : BaseModel
    {
        
        [Column("NAME")]
        public string? Name { get; set; }
        [Column("DESCR")]
        public string? Description { get; set; }
        
        [Column("IS_USED")]
        public bool IsUsed { get; set; }
                
        [Column("PARSER_ID")]
        public Guid? ParserId { get; set; }
        [ForeignKey("ParserId")]
        public virtual ParserModel Parser { get; set; }

        [Column("DEVICETYPE_ID")]
        public Guid? DeviceTypeId { get; set; }
        [ForeignKey("DeviceTypeId")]
        public virtual DeviceTypeModel DeviceType { get; set; }

        [Column("IS_CONFIG")]
        public bool IsConfigurable { get; set; }

    }
}