using IoTEx.Waternet.Parser;

namespace IOT.METADATA.LEIDUIN_WARMTEWISSELAAR_V2
{
    
    namespace STATE
    {
        
    }

    namespace ALERT
    {
      

    }
    namespace MEASUREMENT
    {
        [MetaDataAttribute(Description = "Pressure Sensor1 in mBar", Unit = IOT.METADATA.UNITS.UnitsEnum.mBar, MemberIndex = 1, SensorIndex =0)]
        enum SENSOR1_PRESSURE
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG

        }
        [MetaDataAttribute(Description = "Pressure Sensor2 in mBar", Unit = IOT.METADATA.UNITS.UnitsEnum.mBar, MemberIndex = 1, SensorIndex = 1)]
        enum SENSOR2_PRESSURE
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG

        }
        [MetaDataAttribute(Description = "Device Temperature in  oC", Unit = IOT.METADATA.UNITS.UnitsEnum.oC, MemberIndex = 4, SensorIndex = 0)]
        enum DEVICE_TEMPERATURE
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG

        }
        [MetaDataAttribute(Description = "Temperature Sensor1 in oC", Unit = IOT.METADATA.UNITS.UnitsEnum.oC, MemberIndex = 1, SensorIndex = 2)]
        enum SENSOR1_TEMPERATURE
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG

        }
        [MetaDataAttribute(Description = "Temperature Sensor2 in oC", Unit = IOT.METADATA.UNITS.UnitsEnum.oC, MemberIndex = 1, SensorIndex = 3)]
        enum SENSOR2_TEMPERATURE
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG

        }

        [MetaDataAttribute(Description = "Meter1-FlowSpeed in m/s", Unit = IOT.METADATA.UNITS.UnitsEnum.m_per_s, MemberIndex =1, SensorIndex = 4)]
        enum METER1_FLOW_SPEED
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG
            
        }
        [MetaDataAttribute(Description = "Meter1-ForwardFlowVolume in m3", Unit = IOT.METADATA.UNITS.UnitsEnum.m3, MemberIndex = 6, SensorIndex = 4)]
        enum METER1_FORWARD_FLOW_VOL
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG,
            
        }


        [MetaDataAttribute(Description = "Meter1-Pressure in Bar", Unit = IOT.METADATA.UNITS.UnitsEnum.Bar, MemberIndex = 16, SensorIndex = 4)]
        enum METER1_PRESSURE
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG,
        }
        
        [MetaDataAttribute(Description = "Meter1-Temperature in oC", Unit = IOT.METADATA.UNITS.UnitsEnum.oC, MemberIndex = 17, SensorIndex = 4)]
        enum METER1_TEMPERATURE
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG
        }

        [MetaDataAttribute(Description = "Meter2-FlowSpeed in m/s", Unit = IOT.METADATA.UNITS.UnitsEnum.m_per_s, MemberIndex = 1, SensorIndex = 5)]
        enum METER2_FLOW_SPEED
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG

        }
        [MetaDataAttribute(Description = "Meter2-ForwardFlowVolume in m3", Unit = IOT.METADATA.UNITS.UnitsEnum.m3, MemberIndex = 6, SensorIndex = 5)]
        enum METER2_FORWARD_FLOW_VOL
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG           
        }


        [MetaDataAttribute(Description = "Meter2-Pressure in Bar", Unit = IOT.METADATA.UNITS.UnitsEnum.Bar, MemberIndex = 16, SensorIndex = 5)]
        enum METER2_PRESSURE
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG
        }

        [MetaDataAttribute(Description = "Meter2-Temperature in oC", Unit = IOT.METADATA.UNITS.UnitsEnum.oC, MemberIndex = 17, SensorIndex = 5)]
        enum METER2_TEMPERATURE
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG
        }
    }
    namespace INFO
    {

    }
}