
using IoTEx.Waternet.Parser;

namespace IOT.METADATA.SODAQ_FLOW_METER_TEMP_V1_6
{
    public class DEFAULT
    {

    }
    namespace STATE
    {
        [MetaDataAttribute(Description = "Is Temperature Sensor On or off")]
        enum TEMP_SENSOR_ONOFF
        {
            [MetaDataAttribute(Description = "Sensor is switched ON", Value = 1)]
            ON,
            [MetaDataAttribute(Description = "Sensor is switched OFF", Value = 0)]
            OFF 
        }
        [MetaDataAttribute(Description = "Is Temperature Sensor On or off")]
        enum H1_SENSOR_ONOFF
        {
            [MetaDataAttribute(Description = "Sensor is switched ON", Value = 1)]
            ON,
            [MetaDataAttribute(Description = "Sensor is switched OFF", Value = 0)]
            OFF
        }
        [MetaDataAttribute(Description = "Is Temperature Sensor On or off")]
        enum H2_SENSOR_ONOFF
        {
            [MetaDataAttribute(Description = "Sensor is switched ON", Value = 1)]
            ON,
            [MetaDataAttribute(Description = "Sensor is switched OFF", Value = 0)]
            OFF
        }
        [MetaDataAttribute(Description = "Is Temperature Sensor On or off")]
        enum H3_SENSOR_ONOFF
        {
            [MetaDataAttribute(Description = "Sensor is switched ON", Value = 1)]
            ON,
            [MetaDataAttribute(Description = "Sensor is switched OFF", Value = 0)]
            OFF
        }

    }

    namespace MEASUREMENT
    {
        [MetaDataAttribute(Description = "Flow in m3/day", Unit = IOT.METADATA.UNITS.UnitsEnum.m3_per_day)]
        enum FLOW
        {
            [MetaDataAttribute(Description = "Actual value measured", Value = 0)]
            ACTUAL    
        }
        [MetaDataAttribute(Description = "mNAP Water level of down stream", Unit = IOT.METADATA.UNITS.UnitsEnum.mNAP)]
        enum NAP_LEVEL_DOWNSTREAM
        {
            [MetaDataAttribute(Description = "Actual value measured", Value = 0)]
            ACTUAL
        }
        [MetaDataAttribute(Description = "mNAP Water level of upstream", Unit = IOT.METADATA.UNITS.UnitsEnum.mNAP)]
        enum NAP_LEVEL_UPSTREAM
        {
            [MetaDataAttribute(Description = "Actual value measured", Value = 0)]
            ACTUAL
        }
        [MetaDataAttribute(Description = "mNAP Water level of plate", Unit = IOT.METADATA.UNITS.UnitsEnum.mNAP)]
        enum NAP_LEVEL_PLATE
        {
            [MetaDataAttribute(Description = "Actual value measured", Value = 0)]
            ACTUAL
        }
        [MetaDataAttribute(Description = "window height of water", Unit = IOT.METADATA.UNITS.UnitsEnum.m)]
        enum WATER_HEIGHT_OPENING
        {
            [MetaDataAttribute(Description = "Actual value measured", Value = 0)]
            ACTUAL
        }
        [MetaDataAttribute(Description = "Internal battery voltage", Unit = IOT.METADATA.UNITS.UnitsEnum.Volt)]
        enum INT_VOLTAGE
        {
            [MetaDataAttribute(Description = "Actual value measured", Value = 0)]
            ACTUAL
        }
        [MetaDataAttribute(Description = "External battery voltage", Unit = IOT.METADATA.UNITS.UnitsEnum.Volt)]
        enum EXT_VOLTAGE
        {
            [MetaDataAttribute(Description = "Actual value measured", Value = 0)]
            ACTUAL
        }
        [MetaDataAttribute(Description = "Water temperature in celsius", Unit = IOT.METADATA.UNITS.UnitsEnum.oC)]
        enum WATER_TEMPERATURE
        {
            [MetaDataAttribute(Description = "Actual value measured", Value = 0)]
            ACTUAL
        }
    }
    
    namespace INFO
    {
     
    }
     
}


