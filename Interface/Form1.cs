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
            availablePorts =  JobsWithoutData.SetPort();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            portStatus.Text = JobsWithoutData.StatusPort();
        }
    }
}
