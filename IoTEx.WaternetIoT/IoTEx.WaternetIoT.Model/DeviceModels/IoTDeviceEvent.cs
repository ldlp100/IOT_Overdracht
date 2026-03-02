using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace IoTEx.WaternetIoT.Model.Device
{
    public class IoTDeviceEvent
    {
        public enum DeviceEventType { MEASUREMENT=1, STATE=2, ALERT =3}

        /// <summary>
        /// Define the type of Event sent
        /// </summary>
        [JsonProperty("ET")]
        public DeviceEventType Type { get; set; }
        /// <summary>
        /// Define when the event was sent
        /// </summary>
        [JsonProperty("ED")]
        public DateTime? Date { get; set; }
        /// <summary>
        /// Define a unique Id generated from the device for event
        /// </summary>
        [JsonProperty("EDUID", NullValueHandling = NullValueHandling.Ignore)]
        public string EDUID { get; set; }
        /// <summary>
        /// Define the Type of Measurement
        /// </summary>
        [JsonProperty("EN")]
        public string Name { get; set; }
        /// <summary>
        /// Define the Value of the Measurement
        /// </summary>
        [JsonProperty("EV")]
        public double Value { get; set; }
        /// <summary>
        /// Define the UniqueProcess Code repreesenting the measurement
        /// </summary>
        [JsonProperty("PC")]
        public string PC { get; set; }
    }
}
