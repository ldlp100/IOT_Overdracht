using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using IoTEx.WaternetIoT.Data.Model;
using IoTEx.WaternetIoT.Model.DTOs;
using IoTEx.WaternetIoT.Model.DTOs.API;
using Newtonsoft.Json;
using static IoTEx.Waternet.Parser.IOT_DEVICE_GENERIC_V1_PARSER;

namespace IoTEx.Waternet.Parser
{
    public class IOT_DEVICE_GENERIC_V1_PARSER : BaseParser
    {

        public enum IOT_EVENT
        {
            STATE = 0,
            ALERT,
            MEASUREMENT,
            INFO
        }
        public enum SENSOR_TYPE_ENUM
        {
            SENSOR_KELLER_XW36=0,
            SENSOR_PONZELL_CTV=1,
            SENSOR_AQUATROLL_600=2,
            SENSOR_KROHNE_WATERFLUX_3070=3,
            SENSOR_INTERNAL_PRESSURE_BMP388=4,
            SENSOR_KROHNE_WATERFLUX_3070_EXT_PRESSURE=5,
            SENSOR_ANANLOG_4_20MA = 6,
            SENSOR_ANANLOG_0_10V = 7,
            SENSOR_KROHNE_OPTIWAVE_1400 = 8,
            SENSOR_PULSE =99,
            SENSOR_ANALOG_4_20MA=100,
            SENSOR_ANALOG_0_10V=101,
            SENSOR_PT100_MODBUS = 102,
            SENSOR_LEIDUIN_WARMTEWISSELING = 103,
            SENSOR_TIP_BUCKET =200
            
        }
        public enum IOT_FORMAT_ENUM
        {
            IOT_FLOAT = 0,

            IOT_INT = 1,
            IOT_10TOINT = 2,
            IOT_100TOINT = 3,
            IOT_1000TOINT = 4,

            IOT_UINT = 5,
            IOT_10TOUINT = 6,
            IOT_100TOUINT = 7,
            IOT_1000TOUINT = 8,

            IOT_SHORT = 9,
            IOT_100TOSHORT = 10,
            IOT_1000TOSHORT = 11,

            IOT_USHORT = 12,
            IOT_100TOUSHORT = 13,
            IOT_1000TOUSHORT = 14,

            IOT_INT8 = 15,
            IOT_10INT8 = 16,

            IOT_UINT8 = 17,
            IOT_10UINT8 = 18,
        }
        public enum IOT_DATA_AGGREGATE
        {
            AVG = 0,
            MIN,
            MAX,
            SUM,
            FIRST,
            LAST
        }
        public class DeviceIoTDataDef
        {
            public int SensorIndex { get; set; }
            public SENSOR_TYPE_ENUM SensorType;
            public int PropertyIndex { get; set; }
            public string PropertyName { get; set; }
            public string Unit { get; set; }
            public IOT_FORMAT_ENUM Format { get; set; }
            public IOT_EVENT EventType { get; set; }
            public IOT_DATA_AGGREGATE[] Aggregates { get; set; }
        }
        private Dictionary<string, DeviceIoTDataDef> _Dic = new Dictionary<string, DeviceIoTDataDef>();
        private List<DeviceIoTDataDef> Definitions = new List<DeviceIoTDataDef>();

