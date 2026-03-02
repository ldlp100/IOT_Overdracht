using IoTEx.Waternet.Parser;

namespace IOT.METADATA.TIP_BUCKET_V1
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
        [MetaDataAttribute(Description = "Counter mm", Unit = IOT.METADATA.UNITS.UnitsEnum.mm, MemberIndex = 3)]
        enum COUNTER_MM
        {
            [MetaDataAttribute(Description = "LAST", Value = 5)]
            LAST

        }
        [MetaDataAttribute(Description = "Delta mm", Unit = IOT.METADATA.UNITS.UnitsEnum.mm, MemberIndex = 4)]
        enum DELTA_MM
        {
            [MetaDataAttribute(Description = "LAST", Value = 5)]
            LAST
        }

    }
    namespace INFO
    {

    }
}