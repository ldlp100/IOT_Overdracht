using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using IoTEx.WaternetIoT.Model.Communication;

namespace IoTEx.WaternetIoT.Model.Device
{
    public class IoTOutput
    {
        public string Name { get; set; }
        public string PC { get; set; }
        public bool IsStateAlert { get; set; }

    }

}
