using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class DeviceTypeFirmwareConfigurationViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Symbol { get; set; }
        public string? DefaultValue { get; set; }
        public double? MinValue { get; set; }
        public double? MaxValue { get; set; }
        public double? MinLength { get; set; }
        public double? MaxLength { get; set; }
        public string? TypeName { get; set; }
        public string? Categories { get; set; }

        public DeviceTypeFirmwareConfigurationModel.ConfigurationRole Role { get; set; }
        

        public Guid DeviceTypeFirmwareId { get; set; }
        public string? DeviceTypeFirmwareName { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid? UpdatedById { get; set; }

        public static Dictionary<string, string> DefineMapper()
        {
            Dictionary<string, string> mapper = new Dictionary<string, string>();
            mapper.Add("DeviceTypeFirmwareName", "DeviceTypeFirmware.Name");
            return mapper;
        }

        public DeviceTypeFirmwareConfigurationViewModel()
        {
        }
        public DeviceTypeFirmwareConfigurationViewModel(DeviceTypeFirmwareConfigurationModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Description = model.Description;
            Symbol = model.Symbol;
            DefaultValue = model.DefaultValue;
            Role = model.Role;            
            DeviceTypeFirmwareId = model.DeviceTypeFirmwareId;
            DeviceTypeFirmwareName = (model.DeviceTypeFirmware != null) ? model.DeviceTypeFirmware.Name : "";
            MinLength = model.MinLength;
            MaxLength = model.MaxLength;
            MinValue = model.MinValue;
            MaxValue = model.MaxValue;
            TypeName = model.TypeName;
            Categories = model.Categories;
                
            Created = model.Created;
            Updated = model.Updated;
            CreatedBy = model.CreatedBy.Username;
            UpdatedBy = model.UpdatedBy.Username;
            CreatedById = model.CreatedById;
            UpdatedById = model.UpdatedById;
        }
        public DeviceTypeFirmwareConfigurationModel Create(AppUserModel user)
        {
            DeviceTypeFirmwareConfigurationModel model = new DeviceTypeFirmwareConfigurationModel();
            model.Name = Name;
            model.Description = Description;
            model.Symbol = Symbol;
            model.DefaultValue = DefaultValue;
            model.Role = Role;
            model.DeviceTypeFirmwareId = DeviceTypeFirmwareId;
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            model.CreatedById = user.Id;
            model.UpdatedById = user.Id;
            return model;
        }
        public DeviceTypeFirmwareConfigurationModel Update(DeviceTypeFirmwareConfigurationModel model, AppUserModel user)
        {
            model.Name = Name;
            model.Description = Description;
            model.Symbol = Symbol;
            model.DeviceTypeFirmwareId = DeviceTypeFirmwareId;
            model.DefaultValue = DefaultValue;
            model.Role = Role;            
            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }

    }
}