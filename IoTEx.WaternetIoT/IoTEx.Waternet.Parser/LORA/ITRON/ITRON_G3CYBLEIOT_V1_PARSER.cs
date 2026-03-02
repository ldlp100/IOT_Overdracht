using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Collections;
using System.Linq;
using System.Reflection;
using IOT.DEVICE;
using IoTEx.WaternetIoT.Model.DTOs.API;
using IoTEx.Waternet.Common;
using IoTEx.WaternetIoT.Data.Model;
using IoTEx.WaternetIoT.Model.DTOs;

namespace IoTEx.Waternet.Parser
{

    public class ITRON_G3CYBLEIOT_V1_PARSER : BaseParser
    {
                
        public override string Version
        {
            get { return "G3"; }
        }
        public override APIResultDTO<string> GenerateConfigureDeviceMessage(List<DeviceDefinitionConfigurationDTO> configs)
        {
            return new APIResultDTO<string>() { IsOk = false, Error="NO CONFIGURATION MESSAGE DEFINED" };
        }
        public override List<DeviceDefinitionConfigurationDTO> GetDeviceTypeConfigurationItems()
        {
            return new List<DeviceDefinitionConfigurationDTO>();
        }

        #region PARSING
        public override DeviceMessageDTO ParseIncomingDeviceMessage(DeviceMessageDTO message, string payload, PayLoadEncryptionEnum enc, DeviceDefinitionDTO deviceInfo)
        {
            message.parserNamespace = typeof(IOT.METADATA.ITRON_G3CYBLEIOT_V1.DEFAULT).Namespace;

            int SequenceNr = int.Parse(payload.Substring(0, 1), System.Globalization.NumberStyles.HexNumber);
            int TypeFrame = int.Parse(payload.Substring(1, 1), System.Globalization.NumberStyles.HexNumber);
            ItronSMFrameEnum FrameName = (TypeFrame == 10) ? ItronSMFrameEnum.DS51_A : ((TypeFrame == 0) ? ItronSMFrameEnum.DS51_EVENT : ItronSMFrameEnum.UNDEFINED);

            switch (FrameName)
            {

                case ItronSMFrameEnum.DS51_A:
                    message.msgName = "DS51_A";
                    message = ParseDS51_A(message,payload,deviceInfo);                    
                    break;
                case ItronSMFrameEnum.DS51_EVENT:
                    message.msgName = "DS51_EVENT";
                    message = ParseDS51_EVENT(message, payload, deviceInfo);
                    break;
                case ItronSMFrameEnum.UNDEFINED:
                default:
                    break;
            }

            
            return message;
        }

