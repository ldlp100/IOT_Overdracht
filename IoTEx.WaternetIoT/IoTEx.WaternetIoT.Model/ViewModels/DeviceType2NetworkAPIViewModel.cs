using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class DeviceType2NetworkAPIViewModel
    {
        public Guid Id { get; set; }
        public Guid DeviceTypeId { get; set; }
        public string? DeviceTypeName { get; set; }
               
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
            mapper.Add("DeviceTypeName", "DeviceType.Name");
            return mapper;
        }

        public DeviceType2NetworkAPIViewModel()
        {
        }
        public DeviceType2NetworkAPIViewModel(DeviceType2NetworkAPIModel model)
        {
            Id = model.Id;

            DeviceTypeId = model.DeviceTypeId;
            NetworkAPIId = model.NetworkAPIId;
            DeviceTypeName = (model.DeviceType!=null)?model.DeviceType.Name:"";
            NetworkAPIName = (model.NetworkAPI != null) ? model.NetworkAPI.Name : "";
            Created = model.Created;
            Updated = model.Updated;
            CreatedBy = model.CreatedBy.Username;
            UpdatedBy = model.UpdatedBy.Username;
            CreatedById = model.CreatedById;
            UpdatedById = model.UpdatedById;
        }
        public DeviceType2NetworkAPIModel Create(AppUserModel user)
        {
            DeviceType2NetworkAPIModel model = new DeviceType2NetworkAPIModel();
            model.DeviceTypeId = DeviceTypeId;
            model.NetworkAPIId = NetworkAPIId;
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            model.CreatedById = user.Id;
            model.UpdatedById = user.Id;
            return model;
        }
        public DeviceType2NetworkAPIModel Update(DeviceType2NetworkAPIModel model, AppUserModel user)
        {            
            model.DeviceTypeId = DeviceTypeId;
            //cannot change after creation
            //model.NetworkProviderId = NetworkProviderId;
            model.NetworkAPIId = NetworkAPIId;
            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }

    }
}