using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Data.Model;


namespace IoTEx.WaternetIoT.Model.DTOModels.Old
{
    public class DocumentDeviceViewModel
    {
        public string id { get; set; }
        public string deviceId { get; set; }
        public string name { get; set; }
        public string assetUID { get; set; }
        public bool isTraced { get; set; }
        public bool isActive { get; set; }
        public DeviceDefinitionInfoDTO info { get; set; }
        public DeviceDefinitionLocationDTO location { get; set; }
        public DeviceDefinitionNetworkInfoDTO network { get; set; }
        public List<DeviceDefinitionProjectDTO> projects { get; set; }
        public DateTime publishedDate { get; set; }
        public DateTime? installedDate { get; set; }
        public int publishedCounter { get; set; }
        public string publishedByUserId { get; set; }
        public string publishedByUsername { get; set; }
        public DeviceDefinitionOperationalConfigurationDTO configuration { get; set; }

        public DocumentDeviceViewModel()
        {

        }
        public DocumentDeviceViewModel(DeviceDefinitionDTO model)
        {
            id = model.id;
            deviceId = model.deviceId;
            name = model.name;
            assetUID = model.assetUID;
            isTraced = model.isTraced;
            isActive = model.isActive;
            info = model.info;
            location = model.location;
            network = model.network;
            projects = model.projects;
            publishedDate = model.publishedDate;
            installedDate = model.installedDate;
            publishedCounter = model.publishedCounter;
            publishedByUserId = model.publishedByUserId;
            publishedByUsername = model.publishedByUsername;
            configuration = model.configuration;
        }

    }
}