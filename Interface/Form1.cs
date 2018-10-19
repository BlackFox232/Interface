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
            HighLevel a = new HighLevel();
           
            byte[] Am;
            
            if (port.StatusPort() == "Порт закрыт")
            {
                MessageBox.Show("Откройте порт");
            }
            //else if (index == 0)
            //{
            //    MessageBox.Show("Выберите команду ");
            //}
            else
            {
                Am = a.Seven();

                for (int i = 0; i < Am.Length; i++)
                {
                    outputText.Text +="0x"+Am[i].ToString("x");
                    outputText.Text += " ";
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

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void availablePorts_MouseClick(object sender, MouseEventArgs e)
        {
            portStatus.Text = port.StatusPort();
        }
    }
}