        public DeviceMessageDTO ParseDS51_EVENT(DeviceMessageDTO message, string payload, DeviceDefinitionDTO deviceInfo)
        {
            int sequence = getSequence(payload);
            AlarmCause alarmCause = getAlarmCause(payload);
            AlarmStatus alarmStatus = GetAlarmStatus(payload);

            int meter = MeterKey(payload.Substring(88, 2));
            string pulseWeightstr = GetMeterKeyValue(meter.ToString());
            short pulseWeight;

            if (Int16.TryParse(pulseWeightstr, out pulseWeight))
            {
                string EC1Content = ReadEC1ScaleCSV();
                string PreviousDayNonZeroMinFlow = GetEC1Value(payload.Substring(16, 2), EC1Content);
                Int32 PreviousDayNonZeroMinFlowValue = flowValue(PreviousDayNonZeroMinFlow, pulseWeight);


                string PreviousDayMaxFlow = GetEC1Value(payload.Substring(20, 2), EC1Content);
                Int32 PreviousDayMaxFlowValue = flowValue(PreviousDayMaxFlow, pulseWeight);

                string PreviousDayBackFlowNumberOfAlternations = GetEC1Value(payload.Substring(24, 2), EC1Content);
                Int32 PreviousDayBackFlowNumberOfAlternationsValue = Int32.Parse(PreviousDayBackFlowNumberOfAlternations);

                string PreviousDayBackFlowCumulatedVolume = GetEC1Value(payload.Substring(26, 2), EC1Content);
                Int32 PreviousDayBackFlowCumulatedVolumeValue = flowValue(PreviousDayBackFlowCumulatedVolume, pulseWeight);

                string contentDec = ReadDecompressionRulesCSV();
                string StopPersistenceDurationValue = UInt32.Parse(payload.Substring(38, 1), System.Globalization.NumberStyles.HexNumber).ToString();
                string StopPersistenceDuration = GetDecompressionRuleValue(StopPersistenceDurationValue.ToString(), contentDec);

                string FlowPersistenceAbove0Value = UInt32.Parse(payload.Substring(40, 1), System.Globalization.NumberStyles.HexNumber).ToString();
                string FlowPersistenceAbove0 = GetDecompressionRuleValue(FlowPersistenceAbove0Value, contentDec);

                Int32 RepititionCounter = getRepitionCounter(payload.Substring(62, 2));
                DateTime dateTimeFrame = getDateTimeFrame(payload.Substring(64, 8));

                double SoftwareVersion = getVersion(payload.Substring(72, 2));
                string RadioIDBirdz = payload.Substring(76, 12);

                SetMeasurement(message, dateTimeFrame, dateTimeFrame.Ticks.ToString(), IOT.METADATA.ITRON_G3CYBLEIOT_V1.MEASUREMENT.SEQ_NUM.ACTUAL, sequence, deviceInfo);

                SetAlert( message, dateTimeFrame, dateTimeFrame.Ticks.ToString(), alarmCause.ModuleTampered ? IOT.METADATA.ITRON_G3CYBLEIOT_V1.ALERT.ALERT_MOD_TAMP.TRUE : IOT.METADATA.ITRON_G3CYBLEIOT_V1.ALERT.ALERT_MOD_TAMP.FALSE, deviceInfo);
                SetAlert( message, dateTimeFrame, dateTimeFrame.Ticks.ToString(), alarmCause.FlowPersistenceInProgress ? IOT.METADATA.ITRON_G3CYBLEIOT_V1.ALERT.ALERT_FLOW_PERS_IN_PROG.TRUE : IOT.METADATA.ITRON_G3CYBLEIOT_V1.ALERT.ALERT_FLOW_PERS_IN_PROG.FALSE, deviceInfo);
                SetAlert( message, dateTimeFrame, dateTimeFrame.Ticks.ToString(), alarmCause.StopPersistenceInProgress ? IOT.METADATA.ITRON_G3CYBLEIOT_V1.ALERT.ALERT_STOP_FLOW_PERS_IN_PROG.TRUE: IOT.METADATA.ITRON_G3CYBLEIOT_V1.ALERT.ALERT_STOP_FLOW_PERS_IN_PROG.FALSE, deviceInfo);
                SetAlert( message, dateTimeFrame, dateTimeFrame.Ticks.ToString(), alarmStatus.Battery ? IOT.METADATA.ITRON_G3CYBLEIOT_V1.ALERT.ALERT_LOW_BATTERY.TRUE : IOT.METADATA.ITRON_G3CYBLEIOT_V1.ALERT.ALERT_LOW_BATTERY.FALSE, deviceInfo);
                SetAlert( message, dateTimeFrame, dateTimeFrame.Ticks.ToString(), alarmStatus.ModuleReconfigured ? IOT.METADATA.ITRON_G3CYBLEIOT_V1.ALERT.ALERT_MOD_RECONFIG.TRUE : IOT.METADATA.ITRON_G3CYBLEIOT_V1.ALERT.ALERT_MOD_RECONFIG.FALSE, deviceInfo);
                SetAlert( message, dateTimeFrame, dateTimeFrame.Ticks.ToString(), alarmStatus.ReversedMeter ? IOT.METADATA.ITRON_G3CYBLEIOT_V1.ALERT.ALERT_REVERSED_METER.TRUE : IOT.METADATA.ITRON_G3CYBLEIOT_V1.ALERT.ALERT_REVERSED_METER.FALSE, deviceInfo);
                SetAlert( message, dateTimeFrame, dateTimeFrame.Ticks.ToString(), alarmStatus.ModuleTampered ? IOT.METADATA.ITRON_G3CYBLEIOT_V1.ALERT.ALERT_MOD_TAMP.TRUE : IOT.METADATA.ITRON_G3CYBLEIOT_V1.ALERT.ALERT_MOD_TAMP.FALSE, deviceInfo);
                SetAlert( message, dateTimeFrame, dateTimeFrame.Ticks.ToString(), alarmStatus.AcquisitionStageFailure ? IOT.METADATA.ITRON_G3CYBLEIOT_V1.ALERT.ALERT_ACQ_FAIL.TRUE : IOT.METADATA.ITRON_G3CYBLEIOT_V1.ALERT.ALERT_ACQ_FAIL.FALSE, deviceInfo);

                DateTime yesterday_NOON = new DateTime(dateTimeFrame.Year, dateTimeFrame.Month, dateTimeFrame.Day, 0, 0, 0);
                SetMeasurement(message, yesterday_NOON, dateTimeFrame.Ticks.ToString(), IOT.METADATA.ITRON_G3CYBLEIOT_V1.MEASUREMENT.PREV_DAY_NON_ZERO_MIN_FLOW.ACTUAL, PreviousDayNonZeroMinFlowValue, deviceInfo);
                SetMeasurement(message, yesterday_NOON, dateTimeFrame.Ticks.ToString(), IOT.METADATA.ITRON_G3CYBLEIOT_V1.MEASUREMENT.PREV_DAY_MAX_FLOW.ACTUAL, PreviousDayMaxFlowValue, deviceInfo);
                SetMeasurement(message, yesterday_NOON, dateTimeFrame.Ticks.ToString(), IOT.METADATA.ITRON_G3CYBLEIOT_V1.MEASUREMENT.PREV_DAY_BACKFLOW_NUM_ALTERNATIONS.ACTUAL, PreviousDayBackFlowNumberOfAlternationsValue, deviceInfo);
                SetMeasurement(message, yesterday_NOON, dateTimeFrame.Ticks.ToString(), IOT.METADATA.ITRON_G3CYBLEIOT_V1.MEASUREMENT.PREV_DAY_BACKFLOW_CUM_VOL.ACTUAL, PreviousDayBackFlowCumulatedVolumeValue, deviceInfo);
                

                SetState(message, yesterday_NOON, dateTimeFrame.Ticks.ToString(), GetObjectEnum(typeof(IOT.METADATA.ITRON_G3CYBLEIOT_V1.STATE.DURATION_STOP_FLOWPERSISTENCE), double.Parse(StopPersistenceDurationValue)), deviceInfo);
                SetState(message, yesterday_NOON, dateTimeFrame.Ticks.ToString(), GetObjectEnum(typeof(IOT.METADATA.ITRON_G3CYBLEIOT_V1.STATE.DURATION_FLOWPERSISTENCE_NOT_ZERO), double.Parse(FlowPersistenceAbove0Value)), deviceInfo);

                SetInfo(message, dateTimeFrame, dateTimeFrame.Ticks.ToString(), IOT.METADATA.ITRON_G3CYBLEIOT_V1.INFO.SOFTWARE_VER.ACTUAL, SoftwareVersion.ToString(), deviceInfo);
                SetInfo(message, dateTimeFrame, dateTimeFrame.Ticks.ToString(), IOT.METADATA.ITRON_G3CYBLEIOT_V1.INFO.RADIO_ID_BIRDZ.ACTUAL, RadioIDBirdz, deviceInfo);
                

            }
            
            return message;
        }

