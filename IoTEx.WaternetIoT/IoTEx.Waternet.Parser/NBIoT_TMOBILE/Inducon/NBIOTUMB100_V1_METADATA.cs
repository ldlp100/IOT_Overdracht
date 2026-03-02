using IoTEx.Waternet.Parser;

namespace IOT.METADATA.NBIOTUMB100_V1
{
    public class DEFAULT
    {

    }
    namespace STATE
    {
        [MetaDataAttribute(Description = "Define the type of the precipitation measured by the radar")]
        enum PRECIPITATION_TYPE
        {
            [MetaDataAttribute(Description = "No Rain", Value = 0)]
            NONE = 0,
            [MetaDataAttribute(Description = "Mix of snow and rain", Value = 69)]
            SLEET = 69,
            [MetaDataAttribute(Description = "Freezing Rain", Value = 67)]
            FREEZING_RAIN = 67,
            [MetaDataAttribute(Description = "Normal Rain", Value = 60)]
            RAIN = 60,
            [MetaDataAttribute(Description = "Ice Pellet", Value = 90)]
            HAIL = 90,
            [MetaDataAttribute(Description = "Snow", Value = 70)]
            SNOW = 70,
        }
        
    }

    namespace ALERT
    {

    }
    namespace MEASUREMENT
    {
        [MetaDataAttribute(Description = "Amount of Rain in mm", Unit = IOT.METADATA.UNITS.UnitsEnum.mm)]
        enum PRECIPITATION
        {
            [MetaDataAttribute(Description = "Absolute Value")]
            ABSOLUTE,
            [MetaDataAttribute(Description = "Delta Value")]
            DELTA,
        }

        [MetaDataAttribute(Description = "Amount of Rain in mm per hour", Unit = IOT.METADATA.UNITS.UnitsEnum.mm_per_hour)]
        enum PRECIPITATION_PER_HOUR
        {   
            [MetaDataAttribute(Description = "Sum of the precipitation value")]
            SUM,
        }
        
        
        [MetaDataAttribute(Description = "Air Pressure ", Unit = IOT.METADATA.UNITS.UnitsEnum.hPascal)]
        enum AIR_PRESSURE
        {
            [MetaDataAttribute(Description = "ACTUAL ", Value = 0)]
            ACTUAL
        }
        
    }
    namespace INFO
    {

    }
}