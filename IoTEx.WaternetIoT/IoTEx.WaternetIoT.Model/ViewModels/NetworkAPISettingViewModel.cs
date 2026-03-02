using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class NetworkAPISettingViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Value { get; set; }
        public string? SecretId { get; set; }
        public bool IsSecret { get; set; }
        public bool IsDeviceInfo { get; set; }
        public Guid NetworkAPIId { get; set; }
        public string? NetworkAPIName { get; set; }
        
               

        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid? UpdatedById { get; set; }

        public static Dictionary<string, string> DefineMapper()
        {
            Dictionary<string, string> mapper = new Dictionary<string, string>();
            mapper.Add("NetworkAPIName", "NetworkAPI.Name");
            return mapper;
        }

        public NetworkAPISettingViewModel()
        {
        }
        public NetworkAPISettingViewModel(NetworkAPISettingModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Description = model.Description;
            Value = model.Value;
            IsSecret = model.IsSecret;
            IsDeviceInfo = model.IsDeviceInfo;
            SecretId = model.SecretId;
            NetworkAPIId = model.NetworkAPIId;
            NetworkAPIName = (model.NetworkAPI!= null)?model.NetworkAPI.Name:"";
            Created = model.Created;
            Updated = model.Updated;
            CreatedBy = model.CreatedBy.Username;
            UpdatedBy = model.UpdatedBy.Username;
            CreatedById = model.CreatedById;
            UpdatedById = model.UpdatedById;
        }
        public NetworkAPISettingModel Create(AppUserModel user)
        {
            NetworkAPISettingModel model = new NetworkAPISettingModel();
            model.Name = Name.Trim();
            model.Description = Description;
            model.Value = Value;
            model.IsSecret = IsSecret;
            model.IsDeviceInfo = IsDeviceInfo;
            model.SecretId = SecretId;
            model.NetworkAPIId = NetworkAPIId;            
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            model.CreatedById = user.Id;
            model.UpdatedById = user.Id;
            return model;
        }
        public NetworkAPISettingModel Update(NetworkAPISettingModel model, AppUserModel user)
        {
            model.Name = Name.Trim();
            model.Description = Description;
            model.Value = Value;
            model.IsSecret = IsSecret;
            model.IsDeviceInfo = IsDeviceInfo;
            model.SecretId = SecretId;
            model.NetworkAPIId = NetworkAPIId;
            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }

    }
}