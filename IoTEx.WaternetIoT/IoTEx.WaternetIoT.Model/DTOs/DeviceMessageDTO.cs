
namespace IoTEx.WaternetIoT.Model.DTOs
{
    public enum NetworkTypeEnum { NOT_DEFINED = 1, LORAWAN_KERLINK = 2, SIGFOX = 3, NBIoT_TMOBILE = 5, IOTDEV_UDP_APN_TMOBILE_NBIOT=6 }
    public enum PayLoadEncryptionEnum { HEX, BASE64 }

    public class DeviceMessageDTO
    {        
        public long _ts { get;  }
        public Guid id { get; set; }
        public string msgName { get; set; }
        public string configId { get; set; }
        public string parserNamespace { get; set; }
        public string DMUID { get; set; }
        public string deviceId { get; set; }
        public string deviceNetworkId { get; set; }
        public string deviceSerialNr { get; set; }
        public DateTime rcvDateTime { get; set; }
        public string deviceType { get; set; }
        public NetworkTypeEnum networkType { get; set; }
        public string originalMessage { get; set; }
        public string assetUID { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public List<DeviceMessageEventDTO> events { get; set; }
        public DeviceMessageNetworkDTO networkInfo { get; set; }

        public DeviceMessageDTO()
        {
            events = new List<DeviceMessageEventDTO>();

        }


    }
}
