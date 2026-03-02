using IoTEx.Waternet.Parser;

namespace IOT.METADATA.ELSYS_V1
{

    public class DEFAULT
    {

    }
    
    namespace STATE
    {
        //public static string ALERT_PERSISTENCE_FLOW_STOP_IN_PROGRESS = "PERSISTENCE_FLOW_STOP_IN_PROGRESS";
        [MetaDataAttribute(Description = "The module has detected a flow persistence and depending on the flow and the duration it could be a leak presumption")]
        public enum OCCUPANCY
        {
            [MetaDataAttribute(Description = "Nobody Behind Desk", Value = 0)]
            NOBODY,
            [MetaDataAttribute(Description = "entering,leaving)", Value = 1)]
            PENDING,
            [MetaDataAttribute(Description = "Occupied", Value = 2)]
            OCCUPIED,
            
        }
        
    }

    namespace ALERT
    {
        


    }
    namespace MEASUREMENT
    {
        [MetaDataAttribute(Description = "Sound level", Unit = IOT.METADATA.UNITS.UnitsEnum.dB)]
        enum SOUND_LEVEL
        {
            [MetaDataAttribute(Description = "Peak Value")]
            PEAK,
            [MetaDataAttribute(Description = "Average Value")]
            AVG

        }
       

        [MetaDataAttribute(Description = "Battery level", Unit = IOT.METADATA.UNITS.UnitsEnum.Volt )]
        enum VDD
        {
            [MetaDataAttribute(Description = "Actual Value")]
            ACTUAL
        }
        [MetaDataAttribute(Description = "Temperature", Unit = IOT.METADATA.UNITS.UnitsEnum.oC)]
        enum TEMPERATURE
        {
            [MetaDataAttribute(Description = "Actual Value")]
            ACTUAL
        }
        [MetaDataAttribute(Description = "Humidity", Unit = IOT.METADATA.UNITS.UnitsEnum.pct)]
        enum HUMIDITY
        {
            [MetaDataAttribute(Description = "Actual Value")]
            ACTUAL
        }
        [MetaDataAttribute(Description = "Light in Lux", Unit = IOT.METADATA.UNITS.UnitsEnum.lux)]
        enum LIGHT
        {
            [MetaDataAttribute(Description = "Actual Value")]
            ACTUAL
        }
        [MetaDataAttribute(Description = "Number of motion count", Unit = IOT.METADATA.UNITS.UnitsEnum.none)]
        enum MOTION
        {
            [MetaDataAttribute(Description = "Actual Value")]
            ACTUAL
        }
        

    }
    namespace INFO
    {
        
    }
}