        public override string Version
        {
            get { return "1.0.0"; }
        }
        public override APIResultDTO<string> GenerateConfigureDeviceMessage(List<DeviceDefinitionConfigurationDTO> configs)
        {
            return new APIResultDTO<string>() { IsOk = false, Error = "NO CONFIGURATION MESSAGE DEFINED" };
        }
        public override List<DeviceDefinitionConfigurationDTO> GetDeviceTypeConfigurationItems()
        {
            return new List<DeviceDefinitionConfigurationDTO>();
        }
        public override DeviceMessageDTO ParseIncomingDeviceMessage(DeviceMessageDTO message, string payload, PayLoadEncryptionEnum enc, DeviceDefinitionDTO deviceInfo)
        {
            Definition();
            int index = 0;
            byte[] mByte = HexToBytes(payload);
            string newX = Encoding.ASCII.GetString(mByte);
            mByte = HexToBytes(newX);
            float version = ((float)mByte[index++]) / 10;

            int years = mByte[index++];
            int months = mByte[index++];
            int days = mByte[index++];
            int hours = mByte[index++];
            int minutes = mByte[index++];
            int seconds = mByte[index++];
            DateTime basicDT = new DateTime(2000 + years, months, days, hours, minutes, seconds);
            UInt16 Voltage = BitConverter.ToUInt16(mByte, index);
            float volt = ((float)Voltage) / 100;
            //CreateEvent(basicDT, -1, SENSOR_TYPE_ENUM.SENSOR_AQUATROLL_600, 0, 0, volt);
            SetMeasurement(message, basicDT, "", IOT.METADATA.IOT_DEVICE_GENERIC_V1.MEASUREMENT.IOTDEVICE_VOLT.AVG, volt, deviceInfo);


            index += 2;
            UInt16 MeasureInterval = BitConverter.ToUInt16(mByte, index);
            index += 2;
            UInt16 AggregateInterval = BitConverter.ToUInt16(mByte, index);


            index += 2;
            UInt16 AggregateCount = BitConverter.ToUInt16(mByte, index);
            index += 2;

            
            for (int i = 0; i < AggregateCount; i++)
            {
                ReadData(message, mByte, ref index, basicDT, AggregateInterval * MeasureInterval, deviceInfo);
            }
            AddPostEvent(message,deviceInfo);

            return message;
        }
        public virtual void AddPostEvent(DeviceMessageDTO message, DeviceDefinitionDTO deviceInfo)
        {

        }
        public virtual void Definition()
        {
            
        }
        protected int ResetSensorId(int sensorIndex)
        { 

            
            /* ISSUE WITH OLD VERSION OF FIRMWARE DEVICE - SENSOR  ID IS NOT WELL SET*/
            bool multiSensor = false;

            int singleSensorIndex = (Definitions.Count > 0) ? Definitions[0].SensorIndex : 0;
            for (int i = 0; i < Definitions.Count; i++)
            {
                if (singleSensorIndex != Definitions[i].SensorIndex)
                    multiSensor = true;
            }
            if (!multiSensor && Definitions.Count > 0)
            {
                //sensorType = Definitions[0].SensorType;
                sensorIndex = 0;
            }
            return sensorIndex;
            /*----------------*/
        }
        DeviceIoTDataDef GetDefinition(int sensorIndex, SENSOR_TYPE_ENUM sensorType, int propertyIndex)
        {
            

            for (int i = 0; i < Definitions.Count; i++)
            {
                
                if (Definitions[i].SensorIndex== sensorIndex && Definitions[i].SensorType == sensorType && 
                        Definitions[i].PropertyIndex == propertyIndex)
                {
                    return Definitions[i];
                }
            }
            return null;
        }
        //IoTDataDefineMember(2, 24, "ExternalVoltage", 2, "Volts", 197, 0);
        protected void IoTDataDefineMember(int sensorType, int propIndex, string propName, int eventType, string unit, int format, params int[] aggregates)
        {
            IoTDataDefineMemberExt(0, sensorType, propIndex, propName, eventType, unit, format, aggregates);

        }
        protected void IoTDataDefineMemberExt(int sensorIndex, int sensorType, int propIndex, string propName, int eventType, string unit, int format, params int[] aggregates)
        {
            if (!_Dic.ContainsKey(sensorIndex+"-"+sensorType + "-" + propIndex))
            {
                DeviceIoTDataDef def = new DeviceIoTDataDef()
                {
                    SensorIndex = sensorIndex,
                    SensorType = (SENSOR_TYPE_ENUM)sensorType,
                    PropertyIndex = propIndex,
                    PropertyName = propName,
                    EventType = (IOT_EVENT)eventType,
                    Unit = unit,
                    Format = (IOT_FORMAT_ENUM)format,
                    Aggregates = new IOT_DATA_AGGREGATE[aggregates.Length]
                };

                for (int i = 0; i < aggregates.Length; i++)
                {
                    def.Aggregates[i] = (IOT_DATA_AGGREGATE)aggregates[i];
                }
                Definitions.Add(def);
                _Dic.Add(sensorIndex+"-"+sensorType + "-" + propIndex, def);
            }

        }

