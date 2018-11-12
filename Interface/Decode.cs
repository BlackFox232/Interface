using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{


    internal static class Decode
    {

        

        public static string[] DecodeThird(byte[] bytes)
        {
            byte[][] Sorting(byte[] inputArr) // Сортирует входной массив в двумерный в котором первый массив количество регистров а второй их содержимое 
            {
                int outputArrLength;

                if (inputArr.Length < 8) // Проверка на то больше ли в ответе чем первые 4 ushort регистра
                {
                    outputArrLength = inputArr.Length / 2;
                }
                else
                {
                    outputArrLength = inputArr.Length / 4 + 2;
                }

                byte[][] outputArr = new byte[outputArrLength][]; 

                for (int i = 0; i < outputArrLength; i++)
                {
                    if (i < 4)  //первые 8 байт компануем по 2
                    {
                        outputArr[i] = new byte[2];
                        outputArr[i][1] = inputArr[i * 2];
                        outputArr[i][0] = inputArr[i * 2 + 1];
                    }
                    else //все остальные компануем по 4
                    {
                        outputArr[i] = new byte[4];
                        outputArr[i][3] = inputArr[(i - 3) * 4 + 4];
                        outputArr[i][2] = inputArr[(i - 3) * 4 + 5];
                        outputArr[i][1] = inputArr[(i - 3) * 4 + 6];
                        outputArr[i][0] = inputArr[(i - 3) * 4 + 7];
                    }
                }

                return outputArr;
            }

            string[] regControlStatus = {
            "Время накопления в секундах : ",
            "Время измерения бета : ",
            "Время измерения альфа : ",
            "Код управления усилением с учетом температурной коррекции : ",
            "«Базовое» значение скорости счета для поискового режима в формате с плавающей точкой : ",
            "«Фоновое» значение скорости счета для режима вычитания фона в формате с плавающей точкой : ",
            "«Фоновое» значение скорости счета для режима вычитания фона в формате с плавающей точкой : ",
            "«Фоновое» значение мощности дозы для режима вычитания фона в формате с плавающей точкой : ",
            "Статистическая погрешность «фонового» значения мощности дозы в формате с плавающей точкой : ",

            " " // Последний элемент для добавления строки "Расшифровка остальных состояний не предусмотрена" на случай ввода более 9 первых регистров
            };

            byte[][] statuses = Sorting(bytes);

            void Convertation(int i)
            {
                if (i < 4)
                {
                    regControlStatus[i] += BitConverter.ToUInt16(statuses[i], 0);
                }
                else
                {
                    regControlStatus[i] += BitConverter.ToSingle(statuses[i], 0);
                }
            }
            
            if (statuses.Length >9)
            {
                for (int i = 0; i < 9; i++)
                {
                    Convertation(i);
                }

                regControlStatus[regControlStatus.Length - 1] += 
                    "*********************************************************************" +
                    "\n"+
                    "Расшифровка остальных состояний не предусмотрена";

                return regControlStatus;
            }
            else
            {
                for (int i = 0; i < statuses.Length; i++)
                {
                    Convertation(i);
                }

                string[] regControl = new string[statuses.Length];

                for (int i = 0; i < statuses.Length; i++)
                {
                    regControl[i] = regControlStatus[i];
                }
                return regControl;
            }
        }

        public static void DecodeFourth()
        {
            string[] regDataStatus = {
            "«Живое» время спектра в секундах : ",
            "Значение температуры в градусах. : ",
            "Средняя скорость счета гамма в формате с плавающей точкой : ",
            "Статистическая погрешность средней скорости счета гамма в формате с плавающей точкой, %, ст. 16 бит : ",
            "Средняя мощность дозы гамма в формате с плавающей точкой, Sv/h, rem/h или R/h, мл. 16 бит : ",
            "Статистическая погрешность средней мощности дозы гамма в формате с плавающей точкой, %, ст. 16 бит : ",
            "Доза гамма в формате с плавающей точкой, Sv, мл. 16 бит : ",
            "Время после включения питания, s  : ",
            "Средняя скорость счета бета в формате с плавающей точкой, s-1, мл. 16 бит : ",
            "Статистическая погрешность средней скорости счета бета в формате с плавающей точкой, %, ст. 16 бит : ",
            "Средняя плотность потока бета в формате с плавающей точкой, Sv/h, rem/h или R/h, мл. 16 бит : ",
            "Статистическая погрешность средней плотность потока бета в формате с плавающей точкой, %, мл. 16 бит : ",
            "Флюенс бета в формате с плавающей точкой, Sv, мл. 16 бит : ",
            "Средняя скорость счета альфа в формате с плавающей точкой, s-1, ст. 16 бит : ",
            "Статистическая погрешность средней скорости счета альфа в формате с плавающей точкой, %, мл. 16 бит : ",
            "Средняя плотность потока альфа в формате с плавающей точкой, Sv/h, rem/h или R/h, мл. 16 бит : ",
            "Статистическая погрешность средней плотность потока альфа в формате с плавающей точкой, %, мл. 16 бит : ",
            "Флюенс альфа в формате с плавающей точкой, Sv, мл. 16 бит : ",

            " " // Последний элемент для добавления строки "Расшифровка остальных состояний не предусмотрена" на случай ввода более 9 первых регистров
            };
        }

        public static void DecodeFifth()
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


