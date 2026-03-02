using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Collections;
using IoTEx.WaternetIoT.Model.DTOs.API;
using IoTEx.Waternet.Common;
using IoTEx.WaternetIoT.Model.DTOs;

namespace IoTEx.Waternet.Parser
{
    public class SODAQ_FLOW_METER_TEMP_V1_PARSER : BaseParser
    {
        public override string Version
        {
            get { return "1.5.0"; }
        }        
        public override List<DeviceDefinitionConfigurationDTO> GetDeviceTypeConfigurationItems()
        {
            List<DeviceDefinitionConfigurationDTO> configs = new List<DeviceDefinitionConfigurationDTO>();
            configs.Add(new DeviceDefinitionConfigurationDTO() {name = "SampleInterval", description= "SampleInterval", symbol = "sm", value = "2", type=DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_uint16});
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "AggregateInterval", description = "AggregateInterval", symbol = "aggint", value = "0", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_uint16 });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "UploadInterval", description = "UploadInterval", symbol = "upint", value = "0", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_uint16 });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "h0NAP", description = "The static NAP height of h0", symbol = "lv0", value = "1", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_int16 });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "h1NAP", description = "The static NAP height of h1", symbol = "lv1", value = "1", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_int16 });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "h2NAP", description = "The static NAP height of h2", symbol = "lv2", value = "1", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_int16 });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "h3NAP", description = "The static NAP height of h3", symbol = "lv3", value = "1", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_uint16 });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "linearCoeff", description = "The linear coefficient in the Flow Formula flow=lcof*x^pcof", symbol = "lcof", value = "2", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_float });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "powerCoeff", description = "The power coefficient in the Flow Formula flow = lcof * x ^ pcof", symbol = "pcof", value = "5", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_float });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "SensorSettleMS", description = "The number of ms the sensors should be switched on for accurate measurement ", symbol = "set", value = "5000", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_uint16 });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "Sensor1Min", description = "Minimun measured range of the Ultrasound Sensor S1", symbol = "smin1", value = "35", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_uint16 });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "Sensor2Min", description = "Minimun measured range of the Ultrasound Sensor S2", symbol = "smin2", value = "35", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_uint16 });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "Sensor3Min", description = "Minimun measured range of the Ultrasound Sensor S3", symbol = "smin3", value = "35", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_uint16 });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "Sensor1Max", description = "Maximum measured range of the Ultrasound Sensor S1", symbol = "smax1", value = "350", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_uint16 });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "Sensor2Max", description = "Maximum measured range of the Ultrasound Sensor S2", symbol = "smax2", value = "350", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_uint16 });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "Sensor3Max", description = "Maximum measured range of the Ultrasound Sensor S3", symbol = "smax3", value = "350", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_uint16 });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "TempMin", description = "Minimum measured range of the Temperature Sensor", symbol = "tmin", value = "0", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_uint16 });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "TempMax", description = "Maximum measured range of the Temperature Sensor", symbol = "tmax", value = "100", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_uint16 });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "FlowEquation", description = "The device knows three flow equations depending on type (A=0/B=1/C=2)",Categories="[0,1,2]", MinValue=0, MaxValue=2, symbol = "eq", value = "1",type= DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_uint8 });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "SensorEnableMask", description = "BitMask to define which sensors should be on or off (S1=1,S2=2,S3=4,T=8)", symbol = "sem", value = "15", MinValue=0, MaxValue=15, type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_uint8 });
            
            return configs;

        }
        /// <summary>
        /// Create the message structure to send configuration message to the device
        /// </summary>        
        public override APIResultDTO<string> GenerateConfigureDeviceMessage(List<DeviceDefinitionConfigurationDTO> configs )
        {
            APIResultDTO<string> result = new APIResultDTO<string>();

            List<DeviceDefinitionConfigurationDTO> oriConfigs = GetDeviceTypeConfigurationItems();
            
            byte[] buffer = new byte[100];
            int pos = 0;
            for (int i = 0; i < oriConfigs.Count; i++)
            {
                byte[] byteArray;
                if (oriConfigs[i].GetTrueType() == typeof(float))
                    byteArray = BitConverter.GetBytes(GetFloatFromConfig(configs, oriConfigs[i]));
                else if (oriConfigs[i].GetTrueType() == typeof(UInt16))
                    byteArray = BitConverter.GetBytes(GetUInt16FromConfig(configs, oriConfigs[i]));
                else if (oriConfigs[i].GetTrueType() == typeof(Int16))
                    byteArray = BitConverter.GetBytes(GetInt16FromConfig(configs, oriConfigs[i]));
                else if (oriConfigs[i].GetTrueType() == typeof(sbyte))
                {
                    byteArray = new byte[1];
                    byteArray[0] = (byte)GetsByteFromConfig(configs, oriConfigs[i]);
                }
                else if (oriConfigs[i].GetTrueType() == typeof(byte))
                {
                    byteArray = new byte[1];
                    byteArray[0] = (byte) GetByteFromConfig(configs, oriConfigs[i]);
                }
                else
                    byteArray = BitConverter.GetBytes(GetInt16FromConfig(configs, oriConfigs[i]));

                //Array.Reverse(byteArray);
                Array.Copy(byteArray, 0, buffer, pos, byteArray.Length);
                pos += byteArray.Length;

            }
            byte[] finalBuffer = new byte[pos];

            Array.Copy(buffer, 0, finalBuffer, 0, pos);
            if (finalBuffer.Length != 42)
            {
                result.IsOk = false;
                result.Error = "SIZE BUFFER IN PARSER IS NOT MATCHING THE EXPECTED LENGTH" + ":" + 42;
            }
            else
            {
                result.IsOk = true;
                result.Value = Function.ByteArrayToHexString(finalBuffer);
            }
            return result;
        }

        /// <summary>
        /// Main Parsing function 
        /// </summary>        
        public override DeviceMessageDTO ParseIncomingDeviceMessage(DeviceMessageDTO message, string payload, PayLoadEncryptionEnum enc, DeviceDefinitionDTO deviceInfo)
        {

            byte[] buffer = null;
            

            if (enc == PayLoadEncryptionEnum.HEX)
            {
                buffer = Function.HexStringToByteArray(payload);
                
            }
            ParseMsg(buffer, message, deviceInfo);
            return message;
        }
        
        private DeviceMessageDTO ParseMsg(byte[] buffer, DeviceMessageDTO message, DeviceDefinitionDTO deviceInfo)
        {
                        
            try
            {
                int recordCount = getByte(buffer[0], 0, 4);
                bool On12Volt = Convert.ToBoolean(getByte(buffer[0], 4, 1));
                byte RFU = getByte(buffer[0], 5, 3);
                double batteryVoltage = ((Convert.ToDouble(buffer[1]) + 200) * 10)/1000; //Transform from mV to V
                double SourceVoltage = (Convert.ToDouble(buffer[2]) * 100) / 1000;

                int position = 3;
                int oldDt = 0;
                

                //ADD INT BATTERY
                


                for (int i = 0; i < recordCount; i++)
                {
                    //message.Events.Clear();
                    Int32 dt = BitConverter.ToInt32(buffer, position);
                    string DEUID = dt.ToString();
                    DateTime estimatedDate = message.rcvDateTime;

                    if (i == 0)
                    {
                        SetMeasurement(message, estimatedDate, DEUID, IOT.METADATA.SODAQ_FLOW_METER_TEMP_V1.MEASUREMENT.INT_VOLTAGE.ACTUAL, Convert.ToDouble(batteryVoltage), deviceInfo);
                        SetMeasurement(message, estimatedDate, DEUID, IOT.METADATA.SODAQ_FLOW_METER_TEMP_V1.MEASUREMENT.EXT_VOLTAGE.ACTUAL, Convert.ToDouble(SourceVoltage), deviceInfo);

                        message.DMUID = dt.ToString();
                    }
                    if (i > 0)
                    {
                        Int32 deltaTijd = dt - oldDt;
                        estimatedDate = estimatedDate.AddSeconds(i * deltaTijd);
                    }
                    
                    Int16 H1 = BitConverter.ToInt16(buffer, position + 4);
                    Int16 H2 = BitConverter.ToInt16(buffer, position + 6);
                    Int16 H3 = BitConverter.ToInt16(buffer, position + 8);
                    Int16 T = BitConverter.ToInt16(buffer, position + 10);
                    float flow = BitConverter.ToSingle(buffer, position + 12);
                    
                    position += 16;
                    
                    //Create Events for each Record
                    SetMeasurement(message, estimatedDate, DEUID, IOT.METADATA.SODAQ_FLOW_METER_TEMP_V1.MEASUREMENT.NAP_LEVEL_UPSTREAM.ACTUAL, Convert.ToDouble(H1) / 1000, deviceInfo);
                    SetMeasurement(message, estimatedDate, DEUID, IOT.METADATA.SODAQ_FLOW_METER_TEMP_V1.MEASUREMENT.NAP_LEVEL_DOWNSTREAM.ACTUAL, Convert.ToDouble(H2) / 1000, deviceInfo);
                    SetMeasurement(message, estimatedDate, DEUID, IOT.METADATA.SODAQ_FLOW_METER_TEMP_V1.MEASUREMENT.NAP_LEVEL_PLATE.ACTUAL, Convert.ToDouble(H3) / 1000, deviceInfo);
                    double TEMP = Convert.ToDouble(T) / 100;
                    if (TEMP<100)
                        SetMeasurement(message, estimatedDate, DEUID, IOT.METADATA.SODAQ_FLOW_METER_TEMP_V1.MEASUREMENT.WATER_TEMPERATURE.ACTUAL, TEMP, deviceInfo);

                    SetMeasurement(message, estimatedDate, DEUID, IOT.METADATA.SODAQ_FLOW_METER_TEMP_V1.MEASUREMENT.FLOW.ACTUAL, (double.IsNaN(flow)) ? 0 : flow, deviceInfo);

                    

                    //Reset old time
                    oldDt = dt;
                }

            }
            catch
            {

            }
            return message;
        }


        #region UTILITY
        private static byte getByte(byte bt, int start, int length)
        {
            byte[] exBytes = new byte[1];
            exBytes[0] = bt;

            BitArray bArr = new BitArray(exBytes);
            BitArray newBArr = new BitArray(8);
            for (int i = 0; i < 8; i++)
            {
                newBArr.Set(i, false);
            }
            int counter = 0;
            for (int i = start; i < start + length; i++)
            {
                newBArr.Set(counter, bArr.Get(i));
                counter++;
            }
            byte[] bytes = new byte[1];
            newBArr.CopyTo(bytes, 0);
            return bytes[0];
        }
        #endregion
    }

}
