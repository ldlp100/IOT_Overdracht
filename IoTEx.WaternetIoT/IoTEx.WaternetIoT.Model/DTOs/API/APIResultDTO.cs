using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTEx.WaternetIoT.Model.DTOs.API
{
    public class APIResultDTO<T>
    {
        /// <summary>
        /// Error string 
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Error { get; set; }
        /// <summary>
        /// Value containing the return value.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public T Value { get; set; }
        /// <summary>
        /// Flag indicating if the call was successful or not.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool IsOk { get; set; }


    }
}
