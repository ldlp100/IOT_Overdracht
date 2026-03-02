using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using IOT.DEVICE;
using System.Linq;
using System.Reflection;
using IoTEx.WaternetIoT.Model.DTOs.API;
using IoTEx.WaternetIoT.Data.Model;


using IoTEx.WaternetIoT.Model.DTOs;
using static IoTEx.WaternetIoT.Model.DTOs.DeviceMessageEventDTO;

namespace IoTEx.Waternet.Parser
{
    public abstract class BaseParser : IBaseParser
    {
        public abstract string Version { get; }
        public string Name { get { return GetType().Name; } }

        public abstract DeviceMessageDTO ParseIncomingDeviceMessage(DeviceMessageDTO message, string payload, PayLoadEncryptionEnum enc, DeviceDefinitionDTO deviceInfo);
        public abstract APIResultDTO<string> GenerateConfigureDeviceMessage(List<DeviceDefinitionConfigurationDTO> configs);
        public abstract List<DeviceDefinitionConfigurationDTO> GetDeviceTypeConfigurationItems();

        #region METHOD TO SET THE EVENTS
        protected void SetInfo(DeviceMessageDTO message, DateTime dt, string eduid, object obj, string value, DeviceDefinitionDTO deviceInfo)
        {
            Type type = obj.GetType();
            MetaDataAttribute att = GetAtt(type);
            if (att != null)
            {
                string Name = type.Name + "." + obj.ToString();
                DeviceMessageEventDTO evt = new DeviceMessageEventDTO()
                {
                    received = dt,
                    name = Name,
                    type = DeviceEventType.INFO,
                    info = value,
                    EDUID = eduid,

                };
                evt = ManageProcessCode(evt, deviceInfo, DeviceEventType.INFO);
                message.events.Add(evt);
            }
        }

        protected void SetMeasurement(DeviceMessageDTO message, DateTime dt, string eduid, object obj, double value, DeviceDefinitionDTO deviceInfo)
        {
            Type type = obj.GetType();
            MetaDataAttribute att = GetAtt(type);
            if (att != null)
            {
                string Name = type.Name + "." + obj.ToString();
                DeviceMessageEventDTO evt = new DeviceMessageEventDTO()
                {
                    received = dt,
                    name = Name,
                    type = DeviceEventType.MEASUREMENT,
                    value = value,
                    EDUID = eduid,
                    unit = att.Unit.ToString()
                };
                evt = ManageProcessCode(evt, deviceInfo, DeviceEventType.MEASUREMENT);
                message.events.Add(evt);
            }
        }
        protected void SetAlert(DeviceMessageDTO message, DateTime dt, string eduid, object obj, DeviceDefinitionDTO deviceInfo)
        {

            SetAlertState(DeviceEventType.ALERT, message, dt, eduid, obj, deviceInfo);
        }
        protected void SetState(DeviceMessageDTO message, DateTime dt, string eduid, object obj, DeviceDefinitionDTO deviceInfo)
        {
            Type type = obj.GetType();
            SetAlertState(DeviceEventType.STATE, message, dt, eduid, obj, deviceInfo);
        }
        private void SetAlertState(DeviceEventType eventType, DeviceMessageDTO message, DateTime dt, string eduid, object obj, DeviceDefinitionDTO deviceInfo)
        {
            Type type = obj.GetType();
            IEnumerable<FieldInfo> fieldInfos = type.GetFields().Where(p => !p.IsSpecialName);
            foreach (FieldInfo field in fieldInfos)
            {
                if (field.Name == obj.ToString())
                {
                    MetaDataAttribute attEnumValue = (MetaDataAttribute)field.GetCustomAttributes(typeof(MetaDataAttribute), true).FirstOrDefault();
                    if (attEnumValue != null)
                    {
                        string Name = type.Name + "." + obj.ToString();
                        DeviceMessageEventDTO evt = new DeviceMessageEventDTO()
                        {
                            received = dt,
                            name = Name,
                            type = eventType,
                            value = attEnumValue.Value,
                            EDUID = eduid
                        };
                        evt = ManageProcessCode(evt, deviceInfo, eventType);
                        message.events.Add(evt);
                    }
                }
            }
        }
        #endregion


