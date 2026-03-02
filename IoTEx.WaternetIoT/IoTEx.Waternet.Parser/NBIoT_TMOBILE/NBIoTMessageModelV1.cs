using System;
using System.Collections.Generic;
using System.Text;

namespace IoTEx.WaternetIoT.Data.Model
{
    public class NBIoTMessageModelV1
    {
        /// <summary>
        /// Endpoint identifier
        /// </summary>
        public string deviceId { get; set; }
        /// <summary>
        /// content (hexa decimal payload)
        /// </summary>
        public string payload { get; set; }
        /// <summary>
        /// time of message at the station
        /// </summary>
        public DateTime utcTime { get; set; }

        
    }
}
