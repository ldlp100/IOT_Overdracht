using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using IoTEx.WaternetIoT.Model.PortalModels;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class Device2ProjectViewModel
    {
        public Guid Id { get; set; }
        public Guid? ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public Guid? DeviceId { get; set; }
        public string? DeviceName { get; set; }
        public string? AssetUID { get; set; }
        public bool IsActive { get; set; }
        public DateTime? InstalledDate { get; set; }
        public string? DeviceTypeName { get; set; }
        public Guid? DeviceTypeId { get; set; }
        public string? DeviceFirmName { get; set; }
        public Guid? DeviceFirmId { get; set; }
        public string? DeviceBatchName { get; set; }
        public Guid? DeviceBatchId { get; set; }
        public DateTime? LastMessage { get; set; }
        public double DeviceLat { get; set; }
        public double DeviceLong { get; set; }

        public Device2ProjectViewModel()
        {

        }
        public Device2ProjectViewModel(Device2ProjectModel model)
        {
            Id = model.Id;
            ProjectId = (model!=null)? model.Project.Id: Guid.Empty;
            ProjectName = (model.Project != null) ? model.Project.Name : "";
            DeviceId = (model.Device != null) ? model.Device.Id : Guid.Empty;
            DeviceName = (model.Device != null) ? model.Device.Name : "";
            AssetUID = (model.Device != null) ? model.Device.AssetUID : "";
            IsActive = (model.Device != null) ? model.Device.IsActive : false;
            InstalledDate = (model.Device != null) ? model.Device.InstalledDate : DateTime.MinValue;
            DeviceTypeName = (model.Device != null) ? model.Device.DeviceBatch.DeviceType.Name : "";
            DeviceTypeId = (model.Device != null) ? model.Device.DeviceBatch.DeviceType.Id :Guid.Empty;
            DeviceFirmName = (model.Device != null) ? model.Device.DeviceTypeFirmware.Name : "";
            DeviceBatchName = (model.Device != null) ? model.Device.DeviceBatch.Name : "";
            DeviceBatchId = (model.Device != null) ? model.Device.DeviceBatch.Id : Guid.Empty;
            LastMessage = (model.Device != null) ? model.Device.LastMessage : null;
            DeviceLat = (model.Device != null) ? model.Device.Lat : 0;
            DeviceLong = (model.Device != null) ? model.Device.Long : 0;
        }
        public static Dictionary<string, string> DefineMapper()
        {
            Dictionary<string, string> mapper = new Dictionary<string, string>();
            mapper.Add("ProjectName", "Project.Name");
            mapper.Add("DeviceName", "Device.Name");
            mapper.Add("AssetUID", "Device.AssetUID");
            mapper.Add("IsActive", "Device.IsActive");
            mapper.Add("InstalledDate", "Device.InstalledDate");
            mapper.Add("LastMessage", "Device.LastMessage");
            mapper.Add("DeviceTypeName", "Device.DeviceBatch.DeviceType.Name");
            mapper.Add("DeviceFirmName", "Device.DeviceTypeFirmware.Name");
            mapper.Add("DeviceBatchName", "Device.DeviceBatch.Name");
            mapper.Add("DeviceLat", "Device.Lat");
            mapper.Add("DeviceLong", "Device.Long");
            return mapper;
        }
        public Device2ProjectModel Create(AppUserModel user)
        {
            Device2ProjectModel model = new Device2ProjectModel();
            model.ProjectId = ProjectId;
            model.DeviceId = DeviceId;
            
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            model.CreatedById = user.Id;
            model.UpdatedById = user.Id;
            return model;
        }
        public Device2ProjectModel Update(Device2ProjectModel model, AppUserModel user)
        {            
            model.ProjectId = ProjectId;            
            model.DeviceId = DeviceId;
            
            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }
    }
}   