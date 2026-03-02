using IOT.METADATA.UNITS;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTEx.Waternet.Parser
{
    [AttributeUsage(AttributeTargets.All)]
    public class MetaDataAttribute : Attribute
    {
        public MetaDataAttribute()
        {

        }
        public UnitsEnum Unit { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public int MemberIndex { get; set; }
        public int SensorIndex { get; set; }
    }
}
