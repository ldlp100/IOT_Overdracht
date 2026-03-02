using IoTEx.Waternet.Parser;

namespace IOT.METADATA.IOT_DEVICE_GENERIC_V2
{
    
    namespace STATE
    {
                
    }

    namespace ALERT
    {

    }
    namespace MEASUREMENT
    {
        [MetaDataAttribute(Description = "IoT DEVICE Voltage in Volt", Unit = IOT.METADATA.UNITS.UnitsEnum.Volt)]
        enum IOTDEVICE_VOLT
        {
            [MetaDataAttribute(Description = "LAST", Value = 5)]
            LAST,
            
        }
        [MetaDataAttribute(Description = "IoT DEVICE Voltage in Volt", Unit = IOT.METADATA.UNITS.UnitsEnum.none)]
        enum IOTDEVICE_COUNTER
        {            
            [MetaDataAttribute(Description = "LAST", Value = 5)]
            LAST,
            
        }


    }
    namespace INFO
    {

    }
}