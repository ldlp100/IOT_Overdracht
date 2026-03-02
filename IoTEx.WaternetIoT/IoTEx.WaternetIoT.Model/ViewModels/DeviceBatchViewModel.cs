using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class DeviceBatchViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid DeviceTypeId { get; set; }
        public string? DeviceTypeName { get; set; }
        public Guid? GroupId { get; set; }
        public string? GroupName { get; set; }
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
            mapper.Add("GroupName", "Group.Name");
            return mapper;
        }
        public DeviceBatchViewModel()
        {
            
        }
        public DeviceBatchViewModel(DeviceBatchModel batch)
        {
            
            Id = batch.Id;
            Name = batch.Name;
            DeviceTypeId = batch.DeviceTypeId;
            DeviceTypeName = (batch.DeviceType == null) ? "" : batch.DeviceType.Name;
            GroupId = batch.GroupId;
            GroupName = (batch.Group == null) ? "" : batch.Group.Name;
            Created = batch.Created;
            Updated = batch.Updated;
            CreatedBy = batch.CreatedBy.Username;
            UpdatedBy = batch.UpdatedBy.Username;
            CreatedById = batch.CreatedById;
            UpdatedById = batch.UpdatedById;
        }
        public DeviceBatchModel Create(AppUserModel user)
        {
            DeviceBatchModel model = new DeviceBatchModel();
            model.Name = Name;
            model.DeviceTypeId = DeviceTypeId;
            model.GroupId = GroupId;
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            model.CreatedById = user.Id;
            model.UpdatedById = user.Id;
            return model;
        }
        public DeviceBatchModel Update(DeviceBatchModel model, AppUserModel user)
        {
            model.Name = Name;
            model.DeviceTypeId = DeviceTypeId;
            model.GroupId = GroupId;
            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }
    }
    
}