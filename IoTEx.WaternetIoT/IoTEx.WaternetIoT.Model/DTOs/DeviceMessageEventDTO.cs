using Newtonsoft.Json;
using System;

namespace IoTEx.WaternetIoT.Model.DTOs
{
    
    public class DeviceMessageEventDTO
    {
        public enum DeviceEventType { MEASUREMENT = 1, STATE = 2, ALERT = 3, INFO=4 }
        /// <summary>
        /// Define the type of Event sent
        /// </summary>
        public DeviceEventType type { get; set; }
        /// <summary>
        /// Define when the event was sent
        /// </summary>
        public DateTime? received { get; set; }
        /// <summary>
        /// Define a unique Id generated from the device for event
        /// </summary>
        [JsonProperty("EDUID", NullValueHandling = NullValueHandling.Ignore)]
        public string EDUID { get; set; }
        /// <summary>
        /// Define the Type of Measurement
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Define the Value of the Measurement
        /// </summary>
        public double value { get; set; }
        /// <summary>
        /// Define the Value of the Measurement
        /// </summary>
        public string info { get; set; }
        /// <summary>
        /// Define the Value of the Measurement
        /// </summary>
        public string unit { get; set; }
        /// <summary>
        /// Define the UniqueProcess Code repreesenting the measurement
        /// </summary>
        public string pc { get; set; }
        public string pcValue { get; set; }
        public string pcUnit { get; set; }

    }
}
