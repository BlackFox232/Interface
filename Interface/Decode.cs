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
            string[] regControl;
            int cnt = 0; ;

            void FirstFourBytes()
            {
                regControl[0] += "Время накопления в секундах : "
                    + BitConverter.ToUInt16(new[] { bytes[1], bytes[0] }, 0);
                regControl[1] += "Время измерения бета : "
                    + BitConverter.ToUInt16(new[] { bytes[3], bytes[2] }, 0);
                regControl[2] += "Время измерения альфа : "
                    + BitConverter.ToUInt16(new[] { bytes[5], bytes[4] }, 0);
                regControl[3] += "Код управления усилением с учетом температурной коррекции : "
                    + BitConverter.ToUInt16(new[] { bytes[7], bytes[6] }, 0); // ПОКАЗЫВАЕТ 400 ПРИ ДОПУСТИМОМ МАКСИМУМ 255 И ТУТ И В ATerminal ,СПРОСИТЬ
            }

            void NextFiveFloats()
            {
                regControl[4] += "«Базовое» значение скорости счета для поискового режима в формате с плавающей точкой, s - 1, ст. 16 бит : "
                            + BitConverter.ToSingle(new[] { bytes[11], bytes[10], bytes[9], bytes[8] }, 0);
                regControl[5] += "«Фоновое» значение скорости счета для режима вычитания фона в формате с плавающей точкой, s-1,  ст. 16 бит. : "
                    + BitConverter.ToSingle(new[] { bytes[15], bytes[14], bytes[13], bytes[12] }, 0);
                regControl[6] += "Статистическая погрешность «фонового» значения скорости счета в формате с плавающей точкой, %, ст. 16 бит : "
                    + BitConverter.ToSingle(new[] { bytes[19], bytes[18], bytes[17], bytes[16] }, 0);
                regControl[7] += "«Фоновое» значение мощности дозы для режима вычитания фона в формате с плавающей точкой, ст. 16 бит. Размерность (Sv/h, rem/h или R/h) определяется значением 2-го регистра управления : "
                    + BitConverter.ToSingle(new[] { bytes[23], bytes[22], bytes[21], bytes[20] }, 0);
                regControl[8] += "Статистическая погрешность «фонового» значения мощности дозы в формате с плавающей точкой, %, мл. 16 бит : "
                    + BitConverter.ToSingle(new[] { bytes[27], bytes[26], bytes[25], bytes[24] }, 0);
            }

            if (bytes.Length <= 8) // Проверка на то, содержит ли массив больше 4 первых ushort  
            {
                regControl = new string[bytes.Length / 2]; // Массив содержащий состояния регистров первых 4 ushort в строковом представлении 
                cnt = bytes.Length/2;//получаем кол-во ushort необходимых для расшифровки

                switch (cnt) // Проверка на кол-во считанных регистров и присвоение регистрам их состояния 
                {
                    case 1:

                        regControl[0] += "Время накопления в секундах : "
                            + BitConverter.ToUInt16(new[] { bytes[1], bytes[0] }, 0);

                        break;

                    case 2:

                        regControl[0] += "Время накопления в секундах : "
                            + BitConverter.ToUInt16(new[] { bytes[1], bytes[0] }, 0);
                        regControl[1] += "Время измерения бета : "
                            + BitConverter.ToUInt16(new[] { bytes[3], bytes[2] }, 0);

                        break;

                    case 3:

                        regControl[0] += "Время накопления в секундах : "
                            + BitConverter.ToUInt16(new[] { bytes[1], bytes[0] }, 0);
                        regControl[1] += "Время измерения бета : "
                            + BitConverter.ToUInt16(new[] { bytes[3], bytes[2] }, 0);
                        regControl[2] += "Время измерения альфа : "
                            + BitConverter.ToUInt16(new[] { bytes[5], bytes[4] }, 0);

                        break;

                    case 4:

                        FirstFourBytes();

                        break;
                }
            }
            else if (bytes.Length <= 28) // последующих 5 float
            {

                cnt = bytes.Length - 8; // убираем 8 байт первых четырёх ushort
                cnt /= 4; // получаем количество float 
                cnt += 4; // добавляем первые 4 ushort
                regControl = new string[cnt]; // присваиваем массиву ответа кол-во состояний 
                cnt -= 4; // убираем первые 4 ushort

                FirstFourBytes();

                switch (cnt) // в зависимости от кол-ва float-ов расшифровка
                {
                    case 1:
                        regControl[4] += "«Базовое» значение скорости счета для поискового режима в формате с плавающей точкой, s - 1, ст. 16 бит : "
                            + BitConverter.ToSingle(new[] { bytes[11], bytes[10], bytes[9], bytes[8] }, 0); break;

                    case 2:
                        regControl[4] += "«Базовое» значение скорости счета для поискового режима в формате с плавающей точкой, s - 1, ст. 16 бит : "
                            + BitConverter.ToSingle(new[] { bytes[11], bytes[10], bytes[9], bytes[8] }, 0);
                        regControl[5] += "«Фоновое» значение скорости счета для режима вычитания фона в формате с плавающей точкой, s-1,  ст. 16 бит. : "
                            + BitConverter.ToSingle(new[] { bytes[15], bytes[14], bytes[13], bytes[12] }, 0);

                        break;

                    case 3:
                        regControl[4] += "«Базовое» значение скорости счета для поискового режима в формате с плавающей точкой, s - 1, ст. 16 бит : "
                            + BitConverter.ToSingle(new[] { bytes[11], bytes[10], bytes[9], bytes[8] }, 0);
                        regControl[5] += "«Фоновое» значение скорости счета для режима вычитания фона в формате с плавающей точкой, s-1,  ст. 16 бит. : "
                            + BitConverter.ToSingle(new[] { bytes[15], bytes[14], bytes[13], bytes[12] }, 0); regControl[4] += "«Базовое» значение скорости счета для поискового режима в формате с плавающей точкой, s - 1, ст. 16 бит : " + BitConverter.ToSingle(new[] { bytes[19], bytes[18], bytes[17], bytes[16] }, 0);
                        regControl[6] += "Статистическая погрешность «фонового» значения скорости счета в формате с плавающей точкой, %, ст. 16 бит : "
                            + BitConverter.ToSingle(new[] { bytes[19], bytes[18], bytes[17], bytes[16] }, 0);
                        break;

                    case 4:
                        regControl[4] += "«Базовое» значение скорости счета для поискового режима в формате с плавающей точкой, s - 1, ст. 16 бит : "
                            + BitConverter.ToSingle(new[] { bytes[11], bytes[10], bytes[9], bytes[8] }, 0);
                        regControl[5] += "«Фоновое» значение скорости счета для режима вычитания фона в формате с плавающей точкой, s-1,  ст. 16 бит. : "
                            + BitConverter.ToSingle(new[] { bytes[15], bytes[14], bytes[13], bytes[12] }, 0);
                        regControl[6] += "Статистическая погрешность «фонового» значения скорости счета в формате с плавающей точкой, %, ст. 16 бит : "
                            + BitConverter.ToSingle(new[] { bytes[19], bytes[18], bytes[17], bytes[16] }, 0);
                        regControl[7] += "«Фоновое» значение мощности дозы для режима вычитания фона в формате с плавающей точкой, ст. 16 бит. Размерность (Sv/h, rem/h или R/h) определяется значением 2-го регистра управления : "
                            + BitConverter.ToSingle(new[] { bytes[23], bytes[22], bytes[21], bytes[20] }, 0);

                        break;

                    case 5:
                        NextFiveFloats();
                        break;
                        
                }
            }
            else // больше 4 первых ushort и 5 последующих float
            {
                regControl = new string[10];
                FirstFourBytes();
                NextFiveFloats();
                regControl[regControl.Length - 1] += " Расшифровка остальных регистров в разработке ";
                return regControl;
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


