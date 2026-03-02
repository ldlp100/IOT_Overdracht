using Newtonsoft.Json;
using System;
using System.Collections.Generic;

using IoTEx.WaternetIoT.Model.Communication;


namespace IoTEx.WaternetIoT.Model.Device
{


    public class IoTDeviceMessage
    {
        public enum PayLoadEncryptionEnum { HEX, BASE64 }


        
        /// <summary>
        /// Define a unique MessageId
        /// </summary>
        [JsonProperty("MUID", NullValueHandling = NullValueHandling.Ignore)]
        public Guid MUID { get; set; }

        /// <summary>
        /// Define a unique MessageId from Device
        /// </summary>
        [JsonProperty("DMUID", NullValueHandling = NullValueHandling.Ignore)]
        public string DMUID { get; set; }

        /// <summary>
        /// Define the unique ID of the Device Sending the info
        /// </summary>
        [JsonProperty("DUID", NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceID { get; set; }

        /// <summary>
        /// Define the unique Network ID of the Device Sending the info
        /// </summary>
        [JsonProperty("DNUID", NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceNetworkUID { get; set; }
        /// <summary>
        /// Define the unique ID of the Device Sending the info
        /// </summary>
        [JsonProperty("DGID", NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceGroupID { get; set; }

        /// <summary>
        /// Define the unique ID of the Device Sending the info
        /// </summary>
        [JsonProperty("DSNR", NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceSerialNr { get; set; }
        /// <summary>
        /// Define the time when the message was received
        /// </summary>
        [JsonProperty("RT", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime RcvTime { get; set; }

        [JsonProperty("DVT", NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceType { get; set; }

        [JsonProperty("NT", NullValueHandling = NullValueHandling.Ignore)]
        public NetworkTypeEnum NetworkType { get; set; }
        /// <summary>
        /// Show original message
        /// </summary>
        [JsonProperty("ORI", NullValueHandling = NullValueHandling.Ignore)]
        public string OriginalMessage { get; set; }
        /// <summary>
        /// Define an unique Id for the asset.
        /// </summary>
        [JsonProperty("AUID")]
        public string AssetUID { get; set; }        
        /// <summary>
        /// Define the Latitude where the device is located
        /// </summary>
        [JsonProperty("LAT")]
        public double Latitude { get; set; }
        /// <summary>
        /// Define the Longitude where the device is located
        /// </summary>
        [JsonProperty("LNG")]
        public double Longitude { get; set; }

        /// <summary>
        /// List all the events 
        /// </summary>
        [JsonProperty("EVTS", NullValueHandling = NullValueHandling.Ignore)]
        public List<IoTDeviceEvent> Events { get; set; }

        [JsonProperty("NI", NullValueHandling = NullValueHandling.Ignore)]
        public IoTNetworkInfo NetworkInfo { get; set; }

        public IoTDeviceMessage()
        {
            Events = new List<IoTDeviceEvent>();
            
        }
        

    }
}
