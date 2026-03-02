using System;
using System.Collections.Generic;
using System.Text;
using IoTEx.WaternetIoT.Model.Device;

namespace IoTEx.WaternetIoT.Model.Device.LORA.MCS
{
    public class MCS1608V1
    {
        public MCS1608V1()
        {
                     
        }       
        
        public class MsgIDAliveModel
        {
            
        }
        public class MsgIDTrackingModel
        {
            public enum StatusEnum { StartMessage = 1, ObjectMoving = 2, ObjectStopped = 4, VibrationDetected = 8 }
            public StatusEnum Status { get; set; }
            public double Temp { get; set; }
            public byte GPSFixAge { get; set; }
            public byte SatInFix { get; set; }
            public double Lat { get; set; }
            public double Long { get; set; }
            
        }
        public class MsgIDGenSensModel
        {

            public byte Status { get; set; }
            public double BaromBar { get; set; }
            public int Humidity { get; set; }
            public double Temp { get; set; }
            public int LevelX { get; set; }
            public int LevelY { get; set; }
            public int LevelZ { get; set; }
            public uint VibAmp { get; set; }
            public uint VibFreq { get; set; }
           
            
        }
        public class MsgIDRotModel
        {
            
        }
        public class MsgIDAlarmModel
        {
            
        }
        public class MsgID1WireTModel
        {
            
        }
        public class MsgIDRunningModel
        {
            
        }
        public class MsgIDVibrateModel
        {
            
        }
        public class MsgIDAnalogModel
        {
            
        }
        public class MsgIdGenSensGravMsgModel
        {
            
        }
        public class MsgIdDailyReportModel
        {
            
        }
        public class MsgIdDigIn1MsgModel
        {
            
        }
        public class MsgIdDigIn2MsgModel
        {
            
        }
        public class MsgIDIndoorModel
        {
            
        }
        public class MsgIdShockModel
        {
            
        }
        public class MsgIDRebootModel
        {
            
        }
    }
}
