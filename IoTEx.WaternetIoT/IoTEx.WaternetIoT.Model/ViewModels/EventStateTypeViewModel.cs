using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class EventStateTypeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid? UpdatedById { get; set; }
        public bool IsState { get; set; }
        public bool IsUpdated { get; set; }
        public bool IsReleased { get; set; }
        public Guid? DerivedStateId { get; set; }
        public string DerivedStateName { get; set; }

        public static Dictionary<string, string> DefineMapper()
        {
            Dictionary<string, string> mapper = new Dictionary<string, string>();
            mapper.Add("DerivedStateName", "DerivedState.Name");
            return mapper;
        }

        public EventStateTypeViewModel()
        {
        }
        public EventStateTypeViewModel(EventStateTypeModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Description = model.Description;
            IsState = model.IsState;
            IsReleased = model.IsReleased;
            IsUpdated = model.IsUpdated;
            DerivedStateId = model.DerivedStateId;
            DerivedStateName = (model.DerivedState == null) ? "" : model.DerivedState.Name;
            Created = model.Created;
            Updated = model.Updated;
            CreatedBy = model.CreatedBy.Username;
            UpdatedBy = model.UpdatedBy.Username;
            CreatedById = model.CreatedById;
            UpdatedById = model.UpdatedById;
        }
        public EventStateTypeModel Create(AppUserModel user)
        {
            EventStateTypeModel model = new EventStateTypeModel();
            model.Name = Name;
            model.Description = Description;
            model.DerivedStateId = DerivedStateId;
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            model.CreatedById = user.Id;
            model.UpdatedById = user.Id;
            model.IsState = IsState;
            return model;
        }
        public EventStateTypeModel Update(EventStateTypeModel model, AppUserModel user)
        {
            model.Name = Name;
            model.DerivedStateId = DerivedStateId;
            model.IsState = IsState;
            model.Description = Description;
            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }
    }
}