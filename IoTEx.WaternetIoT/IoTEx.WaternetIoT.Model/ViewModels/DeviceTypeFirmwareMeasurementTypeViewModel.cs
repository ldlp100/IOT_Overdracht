using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class DeviceTypeFirmwareMeasurementTypeViewModel
    {
        public Guid Id { get; set; }
        public Guid? MeasurementTypeId { get; set; }
        public string? MeasurementTypeName { get; set; }
        public Guid? DeviceTypeId { get; set; }
        public string? DeviceTypeName { get; set; }
        public Guid DeviceTypeFirmwareId { get; set; }
        public string? DeviceTypeFirmwareName { get; set; }

        public Guid? UnitTypeId { get; set; }
        public string? UnitTypeName { get; set; }
        public string? Description { get; set; }
        public string? Unit { get; set; }
        public string Name { get; set; }
        public double? MinMeas { get; set; }
        public double? MaxMeas { get; set; }
        public double? MinSensor { get; set; }
        public double? MaxSensor { get; set; }
        public double? OffsetValue { get; set; }

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

        public DeviceTypeFirmwareMeasurementTypeViewModel()
        {
        }
        public DeviceTypeFirmwareMeasurementTypeViewModel(DeviceTypeFirmwareMeasurementTypeModel model)
        {
            Id = model.Id;
            Name = model.Name;
            DeviceTypeFirmwareId = model.DeviceTypeFirmwareId;
            DeviceTypeFirmwareName = model.DeviceTypeFirmware?.Name;
            UnitTypeId = model.UnitTypeId;
            UnitTypeName = (model.UnitType==null)? "":model.UnitType.Name;
            Unit = model.Unit;
            Description = model.Description;
            MinMeas = model.MinMeas;
            MaxMeas = model.MaxMeas;
            MinSensor = model.MinSensor;
            MaxSensor = model.MaxSensor;
            OffsetValue = model.OffsetValue;
            Created = model.Created;
            Updated = model.Updated;
            CreatedBy = model.CreatedBy.Username;
            UpdatedBy = model.UpdatedBy.Username;
            CreatedById = model.CreatedById;
            UpdatedById = model.UpdatedById;
        }
        public DeviceTypeFirmwareMeasurementTypeModel Create(AppUserModel user)
        {
            DeviceTypeFirmwareMeasurementTypeModel model = new DeviceTypeFirmwareMeasurementTypeModel();
            model.MeasurementTypeId = MeasurementTypeId;
            model.Name = Name.Trim();
            model.DeviceTypeFirmwareId = DeviceTypeFirmwareId;
            model.UnitTypeId = UnitTypeId;
            model.Unit = Unit;
            model.Description = Description;
            model.MinMeas = MinMeas; 
            model.MaxMeas = MaxMeas;
            model.MinSensor= MinSensor;
            model.MaxSensor= MaxSensor;
            model.OffsetValue = OffsetValue;
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            model.CreatedById = user.Id;
            model.UpdatedById = user.Id;
            return model;
        }
        public DeviceTypeFirmwareMeasurementTypeModel Update(DeviceTypeFirmwareMeasurementTypeModel model, AppUserModel user)
        {
            model.Name = Name.Trim();
            model.MeasurementTypeId = MeasurementTypeId;
            model.DeviceTypeFirmwareId = DeviceTypeFirmwareId;
            model.UnitTypeId = UnitTypeId;
            model.Unit = Unit;
            model.Description = Description;
            model.MinMeas = MinMeas;
            model.MaxMeas = MaxMeas;
            model.MinSensor = MinSensor;
            model.MaxSensor = MaxSensor;
            model.OffsetValue = OffsetValue;
            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }

    }
}