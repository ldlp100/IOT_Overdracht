using IoTEx.Waternet.Parser;

namespace IOT.METADATA.UNITS
{
    public enum UnitsEnum
    {
        [MetaDataAttribute(Description = "Decibel", Name = "dB")]
        dB,
        [MetaDataAttribute(Description = "Height meter Water Column", Name = "mWC")]
        m_WC,
        [MetaDataAttribute(Description = "Power in kiloWatt", Name = "kW")]
        kWatt,
        [MetaDataAttribute(Description = "Degree ARC", Name = "oArc")]
        oArc,
        [MetaDataAttribute(Description = "Rain Precipitation mm Per Hour", Name = "mm/hr")]
        mm_per_hour,
        [MetaDataAttribute(Description = "Flow in m3 per hour", Name = "m3/hr")]
        m3_per_hour,
        [MetaDataAttribute(Description = "String Information", Name = "STRING")]
        STRING,
        [MetaDataAttribute(Description = "Length in Meter", Name = "m")]
        m,
        [MetaDataAttribute(Description = "Flow in m3 per Day", Name = "m3/day")]
        m3_per_day,
        [MetaDataAttribute(Description = "Conductivity milliSiemens per cm", Name = "mS/cm")]
        mS_per_cm,
        [MetaDataAttribute(Description = "Area in Square Meter", Name = "m2")]
        m2,
        [MetaDataAttribute(Description = "Watt: power, radiant flux", Name = "W")]
        Watt,
        [MetaDataAttribute(Description = "Height in meter in relation to NAP", Name = "mNAP")]
        mNAP,
        [MetaDataAttribute(Description = "Temperature in Degree Celsuis", Name = "oC")]
        oC,
        [MetaDataAttribute(Description = "Height millimeter Water Column", Name = "mm WC")]
        mm_WC,
        [MetaDataAttribute(Description = "Resistivity in ohm cm", Name = "ohm cm")]
        ohm_cm,
        [MetaDataAttribute(Description = "Conductivity micro Siemens per cm", Name = "uS/cm")]
        uS_per_cm,
        [MetaDataAttribute(Description = "Flow in m3 per seconds", Name = "m3/s")]
        m3_per_sec,
        [MetaDataAttribute(Description = "Pressure hecto Pascal", Name = "hPa")]
        hPascal,
        [MetaDataAttribute(Description = "Salinity g per kg", Name = "g/kg")]
        g_per_kg,
        [MetaDataAttribute(Description = "milliwatt", Name = "mW")]
        mW,
        [MetaDataAttribute(Description = "Hertz", Name = "Hz")]
        Hz,
        [MetaDataAttribute(Description = "Barometer pressure in mm of Mercury", Name = "mmHg")]
        mmHg,
        [MetaDataAttribute(Description = "Volume in m3", Name = "m3")]
        m3,
        [MetaDataAttribute(Description = "Speed in Meter per Second", Name = "m/s")]
        m_per_s,
        [MetaDataAttribute(Description = "Concentration mg per L", Name = "mg/L")]
        mg_per_L,
        [MetaDataAttribute(Description = "Lengte in Millimeter", Name = "mm")]
        mm,
        [MetaDataAttribute(Description = "no unit", Name = "none")]
        none,
        [MetaDataAttribute(Description = "Volume in Gallon", Name = "gal")]
        Gallon,
        [MetaDataAttribute(Description = "milli Amper", Name = "mA")]
        mA,
        [MetaDataAttribute(Description = "Voltage in mV", Name = "mV")]
        mVolt,
        [MetaDataAttribute(Description = "Density in g/cm3", Name = "g/cm3")]
        g_per_cm3,
        [MetaDataAttribute(Description = "Parts per notation", Name = "ppt")]
        ppt,
        [MetaDataAttribute(Description = "Pressure in Bar", Name = "Bar")]
        Bar,
        [MetaDataAttribute(Description = "Pressure in Milli bar", Name = "mBar")]
        mBar,
        [MetaDataAttribute(Description = "Volume in ft3", Name = "ft3")]
        ft3,
        [MetaDataAttribute(Description = "Percentage", Name = "%")]
        pct,
        [MetaDataAttribute(Description = "Lux: derived unit of illuminance and luminous emittance, measuring luminous flux per unit area", Name = "lx")]
        lux,
        [MetaDataAttribute(Description = "Flow Liter per  hour", Name = "l/hr")]
        Liter_per_hour,
        [MetaDataAttribute(Description = "Volume in Liter", Name = "L")]
        Liter,
        [MetaDataAttribute(Description = "Flow Gallon per minute", Name = "gal/min")]
        Gallon_per_min,
        [MetaDataAttribute(Description = "The Voltage in V", Name = "V")]
        Volt,
        [MetaDataAttribute(Description = "Ampere Hours", Name = "Ah")]
        Ah,
        [MetaDataAttribute(Description = "Practical Salinity Unit", Name = "PSU")]
        PSU,
    }
}
//namespace IOT.METADATA.UNITS
//{
//    public enum UnitsEnum {
//        [MetaDataAttribute(Description = "Length in meter")]
//        m,
//        [MetaDataAttribute(Description = "Length in mm")]
//        mm,
//        [MetaDataAttribute(Description = "Area in square meter")]
//        m2,
//        [MetaDataAttribute(Description = "Volume in m3")]
//        m3,
//        [MetaDataAttribute(Description = "Volume in L")]
//        L,
//        [MetaDataAttribute(Description = "Flow mm per hour")]
//        mm_per_hour,
//        [MetaDataAttribute(Description = "Flow m3 per hour")]
//        m3_per_hour,
//        [MetaDataAttribute(Description = "Flow m3 per day")]
//        m3_per_day,
//        [MetaDataAttribute(Description = "Flow liters per hour")]
//        L_per_hour,