        protected DeviceMessageDTO ReadData(DeviceMessageDTO message, byte[] mByte, ref int index, DateTime refDT, 
                            int intervalAggr, DeviceDefinitionDTO deviceInfo)
        {
            int sensorId = mByte[index++];
            int sensorType = mByte[index++];
            int propertyIndex = mByte[index++];
            int count = BitConverter.ToUInt16(mByte, index);
            index += 2;
            sensorId = ResetSensorId(sensorId);
            DeviceIoTDataDef def = GetDefinition(sensorId,(SENSOR_TYPE_ENUM)sensorType, propertyIndex);
            if (def != null)
            {
                for (int i = 0; i < count; i++)
                {
                    float value = float.NaN;
                    byte aggrIndex = mByte[index];
                    index += 1;


                    for (int j = 0; j < def.Aggregates.Count(); j++)
                    {
                        switch (def.Format)
                        {
                            case IOT_FORMAT_ENUM.IOT_FLOAT:
                                value = ((float)BitConverter.ToSingle(mByte, index));
                                index += 4;
                                break;
                            case IOT_FORMAT_ENUM.IOT_INT:
                                value = ((float)BitConverter.ToInt32(mByte, index));
                                index += 4;
                                break;
                            case IOT_FORMAT_ENUM.IOT_10TOINT:
                                value = ((float)BitConverter.ToInt32(mByte, index))/10;
                                index += 4;
                                break;
                            case IOT_FORMAT_ENUM.IOT_100TOINT:
                                value = ((float)BitConverter.ToInt32(mByte, index)) / 100;
                                index += 4;
                                break;
                            case IOT_FORMAT_ENUM.IOT_1000TOINT:
                                value = ((float)BitConverter.ToInt32(mByte, index)) / 1000;
                                index += 4;
                                break;
                            case IOT_FORMAT_ENUM.IOT_UINT:
                                value = ((float)BitConverter.ToUInt32(mByte, index));
                                index += 4;
                                break;
                            case IOT_FORMAT_ENUM.IOT_10TOUINT:
                                value = ((float)BitConverter.ToUInt32(mByte, index)) / 10;
                                index += 4;
                                break;
                            case IOT_FORMAT_ENUM.IOT_100TOUINT:
                                value = ((float)BitConverter.ToUInt32(mByte, index)) / 100;
                                index += 4;
                                break;
                            case IOT_FORMAT_ENUM.IOT_1000TOUINT:
                                value = ((float)BitConverter.ToUInt32(mByte, index)) / 1000;
                                index += 4;
                                break;
                            case IOT_FORMAT_ENUM.IOT_SHORT:
                                value = (float)BitConverter.ToInt16(mByte, index);
                                index += 2;
                                break;
                            case IOT_FORMAT_ENUM.IOT_100TOSHORT:
                                value = ((float)BitConverter.ToInt16(mByte, index)) / 100;
                                index += 2;
                                break;
                            case IOT_FORMAT_ENUM.IOT_1000TOSHORT:
                                value = ((float)BitConverter.ToInt16(mByte, index)) / 1000;
                                index += 2;
                                break;
                            case IOT_FORMAT_ENUM.IOT_USHORT:
                                value = (float)BitConverter.ToUInt16(mByte, index);
                                index += 2;
                                break;                            
                            case IOT_FORMAT_ENUM.IOT_100TOUSHORT:
                                value = ((float)BitConverter.ToUInt16(mByte, index)) / 100;
                                index += 2;
                                break;
                            case IOT_FORMAT_ENUM.IOT_1000TOUSHORT:
                                value = ((float)BitConverter.ToUInt16(mByte, index)) / 1000;
                                index += 2;
                                break;
                            case IOT_FORMAT_ENUM.IOT_INT8:
                                value = ((float)(sbyte)mByte[index]);
                                index += 1;
                                break;
                            case IOT_FORMAT_ENUM.IOT_10INT8:
                                value = ((float)(sbyte)mByte[index])*10;
                                index += 1;
                                break;
                            case IOT_FORMAT_ENUM.IOT_UINT8:
                                value = ((float)(byte)mByte[index]);
                                index += 1;
                                break;
                            case IOT_FORMAT_ENUM.IOT_10UINT8:
                                value = ((float)(byte)mByte[index]) * 10;
                                index += 1;
                                break;
                            default:
                                break;
                        }
                        if (!float.IsNaN(value))
                        {
                            message = CreateEvent(message, def, refDT.AddMinutes(-(count -1 - aggrIndex) * intervalAggr), sensorId, (SENSOR_TYPE_ENUM)sensorType, propertyIndex, (int)def.Aggregates[j], value, deviceInfo);

                        }

                    }
                }
            }
            return message;
        }
        protected virtual DeviceMessageDTO CreateEvent(DeviceMessageDTO message, DeviceIoTDataDef def, DateTime RefDT, int SensorId, 
                                                                SENSOR_TYPE_ENUM sensorType, int propertyIndex, int aggregateType, 
                                                                object value, DeviceDefinitionDTO deviceInfo)
        {
            object item = null;
            if (def.EventType == IOT_EVENT.MEASUREMENT)
            {
                item = GetDefinitionMeasurement(this,SensorId, propertyIndex, aggregateType);
                if (item != null)
                    SetMeasurement(message, RefDT, "", item, (float)value, deviceInfo);
            }
            else if (def.EventType == IOT_EVENT.STATE)
            {
                item = GetDefinitionState(this, SensorId, propertyIndex, (float)value);
                if (item != null)
                    SetState(message, RefDT, "", item, deviceInfo);
            }
            else if (def.EventType == IOT_EVENT.ALERT)
            {
                item = GetDefinitionAlert(this, SensorId, propertyIndex, (float)value);
                if (item!=null)
                    SetAlert(message, RefDT, "", item , deviceInfo);
            }
            return message;
        }
        protected object GetDefinitionState(object obj, int sensorIndex, int memberIndex, float value)
        {
            //GET ALL ENUMS FOR DEVICE
            string fullName = "IOT.METADATA." + obj.GetType().Name.Replace("_PARSER", "") + ".STATE";
            List<Type> enumTypes = this.GetType().Assembly.GetTypes().Where(t => t.FullName.StartsWith(fullName) && t.IsEnum).ToList();

