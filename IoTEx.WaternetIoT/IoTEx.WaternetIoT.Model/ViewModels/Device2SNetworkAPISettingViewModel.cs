using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class Device2SNetworkAPISettingViewModel
    {
        public Guid Id { get; set; }
        public Guid SettingId { get; set; }
        public string? SettingName { get; set; }
        
        public Guid? DeviceId { get; set; }
        public string? DeviceName { get; set; }        
        public string Value { get; set; }
       

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
            mapper.Add("SettingName", "Setting.Name");
            return mapper;
        }

        public Device2SNetworkAPISettingViewModel()
        {
        }
        public Device2SNetworkAPISettingViewModel(Device2SNetworkAPISettingModel model)
        {
            Id = model.Id;
            DeviceId = model.DeviceId;
            DeviceName = (model.Device!=null)? model.Device.Name:"";
            SettingId = model.SettingId;
            SettingName = (model.Setting != null) ? model.Setting.Name : "";
            Value = model.Value;
            Created = model.Created;
            Updated = model.Updated;
            CreatedBy = model.CreatedBy.Username;
            UpdatedBy = model.UpdatedBy.Username;
            CreatedById = model.CreatedById;
            UpdatedById = model.UpdatedById;
        }
        public Device2SNetworkAPISettingModel Create(AppUserModel user)
        {
            Device2SNetworkAPISettingModel model = new Device2SNetworkAPISettingModel();

            model.DeviceId = DeviceId;
            model.SettingId = SettingId;
            model.Value = Value;

            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            model.CreatedById = user.Id;
            model.UpdatedById = user.Id;
            return model;
        }
        public Device2SNetworkAPISettingModel Update(Device2SNetworkAPISettingModel model, AppUserModel user)
        {
            model.DeviceId = DeviceId;
            model.SettingId = SettingId;
            model.Value = Value;

            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }

    }
}