
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_APP_USER")]
    public class AppUserModel 
    {
        public enum RoleEnum { Admin, Contributor, Reader }

        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Column("USER_NAME")]
        public string Username { get; set; }
        [Column("ROLE")]
        public RoleEnum Role { get; set; }
        public AppUserModel()
        {
            Username = "";
        }
        
    }
}