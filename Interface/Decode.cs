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
        /// <summary>
        /// Сортирует двумерный массив по 2байта(ushort) и 4 (float) в соответствии с введёнными аргументами, РАБОТАЕТ ТОЛЬКО ЕСЛИ ushort СТОЯТ ВНАЧАЛЕ 
        /// </summary>
        /// <param name="inputArr">Входной массив байтов команды</param>
        /// <param name="bytesFirstUshorts">Сумма байт первых ushort</param>
        /// <param name="numberFirstUshorts">Количество первых ushort</param>
        /// <param name="bytesDecodeRegister">Сумма всех байтов всех регистров для расшифровки</param>
        /// <param name="maxValuesDecodeRegister">Максимальное количество регистров для расшифровки</param>
        /// <returns>Отсортированный массив</returns>
        static byte[][] Sorting2(byte[] inputArr, int bytesFirstUshorts, int numberFirstUshorts, int bytesDecodeRegister, int maxValuesDecodeRegister) // Сортирует входной массив в двумерный в котором первый массив количество регистров а второй их содержимое 
        {
            int outputArrLength; // Переменная содержащая в себе кол-во состояний регистров

            if (inputArr.Length < bytesFirstUshorts) // Проверка на то больше ли в ответе чем первые ushort регистра
            {
                outputArrLength = inputArr.Length / 2;
            }
            else if (inputArr.Length < bytesDecodeRegister)
            {
                outputArrLength = (inputArr.Length - bytesFirstUshorts) / 4 + numberFirstUshorts;
            }
            else
            {
                outputArrLength = maxValuesDecodeRegister;
            }

            byte[][] outputArr = new byte[outputArrLength][];
            int k = 0;
            int i = 0;

            while (i < outputArrLength)
            {
                if (i < numberFirstUshorts)  //Байты первых ushort реистров компануются по 2
                {
                    outputArr[i] = new byte[2];
                    outputArr[i][0] = inputArr[k + 1];
                    outputArr[i][1] = inputArr[k];
                    k = k + 2;
                }
                else //все остальные компануются по 4
                {
                    outputArr[i] = new byte[4];
                    outputArr[i][0] = inputArr[k + 3];
                    outputArr[i][1] = inputArr[k + 2];
                    outputArr[i][2] = inputArr[k + 1];
                    outputArr[i][3] = inputArr[k];
                    k = k + 4;
                }
                ++i;
            }
            return outputArr;
        }

        /// <summary>
        /// Возвращает текстовую расшифровку для команды
        /// </summary>
        /// <param name="registerStatuses">Отсортированный массив(сортируется с помощью Sort)</param>
        /// <param name="maxValuesDecodeRegister">Максимальное количество регистров для расшифровки</param>
        /// <param name="answerMas">Массив с строками статусов регистров </param>
        /// <param name="numberFirstUshorts">кол-во первых ushort</param>
        /// <returns>Отсортированный массив строк</returns>
        static string[] GetStatusMas(byte[][] registerStatuses, int maxValuesDecodeRegister, string[] answerMas, int numberFirstUshorts)
        {
            void Convertation(int i)
            {
                if (i < numberFirstUshorts) // Проверка на то что расшифровывается в текущий момент ushort или float по номеру
                {
                    answerMas[i] += BitConverter.ToUInt16(registerStatuses[i], 0);
                }
                else
                {
                    answerMas[i] += BitConverter.ToSingle(registerStatuses[i], 0);
                }
            }

            if (registerStatuses.Length >= maxValuesDecodeRegister) // Проверка на то используется ли максимально допустимый диапазон статусов регистров для текстовой расшифровки или нет
            {
                for (int i = 0; i < maxValuesDecodeRegister; i++)
                {
                    Convertation(i);
                }

                answerMas[answerMas.Length - 1] +=
                    "*********************************************************************" +
                    "\n" +
                    "Расшифровка остальных состояний не предусмотрена";

                return answerMas;
            }
            else // Если нет то обрезается до нужного
            {
                for (int i = 0; i < registerStatuses.Length; i++)
                {
                    Convertation(i);
                }

                string[] shortMas = new string[registerStatuses.Length]; // Не полный массив строк на случай использования диапазона который меньше доступных текстовых расшифровок

                for (int i = 0; i < registerStatuses.Length; i++)
                {
                    shortMas[i] = answerMas[i];
                }

                return shortMas;
            }
        }


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

            byte[][] statuses = Sorting2(answerBytes, 8, 4, 28, 9);

            regControlStatus = GetStatusMas(statuses, 9, regControlStatus, 4);

            return regControlStatus;
        }

        // 04.Считать состояние регистров данных
        public static string[] DecodeFourth(byte[] answerBytes)
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
            "«Мгновенная» интенсиметр бета, s-1",
            "Средняя скорость счета бета в формате с плавающей точкой, s-1 : ",
            "Статистическая погрешность средней скорости счета бета в формате с плавающей точкой, % : ",
            "Средняя плотность потока бета в формате с плавающей точкой, Sv/h, rem/h или R/h : ",
            "Статистическая погрешность средней плотность потока бета в формате с плавающей точкой, % : ",
            "Флюенс бета в формате с плавающей точкой, Sv : ",
            "«Мгновенная» интенсиметр альфа, s-1",
            "Средняя скорость счета альфа в формате с плавающей точкой, s-1 : ",
            "Статистическая погрешность средней скорости счета альфа в формате с плавающей точкой, % : ",
            "Средняя плотность потока альфа в формате с плавающей точкой, Sv/h, rem/h или R/h : ",
            "Статистическая погрешность средней плотность потока альфа в формате с плавающей точкой, % : ",
            "Флюенс альфа в формате с плавающей точкой, Sv : ",

            " " // Последний элемент для добавления строки "Расшифровка остальных состояний не предусмотрена" на случай ввода более 9 первых регистров
            };
            
            byte[][] statuses = Sorting2(answerBytes, 4, 2, 80, 21);

            regDataStatus = GetStatusMas(statuses, 21, regDataStatus, 2);

            return regDataStatus;
        }

        //05.Подать управляющий сигнал
        public static string[] DecodeFifth(byte[] answerBytes)
        {
            string[] textStatus = new string[1];
            
            ushort[] status = new ushort[2];
            try
            {
                status[0] = BitConverter.ToUInt16(new byte[] { answerBytes[0], answerBytes[1] }, 0);
                status[1] = BitConverter.ToUInt16(new byte[] { answerBytes[2], answerBytes[3] }, 0);

            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Недопустимое значение команды");
                return textStatus;
            }
            
            switch (status[0])
            {
                case 256:
                    textStatus[0] += "Накопление спектра ";
                    break;

                case 512:
                    textStatus[0] += "Измерение бета ";
                    break;

                case 768:
                    textStatus[0] += "Измерение альфа ";
                    break;

                case 1792:
                    textStatus[0] += "Режим настройки ";
                    break;
            }

            if (status[1] > 0)
            {
                textStatus[0] += "разрешено";
            }
            else
            {
                textStatus[0] += "запрещено";
            }

            return textStatus;
        }

        //07.Считать слово состояния 
        public static string[] DecodeSeventh(byte statusBytes)
        {
            int i = 0;
            string[] statusWord = new string[8];

            byte[] bit = new byte[] { };

            if (BitConverter.IsLittleEndian)
            {
                bit = new byte[]
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
                bit = new byte[]
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

            foreach (var item in bit)
            {
                if ((item & statusBytes) != 0)
                {
                    statusWord[i] = "1";
                }
                else
                {
                    statusWord[i] = "0";
                }
                i++;
            }


            string[] DecodeBits(string[] bits)
            {
                statusWord = new string[7];

                if (bits[6] == "1")
                {

                    statusWord[6] += "Идёт накопление спектра";
                }
                else
                {
                    statusWord[6] += "Накопление спектра запрещено";
                }
                if (bits[5] == "1")
                {
                    statusWord[5] += "Измерение бета идёт";
                }
                else
                {
                    statusWord[5] += "Измерение бета запрещено";
                }
                if (bits[4] == "1")
                {
                    statusWord[4] += "Измерение альфа идёт";
                }
                else
                {
                    statusWord[4] += "Измерение альфа запрещено";
                }
                if (bits[3] == "1")
                {
                    statusWord[3] += "Режим вычитания фона альфа включен";
                }
                else
                {
                    statusWord[3] += "Режим вычитания фона альфа выключен";
                }
                if (bits[2] == "1")
                {
                    statusWord[2] += "Режим вычитания фона гамма включен";
                }
                else
                {
                    statusWord[2] += "Режим вычитания фона гамма выключен";
                }
                if (bits[1] == "1")
                {
                    statusWord[1] += "Режим вычитания фона беты включен";
                }
                else
                {
                    statusWord[1] += "Режим вычитания фона бета выключен";
                }
                if (bits[0] == "1")
                {
                    statusWord[0] += "Режим настройки включен";
                }
                else
                {
                    statusWord[0] += "Режим настройки выключен";
                }
                return statusWord;
            }

            statusWord = DecodeBits(statusWord);

            return statusWord;
        }

        //Выделить байты ответа убрав CRC,адрес,номер команды и если имеется путём привсвоения numberParity значения true убрать так же кол-во байт ответа в рабочем массиве
        public static byte[] GetAnswerBytes(byte[] val, bool numberParity = false)
        {
            int cnt = 0;
            int i = 0;
            byte[] _val = new byte[] { };

            if (numberParity == false)
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

                return _val;
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

                return _val;
            }
        }


    }
}