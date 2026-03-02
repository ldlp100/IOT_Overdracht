using System;
using System.Collections.Generic;
using System.Text;

namespace IoTEx.Waternet.Model.PIMS
{
    public class TimeSeriesPIMSModel
    {
        public HeaderPIMSModel header { get; set; }
        public List<EventPIMSModel> events { get; set; }
    }
}