        #region METADATA
        public DeviceDefinitionSettingsDTO GetDeviceMetaDataDefinition()
        {
            DeviceDefinitionSettingsDTO devDefinition = new DeviceDefinitionSettingsDTO();
            devDefinition.Version = this.Version;
            string name = this.GetType().Name;
            name = name.Substring(0, name.Length - "_PARSER".Length);
            devDefinition.states.AddRange(GetDefinitionStates(name));
            devDefinition.alerts.AddRange(GetDefinitionAlerts(name));
            devDefinition.measurements.AddRange(GetDefinitionMeasurements(name));
            //devDefinition.info.AddRange(GetDefinitionInfos(name));
            devDefinition.configurations.AddRange(GetDeviceTypeConfigurationItems());
            return devDefinition;

        }
        protected MetaDataAttribute GetAtt(Type type)
        {
            MetaDataAttribute att = (MetaDataAttribute)type.GetCustomAttributes(typeof(MetaDataAttribute), true).FirstOrDefault();
            return att;
        }

        private List<DeviceDefinitionStateDTO> GetDefinitionStates(string name)
        {
            List<DeviceDefinitionStateDTO> list = new List<DeviceDefinitionStateDTO>();
            string fullName = "IOT.METADATA." + name + ".STATE";

            List<Type> enumType = this.GetType().Assembly.GetTypes().Where(t => t.FullName.StartsWith(fullName) && t.IsEnum).ToList();
            foreach (Type type in enumType)
            {

                List<DeviceDefinitionSubStateDTO> subList = new List<DeviceDefinitionSubStateDTO>();
                FieldInfo[] fieldInfos = type.GetFields();
                foreach (FieldInfo field in fieldInfos)
                {
                    MetaDataAttribute attEnumValue = (MetaDataAttribute)field.GetCustomAttributes(typeof(MetaDataAttribute), true).FirstOrDefault();
                    if (attEnumValue != null)
                    {
                        subList.Add(new DeviceDefinitionSubStateDTO() { name = field.Name, value = attEnumValue.Value, description = attEnumValue.Description });
                    }

                }

                MetaDataAttribute attEnum = GetAtt(type);
                if (attEnum != null)
                {
                    list.Add(new DeviceDefinitionStateDTO()
                    {
                        description = attEnum.Description + "",
                        name = type.Name,
                        //Unit = attEnum.Unit,
                        values = subList
                    });
                }

            }
            return list;
        }
        private List<DeviceDefinitionAlertDTO> GetDefinitionAlerts(string name)
        {
            List<DeviceDefinitionAlertDTO> list = new List<DeviceDefinitionAlertDTO>();
            string fullName = "IOT.METADATA." + name + ".ALERT";

            List<Type> enumType = this.GetType().Assembly.GetTypes().Where(t => t.FullName.StartsWith(fullName) && t.IsEnum).ToList();
            foreach (Type type in enumType)
            {

                List<DeviceDefinitionSubStateDTO> subList = new List<DeviceDefinitionSubStateDTO>();
                FieldInfo[] fieldInfos = type.GetFields();
                foreach (FieldInfo field in fieldInfos)
                {
                    MetaDataAttribute attEnumValue = (MetaDataAttribute)field.GetCustomAttributes(typeof(MetaDataAttribute), true).FirstOrDefault();
                    if (attEnumValue != null)
                    {
                        subList.Add(new DeviceDefinitionSubStateDTO() { name = field.Name, value = attEnumValue.Value, description = attEnumValue.Description });
                    }

                }

                MetaDataAttribute attEnum = GetAtt(type);
                if (attEnum != null)
                {
                    list.Add(new DeviceDefinitionAlertDTO()
                    {
                        description = attEnum.Description + "",
                        name = type.Name,
                        values = subList
                    });
                }

            }
            return list;
        }
        private List<DeviceDefinitionMeasurementDTO> GetDefinitionMeasurements(string name)
        {
            List<DeviceDefinitionMeasurementDTO> list = new List<DeviceDefinitionMeasurementDTO>();
            string fullName = "IOT.METADATA." + name + ".MEASUREMENT";

            List<Type> enumType = this.GetType().Assembly.GetTypes().Where(t => t.FullName.StartsWith(fullName) && t.IsEnum).ToList();
            foreach (Type type in enumType)
            {
                MetaDataAttribute attEnum = GetAtt(type);
                if (attEnum != null)
                {
                    list.Add(new DeviceDefinitionMeasurementDTO()
                    {
                        description = attEnum.Description + "",
                        name = type.Name,
                        unitLabel = attEnum.Unit.ToString()
                    });
                }

            }
            return list;
        }
        private List<DeviceDefinitionExtraInfoDTO> GetDefinitionInfos(string name)
        {
            List<DeviceDefinitionExtraInfoDTO> list = new List<DeviceDefinitionExtraInfoDTO>();
            string fullName = "IOT.METADATA." + name + ".INFO";

            List<Type> enumType = this.GetType().Assembly.GetTypes().Where(t => t.FullName.StartsWith(fullName) && t.IsEnum).ToList();
            foreach (Type type in enumType)
            {

                MetaDataAttribute attEnum = GetAtt(type);
                if (attEnum != null)
                {
                    list.Add(new DeviceDefinitionExtraInfoDTO()
                    {
                        description = attEnum.Description + "",
                        name = type.Name
                    });
                }

            }
            return list;
        }