            foreach (Type type in enumTypes)
            {
                MetaDataAttribute attEnum = GetAtt(type);
                if (attEnum != null)
                {
                    //MATCH THE MENBER INDEX
                    if (attEnum.MemberIndex == memberIndex && attEnum.SensorIndex==sensorIndex)
                    {
                        string[] names = type.GetEnumNames();
                        IEnumerable<FieldInfo> fieldInfos = type.GetFields().Where(p => !p.IsSpecialName);
                        foreach (FieldInfo field in fieldInfos)
                        {
                            MetaDataAttribute attEnumValue = (MetaDataAttribute)field.GetCustomAttributes(typeof(MetaDataAttribute), true).FirstOrDefault();
                            if (attEnumValue.Value == value)
                            {
                                var MyStatus = Enum.Parse(field.FieldType, field.Name,true);
                                return MyStatus;
                            }
                        }

                    }
                }

            }
            return null;
        }
        protected object GetDefinitionAlert(object obj, int sensorIndex, int memberIndex, float value)
        {
            //GET ALL ENUMS FOR DEVICE
            string fullName = "IOT.METADATA." + obj.GetType().Name.Replace("_PARSER", "") + ".ALERT";
            List<Type> enumTypes = this.GetType().Assembly.GetTypes().Where(t => t.FullName.StartsWith(fullName) && t.IsEnum).ToList();

            foreach (Type type in enumTypes)
            {
                MetaDataAttribute attEnum = GetAtt(type);
                if (attEnum != null)
                {
                    //MATCH THE MENBER INDEX
                    if (attEnum.MemberIndex == memberIndex &attEnum.SensorIndex== sensorIndex)
                    {
                        string[] names = type.GetEnumNames();
                        IEnumerable<FieldInfo> fieldInfos = type.GetFields().Where(p => !p.IsSpecialName); 
                        foreach (FieldInfo field in fieldInfos)
                        {
                            MetaDataAttribute attEnumValue = (MetaDataAttribute)field.GetCustomAttributes(typeof(MetaDataAttribute), true).FirstOrDefault();
                            if (attEnumValue.Value == value)
                            {
                                var MyStatus = Enum.Parse(field.FieldType, field.Name, true);
                                return MyStatus;
                            }
                        }

                    }
                }

            }
            return null;
        }
        protected object GetDefinitionMeasurement(object obj, int sensorIndex, int memberIndex, int aggregateType)
        {
            //GET ALL ENUMS FOR DEVICE
            string fullName = "IOT.METADATA." + obj.GetType().Name.Replace("_PARSER", "") + ".MEASUREMENT";
            List<Type> enumTypes = this.GetType().Assembly.GetTypes().Where(t => t.FullName.StartsWith(fullName) && t.IsEnum).ToList();

            foreach (Type type in enumTypes)
            {
                MetaDataAttribute attEnum = GetAtt(type);
                if (attEnum != null)
                {
                    //MATCH THE MENBER INDEX
                    if (attEnum.MemberIndex == memberIndex && attEnum.SensorIndex== sensorIndex)
                    {
                        string[] names = type.GetEnumNames();
                        IEnumerable<FieldInfo> fieldInfos = type.GetFields().Where(p => !p.IsSpecialName);
                        foreach (FieldInfo field in fieldInfos)
                        {
                            MetaDataAttribute attEnumValue = (MetaDataAttribute)field.GetCustomAttributes(typeof(MetaDataAttribute), true).FirstOrDefault();
                            if (attEnumValue.Value == aggregateType)
                            {
                                var MyStatus = Enum.Parse(field.FieldType, field.Name, true);
                                return MyStatus;
                            }
                        }
                        
                    }
                }

            }
            return null;
        }

        protected static byte[] HexToBytes(string hex)
        {

            var len = hex.Length / 2;

            byte[] arr = new byte[len];
            int charIndex = 0;
            for (int i = 0; i < len; i++)
            {
                int hi = HexVal(hex[charIndex++]),
                    lo = HexVal(hex[charIndex++]);
                arr[i] = (byte)((hi << 4) | lo);
            }
            return arr;
        }
        protected static int HexVal(char c)
        {
            if (c >= '0' && c <= '9') return c - '0';
            if (c >= 'a' && c <= 'f') return c - 'a' + 10;
            if (c >= 'A' && c <= 'F') return c - 'A' + 10;
            return ThrowArgOutOfRange(nameof(c));
        }
        protected static int ThrowArgOutOfRange(string argName) =>
            throw new ArgumentOutOfRangeException(argName);

        
    }

}


