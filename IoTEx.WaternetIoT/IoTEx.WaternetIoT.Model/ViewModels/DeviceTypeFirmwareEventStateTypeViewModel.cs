using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class DeviceTypeFirmwareEventStateTypeViewModel
    {
        public Guid Id { get; set; }
        public Guid? DeviceTypeId { get; set; }
        public string? DeviceTypeName { get; set; }
        public Guid? DeviceTypeFirmwareId { get; set; }
        public string? DeviceTypeFirmwareName { get; set; }
        public string? Description { get; set; }
        public string Name { get; set; }
        public Guid? EventStateTypeId { get; set; }
        public string? EventStateTypeName { get; set; }
        public bool IsAlert { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid? UpdatedById { get; set; }

        public static Dictionary<string, string> DefineMapper()
        {
            Dictionary<string, string> mapper = new Dictionary<string, string>();
            mapper.Add("DeviceTypeFirmwareName", "DeviceTypeFirmware.Name");
            return mapper;
        }

        public DeviceTypeFirmwareEventStateTypeViewModel()
        {
        }
        public DeviceTypeFirmwareEventStateTypeViewModel(DeviceTypeFirmwareEventStateTypeModel model)
        {
            Id = model.Id;
            DeviceTypeFirmwareId = model.DeviceTypeFirmwareId;
            DeviceTypeFirmwareName = (model.DeviceTypeFirmware == null) ? "" : model.DeviceTypeFirmware.Name;

            Name = model.Name;
            Description = model.Description;
            //EventStateTypeId = model.EventStateTypeId;
            //EventStateTypeName = (model.EventStateType == null) ? "" : model.EventStateType.Name;
            IsAlert = model.IsAlert;
            Created = model.Created;
            Updated = model.Updated;
            CreatedBy = model.CreatedBy.Username;
            UpdatedBy = model.UpdatedBy.Username;
            CreatedById = model.CreatedById;
            UpdatedById = model.UpdatedById;
        }
        public DeviceTypeFirmwareEventStateTypeModel Create(AppUserModel user)
        {
            DeviceTypeFirmwareEventStateTypeModel model = new DeviceTypeFirmwareEventStateTypeModel();
            model.DeviceTypeFirmwareId = DeviceTypeFirmwareId;
            model.Name = Name.Trim();
            model.Description = Description;
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            model.CreatedById = user.Id;
            model.UpdatedById = user.Id;
            return model;
        }
        public DeviceTypeFirmwareEventStateTypeModel Update(DeviceTypeFirmwareEventStateTypeModel model, AppUserModel user)
        {
            model.Name = Name.Trim();
            model.Description = Description;
            model.DeviceTypeFirmwareId = DeviceTypeFirmwareId;
            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }
    }
}