        public DeviceMessageDTO ParseDS51_A(DeviceMessageDTO message, string payload, DeviceDefinitionDTO deviceInfo)
        {
            int sequence = getSequence(payload);
            int meter = MeterKey(payload.Substring(98, 4));
            string pulseWeightstr = GetMeterKeyValue(meter.ToString());
            short pulseWeight;
            if (Int16.TryParse(pulseWeightstr, out pulseWeight))
            {

                
                TimeSpan time = getDateTimeStamp(payload);

                int alarmFlowPersistenceValue = GetAlarmFlowPersistenceValue(payload);
                AlarmStatus alarmStatus = GetAlarmStatus(payload);
                UInt32 midnightIndexPulse = GetMidnightIndexPulse(payload);
                UInt32 CumulativePositive24Hours = GetCumulativePositive24Hours(payload);
                UInt32 CumulativeNegative24Hours = GetCumulativeNegative24Hours(payload);
               
                Int32 midnightPulseValue = (midnightIndexPulse == 3221225472) ? 0 :  (Int32)midnightIndexPulse * pulseWeight;
                Int32 cumulativePositive24HoursValue = (Int32)CumulativePositive24Hours * pulseWeight;
                Int32 cumulativeNegative24HoursValue = (Int32)CumulativeNegative24Hours * pulseWeight;

                double[] Hours = GetHours(payload, pulseWeight, cumulativePositive24HoursValue, cumulativeNegative24HoursValue);

                string EC1Content = ReadEC1ScaleCSV();
                string PreviousDayNonZeroMinFlow = GetEC1Value(payload.Substring(82, 2), EC1Content);
                Int32 PreviousDayNonZeroMinFlowValue = flowValue(PreviousDayNonZeroMinFlow, pulseWeight);

                string PreviousDayMaxFlow = GetEC1Value(payload.Substring(84, 2), EC1Content);
                Int32 PreviousDayMaxFlowValue = flowValue(PreviousDayMaxFlow, pulseWeight);

                string PreviousDayBackFlowNumberOfAlternations = GetEC1Value(payload.Substring(86, 2), EC1Content);
                Int32 PreviousDayBackFlowNumberOfAlternationsValue = Int32.Parse(PreviousDayBackFlowNumberOfAlternations);

                string PreviousDayBackFlowCumulatedVolume = GetEC1Value(payload.Substring(88, 2), EC1Content);
                Int32 PreviousDayBackFlowCumulatedVolumeValue = flowValue(PreviousDayBackFlowCumulatedVolume, pulseWeight);


                string contentDec = ReadDecompressionRulesCSV();

                string StopPersistenceDurationValue = UInt32.Parse(payload.Substring(90,2), System.Globalization.NumberStyles.HexNumber).ToString();
                string StopPersistenceDuration = GetDecompressionRuleValue(StopPersistenceDurationValue, contentDec);

                string FlowPersistenceAbove0Value = UInt32.Parse(payload.Substring(92, 1), System.Globalization.NumberStyles.HexNumber).ToString();
                string FlowPersistenceAbove0 = GetDecompressionRuleValue(UInt32.Parse(payload.Substring(92, 1), System.Globalization.NumberStyles.HexNumber).ToString(), contentDec);

                DateTime dateTimeFrame = new DateTime(message.rcvDateTime.Year, message.rcvDateTime.Month, message.rcvDateTime.Day, 0, 0, 0);
                //DateTime dateTimeFrame = new DateTime(message.RcvTime.Year, message.RcvTime.Month, message.RcvTime.Day, time.Hours, time.Minutes, time.Seconds);

                SetMeasurement(message, dateTimeFrame, dateTimeFrame.Ticks.ToString(), IOT.METADATA.ITRON_G3CYBLEIOT_V1.MEASUREMENT.SEQ_NUM.ACTUAL, sequence, deviceInfo);

                SetState(message, dateTimeFrame, dateTimeFrame.Ticks.ToString(), GetObjectEnum(typeof(IOT.METADATA.ITRON_G3CYBLEIOT_V1.STATE.FLOW_PERSISTENCE), alarmFlowPersistenceValue), deviceInfo);
                SetAlert(message, dateTimeFrame, dateTimeFrame.Ticks.ToString(), alarmStatus.Battery ? IOT.METADATA.ITRON_G3CYBLEIOT_V1.ALERT.ALERT_LOW_BATTERY.TRUE : IOT.METADATA.ITRON_G3CYBLEIOT_V1.ALERT.ALERT_LOW_BATTERY.FALSE, deviceInfo);
                SetAlert(message, dateTimeFrame, dateTimeFrame.Ticks.ToString(), alarmStatus.ModuleReconfigured ? IOT.METADATA.ITRON_G3CYBLEIOT_V1.ALERT.ALERT_MOD_RECONFIG.TRUE : IOT.METADATA.ITRON_G3CYBLEIOT_V1.ALERT.ALERT_MOD_RECONFIG.FALSE, deviceInfo);
                SetAlert(message, dateTimeFrame, dateTimeFrame.Ticks.ToString(), alarmStatus.ReversedMeter ? IOT.METADATA.ITRON_G3CYBLEIOT_V1.ALERT.ALERT_REVERSED_METER.TRUE : IOT.METADATA.ITRON_G3CYBLEIOT_V1.ALERT.ALERT_REVERSED_METER.FALSE, deviceInfo);
                SetAlert(message, dateTimeFrame, dateTimeFrame.Ticks.ToString(), alarmStatus.ModuleTampered ? IOT.METADATA.ITRON_G3CYBLEIOT_V1.ALERT.ALERT_MOD_TAMP.TRUE : IOT.METADATA.ITRON_G3CYBLEIOT_V1.ALERT.ALERT_MOD_TAMP.FALSE, deviceInfo);
                SetAlert(message, dateTimeFrame, dateTimeFrame.Ticks.ToString(), alarmStatus.AcquisitionStageFailure ? IOT.METADATA.ITRON_G3CYBLEIOT_V1.ALERT.ALERT_ACQ_FAIL.TRUE : IOT.METADATA.ITRON_G3CYBLEIOT_V1.ALERT.ALERT_ACQ_FAIL.FALSE, deviceInfo);

                //LAST 24 HOURS
                DateTime Time24 = new DateTime(dateTimeFrame.Year, dateTimeFrame.Month, dateTimeFrame.Day, dateTimeFrame.Hour, 0, 0);
                SetMeasurement(message, Time24, dateTimeFrame.Ticks.ToString(), IOT.METADATA.ITRON_G3CYBLEIOT_V1.MEASUREMENT.CUM_NEGATIVE_LAST_24HORUS.SUM, cumulativePositive24HoursValue, deviceInfo);
                SetMeasurement(message, Time24, dateTimeFrame.Ticks.ToString(), IOT.METADATA.ITRON_G3CYBLEIOT_V1.MEASUREMENT.CUM_POSITIVE_LAST_24HOURS.SUM, cumulativeNegative24HoursValue, deviceInfo);

                for (int i = 0; i < 24; i++)
                {
                    SetMeasurement(message, Time24.AddHours(i*-1), dateTimeFrame.AddHours(i * -1).Ticks.ToString(), IOT.METADATA.ITRON_G3CYBLEIOT_V1.MEASUREMENT.HOURLY_CONSUMPTION.SUM, Hours[i], deviceInfo);
                }
                //Previous DAY data                
                DateTime TimeNoon = new DateTime(dateTimeFrame.Year, dateTimeFrame.Month, dateTimeFrame.Day, 0, 0, 0);
                SetMeasurement(message, TimeNoon, dateTimeFrame.Ticks.ToString(), IOT.METADATA.ITRON_G3CYBLEIOT_V1.MEASUREMENT.MIDNIGHT_INDEX.ACTUAL, midnightPulseValue, deviceInfo);

                SetMeasurement(message, TimeNoon, dateTimeFrame.Ticks.ToString(), IOT.METADATA.ITRON_G3CYBLEIOT_V1.MEASUREMENT.PREV_DAY_NON_ZERO_MIN_FLOW.ACTUAL, PreviousDayNonZeroMinFlowValue, deviceInfo);
                SetMeasurement(message, TimeNoon, dateTimeFrame.Ticks.ToString(), IOT.METADATA.ITRON_G3CYBLEIOT_V1.MEASUREMENT.PREV_DAY_MAX_FLOW.ACTUAL, PreviousDayMaxFlowValue, deviceInfo);
                SetMeasurement(message, TimeNoon, dateTimeFrame.Ticks.ToString(), IOT.METADATA.ITRON_G3CYBLEIOT_V1.MEASUREMENT.PREV_DAY_BACKFLOW_NUM_ALTERNATIONS.ACTUAL, PreviousDayBackFlowNumberOfAlternationsValue, deviceInfo);
                SetMeasurement(message, TimeNoon, dateTimeFrame.Ticks.ToString(), IOT.METADATA.ITRON_G3CYBLEIOT_V1.MEASUREMENT.PREV_DAY_BACKFLOW_CUM_VOL.ACTUAL, PreviousDayBackFlowCumulatedVolumeValue, deviceInfo);
                SetMeasurement(message, TimeNoon, dateTimeFrame.Ticks.ToString(), IOT.METADATA.ITRON_G3CYBLEIOT_V1.MEASUREMENT.PREV_DAY_BACKFLOW_CUM_VOL.ACTUAL, PreviousDayBackFlowCumulatedVolumeValue, deviceInfo);

                SetState(message, TimeNoon, dateTimeFrame.Ticks.ToString(), GetObjectEnum(typeof(IOT.METADATA.ITRON_G3CYBLEIOT_V1.STATE.DURATION_STOP_FLOWPERSISTENCE), double.Parse(StopPersistenceDurationValue)), deviceInfo);
                SetState(message, TimeNoon, dateTimeFrame.Ticks.ToString(), GetObjectEnum(typeof(IOT.METADATA.ITRON_G3CYBLEIOT_V1.STATE.DURATION_FLOWPERSISTENCE_NOT_ZERO), double.Parse(FlowPersistenceAbove0Value)), deviceInfo);
                


            }

            return message;
        }
        #endregion

