using Newtonsoft.Json;


namespace IoTEx.WaternetIoT.Model.DTOs
{
    

    public class DeviceMessageErrorDTO
    {
        public enum ErrorTypeEnum { DEVICE_NOT_FOUND, NO_EVENTS_FOUND, NETWORKID_NOT_FOUND_IN_MESSAGE, UNKNOWN    }
        
        public string id { get; set; }
        public string errorType { get; set; }
        public string iotHubDeviceId { get; set; }
        public string payload { get; set; }
        public string network { get; set; }
        public string networkId { get; set; }
        public Int64 _ts { get; set; }
    }
}
