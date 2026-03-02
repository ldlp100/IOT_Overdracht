using System;
using System.Collections.Generic;
using System.Text;

namespace IoTEx.Waternet.FnConnector.PIMS.Models
{
    public class EventPIMSModel
    {
        public string date { get; set; }
        public string time { get; set; }
        public string value { get; set; }
        public string flag { get; set; }
    }
}
