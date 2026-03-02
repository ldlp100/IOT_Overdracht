using System;
using System.Collections.Generic;
using System.Text;

namespace IoTEx.Waternet.FnConnector.PIMS.Models
{
    public class MessagePIMSModel
    {
        public string version { get; set; }
        public string timeZone { get; set; }
        public List<TimeSeriesPIMSModel> timeSeries { get; set; }

    }
}
