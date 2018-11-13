using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface
{


    internal static class Decode
    {
        //03.Считать состояние регистров управления
        public static string[] DecodeThird(byte[] answerBytes)
        {
            string[] regControlStatus = {
            "Время накопления в секундах : ",
            "Время измерения бета : ",
            "Время измерения альфа : ",
            "Код управления усилением с учетом температурной коррекции : ",
            "«Базовое» значение скорости счета для поискового режима в формате с плавающей точкой, s-1 : ",
            "«Фоновое» значение скорости счета для режима вычитания фона в формате с плавающей точкой, s-1 : ",
            "Статистическая погрешность «фонового» значения скорости счета в формате с плавающей точкой, % : ",
            "«Фоновое» значение мощности дозы для режима вычитания фона в формате с плавающей точкой, Sv/h, rem/h или R/h : ",
            "Статистическая погрешность «фонового» значения мощности дозы в формате с плавающей точкой, % : ",

            " " // Последний элемент для добавления строки "Расшифровка остальных состояний не предусмотрена" на случай ввода более 9 первых регистров
            };

            byte[][] Sorting(byte[] inputArr)
            {
                int numberRegisters;

                if (inputArr.Length <= 8) // Проверка на то больше ли в ответе чем первые 4 ushort регистра
                {
                    numberRegisters = inputArr.Length / 2;
                }
                else
                {
                    numberRegisters = (inputArr.Length - 8) / 4 + 4;
                }

                byte[][] outputArr = new byte[numberRegisters][]; // Двумерный массив , первый содержит кол-во регистров второй их содержимое
                int k = 0;
                int i = 0;

                while (i < numberRegisters)
                {
                    if (i < 4)  //первые 8 байт компануем по 2
                    {
                        outputArr[i] = new byte[2];
                        outputArr[i][1] = inputArr[k];
                        outputArr[i][0] = inputArr[k + 1];
                        k = k + 2;

                    }
                    else //все остальные компануем по 4
                    {
                        outputArr[i] = new byte[4];
                        outputArr[i][3] = inputArr[k];
                        outputArr[i][2] = inputArr[k + 1];
                        outputArr[i][1] = inputArr[k + 2];
                        outputArr[i][0] = inputArr[k + 3];
                        k = k + 4;
                    }
                    ++i;
                }

                return outputArr;
            }

            byte[][] statuses = Sorting(answerBytes);

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

            if (statuses.Length > 9)
            {
                for (int i = 0; i < 9; i++)
                {
                    Convertation(i);
                }

                regControlStatus[regControlStatus.Length - 1] +=
                    "*********************************************************************" +
                    "\n" +
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

        //04.Считать состояние регистров данных
        public static int DecodeFourth(byte[] answerBytes)
        {
            string[] regDataStatus = {
            "«Живое» время спектра в секундах : ",
            "Значение температуры в градусах. : ",
            "«Мгновенная» интенсиметр гамма, s-1, : ",
            "Средняя скорость счета гамма в формате с плавающей точкой : ",
            "Статистическая погрешность средней скорости счета гамма в формате с плавающей точкой, % : ",
            "Средняя мощность дозы гамма в формате с плавающей точкой, Sv/h, rem/h или R/h : ",
            "Статистическая погрешность средней мощности дозы гамма в формате с плавающей точкой, % : ",
            "Доза гамма в формате с плавающей точкой, Sv : ",
            "Время после включения питания, s : ",
            "Средняя скорость счета бета в формате с плавающей точкой, s-1 : ",
            "Статистическая погрешность средней скорости счета бета в формате с плавающей точкой, % : ",
            "Средняя плотность потока бета в формате с плавающей точкой, Sv/h, rem/h или R/h : ",
            "Статистическая погрешность средней плотность потока бета в формате с плавающей точкой, % : ",
            "Флюенс бета в формате с плавающей точкой, Sv : ",
            "Средняя скорость счета альфа в формате с плавающей точкой, s-1 : ",
            "Статистическая погрешность средней скорости счета альфа в формате с плавающей точкой, % : ",
            "Средняя плотность потока альфа в формате с плавающей точкой, Sv/h, rem/h или R/h : ",
            "Статистическая погрешность средней плотность потока альфа в формате с плавающей точкой, % : ",
            "Флюенс альфа в формате с плавающей точкой, Sv : ",
            " " // Последний элемент для добавления строки "Расшифровка остальных состояний не предусмотрена" на случай ввода более 9 первых регистров
            };

            byte[][] Sorting(byte[] inputArr) // Сортирует входной массив в двумерный в котором первый массив количество регистров а второй их содержимое 
            {
                int outputArrLength;

                if (inputArr.Length < 8) // Проверка на то больше ли в ответе чем первые 4 ushort регистра
                {
                    outputArrLength = inputArr.Length / 2;
                }
                else
                {
                    outputArrLength = (inputArr.Length - 8) / 4 + 4;
                }

                byte[][] outputArr = new byte[outputArrLength][];
                int k = 0;
                int i = 0;

                while (i < outputArrLength)
                {
                    if (i < 4)  //первые 8 байт компануем по 2
                    {
                        outputArr[i] = new byte[2];
                        outputArr[i][1] = inputArr[k + 1];
                        outputArr[i][0] = inputArr[k];
                        k = k + 2
    ;
                    }
                    else //все остальные компануем по 4
                    {
                        outputArr[i] = new byte[4];
                        outputArr[i][3] = inputArr[k + 3];
                        outputArr[i][2] = inputArr[k + 2];
                        outputArr[i][1] = inputArr[k + 1];
                        outputArr[i][0] = inputArr[k];
                        k = k + 4;
                    }
                    ++i;
                }
                return outputArr;
            }
            
        }

        //05.Подать управляющий сигнал
        public static void DecodeFifth()
        {

        }

        //07.Считать слово состояния
        public static string[] DecodeSeventh(string bits)
        {
            string[] statusWord = new string[7];

            if (bits[0] == '1')
            {
                statusWord[0] += "Идёт накопление спектра";
            }
            else
            {
                statusWord[0] += "Накопление спектра запрещено";
            }
            if (bits[1] == '1')
            {
                statusWord[1] += "Измерение бета идёт";
            }
            else
            {
                statusWord[1] += "Измерение бета запрещено";
            }
            if (bits[2] == '1')
            {
                statusWord[2] += "Измерение альфа идёт";
            }
            else
            {
                statusWord[2] += "Измерение альфа запрещено";
            }
            if (bits[3] == '1')
            {
                statusWord[3] += "Режим вычитания фона альфа включен";
            }
            else
            {
                statusWord[3] += "Режим вычитания фона альфа выключен";
            }
            if (bits[4] == '1')
            {
                statusWord[4] += "Режим вычитания фона гамма включен";
            }
            else
            {
                statusWord[4] += "Режим вычитания фона гамма выключен";
            }
            if (bits[5] == '1')
            {
                statusWord[5] += "Режим вычитания фона беты включен";
            }
            else
            {
                statusWord[5] += "Режим вычитания фона бета выключен";
            }
            if (bits[6] == '1')
            {
                statusWord[6] += "Режим настройки включен";
            }
            else
            {
                statusWord[6] += "Режим настройки выключен";
            }

            return statusWord;
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


