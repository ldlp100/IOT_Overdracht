using IoTEx.Waternet.Parser;

namespace IOT.METADATA.IOT_DEVICE_GENERIC_V1
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
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG,
            
        }
        [MetaDataAttribute(Description = "IoT DEVICE Voltage in Volt", Unit = IOT.METADATA.UNITS.UnitsEnum.Volt)]
        enum IOTDEVICE_RESET
        {
            
            [MetaDataAttribute(Description = "SUM", Value = 3)]
            SUM,
            
        }


    }
    namespace INFO
    {

    }
}