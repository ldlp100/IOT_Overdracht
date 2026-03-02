using IoTEx.Waternet.Parser;

namespace IOT.METADATA.WATER_LEVEL_KELLER36_V1
{
    
    namespace STATE
    {
                
    }

    namespace ALERT
    {

    }
    namespace MEASUREMENT
    {
        [MetaDataAttribute(Description = "Sensor Pressure in mBar", Unit = IOT.METADATA.UNITS.UnitsEnum.mBar, MemberIndex = 1)]
        enum SENSOR_PRESSURE
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG

        }

        [MetaDataAttribute(Description = "Sensor Temperature in oC", Unit = IOT.METADATA.UNITS.UnitsEnum.oC, MemberIndex =2)]
        enum SENSOR_TEMPERATURE
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG
            
        }
        [MetaDataAttribute(Description = "Device Pressure in mBar", Unit = IOT.METADATA.UNITS.UnitsEnum.mBar, MemberIndex = 3)]
        enum DEVICE_PRESSURE
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG

        }
        [MetaDataAttribute(Description = "Device Temperature in oC", Unit = IOT.METADATA.UNITS.UnitsEnum.oC, MemberIndex = 4)]
        enum DEVICE_TEMPERATURE
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG

        }
        [MetaDataAttribute(Description = "Delta Pressure in mBar", Unit = IOT.METADATA.UNITS.UnitsEnum.mBar, MemberIndex = 5)]
        enum DELTA_PRESSURE
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG

        }
        [MetaDataAttribute(Description = "Level in mm", Unit = IOT.METADATA.UNITS.UnitsEnum.mm, MemberIndex = 6)]
        enum LEVEL
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG

        }


    }
    namespace INFO
    {

    }
}