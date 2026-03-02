using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class User2ServiceViewModel
    {
        public Guid Id { get; set; }
        public Guid ServiceId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string ServiceName { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid? UpdatedById { get; set; }

        public static Dictionary<string, string> DefineMapper()
        {
            Dictionary<string, string> mapper = new Dictionary<string, string>();
            mapper.Add("UserName", "UserName.Name");
            mapper.Add("ServiceName", "ServiceName.Name");
            return mapper;
        }

        public User2ServiceViewModel()
        {

        }

        public User2ServiceViewModel(User2ServiceModel model)
        {
            Id = model.Id;
            ServiceId = model.ServiceId;
            UserId = model.UserId;
            ServiceName = (model.Service != null) ? model.Service.Name : "";
            UserName = (model.User != null) ? model.User.Username : "";
            Created = model.Created;
            Updated = model.Updated;
            CreatedBy = model.CreatedBy.Username;
            UpdatedBy = model.UpdatedBy.Username;
            CreatedById = model.CreatedById;
            UpdatedById = model.UpdatedById;
        }

        public User2ServiceModel Create(AppUserModel user)
        {
            User2ServiceModel model = new User2ServiceModel();
            model.ServiceId = ServiceId;
            model.UserId = UserId;
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            model.CreatedById = user.Id;
            model.UpdatedById = user.Id;
            return model;
        }

        public User2ServiceModel Update(User2ServiceModel model, AppUserModel user)
        {
            model.ServiceId = ServiceId;
            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }
    }
}