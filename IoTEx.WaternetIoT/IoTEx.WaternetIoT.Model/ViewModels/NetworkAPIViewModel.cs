using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;
using static IoTEx.WaternetIoT.Model.PortalModels.DeviceTypeModel;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class NetworkAPIViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsLORA { get; set; }
        public bool IsSigFox { get; set; }
        public bool IsLTM { get; set; }
        public bool IsNBIoT { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid? UpdatedById { get; set; }

        public static Dictionary<string, string> DefineMapper()
        {
            Dictionary<string, string> mapper = new Dictionary<string, string>();
            
            return mapper;
        }

        public NetworkAPIViewModel()
        {
        }
        public NetworkAPIViewModel(NetworkAPIModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Description = model.Description;
            IsLORA = model.IsLORA;
            IsLTM = model.IsLTM;
            IsNBIoT = model.IsNBIoT;
            IsSigFox = model.IsSigFox;
            Created = model.Created;
            Updated = model.Updated;
            CreatedBy = model.CreatedBy.Username;
            UpdatedBy = model.UpdatedBy.Username;
            CreatedById = model.CreatedById;
            UpdatedById = model.UpdatedById;
        }
        public NetworkAPIModel Create(AppUserModel user)
        {
            NetworkAPIModel model = new NetworkAPIModel();
            model.Name = Name;
            model.Description = Description;
            model.IsSigFox = IsSigFox;
            model.IsLORA = IsLORA;
            model.IsLTM = IsLTM;
            model.IsNBIoT = IsNBIoT;
            
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            model.CreatedById = user.Id;
            model.UpdatedById = user.Id;
            return model;
        }
        public NetworkAPIModel Update(NetworkAPIModel model, AppUserModel user)
        {
            //CANNOT CHANGE NAME AFTER CREATION
            model.Name = Name;
            model.Description = Description;
            model.IsSigFox = IsSigFox;
            model.IsLORA = IsLORA;
            model.IsLTM = IsLTM;
            model.IsNBIoT = IsNBIoT;
            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }

    }
}