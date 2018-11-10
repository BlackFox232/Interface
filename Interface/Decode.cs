using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{


    internal static class Decode
    {
        static byte[][] MySortMethod(byte[] InputArr)
        {
            int OutputArrLength = InputArr.Length / 4 + 2; //вычисляем длину малого массива исходя из длины бОльшего(изначального)
            byte[][] OutputArr = new byte[OutputArrLength][];

            for (int i = 0; i < OutputArrLength; i++)
            {
                if (i < 4)  //первые 8 байт компануем по 2, как ты и просил
                {
                    OutputArr[i] = new byte[2];
                    OutputArr[i][0] = InputArr[i * 2];
                    OutputArr[i][1] = InputArr[i * 2 + 1];
                }
                else //все остальные компануем по 4
                {
                    OutputArr[i] = new byte[4];
                    OutputArr[i][0] = InputArr[(i - 3) * 4 + 4];
                    OutputArr[i][1] = InputArr[(i - 3) * 4 + 5];
                    OutputArr[i][2] = InputArr[(i - 3) * 4 + 6];
                    OutputArr[i][3] = InputArr[(i - 3) * 4 + 7];
                }

            }
            return OutputArr;
        }

        public static string[] DecodeThird(byte[] bytes)
        {
            string[] regControl = {
            "Время накопления в секундах : ",
            "Время измерения бета : ",
            "Время измерения альфа : ",
            "Код управления усилением с учетом температурной коррекции : ",
            "«Базовое» значение скорости счета для поискового режима в формате с плавающей точкой, s - 1, ст. 16 бит : ",
            "«Фоновое» значение скорости счета для режима вычитания фона в формате с плавающей точкой, s-1,  ст. 16 бит. : ",
            "«Фоновое» значение скорости счета для режима вычитания фона в формате с плавающей точкой, s-1,  ст. 16 бит. : ",
            "«Фоновое» значение мощности дозы для режима вычитания фона в формате с плавающей точкой, ст. 16 бит. Размерность (Sv/h, rem/h или R/h) определяется значением 2-го регистра управления : ",
            "Статистическая погрешность «фонового» значения мощности дозы в формате с плавающей точкой, %, мл. 16 бит : "
            };


            

            byte[][] Statuses = MySortMethod(bytes);

            for (int i = 0; i < Statuses.Length; i++)
            {
                if (i < 4)
                {
                    regControl[i] += BitConverter.ToUInt16(Statuses[i], 0);
                }
                else
                {
                    regControl[i] += BitConverter.ToSingle(Statuses[i], 0);
                }                
            }

            return regControl;

        }

            
    

        public static void DecodeFourth()
        {

        }

        public static void DecodeFifth()
        {

        }

        public static void GetFloat()
        {

        }

        public static string[] DecodeSeventh(string bits)
        {
            string[] statusBDKS = new string[7];

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

        //Выделить байты ответа убрав CRC,адрес,номер команды и если имеется путём привсвоения numberParity значения true убрать так же кол-во байт ответа в рабочем массиве
        public static byte[] GetAnswerBytes(byte[] val, bool numberParity = false)
        {
            int cnt = 0;
            int i = 0;
            byte[] _val;

            if (numberParity = false)
            {
                _val = new byte[val.Length - 4];

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

            }
            else
            {
                _val = new byte[val.Length - 5];

                foreach (var item in val)
                {
                    if (cnt == 1 || cnt == 0 || cnt == 2)
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
            }

            return _val;
        }
    }
}


