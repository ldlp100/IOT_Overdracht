using IoTEx.Waternet.Parser;

namespace IOT.METADATA.KROHNE_OPTIWAVE_1400_V1
{
    
    namespace STATE
    {
        
    }

    namespace ALERT
    {
        [MetaDataAttribute(Description = "Alert Error states", MemberIndex = 10)]
        enum ERROR_WARNING_ALERTS
        {
            [MetaDataAttribute(Description = "No errors", Value = 0)]
            NO_ALARMS,
            [MetaDataAttribute(Description = "Sensor error", Value = 1)]
            SENSOR_ERROR,
            [MetaDataAttribute(Description = "Configuration error", Value = 2)]
            CONFIG_ERROR
        }
    }
    namespace MEASUREMENT
    {
        [MetaDataAttribute(Description = "Current in mA", Unit = IOT.METADATA.UNITS.UnitsEnum.mA, MemberIndex =1)]
        enum CURRENT
        {
            [MetaDataAttribute(Description = "LAST", Value = 5)]
            LAST
            
        }
        [MetaDataAttribute(Description = "Distance in mm", Unit = IOT.METADATA.UNITS.UnitsEnum.mm, MemberIndex =2)]
        enum DISTANCE
        {
            [MetaDataAttribute(Description = "LAST", Value = 5)]
            LAST
        }        
        
    }
    namespace INFO
    {

    }
}