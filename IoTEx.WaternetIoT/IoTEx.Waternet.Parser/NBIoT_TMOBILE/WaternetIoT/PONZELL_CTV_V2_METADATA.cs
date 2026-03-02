using IoTEx.Waternet.Parser;

namespace IOT.METADATA.PONZELL_CTV_V2
{
    
    namespace STATE
    {
                
    }

    namespace ALERT
    {

    }
    namespace MEASUREMENT
    {
        [MetaDataAttribute(Description = "Temperature in oC", Unit = IOT.METADATA.UNITS.UnitsEnum.oC, MemberIndex =1)]
        enum TEMPERATURE
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG
            
        }
        [MetaDataAttribute(Description = "Conductivity CTZ in mS/cm", Unit = IOT.METADATA.UNITS.UnitsEnum.mS_per_cm, MemberIndex =2)]
        enum CONDUCTIVITY
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG
        }
        
        [MetaDataAttribute(Description = "Salinity in g/Kg", Unit = IOT.METADATA.UNITS.UnitsEnum.g_per_kg, MemberIndex = 3)]
        enum SALINITY
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG
        }        
        
    }
    namespace INFO
    {

    }
}