using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using IoTEx.WaternetIoT.Model.Communication;

namespace IoTEx.WaternetIoT.Model.Device
{
    public class DeviceInfo
    {
        
        public string DeviceId { get; set; }
        public string Name { get; set; }
        public string SerialNR { get; set; }
        public string ParserClassName { get; set; }
        public string DeviceTypeName { get; set; }  
        public string AppKey { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string AssetUID { get; set; }
        public string NetworkUID { get; set; }
        
        public NetworkTypeEnum Network { get; set; }
        public List<IoTOutput> Outputs { get; set; }

        public string GetCode(string name, bool isStateAlert)
        {
            for (int i = 0; i < Outputs.Count; i++)
            {
                if (Outputs[i].Name == name && Outputs[i].IsStateAlert == isStateAlert)
                {
                    return Outputs[i].PC;
                }
            }
            return "";
        }
    }

}
