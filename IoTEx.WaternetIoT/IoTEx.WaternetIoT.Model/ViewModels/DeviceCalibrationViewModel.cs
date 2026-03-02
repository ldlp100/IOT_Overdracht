using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;
using static IoTEx.WaternetIoT.Model.PortalModels.DeviceTypeModel;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class DeviceCalibrationViewModel
    {
        public Guid Id { get; set; }
        
        public Guid DeviceId { get; set; }
        //public virtual DeviceModel Device { get; set; }

        public string? DeviceTypeFirmware2MeasurementTypeName { get; set; }
        public Guid? DeviceTypeFirmware2MeasurementTypeId { get; set; }
        //public virtual DeviceTypeFirmwareMeasurementTypeModel DeviceTypeFirmware2MeasurementType { get; set; }

        public double? MinMeas { get; set; }
        public double? MaxMeas { get; set; }
        public double? OffsetValue { get; set; }
        public double? MinReal { get; set; }
        public double? MaxReal { get; set; }
                
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid? UpdatedById { get; set; }

        public static Dictionary<string, string> DefineMapper()
        {
            Dictionary<string, string> mapper = new Dictionary<string, string>();
            mapper.Add("DeviceType2MeasurementTypeName", "DeviceType2MeasurementType.Name");
            
            return mapper;
        }

        public DeviceCalibrationViewModel()
        {
        }
        public DeviceCalibrationViewModel(DeviceCalibrationModel model)
        {
            Id = model.Id;
            DeviceId = model.DeviceId;
            MinMeas = model.MinMeas;
            MaxMeas = model.MaxMeas;
            MinReal = model.MinReal;
            MaxReal = model.MaxReal;
            OffsetValue  = model.OffsetValue;
            DeviceTypeFirmware2MeasurementTypeName = (model.DeviceTypeFirmware2MeasurementType == null) ? "" : model.DeviceTypeFirmware2MeasurementType.Name;
            DeviceTypeFirmware2MeasurementTypeId = model.DeviceTypeFirmware2MeasurementTypeId;
            Created = model.Created;
            Updated = model.Updated;
            CreatedBy = model.CreatedBy.Username;
            UpdatedBy = model.UpdatedBy.Username;
            CreatedById = model.CreatedById;
            UpdatedById = model.UpdatedById;
        }
        public DeviceCalibrationModel Create(AppUserModel user)
        {
            DeviceCalibrationModel model = new DeviceCalibrationModel();
            model.DeviceId = DeviceId;
            model.MinMeas = MinReal;
            model.MaxMeas = MaxMeas;
            model.MinReal = MinReal;
            model.MaxReal = MaxReal;
            model.OffsetValue = OffsetValue;
            model.DeviceTypeFirmware2MeasurementTypeId = DeviceTypeFirmware2MeasurementTypeId;
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            model.CreatedById = user.Id;
            model.UpdatedById = user.Id;
            return model;
        }
        public DeviceCalibrationModel Update(DeviceCalibrationModel model, AppUserModel user)
        {
            model.MinMeas = MinMeas;
            model.MaxMeas = MaxMeas;
            model.MinReal = MinReal;
            model.MaxReal = MaxReal;
            model.OffsetValue = OffsetValue;
            model.DeviceTypeFirmware2MeasurementTypeId = DeviceTypeFirmware2MeasurementTypeId;
            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }

    }
}