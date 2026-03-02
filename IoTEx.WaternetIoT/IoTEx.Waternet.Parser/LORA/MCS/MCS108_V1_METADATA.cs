using IoTEx.Waternet.Parser;

namespace IOT.METADATA.MCS108_V1
{
    namespace STATE
    {
        
    }

    namespace ALERT
    {
        
    }
    namespace MEASUREMENT
    {
        [MetaDataAttribute(Description = "Latitude of the device", Unit = IOT.METADATA.UNITS.UnitsEnum.oArc)]
        enum LATITUDE
        {
            [MetaDataAttribute(Description = "Actual Value")]
            ACTUAL
        }
        [MetaDataAttribute(Description = "Longitude of the device", Unit = IOT.METADATA.UNITS.UnitsEnum.oArc)]
        enum LONGITUDE
        {
            [MetaDataAttribute(Description = "Actual Value")]
            ACTUAL
        }
        [MetaDataAttribute(Description = "Air Pressure ", Unit = IOT.METADATA.UNITS.UnitsEnum.hPascal)]
        enum AIR_PRESSURE
        {
            [MetaDataAttribute(Description = "ACTUAL ")]
            ACTUAL
        }
        [MetaDataAttribute(Description = "Air Pressure ", Unit = IOT.METADATA.UNITS.UnitsEnum.oC)]
        enum TEMPERATURE
        {
            [MetaDataAttribute(Description = "ACTUAL ")]
            ACTUAL
        }
        [MetaDataAttribute(Description = "Percentage Air Humidity", Unit = IOT.METADATA.UNITS.UnitsEnum.pct)]
        enum HUMIDITY
        {
            [MetaDataAttribute(Description = "ACTUAL ")]
            ACTUAL
        }
        [MetaDataAttribute(Description = "Rotation Angle in X Direction", Unit = IOT.METADATA.UNITS.UnitsEnum.oArc)]
        enum ANGLE_X
        {
            [MetaDataAttribute(Description = "ACTUAL ")]
            ACTUAL
        }
        [MetaDataAttribute(Description = "Rotation Angle in Y Direction", Unit = IOT.METADATA.UNITS.UnitsEnum.oArc)]
        enum ANGLE_Y
        {
            [MetaDataAttribute(Description = "ACTUAL ")]
            ACTUAL
        }
        [MetaDataAttribute(Description = "Rotation Angle in Z Direction", Unit = IOT.METADATA.UNITS.UnitsEnum.oArc)]
        enum ANGLE_Z
        {
            [MetaDataAttribute(Description = "ACTUAL ")]
            ACTUAL
        }
        [MetaDataAttribute(Description = "Vibration Amplitude", Unit = IOT.METADATA.UNITS.UnitsEnum.mm)]
        enum VIBRATION_AMP
        {
            [MetaDataAttribute(Description = "ACTUAL ")]
            ACTUAL
        }
        [MetaDataAttribute(Description = "Vibration Frequency", Unit = IOT.METADATA.UNITS.UnitsEnum.Hz)]
        enum VIBRATION_FREQUENCY
        {
            [MetaDataAttribute(Description = "ACTUAL ")]
            ACTUAL
        }

    }
    namespace INFO
    {
        

    }
}