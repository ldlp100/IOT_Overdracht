using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IoTEx.WaternetIoT.Model.PortalModels
{
    [Table("WAT_BOSWACHTER")]
    public class BosWachterModel : BaseModel
    {

        [Column("LAT")]
        public double Latitude { get; set; }
        [Column("LNG")]
        public double Longitude { get; set; }
        [Column("BGRONDWATER")]
        public bool BeginGrondwaterbeschermingsgebied { get; set; }
        [Column("BWATERWINGGEBIED")]
        public bool BeginWaterwingebied { get; set; }
        [Column("ONDERBORD")]
        public bool Onderbord { get; set; }
        [Column("DESCR")]
        public string? Description { get; set; }

        [Column("VUILNISBAKKEN")]
        public bool Vuilnisbakken { get; set; }
        [Column("BANKEN")]
        public bool Banken { get; set; }
        [Column("EGRONDWATER")]
        public bool EindGrondwaterbeschermingsgebied { get; set; }
        [Column("EWATERWINGGEBIED")]
        public bool EindWaterwingebied { get; set; }

    }
}