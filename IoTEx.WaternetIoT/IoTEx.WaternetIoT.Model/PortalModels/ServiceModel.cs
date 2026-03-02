using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_SERVICE")]
    public class ServiceModel: BaseModel
    {
        [Column("NAME")]
        public string? Name { get; set; }
        [Column("DESCRIPTION")]
        public string? Description { get; set; }
        [Column("IS_RUNNING")]
        public bool IsRunning { get; set; }
        [Column("START_AUT_URL")]
        public string? StartAutomationUrl { get; set; }
        [Column("STOP_AUT_URL")]
        public string? StopAutomationUrl { get; set; }

        //public virtual ICollection<User2ServiceModel> User2Services { get; set; }
    }
}