using System;
using System.Collections.Generic;
using System.Text;

namespace IoTEx.WaternetIoT.Model.DTOModels.Old.CommunicationModels
{
    public class LORAKerlinkReceivingMessageModelV3_0
    {
        /// <summary>
        /// Endpoint identifier
        /// </summary>
        public string devEui { get; set; }
        /// <summary>
        /// Global application identifier
        /// </summary>
        public string appEui { get; set; }
        /// <summary>
        /// Network endpoint identifier
        /// </summary>
        public string devAddr { get; set; }
        /// <summary>
        /// Cluster identifier
        /// </summary>
        public string clusterId { get; set; }
        /// <summary>
        /// Message identifier
        /// </summary>
        public string msgId { get; set; }
        /// <summary>
        /// frame counter downstream
        /// </summary>
        public int fcntDown { get; set; }
        /// <summary>
        /// frame counter upstream
        /// </summary>
        public int fcntUp { get; set; }
        /// <summary>
        /// When message is sent
        /// </summary>
        public long recvTime { get; set; }
        /// <summary>
        /// port
        /// </summary>
        public int fport { get; set; }
        /// <summary>
        /// content (base64 or hexa if clusterDto.hexa = true)
        /// </summary>
        public string payload { get; set; }
        /// <summary>
        /// The transmission frequency in units of MHz.
        /// </summary>
        public double freq { get; set; }
        /// Modulation technique is LoRa, the string is of the form "SFnBWm where ‘SF’
        /// and ‘BW’ are literals and ‘n’ and ‘m’ are unsigned integers, ‘n’ represents the
        /// ‘spreading factor’ 7≤n≤12 and ‘m’ represents the modulation bandwidth in kHz,
        /// range m smaller than 1000. 
        public string dataRate { get; set; }
        /// <summary>
        /// LORA, FSK
        /// </summary>
        public string modu { get; set; }
        /// <summary>
        /// "codr" comprises the string "k/n", where 'k' represents the carried
        /// bits and 'n' the total number of bits received, including those used by the error
        /// checking/correction algorithm.
        /// </summary>
        public string codingRate { get; set; }
        /// <summary>
        /// True when ADR is enabled
        /// </summary>
        public bool adr { get; set; }
        /// <summary>
        /// Spreading Factor
        /// </summary>
        public int sf { get; set; }
        /// <summary>
        /// Endpoint RX message details
        /// </summary>
        public LORAKerlinkMoteXModelV1_0 motetx { get; set; }

        /// <summary>
        /// List of gateway Rx
        /// </summary>
        public List<LORAKerlinkGwrxModelV1_0> gwrx { get; set; }

        /// <summary>
        /// The objects ‘port’ and ‘payload’ shall not be transmitted on the NS to Network Controller interface
        /// </summary>
        public class LORAKerlinkUserDataModelV1_0
        {
            /// <summary>
            /// port
            /// </summary>
            public int fport { get; set; }
            /// <summary>
            /// content (base64 or hexa if clusterDto.hexa = true)
            /// </summary>
            public string payload { get; set; }
            /// <summary>
            /// max allowed retry
            /// </summary>
            public int maxretry { get; set; }
            /// <summary>
            /// Time to live
            /// </summary>
            public int ttl { get; set; }

        }
        /// <summary>
        /// The radio characteristics of the mote’s transmission of the frame. 
        /// </summary>
        public class LORAKerlinkMoteXModelV1_0
        {
            /// <summary>
            /// The transmission frequency in units of MHz.
            /// </summary>
            public double freq { get; set; }
            /// Modulation technique is LoRa, the string is of the form "SFnBWm where ‘SF’
            /// and ‘BW’ are literals and ‘n’ and ‘m’ are unsigned integers, ‘n’ represents the
            /// ‘spreading factor’ 7≤n≤12 and ‘m’ represents the modulation bandwidth in kHz,
            /// range m smaller than 1000. 
            public string datr { get; set; }
            /// <summary>
            /// LORA, FSK
            /// </summary>
            public string modu { get; set; }
            /// <summary>
            /// "codr" comprises the string "k/n", where 'k' represents the carried
            /// bits and 'n' the total number of bits received, including those used by the error
            /// checking/correction algorithm.
            /// </summary>
            public string codr { get; set; }
            /// <summary>
            /// True when ADR is enabled
            /// </summary>
            public bool adr { get; set; }
            /// <summary>
            /// Spreading Factor
            /// </summary>
            public int sf { get; set; }
        }
        /// <summary>
        /// The characteristics of the frame during its reception by the gateway
        /// </summary>
        public class LORAKerlinkGwrxModelV1_0
        {
            /// <summary>
            /// Extended Unique Identifier
            /// </summary>
            public string gwEui { get; set; }
            /// <summary>
            /// Identifies the antenna, within the GW card. The
            /// value does not identify the antenna within the GW
            /// </summary>
            public int antenna { get; set; }
            /// <summary>
            /// time  when message is received from gateway
            /// </summary>
            public DateTime time { get; set; }
            public double latitude { get; set; }
            public double longitude { get; set; }
            public double altitude { get; set; }
            public string rfRegion { get; set; }

            /// <summary>
            /// Concentrator “IF” channel on which the frame was received
            /// </summary>
            public int channel { get; set; }
            /// <summary>
            /// The measured received signal strength in units of dBm
            /// </summary>
            public int rssis { get; set; }
            /// <summary>
            /// The measured received signal strength in units of dBm
            /// </summary>
            public int rssisd { get; set; }
            /// <summary>
            /// The measured received signal strength in units of dBm
            /// </summary>
            public int rssi { get; set; }
            /// <summary>
            /// The signal to noise ratio, in units of dB
            /// </summary>
            public double snr { get; set; }
            public int frequencyOffset { get; set; }
        }

    }
}