//        [MetaDataAttribute(Description = "Height in meter NAP")]
//        mNAP,
//        [MetaDataAttribute(Description = "Temperature in oC")]
//        oC,
//        [MetaDataAttribute(Description = "Voltage in V")]
//        V,
//        [MetaDataAttribute(Description = "Voltage in mV")]
//        mV,
//        [MetaDataAttribute(Description = "Percentage")]
//        pct,
//        [MetaDataAttribute(Description = "Height in mm of Water Column")]
//        mmWC,
//        [MetaDataAttribute(Description = "Position in degree")]
//        deg,
//        [MetaDataAttribute(Description = "Pressure in hecto Pascal")]
//        hPa,
//        [MetaDataAttribute(Description = "Frequentie in hz")]
//        Hz,
//        [MetaDataAttribute(Description = "Unit less Index")]
//        Index,
//        [MetaDataAttribute(Description = "Unit less Counter")]
//        Count,
//        [MetaDataAttribute(Description = "Amount of Lux to measure light")]
//        Lux,
//        [MetaDataAttribute(Description = "Conductivity micro Siemens per cm")]
//        uS_per_cm,
//        [MetaDataAttribute(Description = "Practical Salinity Unit")]
//        PSU,
//        [MetaDataAttribute(Description = "Parts per notation")]
//        ppt,
//        [MetaDataAttribute(Description = "Density in g/cm3")]
//        g_per_cm3,
//        [MetaDataAttribute(Description = "Barometer pressure in mm of Mercury")]
//        mmHg,
//        [MetaDataAttribute(Description = "Barometer pressure in mm of Mercury")]
//        mg_per_L,
//        [MetaDataAttribute(Description = "Resistivity in ohm cm")]
//        ohm_cm,
//        [MetaDataAttribute(Description = "Decibel")]
//        dB
//    }
//}
namespace IOT.DEVICETYPE.KAMSTRUP_WATER_METER_V1_0.STATE
{
    public enum KM_BURST_HISTORY { HOURS505 = 7, HOURS337TO504 = 6, HOURS25TO72 = 3, HOURS169TO336 = 5, HOURS73TO168 = 4, HOURS1TO2 = 1, HOUR0 = 0, HOURS9TO24 = 2 }
    public enum KM_ALERT { LEAK = 4, BURST = 3, DRY = 1, REV = 2 }
    public enum ALERTONOFF { OFF = 0, ON = 1 }
    public enum KM_HISTORY { HOURS505 = 7, HOURS9TO24 = 2, HOURS169TO336 = 5, HOUR0 = 0, HOURS25TO72 = 3, HOURS73TO168 = 4, HOURS1TO2 = 1, HOURS337TO504 = 6 }
    public enum KM_LEAK_HISTORY { HOURS73TO168 = 4, HOURS505 = 7, HOURS25TO72 = 3, HOURS337TO504 = 6, HOURS9TO24 = 2, HOURS169TO336 = 5, HOURS1TO2 = 1 }
    public enum KM_REVERSE_HISTORY { HOURS505 = 7, HOURS169TO336 = 5, HOURS337TO504 = 6, HOUR0 = 0, HOURS9TO24 = 2, HOURS73TO168 = 4, HOURS1TO2 = 1, HOURS25TO72 = 3 }
    public enum KM_DRY_HISTORY { HOUR0 = 0, HOURS169TO336 = 5, HOURS9TO24 = 2, HOURS1TO2 = 1, HOURS73TO168 = 4, HOURS505 = 7, HOURS25TO72 = 3, HOURS337TO504 = 6 }
}
namespace IOT.DEVICETYPE.KAMSTRUP_WATER_METER_V1_0.ALERT
{
    public enum KM_ALERT { LEAK = 4, BURST = 3, DRY = 1, REV = 2 }
    public enum ALERTONOFF { OFF = 0, ON = 1 }
}
namespace IOT.DEVICETYPE.KAMSTRUP_WATER_METER_V1_0.MEASUREMENT
{
    public enum VOLUME_IN_GAL { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
    public enum FLOW_IN_L_PER_HR { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
    public enum VOLUME_IN_M3 { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
    public enum FLOW_IN_GPM { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
    public enum VOLUME_IN_FT3 { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
}
//namespace IOT.DEVICETYPE.NBIOTUMB100_V1_0.STATE
//{
//    public enum PRECIPITATION_TYPE { SLEET = 69, FREEZING_RAIN = 67, NONE = 0, RAIN = 60, HAIL = 90, SNOW = 70 }
//}
//namespace IOT.DEVICETYPE.NBIOTUMB100_V1_0.MEASUREMENT
//{
//    public enum PRECIPITATION_DELTA { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum PRECIPITATION_PER_HOUR { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum BAROMETER { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum PRECIPITATION_ABS { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//}
namespace IOT.DEVICETYPE.RIOOL_WATER_NIVEAU_V1_0.MEASUREMENT
{
    public enum VOLTAGE_IN_V { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
    public enum BAROMETER { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
    public enum WATER_HOOGTE_IN_RIOOL { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
}
////namespace IOT.DEVICETYPE.NBIOTWAVE_V1_0.MEASUREMENT
////{
////    public enum PRESSURE_IN_MMWC { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
////    public enum VOLTAGE_IN_V { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
////    public enum TEMPERATURE { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
////    public enum HUMIDITY { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
////}
////namespace IOT.DEVICETYPE.MCS108_V1_0.MEASUREMENT
//{
//    public enum VIBRATION_AMP { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum ANGLE_Y { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum LONGITUDE { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum HUMIDITY { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum ANGLE_X { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum ANGLE_Z { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum LATITUDE { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum TEMPERATURE { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum BAROMETER { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VIBRATION_FREQ { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//}
//namespace IOT.DEVICETYPE.SODAQ_4X4_20_FLOW_METER_TEMP_V1_3.STATE
//{
//    public enum H3_ONOFF { OFF = 1, ON = 0 }
//    public enum T_ONOFF { OFF = 1, ON = 0 }
//    public enum H1_ONOFF { OFF = 0, ON = 1 }
//    public enum ON_12VOLT { OFF = 0, ON = 1 }
//    public enum H2_ONOFF { ON = 1, OFF = 0 }
//}
//namespace IOT.DEVICETYPE.SODAQ_4X4_20_FLOW_METER_TEMP_V1_3.MEASUREMENT
//{
//    public enum VOEDING_BATTERIJ { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VOEDING_SOURCE { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum WATER_TEMPERATUUR { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum NIVEAU_STUWBLADHOOGTE { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum NIVEAU_BOVENSTROOMS { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum DEBIET { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum NIVEAU_BENEDENSTROOMS { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//}
//namespace IOT.DEVICETYPE.SM_ITRON_CYBLEIOT_V1_0.MEASUREMENT
//{
//    public enum VOL_HOUR_MIN07 { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VOL_HOUR_MIN10 { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VOL_HOUR_MIN12 { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VOL_HOUR_MIN04 { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VOL_HOUR_MIN17 { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum PREVIOUS_DAY_BACKFLOW_NUM_ALTERNATIONS { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VOL_HOUR_MIN20 { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VOL_HOUR_MIN24 { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum PREVIOUS_DAY_NON_ZEROMIN_FLOW { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum PREVIOUS_DAY_BACKFLOW_CUM_VOL { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VOL_HOUR_MIN19 { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VOL_HOUR_MIN13 { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VOL_HOUR_MIN15 { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum MIDNIGHT_INDEX { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VOL_HOUR_MIN22 { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VOL_HOUR_MIN06 { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VOL_HOUR_MIN21 { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VOL_HOUR_MIN09 { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VOL_HOUR_MIN03 { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VOL_HOUR_MIN14 { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum PULSEWEIGHT { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum CUM_POS_24_HOURS { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VOL_HOUR_MIN11 { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum PREVIOUS_DAY_MAX_FLOW { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VOL_HOUR_MIN02 { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum CUM_NEG_24_HOURS { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VOL_HOUR_MIN08 { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VOL_HOUR_MIN23 { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VOL_HOUR_MIN18 { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VOL_HOUR_MIN01 { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VOL_HOUR_MIN05 { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VOL_HOUR_MIN16 { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//}
namespace IOT.DEVICETYPE.RIOOL_OPVANG_BAAK_NIVEAU_MET_KLEP_V1_0.STATE
{
    public enum BIN_VALVE_STATE { OFF = 0, ON = 1 }
}
namespace IOT.DEVICETYPE.RIOOL_OPVANG_BAAK_NIVEAU_MET_KLEP_V1_0.MEASUREMENT
{
    public enum WATER_HOOGTE_IN_RIOOL { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
    public enum VOLTAGE_IN_V { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
    public enum BAROMETER { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
}
//OLD CODE
//namespace IOT.STATE
//{
//    public enum KM_BURST_HISTORY { HOURS505 = 7, HOURS73TO168 = 4, HOURS169TO336 = 5, HOURS9TO24 = 2, HOURS25TO72 = 3, HOURS1TO2 = 1, HOURS337TO504 = 6, HOUR0 = 0 }
//    public enum KM_LEAK_HISTORY { HOURS505 = 7, HOURS73TO168 = 4, HOURS169TO336 = 5, HOURS9TO24 = 2, HOURS25TO72 = 3, HOURS1TO2 = 1, HOURS337TO504 = 6, HOUR0 = 0 }
//    public enum BIN_VALVE_STATE { ON = 2, OFF = 1 }
//    public enum KM_REVERSE_HISTORY { HOURS505 = 7, HOURS73TO168 = 4, HOURS169TO336 = 5, HOURS9TO24 = 2, HOURS25TO72 = 3, HOURS1TO2 = 1, HOURS337TO504 = 6, HOUR0 = 0 }
//    public enum KM_HISTORY { HOURS505 = 7, HOURS73TO168 = 4, HOURS169TO336 = 5, HOURS9TO24 = 2, HOURS25TO72 = 3, HOURS1TO2 = 1, HOURS337TO504 = 6, HOUR0 = 0 }
//    public enum MS_MOVING_STATE { VIBRATION_DETECTED = 8, OBJECT_STOPPED = 4, OBJECT_MOVING = 2, START_MESSAGE = 1 }
//    public enum KM_DRY_HISTORY { HOURS505 = 7, HOURS73TO168 = 4, HOURS169TO336 = 5, HOURS9TO24 = 2, HOURS25TO72 = 3, HOURS1TO2 = 1, HOURS337TO504 = 6, HOUR0 = 0 }
//}
//namespace IOT.ALERT
//{
//    public enum ALERTONOFF { ON = 1, OFF = 0 }
//    public enum KM_ALERT { LEAK = 4, REV = 2, BURST = 3, DRY = 1 }
//}
//namespace IOT.MEASUREMENT
//{
//    public enum DISTANCE2_IN_M { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum ORIENTATION_Y { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum ORIENTATION_Z { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum ANGLE_Y { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VOLUME_IN_FT3 { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VIBRATION_FREQ { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VOLUME_IN_GAL { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum FLOW_IN_GPM { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum ANGLE_X { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum WATER_HOOGTE_IN_RIOOL { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum WATER_HOOGTE_BOVEN_OPVANGBAK { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum DISTANCE1_IN_M { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum DISTANCE_IN_M { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum BAROMETER { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum PRESSURE_IN_MBAR { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum ANGLE_Z { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum AREA_IN_M2 { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VOLUME_IN_M3 { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum TEMPERATURE { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum PRESSURE_IN_MMWC { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum ORIENTATION_X { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VIBRATION_AMP { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum FLOW_IN_L_PER_HR { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum FLOW_IN_M3_PER_DAY { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum VOLTAGE_IN_V { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum DISTANCE3_IN_M { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum HUMIDITY { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum LONGITUDE { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//    public enum LATITUDE { MIN = 0, MAX = 1, AVG = 2, SUM = 3, COUNT = 4, STD = 5, ACTUAL = 6 }
//}
namespace IOT.DEVICE
{
    public enum DEVICETYPE
    {
        NOT_DEFINED,
        ELSYS_ERSDESK,
        SM_AXIOMA,
        KAMSTRUP_WATER_METER,
        BUOY_AQUATROLL600,
        NBIOTUMB100,
        RIOOL_WATER_NIVEAU,
        NBIOTWAVE,
        MCS108,
        KERLINK_GATEWAY,
        SODAQ_4X4_20_FLOW_METER_TEMP,
        SM_HONEYWELL_MERLIN,
        DEVICE,
        SM_ITRON_CYBLEIOT,
        RIOOL_OPVANG_BAAK_NIVEAU_MET_KLEP,
    }
}
