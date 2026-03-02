using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class DeviceConfigurationViewModel
    {
        public Guid Id { get; set; }
        public Guid DeviceTypeFirmwareConfigurationId { get; set; }
        public string? DeviceTypeFirmwareConfigurationName { get; set; }

        public string? ConfigurationDesc { get; set; }
        public Guid? DeviceId { get; set; }
        public string? DeviceName { get; set; }        
        public string? Value { get; set; }
       

        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid? UpdatedById { get; set; }

        public static Dictionary<string, string> DefineMapper()
        {
            Dictionary<string, string> mapper = new Dictionary<string, string>();
            mapper.Add("DeviceName", "Device.Name");
            return mapper;
        }

        public DeviceConfigurationViewModel()
        {
        }
        public DeviceConfigurationViewModel(DeviceTypeFirmwareConfigurationModel model)
        {
            Id = new Guid("11111111-1111-1111-1111-111111111111");
            //DeviceId = model.DeviceId;
            //DeviceName = (model.Device != null) ? model.Device.Name : "";
            DeviceTypeFirmwareConfigurationId = model.Id;
            DeviceTypeFirmwareConfigurationName = (model.Name != null) ? model.Name : "";
            ConfigurationDesc = (model.Name != null) ? model.Description : "";
            Value = model.DefaultValue;
            Created = model.Created;
            Updated = model.Updated;
            CreatedBy = model.CreatedBy.Username;
            UpdatedBy = model.UpdatedBy.Username;
            CreatedById = model.CreatedById;
            UpdatedById = model.UpdatedById;
        }
        public DeviceConfigurationViewModel(DeviceConfigurationModel model)
        {
            Id = model.Id;
            DeviceId = model.DeviceId;
            DeviceName = (model.Device!=null)? model.Device.Name:"";
            DeviceTypeFirmwareConfigurationId = model.DeviceTypeFirmwareConfigurationId;
            DeviceTypeFirmwareConfigurationName = (model.DeviceTypeFirmwareConfiguration != null) ? model.DeviceTypeFirmwareConfiguration.Name : "";
            ConfigurationDesc = (model.DeviceTypeFirmwareConfiguration != null) ? model.DeviceTypeFirmwareConfiguration.Description : "";
            Value = model.Value;
            Created = model.Created;
            Updated = model.Updated;
            CreatedBy = model.CreatedBy.Username;
            UpdatedBy = model.UpdatedBy.Username;
            CreatedById = model.CreatedById;
            UpdatedById = model.UpdatedById;
        }
        public DeviceConfigurationModel Create(AppUserModel user)
        {
            DeviceConfigurationModel model = new DeviceConfigurationModel();

            model.DeviceId = DeviceId;
            model.DeviceTypeFirmwareConfigurationId = DeviceTypeFirmwareConfigurationId;
            model.Value = Value;

            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            model.CreatedById = user.Id;
            model.UpdatedById = user.Id;
            return model;
        }
        public DeviceConfigurationModel Update(DeviceConfigurationModel model, AppUserModel user)
        {
            model.DeviceId = DeviceId;
            model.DeviceTypeFirmwareConfigurationId = DeviceTypeFirmwareConfigurationId;
            model.Value = Value;

            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }

    }
}