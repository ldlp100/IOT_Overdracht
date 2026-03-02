using System;
using System.Collections.Generic;
using Newtonsoft.Json;

using System.IO;
using System.Collections;
using System.Linq;
using System.Reflection;
using IOT.DEVICE;
using IoTEx.WaternetIoT.Model.DTOs.API;
using IoTEx.WaternetIoT.Data.Model;
using IoTEx.Waternet.Common;
using IoTEx.WaternetIoT.Model.DTOs;

namespace IoTEx.Waternet.Parser
{

    public class ELSYS_V1_PARSER : BaseParser
    {
        
        
        public override string Version
        {
            get { return "1.0.0."; }
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
            const byte TYPE_TEMP = 0x01; //temp 2 bytes -3276.8°C -->3276.7°C
            const byte TYPE_RH = 0x02; //Humidity 1 byte  0-100%
            const byte TYPE_ACC = 0x03; //acceleration 3 bytes X,Y,Z -128 --> 127 +/-63=1G
            const byte TYPE_LIGHT = 0x04; //Light 2 bytes 0-->65535 Lux
            const byte TYPE_MOTION = 0x05; //No of motion 1 byte  0-255
            const byte TYPE_CO2 = 0x06; //Co2 2 bytes 0-65535 ppm 
            const byte TYPE_VDD = 0x07; //VDD 2byte 0-65535mV
            const byte TYPE_ANALOG1 = 0x08; //VDD 2byte 0-65535mV
            const byte TYPE_GPS = 0x09; //3bytes lat 3bytes long binary
            const byte TYPE_PULSE1 = 0x0A; //2bytes relative pulse count
            const byte TYPE_PULSE1_ABS = 0x0B;  //4bytes no 0->0xFFFFFFFF
            const byte TYPE_EXT_TEMP1 = 0x0C;  //2bytes -3276.5C-->3276.5C
            const byte TYPE_EXT_DIGITAL = 0x0D;  //1bytes value 1 or 0
            const byte TYPE_EXT_DISTANCE = 0x0E;  //2bytes distance in mm
            const byte TYPE_ACC_MOTION = 0x0F;  //1byte number of vibration/motion
            const byte TYPE_IR_TEMP = 0x10;  //2bytes internal temp 2bytes external temp -3276.5C-->3276.5C
            const byte TYPE_OCCUPANCY = 0x11;  //1byte data
            const byte TYPE_WATERLEAK = 0x12;  //1byte data 0-255 
            const byte TYPE_GRIDEYE = 0x13;  //65byte temperature data 1byte ref+64byte external temp
            const byte TYPE_PRESSURE = 0x14;  //4byte pressure data (hPa)
            const byte TYPE_SOUND = 0x15;  //2byte sound data (peak/avg)
            const byte TYPE_PULSE2 = 0x16;  //2bytes 0-->0xFFFF
            const byte TYPE_PULSE2_ABS = 0x17;  //4bytes no 0->0xFFFFFFFF
            const byte TYPE_ANALOG2 = 0x18;  //2bytes voltage in mV
            const byte TYPE_EXT_TEMP2 = 0x19;  //2bytes -3276.5C-->3276.5C
            const byte TYPE_EXT_DIGITAL2 = 0x1A;  // 1bytes value 1 or 0 
            const byte TYPE_DEBUG = 0x3D;  // 4bytes debug 

            message.parserNamespace = typeof(IOT.METADATA.ELSYS_V1.DEFAULT).Namespace;
            byte[] data = Function.HexStringToByteArray(payload);

            for (int i = 0; i < data.Count(); i++)
            {
                switch (data[i])
                {
                    case TYPE_TEMP:
                        var temp = (data[i + 1] << 8) | (data[i + 2]);
                        double tempValue = (double)temp / 10;
                        SetMeasurement(message, message.rcvDateTime, "", IOT.METADATA.ELSYS_V1.MEASUREMENT.TEMPERATURE.ACTUAL, tempValue, deviceInfo);
                        i += 2;
                        break;
                    case TYPE_RH: //Humidity
                        var rh = (data[i + 1]);
                        double humidity = rh;
                        SetMeasurement(message, message.rcvDateTime, "", IOT.METADATA.ELSYS_V1.MEASUREMENT.HUMIDITY.ACTUAL, humidity, deviceInfo);
                        i += 1;
                        break;
                    case TYPE_ACC: //Acceleration
                        double x = (sbyte)(data[i + 1]);
                        double y = (sbyte)(data[i + 2]);
                        double z = (sbyte)(data[i + 3]);
                        i += 3;
                        break;
                    case TYPE_LIGHT: //Light
                        var light = (data[i + 1] << 8) | (data[i + 2]);
                        double lightValue = (double)light;
                        SetMeasurement(message, message.rcvDateTime, "", IOT.METADATA.ELSYS_V1.MEASUREMENT.LIGHT.ACTUAL, lightValue, deviceInfo);
                        i += 2;
                        break;
                    case TYPE_MOTION: //Motion sensor(PIR)
                        var motion = (data[i + 1]);
                        double motionValue = (double)motion;
                        SetMeasurement(message, message.rcvDateTime, "", IOT.METADATA.ELSYS_V1.MEASUREMENT.MOTION.ACTUAL, motionValue, deviceInfo);
                        i += 1;
                        break;
                    case TYPE_CO2: //CO2
                        var co2 = (data[i + 1] << 8) | (data[i + 2]);
                        double co2Value = (double)co2;
                        i += 2;
                        break;
                    case TYPE_VDD: //Battery level
                        var vdd = (data[i + 1] << 8) | (data[i + 2]);
                        double vddValue = (double)vdd/1000;
                        SetMeasurement(message, message.rcvDateTime, "", IOT.METADATA.ELSYS_V1.MEASUREMENT.VDD.ACTUAL, vddValue, deviceInfo);
                        i += 2;
                        break;
                    case TYPE_ANALOG1: //Analog input 1
                        var analog1 = (data[i + 1] << 8) | (data[i + 2]);
                        i += 2;
                        break;
                    case TYPE_GPS: //gps
                        var lat = (data[i + 1] << 16) | (data[i + 2] << 8) | (data[i + 3]);
                        var longi= (data[i + 4] << 16) | (data[i + 5] << 8) | (data[i + 6]);
                        i += 6;
                        break;
                    case TYPE_PULSE1: //Pulse input 1
                        var pulse1 = (data[i + 1] << 8) | (data[i + 2]);
                        i += 2;
                        break;
                    case TYPE_PULSE1_ABS: //Pulse input 1 absolute value
                        var pulseAbs = (data[i + 1] << 24) | (data[i + 2] << 16) | (data[i + 3] << 8) | (data[i + 4]);                        
                        i += 4;
                        break;
                    case TYPE_EXT_TEMP1: //External temp
                        var temp2 = (data[i + 1] << 8) | (data[i + 2]);
                        //temp = bin16dec(temp);
                        double externalTemperature = (double)temp2 / 10;
                        i += 2;
                        break;
                    case TYPE_EXT_DIGITAL: //Digital input
                        var digital = (data[i + 1]);
                        i += 1;
                        break;
                    case TYPE_EXT_DISTANCE: //Distance sensor input 
                        var distance = (data[i + 1] << 8) | (data[i + 2]);
                        i += 2;
                        break;
                    case TYPE_ACC_MOTION: //Acc motion
                        var accMotion = (data[i + 1]);
                        i += 1;
                        break;
                    case TYPE_IR_TEMP: //IR temperature
                        var iTemp = (data[i + 1] << 8) | (data[i + 2]);                        
                        var eTemp = (data[i + 3] << 8) | (data[i + 4]);                        
                        double irInternalTemperature = (double )iTemp / 10;
                        double irExternalTemperature = (double)eTemp / 10;
                        i += 4;
                        break;
                case TYPE_OCCUPANCY: //Body occupancy
                        var occupancy = (data[i + 1]);
                        SetState(message, message.rcvDateTime, message.rcvDateTime.Ticks.ToString(), GetObjectEnum(typeof(IOT.METADATA.ELSYS_V1.STATE.OCCUPANCY),(double) occupancy), deviceInfo);
                        i += 1;
                        break;
                case TYPE_WATERLEAK: //Water leak
                        var waterleak = (data[i + 1]);
                        i += 1;
                        break;
                case TYPE_GRIDEYE: //Grideye data
                        i += 65;
                        break;
                case TYPE_PRESSURE: //External Pressure
                        var pressure = (data[i + 1] << 24) | (data[i + 2] << 16) | (data[i + 3] << 8) | (data[i + 4]);
                        double pressureValue = (double)pressure / 1000;
                        i += 4;
                        break;
                case TYPE_SOUND: //Sound
                        var soundPeak = data[i + 1];
                        var soundAvg = data[i + 2];
                        SetMeasurement(message, message.rcvDateTime, "", IOT.METADATA.ELSYS_V1.MEASUREMENT.SOUND_LEVEL.PEAK, soundPeak, deviceInfo);
                        SetMeasurement(message, message.rcvDateTime, "", IOT.METADATA.ELSYS_V1.MEASUREMENT.SOUND_LEVEL.AVG, soundAvg, deviceInfo);
                        i += 2;
                        break;
                case TYPE_PULSE2: //Pulse 2
                        var pulse2 = (data[i + 1] << 8) | (data[i + 2]);
                        i += 2;
                        break;
                case TYPE_PULSE2_ABS: //Pulse input 2 absolute value
                        var pulseAbs2 = (data[i + 1] << 24) | (data[i + 2] << 16) | (data[i + 3] << 8) | (data[i + 4]);
                        i += 4;
                        break;
                case TYPE_ANALOG2: //Analog input 2
                        var analog2 = (data[i + 1] << 8) | (data[i + 2]);
                        i += 2;
                        break;
                case TYPE_EXT_TEMP2: //External temp 2
                        var exttemp = (data[i + 1] << 8) | (data[i + 2]);                        
                        double externalTemperature2 = (double)exttemp / 10;
                        i += 2;
                        break;
                case TYPE_EXT_DIGITAL2: //Digital input 2
                        var digital2 = (data[i + 1]);
                        i += 1;
                        break;
                default: //somthing is wrong with data
                        i = data.Count();
                        break;
                }
            }

            
            
            
            return message;
        }
        
        
        #endregion

    }

}
