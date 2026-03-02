using IoTEx.Waternet.Parser;

namespace IOT.METADATA.KROHNE_WATERFLUX3070_EXT_PRESSURE_V1
{
    
    namespace STATE
    {
        [MetaDataAttribute(Description = "Error Warning states", MemberIndex = 11)]
        enum ERROR_WARNING_STATES
        {
            [MetaDataAttribute(Description = "No errors", Value = 0)]
            NO_ALARMS,
            [MetaDataAttribute(Description = "Active flow measurement warning condition", Value = 1)]
            FLOW_WARNING,
            [MetaDataAttribute(Description = "Active <10% battery condition", Value = 2)]
            LOW_BATTERY_10,
            [MetaDataAttribute(Description = "Active EEPROM error condition", Value = 4)]
            EEPROM_ERROR,
            [MetaDataAttribute(Description = "Active communication error condition", Value = 8)]
            COMM_ERROR,
            [MetaDataAttribute(Description = "Empty Pipe", Value = 16)]
            EMPTY_PIPE,
            [MetaDataAttribute(Description = "Mains Power Failure", Value = 32)]
            MAINS_POWER_FAILURE,

        }
        [MetaDataAttribute(Description = "Battery Type", MemberIndex = 12)]
        enum BATTERY_TYPE
        {
            [MetaDataAttribute(Description = "None Main Supply", Value = 0)]
            NONE_MAIN_SUPPLY,
            [MetaDataAttribute(Description = "Internal 1 battery", Value = 1)]
            INTERNAL1,
            [MetaDataAttribute(Description = "Internal 2 battery", Value = 2)]
            INTERNAL2,
            [MetaDataAttribute(Description = "External battery pack", Value = 3)]
            EXTERNAL
        }
        [MetaDataAttribute(Description = "Flow Direction", MemberIndex = 15)]
        enum FLOW_DIRECTION
        {
            [MetaDataAttribute(Description = "Forward Flow", Value = 0)]
            FORWARD,
            [MetaDataAttribute(Description = "Reverse Flow", Value = 1)]
            REVERSE,
            
        }
    }

