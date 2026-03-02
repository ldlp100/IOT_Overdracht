using IoTEx.Waternet.Parser;

namespace IOT.METADATA.ITRON_G3CYBLEIOT_V1
{

    public class DEFAULT
    {

    }
    
    namespace STATE
    {
        //public static string ALERT_PERSISTENCE_FLOW_STOP_IN_PROGRESS = "PERSISTENCE_FLOW_STOP_IN_PROGRESS";
        [MetaDataAttribute(Description = "The module has detected a flow persistence and depending on the flow and the duration it could be a leak presumption")]
        public enum FLOW_PERSISTENCE
        {
            [MetaDataAttribute(Description = "No Flow Persistence", Value = 0)]
            NO_FLOW,
            [MetaDataAttribute(Description = "Past Persistence during the period", Value = 1)]
            PAST_PERSIST_DURING_PERIOD,
            [MetaDataAttribute(Description = "Persistence in progress", Value = 2)]
            PERSIST_IN_PROG,
            [MetaDataAttribute(Description = "Impacting persistence in progress", Value = 3)]
            IMPACTING_PERS_IN_PROG,
            [MetaDataAttribute(Description = "Wrong Value", Value = 4)]
            WRONG_VALUE,
        }
        [MetaDataAttribute(Description = "Duration since flow is zero", Unit = IOT.METADATA.UNITS.UnitsEnum.Liter)]
        public enum DURATION_STOP_FLOWPERSISTENCE
        {
            [MetaDataAttribute(Description = "No Persistence", Value =0)]
            NO_PERSISTENCE,
            [MetaDataAttribute(Description = "Persistence between 0 and 5 min", Value =1)]
            FROM_0_UPTO_5MIN,
            [MetaDataAttribute(Description = "Persistence between 5 and 15 min", Value = 2)]
            FROM_5_UPTO_15MIN,
            [MetaDataAttribute(Description = "Persistence between 15 and 60 min", Value = 3)]
            FROM_15_UPTO_60MIN,
            [MetaDataAttribute(Description = "Persistence between 1 and 3 hours", Value = 4)]
            FROM_1_UPTO_3HOURS,
            [MetaDataAttribute(Description = "Persistence between 3 and 6 hours", Value = 5)]
            FROM_3_UPTO_6HOURS,
            [MetaDataAttribute(Description = "Persistence between 6 and 12 hours", Value = 6)]
            FROM_6_UPTO_12HOURS,
            [MetaDataAttribute(Description = "Persistence between 12 and 24 hours", Value = 7)]
            FROM_12_UPTO_24HOURS,
            [MetaDataAttribute(Description = "Persistence between 1 and 2 days", Value = 8)]
            FROM_1_UPTO_2DAYS,
            [MetaDataAttribute(Description = "Persistence between 2 and 4 days", Value = 9)]
            FROM_2_UPTO_4DAYS,
            [MetaDataAttribute(Description = "Persistence between 4 and 8 days", Value = 10)]
            FROM_4_UPTO_8DAYS,
            [MetaDataAttribute(Description = "Persistence between 8 and 15 days", Value = 11)]
            FROM_8_UPTO_15DAYS,
            [MetaDataAttribute(Description = "Persistence between 15 and 30 days", Value = 12)]
            FROM_15_UPTO_30DAYS,
            [MetaDataAttribute(Description = "Persistence between 30 and 90 days", Value = 13)]
            FROM_30_UPTO_90DAYS,
            [MetaDataAttribute(Description = "Persistence between 90 and 180 days", Value = 14)]
            FROM_90_UPTO_180DAYS,
            [MetaDataAttribute(Description = "Persistence more than 180 days", Value = 15)]
            MORE_THAN_180DAYS,



        }
        [MetaDataAttribute(Description = "Duration since flow is not zero", Unit = IOT.METADATA.UNITS.UnitsEnum.Liter)]
        public enum DURATION_FLOWPERSISTENCE_NOT_ZERO
        {
            [MetaDataAttribute(Description = "No Persistence", Value = 0)]
            NO_PERSISTENCE,
            [MetaDataAttribute(Description = "Persistence between 0 and 5 min", Value = 1)]
            FROM_0_UPTO_5MIN,
            [MetaDataAttribute(Description = "Persistence between 5 and 15 min", Value = 2)]
            FROM_5_UPTO_15MIN,
            [MetaDataAttribute(Description = "Persistence between 15 and 60 min", Value = 3)]
            FROM_15_UPTO_60MIN,
            [MetaDataAttribute(Description = "Persistence between 1 and 3 hours", Value = 4)]
            FROM_1_UPTO_3HOURS,
            [MetaDataAttribute(Description = "Persistence between 3 and 6 hours", Value = 5)]
            FROM_3_UPTO_6HOURS,
            [MetaDataAttribute(Description = "Persistence between 6 and 12 hours", Value = 6)]
            FROM_6_UPTO_12HOURS,
            [MetaDataAttribute(Description = "Persistence between 12 and 24 hours", Value = 7)]
            FROM_12_UPTO_24HOURS,
            [MetaDataAttribute(Description = "Persistence between 1 and 2 days", Value = 8)]
            FROM_1_UPTO_2DAYS,
            [MetaDataAttribute(Description = "Persistence between 2 and 4 days", Value = 9)]
            FROM_2_UPTO_4DAYS,
            [MetaDataAttribute(Description = "Persistence between 4 and 8 days", Value = 10)]
            FROM_4_UPTO_8DAYS,
            [MetaDataAttribute(Description = "Persistence between 8 and 15 days", Value = 11)]
            FROM_8_UPTO_15DAYS,
            [MetaDataAttribute(Description = "Persistence between 15 and 30 days", Value = 12)]
            FROM_15_UPTO_30DAYS,
            [MetaDataAttribute(Description = "Persistence between 30 and 90 days", Value = 13)]
            FROM_30_UPTO_90DAYS,
            [MetaDataAttribute(Description = "Persistence between 90 and 180 days", Value = 14)]
            FROM_90_UPTO_180DAYS,
            [MetaDataAttribute(Description = "Persistence more than 180 days", Value = 15)]
            MORE_THAN_180DAYS,
            
        }

    }

