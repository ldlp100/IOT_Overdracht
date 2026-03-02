using System;
using System.Collections.Generic;
using System.Text;

namespace IoTEx.Waternet.Model.PIMS
{
    public class MessagePIMSModel
    {
        public string version { get; set; }
        public string timeZone { get; set; }
        public List<TimeSeriesPIMSModel> timeSeries { get; set; }

    }
}
