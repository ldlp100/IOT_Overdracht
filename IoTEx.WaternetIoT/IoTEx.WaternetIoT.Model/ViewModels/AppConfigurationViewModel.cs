using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class AppConfigurationViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Value { get; set; }
        public bool IsDeletable { get; set; }
        public bool IsModifiable { get; set; }
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

        public AppConfigurationViewModel()
        {
        }
        public AppConfigurationViewModel(AppConfigurationModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Description = model.Description;
            Value = model.Value;
            IsDeletable = model.IsDeletable;
            IsModifiable = model.IsModifiable;
            Created = model.Created;
            Updated = model.Updated;
            CreatedBy = model.CreatedBy.Username;
            UpdatedBy = model.UpdatedBy.Username;
            CreatedById = model.CreatedById;
            UpdatedById = model.UpdatedById;
        }
        public AppConfigurationModel Create(AppUserModel user)
        {
            AppConfigurationModel model = new AppConfigurationModel();
            model.Name = Name.Trim();
            model.Description = Description;
            model.Value = Value;
            model.IsModifiable = IsModifiable;
            model.IsDeletable = IsDeletable;
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            model.CreatedById = user.Id;
            model.UpdatedById = user.Id;
            return model;
        }
        public AppConfigurationModel Update(AppConfigurationModel model, AppUserModel user)
        {
            model.Name = Name.Trim();
            model.Description = Description;
            model.Value = Value;
            model.IsModifiable = IsModifiable;
            model.IsDeletable = IsDeletable;
            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }
    }
}