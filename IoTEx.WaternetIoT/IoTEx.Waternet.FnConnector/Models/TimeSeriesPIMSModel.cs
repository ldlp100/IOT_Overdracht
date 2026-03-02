using System;
using System.Collections.Generic;
using System.Text;

namespace IoTEx.Waternet.FnConnector.PIMS.Models
{
    public class TimeSeriesPIMSModel
    {
        public HeaderPIMSModel header { get; set; }
        public List<EventPIMSModel> events { get; set; }
    }
}