    namespace ALERT
    {
        [MetaDataAttribute(Description = "Flow persistence in progress")]
        public enum ALERT_STOP_FLOW_PERS_IN_PROG
        {
            [MetaDataAttribute(Description = "False", Value = 0)]
            FALSE,
            [MetaDataAttribute(Description = "True", Value = 1)]
            TRUE
        }
        [MetaDataAttribute(Description = "Flow persistence in progress")]
        public enum ALERT_FLOW_PERS_IN_PROG
        {
            [MetaDataAttribute(Description = "False", Value = 0)]
            FALSE,
            [MetaDataAttribute(Description = "True", Value = 1)]
            TRUE
        }
        [MetaDataAttribute(Description = "the battery is low")]
        public enum ALERT_LOW_BATTERY
        {
            [MetaDataAttribute(Description = "False", Value = 0)]
            FALSE,
            [MetaDataAttribute(Description = "True", Value = 1)]
            TRUE
        }
        [MetaDataAttribute(Description = "the module has been reconfigured by radio")]
        public enum ALERT_MOD_RECONFIG
        {
            [MetaDataAttribute(Description = "False", Value = 0)]
            FALSE,
            [MetaDataAttribute(Description = "True", Value = 1)]
            TRUE
        }
        [MetaDataAttribute(Description = "A suspected fraud which consists to reverse temporarily the meter in order to deduct the consumption")]
        public enum ALERT_REVERSED_METER
        {
            [MetaDataAttribute(Description = "False", Value = 0)]
            FALSE,
            [MetaDataAttribute(Description = "True", Value = 1)]
            TRUE
        }
        [MetaDataAttribute(Description = "The radio module has detected a tamper attempt by removing the module from the meter or removing the seal")]
        public enum ALERT_MOD_TAMP
        {
            [MetaDataAttribute(Description = "False", Value = 0)]
            FALSE,
            [MetaDataAttribute(Description = "True", Value = 1)]
            TRUE
        }
        [MetaDataAttribute(Description = "The radio module has detected a default into the acquisition stage with a possible impact on the index value")]
        public enum ALERT_ACQ_FAIL
        {
            [MetaDataAttribute(Description = "False", Value = 0)]
            FALSE,
            [MetaDataAttribute(Description = "True", Value = 1)]
            TRUE
        }
       


    }
    namespace MEASUREMENT
    {
        [MetaDataAttribute(Description = "Repitition Counter", Unit = IOT.METADATA.UNITS.UnitsEnum.none)]
        enum REPITITION_CNT
        {
            [MetaDataAttribute(Description = "Actual Value")]
            ACTUAL
        }
        [MetaDataAttribute(Description = "Sequence number of the periodic frame", Unit = IOT.METADATA.UNITS.UnitsEnum.none)]
        enum SEQ_NUM
        {
            [MetaDataAttribute(Description = "Actual Value")]
            ACTUAL
        }
        [MetaDataAttribute(Description = "Index at 0h00 – pulse restitution", Unit = IOT.METADATA.UNITS.UnitsEnum.Liter)]
        enum MIDNIGHT_INDEX
        {
            [MetaDataAttribute(Description = "Actual Value")]
            ACTUAL
        }
        [MetaDataAttribute(Description = "Cumulative of positive consumption during the last 24 legal hours", Unit = IOT.METADATA.UNITS.UnitsEnum.Liter)]
        enum CUM_POSITIVE_LAST_24HOURS
        {
            [MetaDataAttribute(Description = "Cumulative Value")]
            SUM
        }
        [MetaDataAttribute(Description = "Cumulative of negtaive consumption during the last 24 legal hours", Unit = IOT.METADATA.UNITS.UnitsEnum.Liter)]
        enum CUM_NEGATIVE_LAST_24HORUS
        {
            [MetaDataAttribute(Description = "Cumulative Value")]
            SUM
        }
        [MetaDataAttribute(Description = "Hour Consumption(s)", Unit = IOT.METADATA.UNITS.UnitsEnum.Liter)]
        enum HOURLY_CONSUMPTION
        {
            [MetaDataAttribute(Description = "Actual Value")]
            SUM
        }
        
