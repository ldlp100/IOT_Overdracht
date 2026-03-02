using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class User2ProjectViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        public Guid ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public string? ProjectDescription { get; set; }
        public bool? ProjectIsActive { get; set; }
    public AppUserModel.RoleEnum Role { get; set; }

        public User2ProjectViewModel()
        {

        }
        public User2ProjectViewModel(User2ProjectModel model)
        {
            Id = model.Id;
            UserId = (model.User != null) ? model.User.Id : Guid.Empty;
            UserName = (model.User != null) ? model.User.Username : "";
            ProjectId = (model!=null)? model.Project.Id: Guid.Empty;
            ProjectName = (model?.Project != null) ? model.Project.Name : "";
            ProjectDescription = (model?.Project != null) ? model.Project.Description : "";
            ProjectIsActive = (model?.Project != null) ? model.Project.IsActive : false;
            Role = model.Role;

        }
        public static Dictionary<string, string> DefineMapper()
        {
            Dictionary<string, string> mapper = new Dictionary<string, string>();
            mapper.Add("ProjectName", "Project.Name");
            mapper.Add("ProjectDescription", "Project.Description");
            mapper.Add("ProjectIsActive", "Project.IsActive");
            mapper.Add("UserName", "User.Username");
            return mapper;
        }
        public User2ProjectModel Create(AppUserModel user)
        {
            User2ProjectModel model = new User2ProjectModel();
            model.UserId = UserId;
            model.ProjectId = ProjectId;
            model.Role = Role;
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            model.CreatedById = user.Id;
            model.UpdatedById = user.Id;
            return model;
        }
        public User2ProjectModel Update(User2ProjectModel model, AppUserModel user)
        {                       
            model.UserId = UserId;
            model.ProjectId = ProjectId; 
            model.Role = Role;
            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }
    }
}   