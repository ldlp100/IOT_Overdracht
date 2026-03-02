using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class UnitTypeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Label { get; set; }
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

        public UnitTypeViewModel()
        {
        }
        public UnitTypeViewModel(UnitTypeModel model)
        {

            Id = model.Id;
            Name = model.Name;
            Description = model.Description;
            Label = model.Label;
            Created = model.Created;
            Updated = model.Updated;
            CreatedBy = model.CreatedBy.Username;
            UpdatedBy = model.UpdatedBy.Username;
            CreatedById = model.CreatedById;
            UpdatedById = model.UpdatedById;
        }
        public UnitTypeModel Create(AppUserModel user)
        {
            UnitTypeModel model = new UnitTypeModel();
            model.Name = Name.Trim();
            model.Label = Label.Trim();
            model.Description = Description;
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            model.CreatedById = user.Id;
            model.UpdatedById = user.Id;
            return model;
        }
        public UnitTypeModel Update(UnitTypeModel model, AppUserModel user)
        {
            model.Name = Name.Trim();
            model.Description = Description;
            model.Label = Label.Trim();
            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }
    }
}