        [MetaDataAttribute(Description = "Non-zero min flow", Unit = IOT.METADATA.UNITS.UnitsEnum.Liter_per_hour)]
        enum PREV_DAY_NON_ZERO_MIN_FLOW
        {
            [MetaDataAttribute(Description = "Actual Value")]
            ACTUAL
        }
        [MetaDataAttribute(Description = "Max flow", Unit = IOT.METADATA.UNITS.UnitsEnum.Liter_per_hour)]
        enum PREV_DAY_MAX_FLOW
        {
            [MetaDataAttribute(Description = "Actual Value")]
            ACTUAL
        }
        [MetaDataAttribute(Description = "Number of alternations, positive and negative ways", Unit = IOT.METADATA.UNITS.UnitsEnum.none)]
        enum PREV_DAY_BACKFLOW_NUM_ALTERNATIONS
        {
            [MetaDataAttribute(Description = "Actual Value")]
            ACTUAL
        }
        [MetaDataAttribute(Description = "Cumulated volume of backflow", Unit = IOT.METADATA.UNITS.UnitsEnum.Liter)]
        enum PREV_DAY_BACKFLOW_CUM_VOL
        {
            [MetaDataAttribute(Description = "Actual Value")]
            ACTUAL
        }
        
        [MetaDataAttribute(Description = "Meter Key", Unit = IOT.METADATA.UNITS.UnitsEnum.Liter)]
        enum METER_KEY
        {
            [MetaDataAttribute(Description = "Actual Value")]
            ACTUAL
        }
        
        /*
       
            
           
            public static string DURATION_FLOW_IS_ZERO = "DURATION_FLOW_IS_ZERO";
            public static string DURATION_FLOW_ISNOT_ZERO = "DURATION_FLOW_ISNOT_ZERO";
            public static string METER_KEY = "METER_KEY";
            public static string SOFT_VERSION = "SOFT_VERSION";
            public static string RADIO_ID_HR = "RADIO_ID_HR";
            */
    }
    namespace INFO
    {
        [MetaDataAttribute(Description = "Software Version")]
        enum SOFTWARE_VER
        {
            [MetaDataAttribute(Description = "Actual Value")]
            ACTUAL
        }
        [MetaDataAttribute(Description = "Radio ID Birdz")]
        enum RADIO_ID_BIRDZ
        {
            [MetaDataAttribute(Description = "Actual Value")]
            ACTUAL
        }

    }
}