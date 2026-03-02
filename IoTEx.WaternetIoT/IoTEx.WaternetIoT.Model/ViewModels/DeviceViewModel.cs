using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class DeviceViewModel
    {
        public Guid Id { get; set; }
        public string? AssetUID { get; set; }
        public DateTime? LastMessage { get; set; }
        public bool IsActive { get; set; }
        public bool IsTraced { get; set; }
        public string? Name { get; set; }
        public double Long { get; set; }
        public double Lat { get; set; }
        public string? SerialNr { get; set; }
        public string? HarwareVersion { get; set; }
        public string? NetworkId { get; set; }
        public string? SigfoxPAC { get; set; }
        public string? SigFoxId { get; set; }
        public string? SigfoxAPPKey { get; set; }
        public string? LORA_DEVEUI { get; set; }
        public string? LORA_OTAA_APPEUI { get; set; }
        public string? LORA_OTAA_APPKEY { get; set; }
        public string? IMEI { get; set; }
        public string? IMEIAppKey { get; set; }
        public string? ICCID { get; set; }
        public DateTime? PublishedDocDate { get; set; }
        public DateTime? InstalledDate { get; set; }
        public double Altitude { get; set; }
        public bool IsRegistered { get; set; }
        public bool IsChanged { get; set; }
        public Guid? DeviceTypeId { get; set; }
        public string? DeviceTypeName { get; set; }
        public Guid? DeviceTypeFirmwareId { get; set; }        
        public string? DeviceTypeFirmwareName { get; set; }
        public Guid? DeviceBatchId { get; set; }
        public string? DeviceBatchName { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid? UpdatedById { get; set; }

        public static Dictionary<string, string> DefineMapper()
        {
            Dictionary<string, string> mapper = new Dictionary<string, string>();
            mapper.Add("DeviceTypeName", "DeviceBatch.DeviceType.Name");
            mapper.Add("DeviceBatchName", "DeviceBatch.Name");
            mapper.Add("DeviceTypeFirmwareName", "DeviceTypeFirmware.Name");
            mapper.Add("imei", "IMEI");
            mapper.Add("lora_DEVEUI", "LORA_DEVEUI");
            mapper.Add("lora_OTAA_APPEUI", "LORA_OTAA_APPEUI");
            mapper.Add("lora_OTAA_APPKEY", "LORA_OTAA_APPKEY");
            mapper.Add("imeiAppKey", "IMEIAppKey");
            mapper.Add("iccid", "ICCID");
            
           
            return mapper; 
        }
            

        public DeviceViewModel()
        {
            
        }
        public DeviceViewModel(DeviceModel device)
        {
            
            Id = device.Id;
            Name = device.Name;
            
            LastMessage = device.LastMessage;
            HarwareVersion = device.HarwareVersion;
            SerialNr = device.SerialNr;
            IsActive = device.IsActive;
            IsTraced = device.IsTraced;
            Long = device.Long;
            Lat = device.Lat;
            Altitude = device.Altitude;
            AssetUID = device.AssetUID;
            IsChanged = device.IsChanged;
            SigfoxPAC = device.SigfoxPAC;
            SigFoxId = device.SigFoxId;
            SigfoxAPPKey = device.SigfoxAPPKey;
            LORA_DEVEUI = device.LORA_DEVEUI;
            LORA_OTAA_APPEUI = device.LORA_OTAA_APPEUI;
            LORA_OTAA_APPKEY = device.LORA_OTAA_APPKEY;
            IMEI = device.IMEI;
            IMEIAppKey = device.IMEIAppKey;
            ICCID = device.ICCID;
            DeviceTypeId = device.DeviceBatch?.DeviceTypeId;
            DeviceTypeName = (device.DeviceBatch?.DeviceType == null) ? "" : device.DeviceBatch.DeviceType.Name;

            DeviceTypeFirmwareId = device.DeviceTypeFirmwareId;
            DeviceTypeFirmwareName = (device.DeviceTypeFirmware == null) ? "" : device.DeviceTypeFirmware.Name;

            DeviceBatchId = device.DeviceBatchId;
            DeviceBatchName = (device.DeviceBatch == null) ?"":device.DeviceBatch.Name;

            //PublishedDocId = device.PublishedDocId;
            PublishedDocDate = device.PublishedDocDate;
            InstalledDate = device.InstalledDate;

            Created = device.Created;
            Updated = device.Updated;
            CreatedBy = device.CreatedBy.Username;
            UpdatedBy = device.UpdatedBy.Username;
            CreatedById = device.CreatedById;
            UpdatedById = device.UpdatedById;
        }
        public DeviceModel Create(AppUserModel user)
        {
            DeviceModel model = new DeviceModel();
            model.Name = Name;
            model.LastMessage = LastMessage;
            model.IsActive = IsActive;
            model.IsTraced = IsTraced;
            model.SerialNr = SerialNr;
            model.IsChanged = IsChanged;
            //model.IsRegistered = IsRegistered;
            model.HarwareVersion = HarwareVersion;
            //model.FirmWareVersion = FirmWareVersion;
            model.Long = Long;
            model.Lat = Lat;
            model.Altitude = Altitude;
            model.AssetUID = AssetUID;
            model.SigfoxPAC = SigfoxPAC;
            model.SigFoxId = SigFoxId;
            model.SigfoxAPPKey = SigfoxAPPKey;
            model.LORA_DEVEUI = LORA_DEVEUI;
            model.LORA_OTAA_APPEUI = LORA_OTAA_APPEUI;
            model.LORA_OTAA_APPKEY = LORA_OTAA_APPKEY;
            //model.LORA_ABP_APPSKey = LORA_ABP_APPSKey;
            //model.LORA_ABP_NwkSKey = LORA_ABP_NwkSKey;
            //model.LORA_ABP_devADDR = LORA_ABP_devADDR;
            model.IMEI = IMEI;
            model.IMEIAppKey = IMEIAppKey;
            model.ICCID = ICCID;
            //model.DeviceTypeId = DeviceTypeId;
            model.DeviceTypeFirmwareId = DeviceTypeFirmwareId;
            model.PublishedDocDate = PublishedDocDate;
            model.InstalledDate = InstalledDate;
            model.DeviceBatchId = DeviceBatchId;
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            model.CreatedById = user.Id;
            model.UpdatedById = user.Id;
            return model;
        }
        public DeviceModel Update(DeviceModel model, AppUserModel user)
        {
            model.Name = Name;
            model.LastMessage = LastMessage;
            model.IsActive = IsActive;
            model.IsTraced = IsTraced;
            model.SerialNr = SerialNr;
            model.HarwareVersion = HarwareVersion;
            //model.FirmWareVersion = FirmWareVersion;
            model.IsChanged = IsChanged;
            //model.IsRegistered = IsRegistered;
            model.IsActive = IsActive;
            model.Long = Long;
            model.Lat = Lat;
            model.Altitude = Altitude;
            model.AssetUID = AssetUID;
            model.SigfoxPAC = SigfoxPAC;
            model.SigFoxId = SigFoxId;
            model.SigfoxAPPKey = SigfoxAPPKey;
            model.LORA_DEVEUI = LORA_DEVEUI;
            model.LORA_OTAA_APPEUI = LORA_OTAA_APPEUI;
            model.LORA_OTAA_APPKEY = LORA_OTAA_APPKEY;
            //model.LORA_ABP_APPSKey = LORA_ABP_APPSKey;
            //model.LORA_ABP_NwkSKey = LORA_ABP_NwkSKey;
            //model.LORA_ABP_devADDR = LORA_ABP_devADDR;
            model.IMEI = IMEI;
            model.IMEIAppKey = IMEIAppKey;
            model.ICCID = ICCID;            
            //model.DeviceTypeId = DeviceTypeId;
            model.DeviceTypeFirmwareId = DeviceTypeFirmwareId;
            model.DeviceBatchId = DeviceBatchId;
            model.PublishedDocDate = PublishedDocDate;
            model.InstalledDate = InstalledDate;
            model.DeviceBatchId = DeviceBatchId;
            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }
        public DeviceModel UpdateLimited(DeviceModel model, AppUserModel user)
        {
            model.Name = Name;
            model.IsActive = IsActive;
            model.SerialNr = SerialNr;
            model.HarwareVersion = HarwareVersion;
            model.IsChanged = IsChanged;
            model.IsActive = IsActive;
            model.Long = Long;
            model.Lat = Lat;
            model.Altitude = Altitude;
            model.AssetUID = AssetUID;
            model.PublishedDocDate = PublishedDocDate;
            model.Updated = DateTime.Now;
            model.UpdatedById = user.Id;
            return model;
        }
    }
    
}