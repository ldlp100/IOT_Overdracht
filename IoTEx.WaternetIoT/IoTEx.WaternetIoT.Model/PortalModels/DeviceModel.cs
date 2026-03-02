using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_DEVICE")]
    public class DeviceModel : BaseModel
    {

        [Column("ASSET_UID")]
        public string? AssetUID { get; set; }
        
        [Column("LAST_MESSAGE")]
        public DateTime? LastMessage { get; set; }
        
        [Column("IS_ACTIVE")]
        public bool IsActive { get; set; }
        
        [Column("IS_TRACED")]
        public bool IsTraced { get; set; }
        
        [Column("NAME")]
        public string? Name { get; set; }
        
        [Column("LNG")]
        public double Long { get; set; }
        
        [Column("LAT")]
        public double Lat { get; set; }
        
        [Column("SERIALNR")]
        public string? SerialNr { get; set; }
        
        [Column("HDW_VER")]
        public string? HarwareVersion { get; set; }
        
        //[Column("FIRMW_VER")]
        //public string? FirmWareVersion { get; set; }

        [Column("SIGFOX_ID")]
        public string? SigFoxId { get; set; }

        [Column("SIGFOX_PAC")]
        public string? SigfoxPAC { get; set; }
        [Column("SIGFOX_APPKey")]
        public string? SigfoxAPPKey { get; set; }

        [Column("LORA_DEVEUI")]
        public string? LORA_DEVEUI { get; set; }
   
        [Column("LORA_OTAA_APPEUI")]
        public string? LORA_OTAA_APPEUI { get; set; }
        
        [Column("LORA_OTAA_APPKEY")]
        public string? LORA_OTAA_APPKEY { get; set; }

        [Column("IMEI")]
        public string? IMEI { get; set; }
        
        [Column("IMEI_APPKEY")]
        public string? IMEIAppKey { get; set; }
        
        [Column("ICCID")]
        public string? ICCID { get; set; }
        
        [Column("PUBLISHED_DOC_DT")]
        public DateTime? PublishedDocDate { get; set; }
        
        [Column("INSTALL_DT")]
        public DateTime? InstalledDate { get; set; }

        [Column("PUBLISHED_DOC_ID")]
        public string? PublishedDocId { get; set; }

        [Column("ALT")]
        public double Altitude { get; set; }

        [Column("ISREGISTERED")]
        public bool IsRegistered { get; set; }

        [Column("ISCHANGED")]
        public bool IsChanged { get; set; }

        //[Column("PROV_LORA")]
        //public bool IsLORAProv { get; set; }

        //[Column("PROV_SIGFOX")]
        //public bool IsSigfoxProv{ get; set; }

        //[Column("PROV_NBIOT")]
        //public bool IsNBIoTProv { get; set; }

        //[Column("PROV_LTM")]
        //public bool IsLTMProv { get; set; }

        //[Column("LORA_ABP_APPSKey")]
        //public string? LORA_ABP_APPSKey  { get; set; }

        //[Column("LORA_ABP_NwkSKey")]
        //public string? LORA_ABP_NwkSKey { get; set; }

        //[Column("LORA_ABP_devADDR")]
        //public string? LORA_ABP_devADDR { get; set; }


        [Column("DEVICE_TYPE_FRW_ID")]
        public Guid? DeviceTypeFirmwareId { get; set; }
        [ForeignKey("DeviceTypeFirmwareId")]
        public virtual DeviceTypeFirmwareModel DeviceTypeFirmware { get; set; }

        //[Column("DEVICE_TYPE_ID")]
        //public Guid? DeviceTypeId { get; set; }
        //[ForeignKey("DeviceTypeId")]
        //public virtual DeviceTypeModel DeviceType { get; set; }


        [Column("DEVICE_BATCH_ID")]
        public Guid? DeviceBatchId { get; set; }
        [ForeignKey("DeviceBatchId")]
        public virtual DeviceBatchModel DeviceBatch { get; set; }
    }

    
}