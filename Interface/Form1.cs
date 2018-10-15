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

namespace Interface
{
    public partial class Form1 : Form
    {
        int index { get; set; }
        Port port = new Port();

        public Form1()
        {

            InitializeComponent();

            availablePorts.Items.AddRange(port.GetPortsName());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            port.SetPort(availablePorts.Text);
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
            byte[] Am;
            int cnt = 0;

            if (port.StatusPort() == "Порт закрыт")
            {
                MessageBox.Show("Откройте порт");
            }
            else if (index == 0)
            {
                MessageBox.Show("Выберите команду ");
            }
            else
            {

                Am = Commands.Comm3(0x1000,0x1500);

                foreach (var item in Am)
                {
                    
                    outputText.Text += Am[cnt].ToString("x");
                    outputText.Text += "check ";
                    cnt++;
                }

                outputText.Text += "\n";
                
                portStatus.Text = port.StatusPort();
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
             index = command.SelectedIndex + 1;   
        }
    }
}
