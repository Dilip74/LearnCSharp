using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = Environment.OSVersion.ToString();
            label2.Text = Environment.OSVersion.Platform.ToString();
            label3.Text = Environment.MachineName.ToString();
            label4.Text = Environment.ProcessorCount.ToString();

            
            //ulong ram = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;
        }
    }
}
