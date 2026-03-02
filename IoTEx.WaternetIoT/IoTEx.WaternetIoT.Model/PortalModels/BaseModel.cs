using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace IoTEx.WaternetIoT.Model.PortalModels
{
    public class BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public Guid Id { get; set; }
        [Column("CREATED")]
        public DateTime? Created { get; set; }
        [Column("UPDATED")]
        public DateTime? Updated { get; set; }

        [Column("CREATED_BY")]
        public Guid? CreatedById { get; set; }
        [ForeignKey("CreatedById")]
        public virtual AppUserModel? CreatedBy { get; set; }
        [Column("UPDATED_BY")]
        public Guid? UpdatedById { get; set; }
        [ForeignKey("UpdatedById")]
        public virtual AppUserModel? UpdatedBy { get; set; }
        
        public BaseModel()
        {
            Created = DateTime.Now;
            Updated = DateTime.Now;
        }
    }
}