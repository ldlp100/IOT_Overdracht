using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;
using static IoTEx.WaternetIoT.Model.PortalModels.DeviceTypeModel;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class DeviceTypeFirmwareViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        
        public Guid? ParserId { get; set; }
        public string? ParserName { get; set; }
        public Guid? DeviceTypeId { get; set; }
        public string? DeviceTypeName { get; set; }
        public bool IsConfigurable { get; set; }
        public bool IsUsed { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid? UpdatedById { get; set; }

        public static Dictionary<string, string> DefineMapper()
        {
            Dictionary<string, string> mapper = new Dictionary<string, string>();            
            mapper.Add("ParserName", "Parser.Name");
            mapper.Add("DeviceTypeName", "DeviceType.Name");
            mapper.Add("DeviceTypeFirmwareMeasName", "DeviceTypeFirmwareMeas.Name");
            mapper.Add("DeviceTypeFirmwareStateName", "DeviceTypeFirmwareState.Name");
            mapper.Add("DeviceTypeFirmwareAlertName", "DeviceTypeFirmwareAlert.Name");

            return mapper;
        }

        public DeviceTypeFirmwareViewModel()
        {
        }
        public DeviceTypeFirmwareViewModel(DeviceTypeFirmwareModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Description = model.Description;            
            IsUsed = model.IsUsed;
            DeviceTypeId = model.DeviceTypeId;
            DeviceTypeName = (model.DeviceType == null) ? "" : model.DeviceType.Name;
            ParserId = model.ParserId;
            ParserName = (model.Parser == null) ? "" : model.Parser.Name;
            
            IsConfigurable = model.IsConfigurable;
            Created = model.Created;
            Updated = model.Updated;
            CreatedBy = model.CreatedBy.Username;
            UpdatedBy = model.UpdatedBy.Username;
            CreatedById = model.CreatedById;
            UpdatedById = model.UpdatedById;
        }
        public DeviceTypeFirmwareModel Create(AppUserModel user)
        {
            DeviceTypeFirmwareModel model = new DeviceTypeFirmwareModel();
            model.Name = Name;
            model.Description = Description;
            model.IsUsed = IsUsed;
            model.DeviceTypeId = DeviceTypeId;
            model.IsConfigurable = IsConfigurable;
            model.ParserId = ParserId;
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            model.CreatedById = user.Id;
            model.UpdatedById = user.Id;
            return model;
        }
        public DeviceTypeFirmwareModel Update(DeviceTypeFirmwareModel model, AppUserModel user)
        {
            
            model.Name = Name;
            model.Description = Description;
            model.IsUsed = IsUsed;
            model.DeviceTypeId = DeviceTypeId;
            model.IsConfigurable = IsConfigurable;
            model.ParserId = ParserId;
            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }

    }
}