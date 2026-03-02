using IoTEx.Waternet.Parser;

namespace IOT.METADATA.PULSE_V1
{
    
    namespace STATE
    {
                
    }

    namespace ALERT
    {

    }
    namespace MEASUREMENT
    {
        [MetaDataAttribute(Description = "Counter", Unit = IOT.METADATA.UNITS.UnitsEnum.none, MemberIndex =1)]
        enum COUNTER
        {
            [MetaDataAttribute(Description = "LAST", Value = 5)]
            LAST
            
        }
        [MetaDataAttribute(Description = "Delta", Unit = IOT.METADATA.UNITS.UnitsEnum.none, MemberIndex =2)]
        enum DELTA
        {
            [MetaDataAttribute(Description = "LAST", Value = 5)]
            LAST
        }
        [MetaDataAttribute(Description = "CounterX", Unit = IOT.METADATA.UNITS.UnitsEnum.none, MemberIndex = 3)]
        enum COUNTERX
        {
            [MetaDataAttribute(Description = "LAST", Value = 5)]
            LAST

        }
        [MetaDataAttribute(Description = "DeltaX", Unit = IOT.METADATA.UNITS.UnitsEnum.none, MemberIndex = 4)]
        enum DELTAX
        {
            [MetaDataAttribute(Description = "LAST", Value = 5)]
            LAST
        }

    }
    namespace INFO
    {

    }
}