        protected void GetValueConfigurationItem(DeviceDefinitionDTO deviceInfo, string name,ref object variable)
        {
            if (deviceInfo != null)
            {
                if (deviceInfo.settings != null)
                {
                    if (deviceInfo.settings.configurations != null)
                    {

                        DeviceDefinitionConfigurationDTO config = deviceInfo.settings.configurations.Find(o => o.name == name);
                        if (config != null)
                        {
                            switch (config.type)
                            {
                                case DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_string:
                                    variable = config.value;
                                    break;
                                case DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_bool:
                                    short refBool;
                                    if (short.TryParse(config.value, out refBool))
                                    {
                                        variable = (refBool == 1);
                                    }
                                    break;
                                case DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_int16:
                                    Int16 refInt;
                                    if (short.TryParse(config.value, out refInt))
                                    {
                                        variable = refInt;
                                    }                                    
                                    break;
                                case DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_date:
                                    DateTime refDT;
                                    if (DateTime.TryParse(config.value, out refDT))
                                    {
                                        variable = refDT;
                                    }
                                    break;
                                    break;
                                case DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_uint16:
                                    UInt16 refUInt;
                                    if (ushort.TryParse(config.value, out refUInt))
                                    {
                                        variable = refUInt;
                                    }
                                    break;
                                    
                                case DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_float:
                                    float refFloat;
                                    if (float.TryParse(config.value, out refFloat))
                                    {
                                        variable = refFloat;
                                    }
                                    break;
                                case DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_uint8:
                                    ushort refushort;
                                    if (ushort.TryParse(config.value, out refushort))
                                    {
                                        variable = refushort;
                                    }
                                    break;
                                case DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_int8:
                                    short refshort;
                                    if (short.TryParse(config.value, out refshort))
                                    {
                                        variable = refshort;
                                    }
                                    break;
                                case DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_double:
                                    double refDouble;
                                    if (double.TryParse(config.value, out refDouble))
                                    {
                                        variable = refDouble;
                                    }
                                    break;
                                
                            }


                        }

                    }
                }
            }
            
        }


        protected double GetStateAlertValue(Type enumType)
        {
            MetaDataAttribute att = GetAtt(enumType);
            if (att != null)
            {
                return att.Value;
            }
            return double.NaN;
        }

