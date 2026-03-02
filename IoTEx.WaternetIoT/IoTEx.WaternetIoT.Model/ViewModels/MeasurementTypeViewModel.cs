using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;
using static IoTEx.WaternetIoT.Model.PortalModels.MeasurementTypeModel;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class MeasurementTypeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UnitTypeId { get; set; }
        public string UnitTypeName { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid? UpdatedById { get; set; }

        public static Dictionary<string, string> DefineMapper()
        {
            Dictionary<string, string> mapper = new Dictionary<string, string>();
            mapper.Add("UnitTypeName", "UnitType.Name");
            return mapper;
        }

        public MeasurementTypeViewModel()
        {
        }
        public MeasurementTypeViewModel(MeasurementTypeModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Description = model.Description;
            UnitTypeId = model.UnitTypeId;
            UnitTypeName = (model.UnitType == null) ? "" : model.UnitType.Name;
            Created = model.Created;
            Updated = model.Updated;
            CreatedBy = model.CreatedBy.Username;
            UpdatedBy = model.UpdatedBy.Username;
            CreatedById = model.CreatedById;
            UpdatedById = model.UpdatedById;
        }
        public MeasurementTypeModel Create(AppUserModel user)
        {
            MeasurementTypeModel model = new MeasurementTypeModel();
            model.Name = Name;
            model.Description = Description;
            model.UnitTypeId = UnitTypeId;
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            model.CreatedById = user.Id;
            model.UpdatedById = user.Id;
            return model;
        }
        public MeasurementTypeModel Update(MeasurementTypeModel model, AppUserModel user)
        {
            model.Name = Name;
            model.Description = Description;
            model.UnitTypeId = UnitTypeId;
            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }
    }
}