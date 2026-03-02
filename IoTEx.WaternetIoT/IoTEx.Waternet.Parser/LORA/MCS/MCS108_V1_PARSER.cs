using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using IoTEx.WaternetIoT.Model.DTOs.API;
using IoTEx.Waternet.Common;
using IoTEx.WaternetIoT.Model.DTOs;

namespace IoTEx.Waternet.Parser
{
    public class MCS108_V1_PARSER: BaseParser
    {        
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

        public enum StatusEnum { START_MESSAGE = 1, OBJECT_MOVING = 2, OBJECT_STOPPED = 4, VIBRATION_DETECTED = 8 }
        public override DeviceMessageDTO ParseIncomingDeviceMessage(DeviceMessageDTO message, string payload, PayLoadEncryptionEnum enc, DeviceDefinitionDTO deviceInfo)
        {
            
            byte[] buffer = null;
            string header = "";

            if (enc == PayLoadEncryptionEnum.HEX)
            {
                buffer = Function.HexStringToByteArray(payload);
                header = payload.Substring(0, 2);
            }

            switch (header)
            {
                //case "00":
                //    messageParsed = true;
                //    return JsonConvert.SerializeObject(MCS108V1Parser.ParseMsgIDAlive(buffer,out messageId));
                case "01":
                    return ParseMsgIDTracking(buffer, message,deviceInfo);
                case "02":
                    return ParseMsgIDGenSens(buffer, message,deviceInfo);
                /*
                case "03":
                    return JsonConvert.SerializeObject(new MsgIDRot());
                case "04":
                    return JsonConvert.SerializeObject(new MsgIDAlarm());
                case "06":
                    return JsonConvert.SerializeObject(new MsgID1WireTModel(buffer));
                case "07":
                    return JsonConvert.SerializeObject(new MsgIDRunning());
                case "08":
                    return JsonConvert.SerializeObject(new MsgIDVibrate());
                case "09":
                    return JsonConvert.SerializeObject(new MsgIDAnalog());
                case "0A":
                    return JsonConvert.SerializeObject(new MsgIdGenSensGravMsg());
                case "0B":
                    return JsonConvert.SerializeObject(new MsgIdDailyReport());
                case "0C":
                    return JsonConvert.SerializeObject(new MsgIdDigIn1Msg());
                case "0D":
                    return JsonConvert.SerializeObject(new MsgIdDigIn2Msg());
                case "81":
                    return JsonConvert.SerializeObject(new MsgIDIndoor());
                case "82":
                    return JsonConvert.SerializeObject(new MsgIdShock());
                case "0E":
                    return JsonConvert.SerializeObject(new MsgIDReboot());
                */
                default:
                    return message;
            }

        }

        private DeviceMessageDTO ParseMsgIDTracking(byte[] buffer, DeviceMessageDTO message, DeviceDefinitionDTO deviceInfo)
        {
            
            try
            {


                string status = ((StatusEnum)buffer[1]).ToString();
                double temp = ((double)buffer[2] * 256 + buffer[3]) / 100;
                byte gpsFixAge = buffer[4];
                byte satInFix = buffer[5];
                double Lat = (double)(buffer[6] * 256 * 256 + buffer[7] * 256 + buffer[8]) / 100000;
                double Long = (double)(buffer[9] * 256 * 256 + buffer[10] * 256 + buffer[11]) / 100000;

                SetMeasurement(message, message.rcvDateTime, "", IOT.METADATA.MCS108_V1.MEASUREMENT.LATITUDE.ACTUAL, Lat, deviceInfo);
                SetMeasurement(message, message.rcvDateTime, "", IOT.METADATA.MCS108_V1.MEASUREMENT.LONGITUDE.ACTUAL, Long, deviceInfo);

            }
            catch
            {

            }
            return message;
        }
        

        private DeviceMessageDTO ParseMsgIDGenSens(byte[] buffer, DeviceMessageDTO message, DeviceDefinitionDTO deviceInfo)
        {
            
            try
            {
                MemoryStream stream = new MemoryStream(buffer, false);
                System.IO.BinaryReader binStream = new BinaryReader(stream);

                int messageId = binStream.ReadByte();
                int status = binStream.ReadByte();
                double baromBar = (double)(100000 + binStream.ReadInt16BE()) / 100;
                double temp = ((double)binStream.ReadInt16BE()) / 100;
                int humidity = binStream.ReadUInt8();
                double levelX = binStream.ReadInt8BE();
                double levelY = binStream.ReadInt8BE();
                double levelZ = binStream.ReadInt8BE();
                int vibAmp = binStream.ReadUInt8();
                int vibFreq = binStream.ReadUInt8();

                SetMeasurement(message, message.rcvDateTime, "", IOT.METADATA.MCS108_V1.MEASUREMENT.AIR_PRESSURE.ACTUAL, baromBar, deviceInfo);
                SetMeasurement(message, message.rcvDateTime, "", IOT.METADATA.MCS108_V1.MEASUREMENT.TEMPERATURE.ACTUAL, temp, deviceInfo);
                SetMeasurement(message, message.rcvDateTime, "", IOT.METADATA.MCS108_V1.MEASUREMENT.HUMIDITY.ACTUAL, Convert.ToDouble(humidity), deviceInfo);
                SetMeasurement(message, message.rcvDateTime, "", IOT.METADATA.MCS108_V1.MEASUREMENT.ANGLE_X.ACTUAL, levelX, deviceInfo);
                SetMeasurement(message, message.rcvDateTime, "", IOT.METADATA.MCS108_V1.MEASUREMENT.ANGLE_Y.ACTUAL, levelY, deviceInfo);
                SetMeasurement(message, message.rcvDateTime, "", IOT.METADATA.MCS108_V1.MEASUREMENT.ANGLE_Z.ACTUAL, levelZ, deviceInfo);
                SetMeasurement(message, message.rcvDateTime, "", IOT.METADATA.MCS108_V1.MEASUREMENT.VIBRATION_AMP.ACTUAL, Convert.ToDouble(vibAmp), deviceInfo);
                SetMeasurement(message, message.rcvDateTime, "", IOT.METADATA.MCS108_V1.MEASUREMENT.VIBRATION_FREQUENCY.ACTUAL, Convert.ToDouble(vibFreq), deviceInfo);

                return message;
            }
            catch
            {
                return null;
            }
        }

        
    }

}
