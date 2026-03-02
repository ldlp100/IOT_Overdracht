using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class SupplierViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? TelNumber { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid? UpdatedById { get; set; }

        public static Dictionary<string, string> DefineMapper()
        {
            Dictionary<string, string> mapper = new Dictionary<string, string>();
            mapper.Add("CreatedBy", "CreatedBy.Username");
            mapper.Add("UpdatedBy", "UpdatedBy.Username");
            return mapper;
        }

        public SupplierViewModel()
        {
        }
        public SupplierViewModel(SupplierModel model)
        {
            Id = model.Id;
            Name = model.Name;
            TelNumber = model.TelNumber;
            Description = model.Description;
            Created = model.Created;
            Updated = model.Updated;
            CreatedBy = model.CreatedBy.Username;
            UpdatedBy = model.UpdatedBy.Username;
            CreatedById = model.CreatedById;
            UpdatedById = model.UpdatedById;
        }
        public SupplierModel Create(AppUserModel user)
        {
            SupplierModel model = new SupplierModel();
            model.Name = Name;
            model.TelNumber = TelNumber;
            model.Description = Description;
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            model.CreatedById = user.Id;
            model.UpdatedById = user.Id;
            return model;
        }
        public SupplierModel Update(SupplierModel model, AppUserModel user)
        {
            model.Name = Name;
            model.TelNumber = TelNumber;
            model.Description = Description;
            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }
    }
}