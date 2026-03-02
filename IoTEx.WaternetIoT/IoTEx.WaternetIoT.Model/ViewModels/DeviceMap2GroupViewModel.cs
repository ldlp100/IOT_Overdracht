using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class GEOJSON
    {
        public string type { get; set; }
        public GEOMETRY geometry { get; set; }
        public Dictionary<string, string> properties { get; set; }

        public class GEOMETRY
        {
            public string type { get; set; }
            public double[] coordinates { get; set; }
        
        }
                
        
        public GEOJSON()
        {

        }
        public GEOJSON(DeviceModel device)
        {
            type = "Feature";
            geometry = new GEOMETRY();
            geometry.coordinates = new double[2];
            geometry.coordinates[0] = device.Long;
            geometry.coordinates[1] = device.Lat;
            geometry.type = "Position";
            properties = new Dictionary<string, string>();
            properties.Add("AUID", device.AssetUID);
            properties.Add("ID", device.Id.ToString());
            properties.Add("ACTIVE", device.IsActive.ToString());


        }

    }
}   