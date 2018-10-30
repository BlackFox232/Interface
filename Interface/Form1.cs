using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BDKS_06;
using System.IO;
using Interface;

namespace Interface
{
    public partial class Form1 : Form
    {
        Port port = new Port();

        public Form1()
        {
            InitializeComponent();

            availablePorts.Items.AddRange(port.GetPortsName());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            port.SetPortName(availablePorts.Text);
            portStatus.Text = port.StatusPort();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            portStatus.Text = port.StatusPort();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (portStatus.Text == "Порт закрыт")
            {
                this.portStatus.ForeColor = System.Drawing.Color.OrangeRed;
            }
            else
            {
                this.portStatus.ForeColor = System.Drawing.Color.LightGreen;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
                byte[] Am = new byte[] { };
                HighLevel high = new HighLevel();
                string textCom;
                int k;

                textCom = command.Text;
                k = textCom.IndexOf(".");

                textCom = textCom.Substring(0, k);
                Int32.TryParse(textCom, out k);

                try
                {
                    switch (k)
                    {
                        case 2:
                            ushort a, b;
                            a = ushort.Parse(ushort1.Text);
                            b = ushort.Parse(ushort2.Text);

                            Am = high.Second(a, b);
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
                            Am = high.Seventh();
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

                    Am = Decode.GetDecodeValues(Am);

                    for (int i = 0; i < Am.Length; i++)
                    {
                        outputText.Text += Am[i].ToString("x");
                        outputText.Text += " ";
                    }

                    outputText.Text += "\n";
                    portStatus.Text = port.StatusPort();
                }
                catch(OverflowException)
                {
                    MessageBox.Show("Слишком большое или слишком маленькое значение одного из аргументов");
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Один из аргументов имеет недопустимый формат");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Введите корректные значения");
                }
                
            }

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            port.ClosePort();
            portStatus.Text = port.StatusPort();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            port.OpenPort();
            portStatus.Text = port.StatusPort();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) => port.ClosePort();

        private void command_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void command_SelectedIndexChanged(object sender, EventArgs e)
        {
            command.Text = "";

        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void command_SelectedValueChanged(object sender, EventArgs e)
        {
            string textCom;
            int k;

            textCom = command.Text;
            k = textCom.IndexOf(".");

            textCom = textCom.Substring(0, k);
            Int32.TryParse(textCom, out k);

            Hide();

            switch (k)
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
    }
}
