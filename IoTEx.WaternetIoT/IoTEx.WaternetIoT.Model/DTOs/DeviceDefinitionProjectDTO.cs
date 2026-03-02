using Newtonsoft.Json;
using System;


namespace IoTEx.WaternetIoT.Model.DTOs
{
    public class DeviceDefinitionProjectDTO
    {
        public string id { get; set; }
        public string name { get; set; }
        public string targetDB { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public bool isActive
        {
            get
            {
                DateTime now = DateTime.UtcNow;
                if (startDate != null)
                {

                    if (now > startDate)
                    {
                        if (endDate == null)
                        {
                            return true;
                        }
                        if (now < endDate)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
    }
}
