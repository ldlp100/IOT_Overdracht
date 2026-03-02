using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace IoTEx.WaternetIoT.Model.DTOModels.Old
{

    public class DocumentCSVModel
    {
        public string DeviceId { get; set; }
        public string AssetUID { get; set; }
        public DateTime? EvtDate { get; set; }
        public string Name { get; set; }
        public string EventType { get; set; }
        public double Value { get; set; }
        public string Unit { get; set; }
        public string EDUID { get; set; }
        public DocumentCSVModel(string deviceId, string assetUID, DateTime? dt, string eduid, string name, string eventType, string unit, double value)
        {
            DeviceId = deviceId;
            AssetUID = assetUID;
            EvtDate = dt;
            EDUID = eduid;
            Name = name;
            EventType = eventType;
            Unit = unit;
            Value = value;

        }
    }

}
