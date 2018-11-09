using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    //Расшифровка ответа команд
    internal static class Decode
    {
        public static void DecodeThird(byte[] bytes)
        {
            
        }

        public static void DecodeFourth()
        {

        }

        public static void DecodeFifth()
        {

        }

        public static string[] DecodeSeventh(string bits)
        {
            string[] statusBDKS = new string[7] ;

            if (bits[0] == '1')
            {
                statusBDKS[0] += "Идёт накопление спектра";    
            }
            else
            {
                statusBDKS[0] += "Накопление спектра запрещено";
            }
            if (bits[1] == '1')
            {
                statusBDKS[1] += "Измерение бета идёт";
            }
            else
            {
                statusBDKS[1] += "Измерение бета запрещено";
            }
            if (bits[2] == '1')
            {
                statusBDKS[2] += "Измерение альфа идёт";
            }
            else
            {
                statusBDKS[2] += "Измерение альфа запрещено";
            } 
            if (bits[3] == '1')
            {
                statusBDKS[3] += "Режим вычитания фона альфа включен";
            }
            else
            {
                statusBDKS[3] += "Режим вычитания фона альфа выключен";
            }
            if (bits[4] == '1')
            {
                statusBDKS[4] += "Режим вычитания фона гамма включен";
            }
            else
            {
                statusBDKS[4] += "Режим вычитания фона гамма выключен";
            }
            if (bits[5] == '1')
            {
                statusBDKS[5] += "Режим вычитания фона беты включен";
            }
            else
            {
                statusBDKS[5] += "Режим вычитания фона бета выключен";
            }
            if (bits[6] == '1')
            {
                statusBDKS[6] += "Режим настройки включен";
            }
            else
            {
                statusBDKS[6] += "Режим настройки выключен";
            }         

            return statusBDKS;
        }

        public static string GetBits(byte wordStatus)
        {
            string s = "";
            byte[] bits = new byte[] { };
          
            if (BitConverter.IsLittleEndian)
            {
                bits = new byte[]
                {
                0b1000_0000,
                0b100_0000,
                0b10_0000,
                0b1_0000,
                0b1000,
                0b100,
                0b10,
                0b1
                };
            }
            else
            {
                bits = new byte[]
                {
                0b1,
                0b10,
                0b100,
                0b1000,
                0b1_0000,
                0b10_0000,
                0b100_0000,
                0b1000_0000
                };
            }

            foreach (var item in bits)
            {
                if ((item & wordStatus) != 0)
                {
                    s += '1';
                }
                else
                {
                    s += '0';
                }
            }

            return s;
        }

        /// <summary>
        /// Получить байты ответа без CRC , адреса и номера команды
        /// </summary>
        /// <param name="val">Массив с CRC ,адресом и номером команды </param>
        /// <returns>Массив без CRC,адреса и команды</returns>
        public static byte[] GetAnswerBytes(byte[] val)
        {
            byte[] _val = new byte[val.Length - 4];
            int cnt = 0;
            int i = 0;

            foreach (var item in val)
            {
                if (cnt == 1 || cnt == 0)
                {

                }
                else if (cnt == val.Length - 1 || cnt == val.Length - 2)
                {

                }
                else
                {
                    _val[i] = item;
                    i++;
                }
                cnt++;
            }

            return _val;
        }
    }
}
