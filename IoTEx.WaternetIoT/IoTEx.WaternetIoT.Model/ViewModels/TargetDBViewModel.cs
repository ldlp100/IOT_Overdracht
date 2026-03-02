using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class TargetDBViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ConnectionString { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid? UpdatedById { get; set; }
        

        public static Dictionary<string, string> DefineMapper()
        {
            Dictionary<string, string> mapper = new Dictionary<string, string>();
            
            return mapper; 
        }
        public TargetDBViewModel()
        {
            
        }
        public TargetDBViewModel(TargetDBModel targetDB)
        {
            
            Id = targetDB.Id;
            Name = targetDB.Name;
            Description = targetDB.Description;
            ConnectionString = targetDB.ConnectionString;

            Created = targetDB.Created;
            Updated = targetDB.Updated;
            CreatedBy = targetDB.CreatedBy.Username;
            UpdatedBy = targetDB.UpdatedBy.Username;
            CreatedById = targetDB.CreatedById;
            UpdatedById = targetDB.UpdatedById;
        }
        public TargetDBModel Create(AppUserModel user)
        {
            TargetDBModel model = new TargetDBModel();
            model.Name = Name;
            model.Description = Description;
            model.ConnectionString = ConnectionString;
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            model.CreatedById = user.Id;
            model.UpdatedById = user.Id;
            return model;
        }
        public TargetDBModel Update(TargetDBModel model, AppUserModel user)
        {
            model.Name = Name;
            model.Description = Description;
            model.ConnectionString = ConnectionString;
            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }
    }
    
}