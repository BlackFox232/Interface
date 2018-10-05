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

namespace Interface
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

            availablePorts.Items.AddRange(JobsWithoutData.GetPortsName());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            JobsWithoutData.SetPort(availablePorts.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            portStatus.Text = JobsWithoutData.StatusPort();
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



            if (JobsWithoutData.StatusPort() == "Порт закрыт")
            {
                MessageBox.Show("Откройте порт");
            }
            else
            {
                byte[] am = { 0x1, 0x7 };

                am = JobsWithoutData.Write(am);

                for (int i = 0; i < am.Length; i++)
                {
                    outputText.Text += am[i].ToString("x");
                    outputText.Text += " ";
                }

                //outputText.Text += Form.ToString("/n");

                portStatus.Text = JobsWithoutData.StatusPort();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            JobsWithoutData.ClosePort();
            portStatus.Text = JobsWithoutData.StatusPort();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            JobsWithoutData.OpenPort();
            portStatus.Text = JobsWithoutData.StatusPort();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) => JobsWithoutData.ClosePort();
    }
}
