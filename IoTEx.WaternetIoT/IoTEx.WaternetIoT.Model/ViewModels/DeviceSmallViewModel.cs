using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class DeviceSmallViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string SerialNr { get; set; }
        public string HarwareVersion { get; set; }        
        public double Long { get; set; }
        public double Lat { get; set; }
        public double Altitude { get; set; }
        public bool IsRegistered { get; set; }
        public bool IsChanged { get; set; }        
        public string SigFoxId { get; set; }
        public string LORA_DEVEUI { get; set; }
        public string IMEI { get; set; }
        public string ICCID { get; set; }
        public string DeviceTypeName { get; set; }
        public string DeviceTypeFirmwareName { get; set; }
        public string DeviceBatchName { get; set; }
        public string AssetUID { get; set; }
        public string ParserName { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid? UpdatedById { get; set; }
        public string PublishedDocId { get; set; }
        public DateTime? PublishedDocDate { get; set; }
        public string PublishedDocBy { get; set; }
        public List<DeviceSettingViewModel> Settings { get; set; }

        public DeviceSmallViewModel()
        {
            
        }
        public DeviceSmallViewModel(DeviceModel device)
        {
            
            Id = device.Id;
            Name = device.Name;
            HarwareVersion = device.HarwareVersion;
            SerialNr = device.SerialNr;
            IsActive = device.IsActive;
            Long = device.Long;
            Lat = device.Lat;
            Altitude = device.Altitude;
            AssetUID = device.AssetUID;
            IsRegistered = device.IsRegistered;
            IsChanged = device.IsChanged;
            SigFoxId = device.SigFoxId;
            LORA_DEVEUI = device.LORA_DEVEUI;
            IMEI = device.IMEI;
            ICCID = device.ICCID;
            DeviceTypeName = (device.DeviceBatch.DeviceType == null) ? "" : device.DeviceBatch.DeviceType.Name;
            DeviceTypeFirmwareName = (device.DeviceTypeFirmware == null) ? "" : device.DeviceTypeFirmware.Name;
            DeviceBatchName = (device.DeviceBatch == null) ?"":device.DeviceBatch.Name;
            PublishedDocId = device.PublishedDocId;
            PublishedDocDate = device.PublishedDocDate;
            

            Created = device.Created;
            Updated = device.Updated;
            CreatedBy = device.CreatedBy.Username;
            UpdatedBy = device.UpdatedBy.Username;
            CreatedById = device.CreatedById;
            UpdatedById = device.UpdatedById;

            //Add Settings

        }
        
    }
    public class DeviceSettingViewModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public string value { get; set; }
        public string unit { get; set; }

    }
}