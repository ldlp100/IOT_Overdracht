using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class DeviceTypeEventState2SubStateTypeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public string Description { get; set; }
        public bool IsReleased { get; set; }
        public bool IsUpdated { get; set; }
        public Guid DeviceTypeEventStateTypeId { get; set; }
        public string? DeviceTypeEventStateTypeName { get; set; }
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
            mapper.Add("DeviceTypeEventStateTypeName", "DeviceTypeEventStateType.Name");
            return mapper;
        }

        public DeviceTypeEventState2SubStateTypeViewModel()
        {
        }
        public DeviceTypeEventState2SubStateTypeViewModel(DeviceTypeEventState2SubStateTypeModel model)
        {
            
            Id = model.Id;
            Name = model.Name;
            Value = model.Value;
            IsReleased = model.IsReleased;
            IsUpdated = model.IsUpdated;
            Description = model.Description;
            DeviceTypeEventStateTypeId = model.DeviceTypeEventStateTypeId;
            DeviceTypeEventStateTypeName = (model.DeviceTypeFirmwareEventStateType == null) ? "" : model.DeviceTypeFirmwareEventStateType.Name;
            EndDate = model.EndDate;
            StartDate = model.StartDate;
            Created = model.Created;
            Updated = model.Updated;
            CreatedBy = model.CreatedBy.Username;
            UpdatedBy = model.UpdatedBy.Username;
            CreatedById = model.CreatedById;
            UpdatedById = model.UpdatedById;
        }
        public DeviceTypeEventState2SubStateTypeModel Create(AppUserModel user)
        {
            DeviceTypeEventState2SubStateTypeModel model = new DeviceTypeEventState2SubStateTypeModel();
            model.Name = Name;
            model.Value = Value;
            model.Description = Description;
            model.DeviceTypeEventStateTypeId = DeviceTypeEventStateTypeId;
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            model.CreatedById = user.Id;
            model.UpdatedById = user.Id;
            return model;
        }
        public DeviceTypeEventState2SubStateTypeModel Update(DeviceTypeEventState2SubStateTypeModel model, AppUserModel user)
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