using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Collections;
using IoTEx.WaternetIoT.Model.DTOs.API;
using IoTEx.Waternet.Common;
using IoTEx.WaternetIoT.Model.DTOs;

namespace IoTEx.Waternet.Parser
{
    public class SODAQ_FLOW_METER_TEMP_V1_6_PARSER : BaseParser
    {
        public override string Version
        {
            get { return "1.6.0"; }
        }        
        public override List<DeviceDefinitionConfigurationDTO> GetDeviceTypeConfigurationItems()
        {
            List<DeviceDefinitionConfigurationDTO> configs = new List<DeviceDefinitionConfigurationDTO>();
            configs.Add(new DeviceDefinitionConfigurationDTO() {name = "SampleInterval", description= "SampleInterval", symbol = "sampint=", value = "30", type=DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_uint16});
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "AggregateInterval", description = "AggregateInterval", symbol = "aggint", value = "0", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_uint16 });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "UploadInterval", description = "UploadInterval", symbol = "upint", value = "0", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_uint16 });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "h0NAP", description = "The static NAP height of h0", symbol = "h0ref", value = "0", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_int16 });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "h1NAP", description = "The static NAP height of h1", symbol = "h1ref", value = "0", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_int16 });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "h2NAP", description = "The static NAP height of h2", symbol = "h2ref", value = "0", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_int16 });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "h3NAP", description = "The static NAP height of h3", symbol = "h3ref", value = "0", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_uint16 });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "linearCoeff", description = "The linear coefficient in the Flow Formula flow=lcof*x^pcof", symbol = "lcoef", value = "2", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_float });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "powerCoeff", description = "The power coefficient in the Flow Formula flow = lcof * x ^ pcof", symbol = "pcoef", value = "5", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_float });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "SensorSettleMS", description = "The number of ms the sensors should be switched on for accurate measurement ", symbol = "sset", value = "5000", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_uint16 });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "Sensor1Min", description = "Minimun measured range of the Ultrasound Sensor S1", symbol = "umin1", value = "35", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_uint16 });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "Sensor2Min", description = "Minimun measured range of the Ultrasound Sensor S2", symbol = "umin2", value = "35", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_uint16 });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "Sensor3Min", description = "Minimun measured range of the Ultrasound Sensor S3", symbol = "umin3", value = "35", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_uint16 });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "Sensor1Max", description = "Maximum measured range of the Ultrasound Sensor S1", symbol = "umax1", value = "350", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_uint16 });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "Sensor2Max", description = "Maximum measured range of the Ultrasound Sensor S2", symbol = "umax2", value = "350", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_uint16 });
            configs.Add(new DeviceDefinitionConfigurationDTO() { name = "Sensor3Max", description = "Maximum measured range of the Ultrasound Sensor S3", symbol = "umax3", value = "350", type = DeviceDefinitionConfigurationDTO.ConfigurationTypeEnum.type_uint16 });
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
            short messageType = getByte(buffer[0], 0, 4);
            if (messageType==2)
                ParseConfigurationMsg(buffer, message, deviceInfo);
            else if (messageType==1)
                ParseMeasurementMsg(buffer, message, deviceInfo);
            return message;
        }
        private DeviceMessageDTO ParseConfigurationMsg(byte[] buffer, DeviceMessageDTO message, DeviceDefinitionDTO deviceInfo)
        {

            try
            {
                Int32 DEUID = BitConverter.ToInt32(buffer, 1);
                Int16 sampleInterval = BitConverter.ToInt16(buffer, 5);
                Int16 h0NAP = BitConverter.ToInt16(buffer, 7);
                Int16 h1NAP = BitConverter.ToInt16(buffer, 9);
                Int16 h2NAP = BitConverter.ToInt16(buffer, 11);
                Int16 h3NAP = BitConverter.ToInt16(buffer, 13);
                float linearCoeff = BitConverter.ToSingle(buffer, 15);
                float powerCoeff = BitConverter.ToSingle(buffer, 19);
                Int16 sensorSettleMS = BitConverter.ToInt16(buffer, 23);
                Int16 sensor1Min = BitConverter.ToInt16(buffer, 25);
                Int16 sensor2Min = BitConverter.ToInt16(buffer, 27);
                Int16 sensor3Min = BitConverter.ToInt16(buffer, 29);
                Int16 sensor1Max = BitConverter.ToInt16(buffer, 31);
                Int16 sensor2Max = BitConverter.ToInt16(buffer, 33);
                Int16 sensor3Max = BitConverter.ToInt16(buffer, 35);
                Int16 tempMin = BitConverter.ToInt16(buffer, 37);
                Int16 tempMax = BitConverter.ToInt16(buffer, 39);
                short flowEquation = getByte(buffer[41], 0, 4);
                short sensor1Mask = getByte(buffer[41], 4, 1);
                short sensor2Mask = getByte(buffer[41], 5, 1);
                short sensor3Mask = getByte(buffer[41], 6, 1);
                short sensor4Mask = getByte(buffer[41], 7, 1);
                DateTime estimatedDate = message.rcvDateTime;

                //SetInfo(message, estimatedDate, DEUID, IOT.METADATA.SODAQ_FLOW_METER_TEMP_V1_6.INFO..INT_VOLTAGE.ACTUAL, Convert.ToDouble(batteryVoltage), deviceInfo);


            }
            catch
            {

            }
            return message;
        }
        private DeviceMessageDTO ParseMeasurementMsg(byte[] buffer, DeviceMessageDTO message, DeviceDefinitionDTO deviceInfo)
        {
                        
            try
            {
                int recordCount = getByte(buffer[1], 0, 4);
                bool On12Volt = Convert.ToBoolean(getByte(buffer[1], 4, 1));
                byte RFU = getByte(buffer[1], 5, 3);
                double batteryVoltage = ((Convert.ToDouble(buffer[2]) + 200) * 10)/1000; //Transform from mV to V
                double SourceVoltage = (Convert.ToDouble(buffer[3]) * 100) / 1000;

                int position = 4;
                int oldDt = 0;
                

                //ADD INT BATTERY
                
                for (int i = 0; i < recordCount; i++)
                {
                    Int32 dt = BitConverter.ToInt32(buffer, position);
                    string DEUID = dt.ToString();
                    DateTime estimatedDate = message.rcvDateTime;

                    if (i == 0)
                    {
                        SetMeasurement(message, estimatedDate, DEUID, IOT.METADATA.SODAQ_FLOW_METER_TEMP_V1_6.MEASUREMENT.INT_VOLTAGE.ACTUAL, Convert.ToDouble(batteryVoltage), deviceInfo);
                        SetMeasurement(message, estimatedDate, DEUID, IOT.METADATA.SODAQ_FLOW_METER_TEMP_V1_6.MEASUREMENT.EXT_VOLTAGE.ACTUAL, Convert.ToDouble(SourceVoltage), deviceInfo);

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
                    Int16 HW = BitConverter.ToInt16(buffer, position + 10);
                    Int16 T = BitConverter.ToInt16(buffer, position + 12);
                    float flow = BitConverter.ToSingle(buffer, position + 14);
                    
                    position += 18;
                    
                    //Create Events for each Record
                    SetMeasurement(message, estimatedDate, DEUID, IOT.METADATA.SODAQ_FLOW_METER_TEMP_V1_6.MEASUREMENT.NAP_LEVEL_UPSTREAM.ACTUAL, Convert.ToDouble(H1) / 1000, deviceInfo);
                    SetMeasurement(message, estimatedDate, DEUID, IOT.METADATA.SODAQ_FLOW_METER_TEMP_V1_6.MEASUREMENT.NAP_LEVEL_DOWNSTREAM.ACTUAL, Convert.ToDouble(H2) / 1000, deviceInfo);
                    SetMeasurement(message, estimatedDate, DEUID, IOT.METADATA.SODAQ_FLOW_METER_TEMP_V1_6.MEASUREMENT.NAP_LEVEL_PLATE.ACTUAL, Convert.ToDouble(H3) / 1000, deviceInfo);
                    SetMeasurement(message, estimatedDate, DEUID, IOT.METADATA.SODAQ_FLOW_METER_TEMP_V1_6.MEASUREMENT.WATER_HEIGHT_OPENING.ACTUAL, Convert.ToDouble(HW) / 1000, deviceInfo);

                    double TEMP = Convert.ToDouble(T) / 100;
                    if (TEMP<100)
                        SetMeasurement(message, estimatedDate, DEUID, IOT.METADATA.SODAQ_FLOW_METER_TEMP_V1_6.MEASUREMENT.WATER_TEMPERATURE.ACTUAL, TEMP, deviceInfo);

                    SetMeasurement(message, estimatedDate, DEUID, IOT.METADATA.SODAQ_FLOW_METER_TEMP_V1_6.MEASUREMENT.FLOW.ACTUAL, (double.IsNaN(flow)) ? 0 : flow, deviceInfo);

                    

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
