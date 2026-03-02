using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class AppUserViewModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public AppUserModel.RoleEnum Role { get; set; }
        

        public static Dictionary<string, string> DefineMapper()
        {
            Dictionary<string, string> mapper = new Dictionary<string, string>();
            return mapper;
        }

        public AppUserViewModel()
        {
        }
        public AppUserViewModel(AppUserModel model)
        {
            Id = model.Id;
            Username = model.Username;
            Role = model.Role;            
        }
        public AppUserModel Create(AppUserModel user)
        {
            AppUserModel model = new AppUserModel();
            model.Username = Username.Trim();
            model.Role = Role;            
            return model;
        }
        public AppUserModel Update(AppUserModel model, AppUserModel user)
        {
            model.Username = Username.Trim();
            model.Role = user.Role;            
            return model;
        }
    }
}