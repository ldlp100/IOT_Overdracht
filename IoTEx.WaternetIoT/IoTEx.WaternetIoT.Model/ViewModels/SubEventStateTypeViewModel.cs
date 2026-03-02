using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class SubEventStateTypeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
        public bool IsReleased { get; set; }
        public bool IsUpdated { get; set; }
        public Guid? EventStateTypeId { get; set; }
        public string EventStateTypeName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid? UpdatedById { get; set; }

        public static Dictionary<string, string> DefineMapper()
        {
            Dictionary<string, string> mapper = new Dictionary<string, string>();
            mapper.Add("DeviceTypeName", "DeviceType.Name");
            mapper.Add("DepartmentName", "Department.Name");
            return mapper;
        }

        public SubEventStateTypeViewModel()
        {
        }
        public SubEventStateTypeViewModel(SubEventStateTypeModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Value = model.Value;
            IsReleased = model.IsReleased;
            IsUpdated = model.IsUpdated;
            Description = model.Description;
            EventStateTypeId = model.EventStateTypeId;
            EventStateTypeName = (model.EventStateType == null) ? "" : model.EventStateType.Name;
            EndDate = model.EndDate;
            StartDate = model.StartDate;
            Created = model.Created;
            Updated = model.Updated;
            CreatedBy = model.CreatedBy.Username;
            UpdatedBy = model.UpdatedBy.Username;
            CreatedById = model.CreatedById;
            UpdatedById = model.UpdatedById;
        }
        public SubEventStateTypeModel Create(AppUserModel user)
        {
            SubEventStateTypeModel model = new SubEventStateTypeModel();
            model.Name = Name;
            model.Value = Value;
            model.Description = Description;
            model.EventStateTypeId = EventStateTypeId;
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            model.CreatedById = user.Id;
            model.UpdatedById = user.Id;
            return model;
        }
        public SubEventStateTypeModel Update(SubEventStateTypeModel model, AppUserModel user)
        {
            model.Name = Name;
            model.Description = Description;
            model.Value = Value;
            //model.EventStateTypeId = EventStateTypeId;
            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }
    }
}