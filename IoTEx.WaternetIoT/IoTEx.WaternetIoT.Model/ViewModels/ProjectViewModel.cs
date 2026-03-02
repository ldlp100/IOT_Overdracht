using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class ProjectViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? TargetDBString { get; set; }
        public string? Description { get; set; }
        //public Guid? ParentGroupId { get; set; }
        //public string ParentGroupName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsActive { get; set; }
        //public bool IsProject { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int AccessLevel { get; set; }
        public Guid? TargetDBId { get; set; }
        public string? TargetDBName { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid? UpdatedById { get; set; }

        public static Dictionary<string, string> DefineMapper()
        {
            Dictionary<string, string> mapper = new Dictionary<string, string>();
            mapper.Add("TargetDBName", "TargetDB.Name");
            return mapper;
        }

        public ProjectViewModel()
        {
        }
        //public ProjectViewModel(User2ProjectModel model)
        //{
        //    Id = model.Project.Id;
        //    Name = model.Project.Name;
        //    TargetDBString = model.Project.TargetDBString;
        //    Description = model.Project.Description;
        //    //ParentGroupId = model.Group.ParentGroupId;
        //    AccessLevel = (int)model.Project.AccessLevel;
        //    EndDate = model.Project.EndDate;
        //    Latitude = model.Project.Latitude;
        //    Longitude = model.Project.Longitude;
        //    IsActive = model.Project.IsActive;
        //    //IsProject = model.Group.IsProject;
        //    TargetDBId = model.Project.TargetDBId;
        //    TargetDBName = model.Project.TargetDB.Name;
        //    BeginDate = model.Project.BeginDate;
        //    Created = model.Project.Created;
        //    Updated = model.Project.Updated;
        //    CreatedBy = model.Project.CreatedBy.Username;
        //    UpdatedBy = model.Project.UpdatedBy.Username;
        //    CreatedById = model.Project.CreatedById;
        //    UpdatedById = model.Project.UpdatedById;
        //}
        public ProjectViewModel(ProjectModel model)
        {
            Id = model.Id;
            Name = model.Name;
            TargetDBString = model.TargetDBString;
            Description = model.Description;
            //ParentGroupId = model.ParentGroupId;
            EndDate = model.EndDate;
            Latitude = model.Latitude;
            Longitude = model.Longitude;
            IsActive = model.IsActive;
            //IsProject = model.IsProject;
            AccessLevel = (int)model.AccessLevel;
            TargetDBId = model.TargetDBId;
            TargetDBName = (model.TargetDB == null) ? "" : model.TargetDB.Name;
            BeginDate = model.BeginDate;
            Created = model.Created;
            Updated = model.Updated;
            CreatedBy = model.CreatedBy.Username;
            UpdatedBy = model.UpdatedBy.Username;
            CreatedById = model.CreatedById;
            UpdatedById = model.UpdatedById;
        }
        public bool DeductIsActive()
        {
            if (BeginDate == null && EndDate == null)
            {
                return false;
            }
            if (BeginDate!=null && EndDate == null)
            {
                if (BeginDate<=DateTime.UtcNow)
                {
                    return true;
                }
            }
            if (BeginDate == null && EndDate != null)
            {
                return false;
            }
            if (BeginDate != null && EndDate != null)
            {
                if (BeginDate <= DateTime.UtcNow && EndDate>= DateTime.UtcNow)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public ProjectModel Create(AppUserModel user)
        {
            ProjectModel model = new ProjectModel();
            model.Name = Name;
            model.TargetDBString = TargetDBString;
            //model.ParentGroupId = ParentGroupId;
            model.Description = Description;
            model.BeginDate = BeginDate;
            model.EndDate = EndDate;
            model.Longitude = Longitude;
            model.Latitude = Latitude;
            model.IsActive = IsActive;
            //model.IsProject = IsProject;
            model.AccessLevel = (ProjectModel.AccessEnum) AccessLevel;
            model.TargetDBId = TargetDBId;
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            model.CreatedById = user.Id;
            model.UpdatedById = user.Id;
            return model;
        }
        public ProjectModel Update(ProjectModel model, AppUserModel user)
        {
            model.Name = Name;
            model.TargetDBString = TargetDBString;
            //model.ParentGroupId = ParentGroupId;
            model.Description = Description;
            model.BeginDate = BeginDate;
            model.EndDate = EndDate;
            model.Longitude = Longitude;
            model.Latitude = Latitude;
            model.IsActive = IsActive;
            //model.IsProject = IsProject;
            model.AccessLevel = (ProjectModel.AccessEnum)AccessLevel;
            model.TargetDBId = TargetDBId;
            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }
        public ProjectModel UpdateFromUser(ProjectModel model, AppUserModel user)
        {
            model.Name = Name.ToUpper();
            //model.ParentGroupId = ParentGroupId;
            model.Description = Description;
            model.BeginDate = BeginDate;
            model.EndDate = EndDate;
            model.Longitude = Longitude;
            model.Latitude = Latitude;
            model.IsActive = IsActive;
            model.TargetDBId = TargetDBId;
            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }
    }
}