        protected UInt16 GetUInt16FromConfig(List<DeviceDefinitionConfigurationDTO> configs, DeviceDefinitionConfigurationDTO oriConfiguration)
        {
            DeviceDefinitionConfigurationDTO configuration = configs.Find(o => o.name == oriConfiguration.name);


            UInt16 value;

            if (configuration != null)
            {
                if (UInt16.TryParse(configuration.value, out value))
                {
                    return value;
                }
            }
            UInt16.TryParse(oriConfiguration.value, out value);
            return value;
        }
        protected Int16 GetInt16FromConfig(List<DeviceDefinitionConfigurationDTO> configs, DeviceDefinitionConfigurationDTO oriConfiguration)
        {
            DeviceDefinitionConfigurationDTO configuration = configs.Find(o => o.name == oriConfiguration.name);


            Int16 value;

            if (configuration != null)
            {
                if (Int16.TryParse(configuration.value, out value))
                {
                    return value;
                }
            }
            Int16.TryParse(oriConfiguration.value, out value);
            return value;

        }
        protected byte GetByteFromConfig(List<DeviceDefinitionConfigurationDTO> configs, DeviceDefinitionConfigurationDTO oriConfiguration)
        {
            DeviceDefinitionConfigurationDTO configuration = configs.Find(o => o.name == oriConfiguration.name);


            byte value;

            if (configuration != null)
            {
                if (byte.TryParse(configuration.value, out value))
                {
                    return value;
                }
            }
            byte.TryParse(oriConfiguration.value, out value);
            return value;
        }
        protected sbyte GetsByteFromConfig(List<DeviceDefinitionConfigurationDTO> configs, DeviceDefinitionConfigurationDTO oriConfiguration)
        {
            DeviceDefinitionConfigurationDTO configuration = configs.Find(o => o.name == oriConfiguration.name);


            sbyte value;

            if (configuration != null)
            {
                if (sbyte.TryParse(configuration.value, out value))
                {
                    return value;
                }
            }
            sbyte.TryParse(oriConfiguration.value, out value);
            return value;
        }
        protected float GetFloatFromConfig(List<DeviceDefinitionConfigurationDTO> configs, DeviceDefinitionConfigurationDTO oriConfiguration)
        {
            DeviceDefinitionConfigurationDTO configuration = configs.Find(o => o.name == oriConfiguration.name);


            float value;

            if (configuration != null)
            {
                if (float.TryParse(configuration.value, out value))
                {
                    return value;
                }
            }
            float.TryParse(oriConfiguration.value, out value);
            return value;
        }
        #endregion

        protected object GetObjectEnum(Type type, double value)
        {

            FieldInfo[] fieldInfos = type.GetFields();
            foreach (FieldInfo field in fieldInfos)
            {
                MetaDataAttribute attEnumValue = (MetaDataAttribute)field.GetCustomAttributes(typeof(MetaDataAttribute), true).FirstOrDefault();
                if (attEnumValue != null)
                {
                    if (attEnumValue.Value == value)
                    {
                        object obj = Enum.Parse(type, field.Name);
                        return obj;
                    }
                }

            }
            return null;
        }
        private static DeviceMessageEventDTO ManageProcessCode(DeviceMessageEventDTO evt, DeviceDefinitionDTO deviceInfo, DeviceEventType eventType)
        {
            DeviceDefinitionProcessCodeDTO Process = null;
            DeviceDefinitionMeasurementDTO Measurement = null;

            evt.pcValue = evt.value.ToString();

            if (eventType == DeviceEventType.ALERT)
            {
                Process = deviceInfo.settings.processCodes.Find(p => p.alertName == evt.name);
            }
            else if (eventType == DeviceEventType.STATE)
                Process = deviceInfo.settings.processCodes.Find(p => p.stateName == evt.name);
            else if (eventType == DeviceEventType.MEASUREMENT)
            {
                //LL-CORRECT IN FUTURE
                int pos = evt.name.IndexOf('.');
                string shortName = evt.name.Substring(0, pos);
                Process = deviceInfo.settings.processCodes.Find(p => p.measurementName == shortName);
                Measurement = deviceInfo.settings.measurements.Find(p => p.name == shortName);
                if (Measurement != null && Process != null)
                    evt.pcValue = ConvertValue(evt.value, Measurement.unitLabel, Process.unitTypeLabel);
            }
            else if (eventType == DeviceEventType.INFO)
                Process = deviceInfo.settings.processCodes.Find(p => p.infoName == evt.name);

            if (Process != null)
            {
                evt.pc = Process.name;
                evt.pcUnit = Process.unitTypeName;
            }
            else
            {
                evt.pcValue = null;
            }
            return evt;
        }
        private static string ConvertValue(double value, string oriUnit, string targetUnit)
        {

            if (oriUnit == targetUnit)
                return value.ToString();
            else if (oriUnit == IOT.METADATA.UNITS.UnitsEnum.m3_per_day.ToString() && targetUnit == IOT.METADATA.UNITS.UnitsEnum.m3_per_hour.ToString())
                return (value / 24).ToString();
            else
                return double.NaN.ToString();
        }
    }
}
