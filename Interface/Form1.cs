using System;
using System.Drawing;
using System.Windows.Forms;
using BDKS_06;

namespace Interface
{
    public partial class Form1 : Form
    {
        private Port port = new Port();
        private static int CommandIndex { get; set; }

        public Form1()
        {
            InitializeComponent();

            availablePorts.Items.AddRange(port.GetPortsName());
        }

        //Установка имени порта
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            port.ClosePort();

            port.SetPortName(availablePorts.Text);

            portStatus.Text = port.StatusPort();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            portStatus.Text = port.StatusPort();
        }

        //Цвет статуса порта
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (portStatus.Text == "Порт закрыт")
            {
                this.portStatus.ForeColor = Color.OrangeRed;
            }
            else
            {
                this.portStatus.ForeColor = Color.LightGreen;
            }
        }

        //Выполнение команды
        private void Button1_Click_1(object sender, EventArgs e)
        {
            if (portStatus.Text == "Порт закрыт")
            {
                MessageBox.Show("Откройте порт");
            }
            else if (command.Text == "")
            {
                MessageBox.Show("Выберите команду");
            }
            else
            {
                HighLevel high = new HighLevel();

                byte[] workBytes = new byte[] { };
                ushort ush1, ush2, ush3, ush4;
                byte by1, by2, by3, by4, by5, by6, by7, by8;
                string[] decodeText;

                try
                {
                    switch (CommandIndex)
                    {
                        case 2:

                            ush1 = ushort.Parse(ushort1.Text);
                            ush2 = ushort.Parse(ushort2.Text);

                            workBytes = high.Second(ush1, ush2);
                            ShowAnswerBytes(workBytes);

                            break;

                        case 3:
                            
                            ush1 = ushort.Parse(ushort1.Text);
                            ush2 = ushort.Parse(ushort2.Text);
                            
                            workBytes = high.Third(ush1, ush2);
                            ShowAnswerBytes(workBytes);

                            workBytes = Decode.GetAnswerBytes(workBytes,numberParity:true);
                            decodeText = Decode.DecodeThird(workBytes);

                            ShowAnswerText(decodeText);
                          

                            break;

                        case 4:

                            ush1 = ushort.Parse(ushort1.Text);
                            ush2 = ushort.Parse(ushort2.Text);

                            workBytes = high.Fourth(ush1, ush2);
                            ShowAnswerBytes(workBytes);

                            workBytes = Decode.GetAnswerBytes(workBytes, numberParity: true);
                            decodeText =  Decode.DecodeFourth(workBytes);

                            ShowAnswerText(decodeText);

                            break;

                        case 5:

                            ush1 = ushort.Parse(ushort1.Text);
                            ush2 = ushort.Parse(ushort2.Text);

                            workBytes = high.Fifth(ush1, ush2);
                            ShowAnswerBytes(workBytes);

                            workBytes = Decode.GetAnswerBytes(workBytes);
                            decodeText = Decode.DecodeFifth(workBytes);

                            ShowAnswerText(decodeText);

                            break;

                        case 6:

                            ush1 = ushort.Parse(ushort1.Text);
                            ush2 = ushort.Parse(ushort2.Text);

                            workBytes = high.Sixth(ush1, ush2);
                            ShowAnswerBytes(workBytes);

                            break;

                        case 7:                           
                            
                            workBytes = high.Seventh();                            
                            ShowAnswerBytes(workBytes);

                            workBytes = Decode.GetAnswerBytes(workBytes);

                            decodeText = Decode.DecodeSeventh(workBytes[0]);
                            
                            ShowAnswerText(decodeText);

                            break;

                        case 8:

                            ush1 = ushort.Parse(ushort1.Text);
                            by1 = byte.Parse(byte1.Text);
                            by2 = byte.Parse(byte2.Text);

                            workBytes = high.Eighth(ush1, by1, by2);
                            ShowAnswerBytes(workBytes);

                            break;

                        case 9:

                            by1 = byte.Parse(byte1.Text);
                            ush1 = ushort.Parse(ushort1.Text);
                            ush2 = ushort.Parse(ushort2.Text);
                            ush3 = ushort.Parse(ushort3.Text);

                            workBytes = high.Nineth(by1, ush1, ush2, ush3);
                            ShowAnswerBytes(workBytes);

                            break;

                        case 10:

                            by1 = byte.Parse(byte1.Text);
                            ush1 = ushort.Parse(ushort1.Text);
                            ush2 = ushort.Parse(ushort2.Text);
                            ush3 = ushort.Parse(ushort3.Text);
                            by3 = byte.Parse(byte3.Text);
                            by4 = byte.Parse(byte4.Text);
                            by5 = byte.Parse(byte5.Text);
                            by6 = byte.Parse(byte6.Text);
                            by7 = byte.Parse(byte7.Text);
                            by8 = byte.Parse(byte8.Text);

                            workBytes = high.Tenth(by1, ush1, ush2, ush3, by3, by4, by5, by6, by7, by8);
                            ShowAnswerBytes(workBytes);

                            break;

                        case 11:

                            by1 = byte.Parse(byte1.Text);
                            ush1 = ushort.Parse(ushort1.Text);
                            ush2 = ushort.Parse(ushort2.Text);

                            workBytes = high.Eleventh(by1, ush1, ush2);
                            ShowAnswerBytes(workBytes);

                            break;

                        case 16:

                            by1 = byte.Parse(byte1.Text);
                            ush1 = ushort.Parse(ushort1.Text);
                            ush2 = ushort.Parse(ushort2.Text);
                            ush3 = ushort.Parse(ushort3.Text);
                            ush4 = ushort.Parse(ushort4.Text);

                            workBytes = high.Sixteenth(by1, ush1, ush2, ush3, ush4);
                            ShowAnswerBytes(workBytes);

                            break;

                        case 17:

                            workBytes = high.Seventeenth();
                            ShowAnswerBytes(workBytes);

                            break;

                        case 18:

                            by1 = byte.Parse(byte1.Text);
                            ush1 = ushort.Parse(ushort1.Text);
                            ush2 = ushort.Parse(ushort2.Text);

                            workBytes = high.Eightteenth(by1, ush1, ush2);
                            ShowAnswerBytes(workBytes);

                            break;

                        case 19:

                            by1 = byte.Parse(byte1.Text);
                            ush1 = ushort.Parse(ushort1.Text);
                            ush2 = ushort.Parse(ushort2.Text);
                            by3 = byte.Parse(byte3.Text);
                            by4 = byte.Parse(byte3.Text);
                            by5 = byte.Parse(byte3.Text);
                            by6 = byte.Parse(byte3.Text);

                            workBytes = high.Nineteenth(by1, ush1, ush2, by3, by4, by5, by6);
                            ShowAnswerBytes(workBytes);

                            break;
                    }
                }
                catch (OverflowException)
                {
                    MessageBox.Show("Слишком большое или слишком маленькое значение одного из аргументов,OfverflowException");
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Один из аргументов имеет недопустимый формат,ArgumentException");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Введите корректные значения,FormatException");
                }
            }
        }

        //Закрыть порт
        private void Button2_Click(object sender, EventArgs e)
        {
            port.ClosePort();
            portStatus.Text = port.StatusPort();
        }

        //Открыть порт
        private void Button3_Click(object sender, EventArgs e)
        {
            port.OpenPort();
            portStatus.Text = port.StatusPort();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) => port.ClosePort();

        //Отображение полей для ввода аргументов
        private void Command_SelectedValueChanged(object sender, EventArgs e)
        {
            CommandIndex = GetCommandIndex();

            Hide();

            switch (CommandIndex)
            {
                case 2:
                    Show1();
                    break;
                case 3:
                    Show1();
                    break;
                case 4:
                    Show1();
                    break;
                case 5:
                    Show1();
                    break;
                case 6:
                    Show1();
                    break;
                case 7:

                    break;
                case 8:
                    Show2();
                    break;
                case 9:
                    Show5();
                    break;
                case 10:
                    Show8();
                    break;
                case 11:
                    Show3();
                    break;
                case 16:
                    Show6();
                    break;
                case 17:
                    break;
                case 18:
                    Show3();
                    break;
                case 19:
                    Show7();
                    break;
            }
        }

        // Индекс команды для реализации логики выбора одной из доступных 18 команд
        private int GetCommandIndex()
        {
            string textCom;
            int index;

            textCom = command.Text;
            index = textCom.IndexOf(".");

            textCom = textCom.Substring(0, index);
            Int32.TryParse(textCom, out index);

            return index;
        }

        //Нажатие на выбор порта реализующее обновление списка доступных COM портов
        private void AvailablePorts_MouseClick(object sender, MouseEventArgs e)
        {
            availablePorts.Text = "";
            availablePorts.Items.Clear();
            availablePorts.Items.AddRange(port.GetPortsName());
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            outputText.Text = "";
        }
    }
}