        #region UTILITY

        private int getSequence(string payload)
        {
            string seqH = payload.Substring(0, 1);
            int num = Convert.ToInt32(seqH, 16);
            return num;
        }
        private double getVersion(string contentStr)
        {
            byte[] bytes = Function.HexToBytes(contentStr);
            string[] b = bytes.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')).ToArray();

            BitArray array = new BitArray(bytes);
            int minorValue = Function.BitExtractedToInt(array, 0, 4);
            int majorValue = Function.BitExtractedToInt(array, 4, 4);

            return double.Parse(majorValue + "." + minorValue);
        }
        private DateTime getDateTimeFrame(string contentStr)
        {
            byte[] bytes = Function.HexToBytes(contentStr);
            Array.Reverse(bytes);
            string dataHexaValue = Function.ByteArrayToHexString(bytes);
            UInt32 intDecimalValue2 = UInt32.Parse(dataHexaValue, System.Globalization.NumberStyles.HexNumber);
            return new DateTime(2012, 1, 1).AddSeconds(intDecimalValue2);
        }
        private AlarmCause getAlarmCause(string contentStr)
        {
            string fiedlHexa = contentStr.Substring(4, 2);
            byte[] byteField = Function.HexToBytes(fiedlHexa);
            BitArray bits = new BitArray(byteField);


            return new AlarmCause()
            {
                ModuleTampered = bits[2],
                FlowPersistenceInProgress = bits[4],
                StopPersistenceInProgress = bits[5]
            };
        }
        static Int32 flowValue(string value, int pulseweight)
        {
            if (value == "Overflow" || value == "Anomaly")
            {
                return 0;
            }
            else
            {
                return Int32.Parse(value) * pulseweight;
            }

        }
        static Int32 getRepitionCounter(string contentStr)
        {
            byte[] bytes = Function.HexToBytes(contentStr);
            return bytes[0];

        }
        static int MeterKey(string meter)
        {

            byte[] bytes = Function.HexToBytes(meter);
            string[] b = bytes.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')).ToArray();
            //Array.Reverse(b);

            BitArray array = new BitArray(bytes);
            int decValue = Function.BitExtractedToInt(array, 0, 4);

            return decValue;
        }
        static TimeSpan getDateTimeStamp(string contentStr)
        {
            string meter = contentStr.Substring(98, 4);
            byte[] bytes = Function.HexToBytes(meter);
            int number = BitConverter.ToInt16(bytes, 0);
            string[] b = bytes.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')).ToArray();
            //Array.Reverse(b);

            BitArray array = new BitArray(bytes);

            int dechours = Function.BitExtractedToInt(array, 11, 4);
            int decminutes = Function.BitExtractedToInt(array, 4, 6);
            int realMinutes = decminutes / 2;
            int realseconds = (decminutes % 2) * 30;

            return new TimeSpan(0, dechours, realMinutes, realseconds);

        }     
        static string GetMeterKeyValue(string lookupValue)
        {
            string table = ReadMeterKeyTableCSV();
            string value = GetValueInLookupTable(lookupValue, table, 1);
            return value;
        }
        static string GetEC1Value(string FieldHexaValue, string content)
        {

            byte[] bytes = Function.HexToBytes(FieldHexaValue);
            string value = GetValueInLookupTable(bytes[0].ToString(), content, 1);

            return value;
        }
        static string GetEC2Value(string valueToSearch)
        {
            string content = ReadEC2ScaleCSV();
            string value = GetValueInLookupTable(valueToSearch, content, 2);
            return value;
        }
        static string GetDecompressionRuleValue(string valueToSearch, string content)
        {

            string value = GetValueInLookupTable(valueToSearch, content, 1);
            return value;
        }
        static double[] GetHours(string contentStr, int pulseWeight, int positiveConsumption, int negativeConsumption)
        {
            string fileContent = ReadEC2ScaleCSV();
            double[] Hours = new double[24];
            //UInt32[] Hours = new UInt32[24];
            string FieldHexaValue = contentStr.Substring(34, 48);
            byte[] bytes = Function.HexToBytes(FieldHexaValue);
            for (int i = 0; i < 24; i++)
            {
                string hex = FieldHexaValue.Substring(i * 2, 2);
                UInt32 hour = UInt32.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                if (hour < 0)
                    Hours[i] = Math.Round(double.Parse(GetValueInLookupTable(hour.ToString(), fileContent, 2)) * pulseWeight * negativeConsumption / 100);
                else
                    Hours[i] = Math.Round(double.Parse(GetValueInLookupTable(hour.ToString(), fileContent, 2)) * pulseWeight * positiveConsumption / 100);

            }
            return Hours;
        }
        static UInt32 GetCumulativeNegative24Hours(string contentStr)
        {
            string FieldHexaValue = contentStr.Substring(24, 8);
            string field1 = contentStr.Substring(24, 4);
            string field2 = contentStr.Substring(28, 2);
            string field3 = contentStr.Substring(30, 4);
            string dataHexaValue = field2.Substring(0, 1) + field3.Substring(2, 2) + field3.Substring(0, 2);

            UInt32 intDecimalValue2 = UInt32.Parse(dataHexaValue, System.Globalization.NumberStyles.HexNumber);

            return intDecimalValue2;
        }
        static UInt32 GetCumulativePositive24Hours(string message)
        {
            string FieldHexaValue = message.Substring(24, 8);
            string field1 = message.Substring(24, 4);
            string field2 = message.Substring(28, 2);
            string field3 = message.Substring(30, 4);
            string dataHexaValue = field2.Substring(1, 1) + field1.Substring(2, 2) + field1.Substring(0, 2);

            UInt32 intDecimalValue2 = UInt32.Parse(dataHexaValue, System.Globalization.NumberStyles.HexNumber);

            return intDecimalValue2;
        }
        static UInt32 GetMidnightIndexPulse(string message)
        {
            string FieldHexaValue = message.Substring(16, 8);
            byte[] bytes = Function. HexToBytes(FieldHexaValue);
            Array.Reverse(bytes);
            string hex = Function.ByteArrayToHexString(bytes);
            UInt32 intValue2 = UInt32.Parse(hex, System.Globalization.NumberStyles.HexNumber);
            if (intValue2 == 3221225472)
                return 0;

            return intValue2;
        }
        static AlarmStatus GetAlarmStatus(string message)
        {
            AlarmStatus alarm = new AlarmStatus();
            string FieldHexaValue = message.Substring(6, 10);
            byte[] byteAlarmFlowPersistence = Function.HexToBytes(FieldHexaValue);
            string strBinAlarmFlowPersistence = string.Join("", byteAlarmFlowPersistence.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));
            BitArray d = new BitArray(byteAlarmFlowPersistence);
            alarm.Battery = d[15];
            alarm.ModuleReconfigured = d[19];
            alarm.ReversedMeter = d[27];
            alarm.ModuleTampered = d[29];
            alarm.AcquisitionStageFailure = d[30];

