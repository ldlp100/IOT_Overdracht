using System;
using System.Collections.Generic;
using System.Text;

namespace IoTEx.Waternet.Common
{
    public class DataModelFunctions
    {
        public static string TranslateEnum(object value)
        {
            
            string finalValue = value.GetType().Name + "." + value.ToString();

            return finalValue;
        }
        public static string GetEnumName(Type type)
        {
            return System.Reflection.Assembly.GetAssembly(type).GetName().Name;
        }
    }
}
