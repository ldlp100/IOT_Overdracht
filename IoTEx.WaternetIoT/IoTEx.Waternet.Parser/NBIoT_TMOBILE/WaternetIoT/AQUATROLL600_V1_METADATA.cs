using IoTEx.Waternet.Parser;

namespace IOT.METADATA.AQUATROLL600_V1
{
    
    namespace STATE
    {
                
    }

    namespace ALERT
    {

    }
    namespace MEASUREMENT
    {
        [MetaDataAttribute(Description = "Temperatuur in oC", Unit = IOT.METADATA.UNITS.UnitsEnum.oC, MemberIndex = 1)]
        enum TEMPERATUUR
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG

        }
        [MetaDataAttribute(Description = "Depth in mm", Unit = IOT.METADATA.UNITS.UnitsEnum.mm, MemberIndex =3)]
        enum DEPTH
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG
            
        }
        [MetaDataAttribute(Description = "Actual Conductivity in uS/cm", Unit = IOT.METADATA.UNITS.UnitsEnum.uS_per_cm, MemberIndex =5)]
        enum ACTUAL_CONDUCTIVITY
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG
        }
        [MetaDataAttribute(Description = "Special Conductivity in uS/cm", Unit = IOT.METADATA.UNITS.UnitsEnum.uS_per_cm, MemberIndex = 6)]
        enum SPECIAL_CONDUCTIVITY
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG
        }
        [MetaDataAttribute(Description = "Resistivity in ohm/cm", Unit = IOT.METADATA.UNITS.UnitsEnum.ohm_cm, MemberIndex = 7)]
        enum RESISTIVITY
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG
        }
        [MetaDataAttribute(Description = "Salinity in PSU", Unit = IOT.METADATA.UNITS.UnitsEnum.PSU, MemberIndex = 8)]
        enum SALINITY
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG
        }
        [MetaDataAttribute(Description = "Total Dissolved Solids in ppt", Unit = IOT.METADATA.UNITS.UnitsEnum.ppt, MemberIndex = 9)]
        enum TOTAL_DISSOLVED_SOLIDS
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG
        }
        [MetaDataAttribute(Description = "Density Of Water in g/cm3", Unit = IOT.METADATA.UNITS.UnitsEnum.g_per_cm3, MemberIndex = 10)]
        enum DENSITY_OF_WATER
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG
        }
        [MetaDataAttribute(Description = "Barometric Pressure mmHg", Unit = IOT.METADATA.UNITS.UnitsEnum.mmHg, MemberIndex = 11)]
        enum BAROMETRIC_PRESSURE
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG
        }
        [MetaDataAttribute(Description = "External Voltage in Volt", Unit = IOT.METADATA.UNITS.UnitsEnum.Volt, MemberIndex = 24)]
        enum EXT_VOLTAGE
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG
        }
        [MetaDataAttribute(Description = "Battery Capacity in %", Unit = IOT.METADATA.UNITS.UnitsEnum.pct, MemberIndex = 25)]
        enum BATTERY_CAPACITY
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG
        }
        [MetaDataAttribute(Description = "NitrateNO3-Concentration in mg/L", Unit = IOT.METADATA.UNITS.UnitsEnum.mg_per_L, MemberIndex = 29)]
        enum NITRATENO3_CONCENTRATION
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG
        }
        [MetaDataAttribute(Description = "NitrateNO3-mV ", Unit = IOT.METADATA.UNITS.UnitsEnum.mVolt, MemberIndex = 30)]
        enum NITRATENO3_MV
        {
            [MetaDataAttribute(Description = "AVG", Value = 0)]
            AVG
        }

    }
    namespace INFO
    {

    }
}