            //int AlarmFlowPersistenceIntValue = Convert.ToInt32(strBinAlarmFlowPersistenceValue, 2);

            return alarm;
        }
        static int GetAlarmFlowPersistenceValue(string message)
        {
            string strAlarmFlowPersistence = message.Substring(4, 2);
            byte[] byteAlarmFlowPersistence = Function.HexToBytes(strAlarmFlowPersistence);
            string strBinAlarmFlowPersistence = string.Join(" ", byteAlarmFlowPersistence.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));
            string strBinAlarmFlowPersistenceValue = strBinAlarmFlowPersistence.Substring(1, 2);
            int AlarmFlowPersistenceIntValue = Convert.ToInt32(strBinAlarmFlowPersistenceValue, 2);
            return AlarmFlowPersistenceIntValue;



        }
        static string ReadMeterKeyTableCSV()
        {
            string[] names = Assembly.GetCallingAssembly().GetManifestResourceNames();
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].IndexOf("ITRON_MeterKeyTable") > -1)
                {
                    Stream stream = Assembly.GetCallingAssembly().GetManifestResourceStream(names[i]);
                    StreamReader reader = new StreamReader(stream);
                    string content = reader.ReadToEnd();
                    return content;
                }
            }
            return "";
        }
        static string ReadEC1ScaleCSV()
        {
            string[] names = Assembly.GetCallingAssembly().GetManifestResourceNames();
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].IndexOf("ITRON_EC1Scale") > -1)
                {
                    Stream stream = Assembly.GetCallingAssembly().GetManifestResourceStream(names[i]);
                    StreamReader reader = new StreamReader(stream);
                    string content = reader.ReadToEnd();

                    return content;
                }
            }
            return "";
        }
        static string ReadEC2ScaleCSV()
        {
            string[] names = Assembly.GetCallingAssembly().GetManifestResourceNames();
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].IndexOf("ITRON_EC2Scale") > -1)
                {
                    Stream stream = Assembly.GetCallingAssembly().GetManifestResourceStream(names[i]);
                    StreamReader reader = new StreamReader(stream);
                    string content = reader.ReadToEnd();
                    return content;
                }
            }
            return "";
        }
        static string ReadDecompressionRulesCSV()
        {
            string[] names = Assembly.GetCallingAssembly().GetManifestResourceNames();
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].IndexOf("ITRON_DecompressionRules") > -1)
                {
                    Stream stream = Assembly.GetCallingAssembly().GetManifestResourceStream(names[i]);
                    StreamReader reader = new StreamReader(stream);
                    string content = reader.ReadToEnd();
                    return content;
                }
            }
            return "";
        }
        static string GetValueInLookupTable(string valueToSearch, string lookupTable, int index)
        {
            string stringToSearch = "\n" + valueToSearch + "\t";
            int startIndex = lookupTable.IndexOf(stringToSearch);
            if (startIndex > -1)
            {
                int endLineIndex = lookupTable.IndexOf("\r\n", startIndex + 1);
                string line = lookupTable.Substring(startIndex + 1, endLineIndex - startIndex - 1);
                string[] elements = line.Split('\t');
                string value = elements[index];
                return value;
            }
            return "N/A";
        }
                
        public enum ItronSMFrameEnum { UNDEFINED, DS51_A, DS51_EVENT };
        public class AlarmStatus
        {
            public bool Battery { get; set; }
            public bool ModuleReconfigured { get; set; }
            public bool ReversedMeter { get; set; }
            public bool ModuleTampered { get; set; }
            public bool AcquisitionStageFailure { get; set; }

        }
        public class AlarmCause
        {
            public bool ModuleTampered { get; set; }
            public bool FlowPersistenceInProgress { get; set; }
            public bool StopPersistenceInProgress { get; set; }
        }
        #endregion
    }

}
