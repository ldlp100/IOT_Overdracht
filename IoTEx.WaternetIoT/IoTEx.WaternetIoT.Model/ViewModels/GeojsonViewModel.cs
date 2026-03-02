using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using IoTEx.WaternetIoT.Model.PortalModels;
using IoTEx.WaternetIoT.Model.ViewModels;
using static IoTEx.WaternetIoT.Model.ViewModels.GEOJSON;

namespace IoTEx.WaternetIoT.Model.ViewModels
{
    public class GeojsonViewModel
    {
        public string type { get; set; }
        public GEOMETRY geometry { get; set; }
        //public Dictionary<string, string> properties { get; set; }


        public static Dictionary<string, string> DefineMapper()
        {
            Dictionary<string, string> mapper = new Dictionary<string, string>();
            
            return mapper; 
        }
        public GeojsonViewModel()
        {
            
        }
        //public GeojsonViewModel(ParserModel parser)
        //{

        //    type = "Feature";
        //    geometry = new GEOMETRY();
        //    geometry.coordinates = new double[2];
        //    geometry.coordinates[0] = device.Long;
        //    AssetUID = (model.Device != null) ? model.Device.AssetUID : "";
        //    geometry.coordinates[1] = device.Lat;
        //    geometry.type = "Position";
        //    properties = new Dictionary<string, string>();
        //    properties.Add("AUID", device.AssetUID);
        //    properties.Add("ID", device.Id.ToString());
        //    properties.Add("ACTIVE", device.IsActive.ToString());
        //}
    }
    
}

//public class GEOMETRY
//{
//    public string type { get; set; }
//    public double[] coordinates { get; set; }
//}