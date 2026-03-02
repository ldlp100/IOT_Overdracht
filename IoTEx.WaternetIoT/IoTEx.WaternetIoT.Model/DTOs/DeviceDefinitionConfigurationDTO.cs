using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTEx.WaternetIoT.Model.DTOs
{
    public class DeviceDefinitionConfigurationDTO
    {
        public enum ConfigurationTypeEnum { type_string, type_bool, type_int16, type_date, type_uint16, type_float, type_uint8, type_int8, type_double }
        public string id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string description { get; set; }
        public string role { get; set; }
        public string value { get; set; }
        public ConfigurationTypeEnum type { get; set; }
        public double? MinLength { get; set; }
        public double? MaxLength { get; set; }
        public double? MinValue { get; set; }
        public double? MaxValue { get; set; }
        public string Categories { get; set; }
        public string RegEx { get; set; }
        public string updatedById { get; set; }
        public string updatedByName { get; set; }
        public Type GetTrueType()
        {
            switch (type)
            {
                case ConfigurationTypeEnum.type_string:
                    return typeof(string);
                case ConfigurationTypeEnum.type_bool:
                    return typeof(bool);
                case ConfigurationTypeEnum.type_int16:
                    return typeof(Int16);
                case ConfigurationTypeEnum.type_date:
                    return typeof(DateTime);
                case ConfigurationTypeEnum.type_uint16:
                    return typeof(UInt16);
                case ConfigurationTypeEnum.type_float:
                    return typeof(float);
                case ConfigurationTypeEnum.type_uint8:
                    return typeof(sbyte);
                case ConfigurationTypeEnum.type_int8:
                    return typeof(byte);
                case ConfigurationTypeEnum.type_double:
                    return typeof(double);
                default:
                    return typeof(string);
            }
        }
    }
}
