using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class DeviceOutputViewModel
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public string? DeviceName { get; set; }
        public string PC { get; set; }
        public Guid? EventStateTypeId { get; set; }
        public string? EventStateTypeName { get; set; }
        public Guid? MeasurementTypeId { get; set; }
        public string? MeasurementTypeName { get; set; }
        public Guid? UnitTypeId { get; set; }
        public string? UnitTypeName { get; set; }
        public bool? EventStateTypeIsAlert { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid? UpdatedById { get; set; }

        public static Dictionary<string, string> DefineMapper()
        {
            Dictionary<string, string> mapper = new Dictionary<string, string>();
            mapper.Add("DeviceName","Device.Name");
            mapper.Add("EventStateTypeName", "EventStateType.Name");
            mapper.Add("MeasurementTypeName", "MeasurementType.Name");
            mapper.Add("UnitTypeName", "UnitType.Name");
            mapper.Add("EventStateTypeIsAlert", "EventStateType.isAlert");
            return mapper;
        }

        public DeviceOutputViewModel()
        {
        }
        public DeviceOutputViewModel(DeviceOutputModel model)
        {
            Id = model.Id;
            DeviceId = model.DeviceId;
            DeviceName = (model.Device == null) ? "" : model.Device.Name;
            PC = model.PC;
            EventStateTypeId = model.EventStateTypeId;
            EventStateTypeName = (model.EventStateType == null) ? "" : model.EventStateType.Name;
            MeasurementTypeId = model.MeasurementTypeId;
            MeasurementTypeName = (model.MeasurementType == null) ? "" : model.MeasurementType.Name;
            UnitTypeId = model.UnitTypeId;
            UnitTypeName = (model.UnitType == null) ? "" : model.UnitType.Name;
            EventStateTypeIsAlert = (model.EventStateType == null) ? null : model.EventStateType.IsAlert;
            Created = model.Created;
            Updated = model.Updated;
            CreatedBy = model.CreatedBy.Username;
            UpdatedBy = model.UpdatedBy.Username;
            CreatedById = model.CreatedById;
            UpdatedById = model.UpdatedById;
        }
        public DeviceOutputModel Create(AppUserModel user)
        {
            DeviceOutputModel model = new DeviceOutputModel();
            model.DeviceId = DeviceId;
            model.EventStateTypeId = EventStateTypeId;
            model.MeasurementTypeId = MeasurementTypeId;
            model.UnitTypeId = UnitTypeId;
            model.PC = PC.Trim();
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            model.CreatedById = user.Id;
            model.UpdatedById = user.Id;
            return model;
        }
        public DeviceOutputModel Update(DeviceOutputModel model, AppUserModel user)
        {
            model.PC = PC.Trim();
            model.DeviceId = DeviceId;
            model.EventStateTypeId = EventStateTypeId;
            model.MeasurementTypeId = MeasurementTypeId;
            model.UnitTypeId = UnitTypeId;
            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }
    }
}