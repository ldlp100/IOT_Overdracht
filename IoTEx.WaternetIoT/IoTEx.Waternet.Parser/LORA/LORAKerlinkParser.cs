using IoTEx.Waternet.Common;
using IoTEx.WaternetIoT.Data.Model;
using IoTEx.WaternetIoT.Model.DTOs;
using System;
using System.Collections.Generic;

namespace IoTEx.Waternet.Parser.LORA
{
    public class LORAKerlinkParserV3_0
    {
        
        public static DeviceMessageDTO Parse(DeviceMessageDTO deviceMessage, dynamic data, PayLoadEncryptionEnum enc, DeviceDefinitionDTO deviceInfo)
        {
            
            LORAKerlinkReceivingMessageModelV3_0 messageComm = ParseComm(deviceMessage, data);
            //deviceMessage.NetworkInfo = JsonConvert.SerializeObject(messageComm);
            
            deviceMessage.networkType = NetworkTypeEnum.LORAWAN_KERLINK;

            
            if (messageComm.payload != "")
            {
                return ParseMessage(deviceMessage, enc, messageComm.payload, deviceInfo);                
            }

            
            return deviceMessage;

        }

        private static LORAKerlinkReceivingMessageModelV3_0 ParseComm(DeviceMessageDTO message, dynamic data)
        {

            LORAKerlinkReceivingMessageModelV3_0 messageComm = new LORAKerlinkReceivingMessageModelV3_0();
            messageComm.appEui = data.appEui ?? "";
            //messageComm.clusterId = data.endDevice.cluster.id ?? "";
            messageComm.devAddr = data.endDevice.devAddr ?? "";
            messageComm.devEui = data.endDevice.devEui ?? "";
            messageComm.fcntDown = data.fCntDown ?? 0;
            messageComm.fcntUp = data.fcntUp ?? 0;
            messageComm.recvTime = data.recvTime ?? 0;
            messageComm.payload = data.payload ?? "";
            messageComm.fport = data.fPort ?? 0;
            messageComm.freq = data.ulFrequency ?? 0.0;
            messageComm.dataRate = data.dataRate                                                                                                                         ?? "";
            messageComm.adr = data.adr ?? false;
            messageComm.codingRate = data.codingRate ?? "";
            messageComm.modu = data.modulation ?? "";
            messageComm.sf = Int32.Parse(((string)(data.dataRate ?? "")).Replace("BW125", "").Replace("SF", ""));
            if (messageComm.recvTime > 0)
                message.rcvDateTime = Function.UnixTimeMillisecondsStampToDateTime(messageComm.recvTime);

            messageComm.gwrx = new List<LORAKerlinkReceivingMessageModelV3_0.LORAKerlinkGwrxModelV1_0>();
            var s = data.gwInfo;
            int gatewaysCount = data.gwCnt;
            double bestRSSI = 0.0;
            double bestSNR = 0.0;
            DateTime dt = new DateTime();
            string bestStation = "";

            for (int i = 0; i < gatewaysCount; i++)
            {
                messageComm.gwrx.Add(new LORAKerlinkReceivingMessageModelV3_0.LORAKerlinkGwrxModelV1_0());
                messageComm.gwrx[i].gwEui = data.gwInfo[i].gwEui ?? "";
                messageComm.gwrx[i].rfRegion = s[i].rfRegion ?? "";
                messageComm.gwrx[i].rssis = s[i].rssis ?? 0;
                messageComm.gwrx[i].rssi = s[i].rssi ?? 0;
                messageComm.gwrx[i].rssisd = s[i].rssisd ?? 0;
                messageComm.gwrx[i].snr = s[i].snr ?? 0.0;
                messageComm.gwrx[i].latitude = s[i].latitude ?? 0.0;
                messageComm.gwrx[i].longitude = s[i].longitude ?? 0.0;
                messageComm.gwrx[i].altitude = s[i].altitude ?? 0.0;
                messageComm.gwrx[i].channel = s[i].channel ?? 0;
                messageComm.gwrx[i].antenna = s[i].antenna ?? 0;
                messageComm.gwrx[i].frequencyOffset = s[i].frequencyOffset ?? 0;
                
                if ((messageComm.gwrx[i].rssis < 0 && messageComm.gwrx[i].rssis > bestRSSI) || bestRSSI == 0)
                {
                    bestRSSI = messageComm.gwrx[i].rssis;
                    bestSNR = messageComm.gwrx[i].snr;
                    bestStation = messageComm.gwrx[i].gwEui;
                    dt = Function.UnixTimeMillisecondsStampToDateTime( messageComm.recvTime);
                }
            }

            message.networkInfo = new DeviceMessageNetworkDTO();
            message.networkInfo.rssi = bestRSSI;
            message.networkInfo.snr = bestSNR;
            message.networkInfo.sf = messageComm.sf;
            message.networkInfo.station = bestStation;
            message.networkInfo.date = dt;
            message.networkInfo.cnt = gatewaysCount;
            
            return messageComm;


        }

        public static DeviceMessageDTO ParseMessage(DeviceMessageDTO message, PayLoadEncryptionEnum enc,  string encPayload, DeviceDefinitionDTO deviceInfo)
        {

            try
            {
                IBaseParser parser = (IBaseParser)System.Reflection.Assembly.GetAssembly(typeof(IBaseParser)).CreateInstance("IoTEx.Waternet.Parser." + 
                    deviceInfo.info.deviceParserClassName);
                if (parser != null)
                {

                    return parser.ParseIncomingDeviceMessage(message, encPayload, enc, deviceInfo);

                }   

            }
            catch (Exception ex)
            {
                
            }
            return message;
        }
        
    }
}
