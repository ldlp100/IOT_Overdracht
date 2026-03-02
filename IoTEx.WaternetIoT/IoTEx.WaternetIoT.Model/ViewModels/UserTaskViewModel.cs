using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;
using static IoTEx.WaternetIoT.Model.PortalModels.UserTaskModel;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class UserTaskViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int State { get; set; }
        public int Progress { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        public string HREF { get; set; }
        public TaskTypeEnum TaskType { get; set; }
        public Guid? GroupId { get; set; }
        public Guid? DeviceId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid? UpdatedById { get; set; }

        public static Dictionary<string, string> DefineMapper()
        {
            Dictionary<string, string> mapper = new Dictionary<string, string>();
            mapper.Add("UserName", "User.Name");
            return mapper;
        }

        public UserTaskViewModel()
        {
        }
        public UserTaskViewModel(UserTaskModel model)
        {

            Id = model.Id;
            Name = model.Name;
            StartDate = model.StartDate;
            EndDate = model.EndDate;
            Progress = model.Progress;
            Message = model.Message;
            Description = model.Description;
            State = (int)model.State;
            HREF = model.HREF;
            UserId = model.UserId;
            TaskType = model.TaskType;
            GroupId = model.GroupId;
            DeviceId = model.DeviceId;
            Created = model.Created;
            Updated = model.Updated;
            CreatedBy = model.CreatedBy.Username;
            UpdatedBy = model.UpdatedBy.Username;
            CreatedById = model.CreatedById;
            UpdatedById = model.UpdatedById;
        }
     
        

        public UserTaskModel Create(AppUserModel user)
        {
            UserTaskModel model = new UserTaskModel();
            model.Name = Name;
            model.UserId = user.Id;            
            //model.StartDate = StartDate;
            //model.EndDate = EndDate;
            //model.Progress = Progress;
            //model.HREF = HREF;
            //model.TaskType = TaskType;
            //model.UserId = UserId;
            //model.GroupId = GroupId;
            //model.DeviceId = DeviceId;

            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            model.CreatedById = user.Id;
            model.UpdatedById = user.Id;
            return model;
        }
        public UserTaskModel Update(UserTaskModel model, AppUserModel user)
        {
            model.Name = Name;
            //model.TaskType = TaskType;
            //model.UserId = UserId;
            //model.GroupId = GroupId;
            //model.DeviceId = DeviceId;

            //model.StartDate = StartDate;
            //model.EndDate = EndDate;
            //model.HREF = HREF;
            //model.Progress = Progress;
            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }
       
    }
}