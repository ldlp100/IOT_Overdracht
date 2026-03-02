using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using IoTEx.WaternetIoT.Data.Model;
using IoTEx.WaternetIoT.Model.DTOs;
using Newtonsoft.Json;
using static IoTEx.Waternet.Parser.IOT_DEVICE_GENERIC_V1_PARSER;

namespace IoTEx.Waternet.Parser
{
    public class IOT_DEVICE_GENERIC_V2_PARSER : IOT_DEVICE_GENERIC_V1_PARSER
    {
                
        
        public override string Version
        {
            get { return "2.0.0"; }
        }

        public override DeviceMessageDTO ParseIncomingDeviceMessage(DeviceMessageDTO message, string payload, PayLoadEncryptionEnum enc, DeviceDefinitionDTO deviceInfo)
        {
            Definition();
            int index = 0;
            byte[] mByte = HexToBytes(payload);
            if (message.networkType != NetworkTypeEnum.IOTDEV_UDP_APN_TMOBILE_NBIOT)
            { 
                string newX = Encoding.ASCII.GetString(mByte);
                mByte = HexToBytes(newX);
            }
            float version = ((float)mByte[index++]) / 10;
            int counter = mByte[index++];
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
            SetMeasurement(message, basicDT, "", IOT.METADATA.IOT_DEVICE_GENERIC_V2.MEASUREMENT.IOTDEVICE_VOLT.LAST, volt, deviceInfo);
            SetMeasurement(message, basicDT, "", IOT.METADATA.IOT_DEVICE_GENERIC_V2.MEASUREMENT.IOTDEVICE_COUNTER.LAST, counter, deviceInfo);


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
        
        
    }

}