    namespace ALERT
    {
        [MetaDataAttribute(Description = "Pressure Alarm State", MemberIndex = 9)]
        enum PRESSURE_ALARM
        {
            [MetaDataAttribute(Description = "No alarms", Value = 0)]
            NO_ALARMS,
            [MetaDataAttribute(Description = "Active minimum alarms condition", Value = 1)]
            ACTIVE_MIN_ALARMS,
            [MetaDataAttribute(Description = "Active maximum alarms condition", Value = 2)]
            ACTIVE_MAX_ALARMS,
            //[MetaDataAttribute(Description = "old unread minimum alarm condition", Value = 4)]
            //OLD_UNREAD_MIN_ALARMS,
            //[MetaDataAttribute(Description = "Old unread maximum alarm condition", Value = 8)]
            //OLD_UNREAD_MAX_ALARMS,
            //[MetaDataAttribute(Description = "Pressure sensor measurement error", Value = 16)]
            //MEASUREMENT_ERROR,

        }
        [MetaDataAttribute(Description = "Temperature Alarm State", MemberIndex = 10)]
        enum TEMPERATURE_ALARM
        {
            [MetaDataAttribute(Description = "No alarms", Value = 0)]
            NO_ALARMS,
            [MetaDataAttribute(Description = "Active minimum alarms condition", Value = 1)]
            ACTIVE_MIN_ALARMS,
            [MetaDataAttribute(Description = "Active maximum alarms condition", Value = 2)]
            ACTIVE_MAX_ALARMS,
            //[MetaDataAttribute(Description = "old unread minimum alarm condition", Value = 4)]
            //OLD_UNREAD_MIN_ALARMS,
            //[MetaDataAttribute(Description = "Old unread maximum alarm condition", Value = 8)]
            //OLD_UNREAD_MAX_ALARMS,
            //[MetaDataAttribute(Description = "Temperature sensor measurement error", Value = 16)]
            //MEASUREMENT_ERROR,

        }
    }
    namespace MEASUREMENT
    {
        [MetaDataAttribute(Description = "FlowSpeed in m/sec", Unit = IOT.METADATA.UNITS.UnitsEnum.m_per_s, MemberIndex =1)]
        enum FLOW_SPEED
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG
            
        }
        [MetaDataAttribute(Description = "VolumeFlow in m3/hr", Unit = IOT.METADATA.UNITS.UnitsEnum.m3_per_hour, MemberIndex =2)]
        enum VOLUME_FLOW
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG
        }        
        [MetaDataAttribute(Description = "Counter1 in m3", Unit = IOT.METADATA.UNITS.UnitsEnum.m3, MemberIndex = 3)]
        enum COUNTER1
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG,
            [MetaDataAttribute(Description = "LAST", Value = 5)]
            LAST
        }
        [MetaDataAttribute(Description = "Counter2 in m3", Unit = IOT.METADATA.UNITS.UnitsEnum.m3, MemberIndex = 4)]
        enum COUNTER2
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG,
            [MetaDataAttribute(Description = "LAST", Value = 5)]
            LAST
        }
        [MetaDataAttribute(Description = "TotalFlowVolume in m3", Unit = IOT.METADATA.UNITS.UnitsEnum.m3, MemberIndex = 5)]
        enum TOTAL_FLOW_VOL
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG,
            [MetaDataAttribute(Description = "LAST", Value = 5)]
            LAST

        }
        [MetaDataAttribute(Description = "ForwardFlowVolume in m3", Unit = IOT.METADATA.UNITS.UnitsEnum.m3, MemberIndex = 6)]
        enum FORWARD_FLOW_VOL
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG,
            [MetaDataAttribute(Description = "LAST", Value = 5)]
            LAST
        }
        [MetaDataAttribute(Description = "ReverseFlowVolume in m3", Unit = IOT.METADATA.UNITS.UnitsEnum.m3, MemberIndex = 7)]
        enum REVERSE_FLOW_VOL
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG,
            [MetaDataAttribute(Description = "LAST", Value = 5)]
            LAST
        }
        //[MetaDataAttribute(Description = "Pressure in mBar", Unit = IOT.METADATA.UNITS.UnitsEnum.mBar, MemberIndex = 8)]
        //enum PRESSURE
        //{
        //    [MetaDataAttribute(Description = "AVG", Value = 0)]
        //    AVG
        //}
        [MetaDataAttribute(Description = "BatteryCapacity in Ah", Unit = IOT.METADATA.UNITS.UnitsEnum.Ah, MemberIndex = 13)]
        enum BATTERY_CAPACITY
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG,
            [MetaDataAttribute(Description = "LAST", Value = 5)]
            LAST
        }
        [MetaDataAttribute(Description = "BatteryLeft in Ah", Unit = IOT.METADATA.UNITS.UnitsEnum.Ah, MemberIndex = 14)]
        enum BATTERY_LEFT
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG,
            [MetaDataAttribute(Description = "LAST", Value = 5)]
            LAST
        }
        [MetaDataAttribute(Description = "Pressure in Bar", Unit = IOT.METADATA.UNITS.UnitsEnum.Bar, MemberIndex = 1, SensorIndex =1)]
        enum PRESSURE
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG,
            [MetaDataAttribute(Description = "MIN", Value = 1)]
            MIN,
            [MetaDataAttribute(Description = "MAX", Value = 2)]
            MAX,
            [MetaDataAttribute(Description = "LAST", Value = 5)]
            LAST
        }
        [MetaDataAttribute(Description = "Temperature in oC", Unit = IOT.METADATA.UNITS.UnitsEnum.oC, MemberIndex = 2, SensorIndex = 1)]
        enum TEMPERATURE
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG,
            [MetaDataAttribute(Description = "MIN", Value = 1)]
            MIN,
            [MetaDataAttribute(Description = "MAX", Value = 2)]
            MAX,
            [MetaDataAttribute(Description = "LAST", Value = 5)]
            LAST
        }
        [MetaDataAttribute(Description = "NAP Corrected Pressure in Bar", Unit = IOT.METADATA.UNITS.UnitsEnum.Bar, MemberIndex = 99)]
        enum NAP_CORRECTED_PRESSURE
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG,
            [MetaDataAttribute(Description = "MIN", Value = 1)]
            MIN,
            [MetaDataAttribute(Description = "MAX", Value = 2)]
            MAX,
            [MetaDataAttribute(Description = "LAST", Value = 5)]
            LAST
        }
    }
    namespace INFO
    {

    }
}