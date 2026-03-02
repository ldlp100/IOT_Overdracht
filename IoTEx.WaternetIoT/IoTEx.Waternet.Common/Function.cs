using System;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace IoTEx.Waternet.Common
{
    public class Function
    {
        /// <summary>
        /// Gets the sha256 from string.
        /// </summary>
        /// <param name="strData">The string data.</param>
        /// <returns></returns>
        public static string GetSha256FromString(string strData)
        {
            var message = Encoding.ASCII.GetBytes(strData);
            var hashString = new SHA256Managed();
            var hashValue = hashString.ComputeHash(message);
            return hashValue.Aggregate("", (current, x) => current + String.Format("{0:x2}", x));
        }
        /// <summary>
        /// Hexadecimals the string to byte array.
        /// </summary>
        /// <param name="hex">The hexadecimal.</param>
        /// <returns></returns>
        public static byte[] HexStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
        //public static string ByteArrayToHexString(byte[] Bytes)
        //{
        //    StringBuilder Result = new StringBuilder(Bytes.Length * 2);
        //    string HexAlphabet = "0123456789ABCDEF";

        //    foreach (byte B in Bytes)
        //    {
        //        Result.Append(HexAlphabet[(int)(B >> 4)]);
        //        Result.Append(HexAlphabet[(int)(B & 0xF)]);
        //    }

        //    return Result.ToString();
        //}
        public static int BitExtractedToInt(BitArray array, int p, int k)
        {
            BitArray array2 = new BitArray(16, false);
            for (int i = 0; i < (k); i++)
            {
                array2[i] = array[p + i];
            }
            int[] intArray = new int[1];
            array2.CopyTo(intArray, 0);

            return Convert.ToInt16(intArray[0]);
        }
        public static byte[] HexToBytes(string hex)
        {
            // assumes *just* the hex; you will
            // need to adjust this if your string
            // has separaters, line-breaks, etc
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
        static int HexVal(char c)
        {
            if (c >= '0' && c <= '9') return c - '0';
            if (c >= 'a' && c <= 'f') return c - 'a' + 10;
            if (c >= 'A' && c <= 'F') return c - 'A' + 10;
            return ThrowArgOutOfRange(nameof(c));
        }
        static int ThrowArgOutOfRange(string argName) =>
            throw new ArgumentOutOfRangeException(argName);
        /// <summary>
        /// Byte array to hexadecimal string.
        /// </summary>
        /// <param name="byteArray">The byte array.</param>
        /// <returns></returns>
        public static string ByteArrayToHexString(byte[] byteArray)
        {
            return BitConverter.ToString(byteArray).Replace("-", String.Empty);
        }

        public static DateTime UnixTimeToDateTime(int unixTime)
        {
            var timeStamp =
                new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(unixTime);
            return timeStamp;
        }
        public static DateTime UnixTimeMillisecondsStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
