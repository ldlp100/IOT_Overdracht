using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IoTEx.WaternetIoT.DAL
{
    public static class DataReaderExtensions
    {
        public static List<T> SerializeToList<T>(this IDataReader reader) where T : new()
        {
            var results = new List<T>();
            var properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);

            while (reader.Read())
            {
                T item = new T();
                foreach (var property in properties)
                {
                    if (reader.HasColumn(property.Name) && !reader.IsDBNull(reader.GetOrdinal(property.Name)))
                    {
                       property.SetValue(item, reader[property.Name]);
                    }
                }
                results.Add(item);
            }
            return results;
        }

        // Extension method to check if a column exists in the data reader
        public static bool HasColumn(this IDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
