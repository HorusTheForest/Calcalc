using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calcalc
{
    public partial class Form1 : Form
    {
        double arg1 = 0, arg2 = 0;
        String oper;
        bool isEqual = false;
        double memory = 0;

        public Form1()
        {
            InitializeComponent();

        }

        private void NumKey_Click(object sender, EventArgs e)
        {
            if (isEqual)
            {
                tbInput.Text = String.Empty;
                tbMemory.Text = String.Empty;
                isEqual = false;
            }
            Button key = (Button)sender;
            tbInput.Text += key.Tag;
            if (!(tbInput.Text.Contains(","))) WriteInput(ReadInput());
            
            

        }

        private void OperatorKey_Click(object sender, EventArgs e)
        {
            if (isEqual) isEqual = false;
            Button key = (Button)sender;
            tbMemory.Text += tbInput.Text + key.Tag;
            arg1 = ReadInput();
            tbInput.Text = "";
            oper = Convert.ToString(key.Tag);

        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            String s = tbInput.Text;
            tbMemory.Text += "\u221A(" + s + ")";
            WriteInput(Math.Sqrt(ReadInput()));
            
        }

        private void btnNegate_Click(object sender, EventArgs e)
        {
            if (!(tbInput.Text == ""))
            {
                tbInput.Text = Convert.ToString(-1 * Convert.ToDouble(tbInput.Text));
            }
        }

        private double ReadInput()
        {
            if (!(tbInput.Text == "")) return Convert.ToDouble(tbInput.Text);
            else return 0;
            
        }

        private void WriteInput(double number)
        {
            tbInput.Text = Convert.ToString(number);
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (tbInput.Text == "")
            {
                WriteInput((arg1 / 100) * arg1);
            }
            else
            {
                WriteInput((ReadInput() / 100) * arg1);
            }
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            tbInput.Text = "";
            tbMemory.Text = "";
            arg1 = 0;
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            tbInput.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (!(tbInput.Text.Length == 0))
            tbInput.Text = tbInput.Text.Remove(tbInput.Text.Length - 1);
        }

        private void btnEq_Click(object sender, EventArgs e)
        {
            WriteInput(ReadInput());
            tbMemory.Text += tbInput.Text;
            tbMemory.Text += "=";
            switch (oper)
            {
                case "+":
                    arg2 = ReadInput();
                    WriteInput(arg1 + ReadInput());
                    isEqual = true;
                    break;
                case "-":
                    WriteInput(arg1 - ReadInput());
                    isEqual = true;
                    break;
                case "*":
                    WriteInput(arg1 * ReadInput());
                    isEqual = true;
                    break;
                case "/":
                    if (ReadInput() == 0)
                    {
                        MessageBox.Show("No dividing through 0");
                        tbInput.Text = String.Empty;
                        tbMemory.Text = String.Empty;
                    }
                    WriteInput(arg1 / ReadInput());
                    isEqual = true;
                    break;
                default:
                    isEqual = true;
                    break;
            }
        }

        private void btnFraction_Click(object sender, EventArgs e)
        {
            String s = tbInput.Text;
            tbMemory.Text += "1/(" + s + ")";
            WriteInput(1/(ReadInput()));
        }

        private void btnMS_Click(object sender, EventArgs e)
        {
            btnMR.Enabled = true;
            btnMC.Enabled = true;
            memory = ReadInput();
        }

        private void btnMminus_Click(object sender, EventArgs e)
        {
            memory -= ReadInput();
        }

        private void btnMplus_Click(object sender, EventArgs e)
        {
            memory += ReadInput();
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            WriteInput(memory);
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            btnMR.Enabled = false;
            btnMC.Enabled = false;
            memory = 0;
        }

        private void btnNumPer_Click(object sender, EventArgs e)
        {
            if (tbInput.Text == "") tbInput.Text += "0";
            if (!(tbInput.Text.Contains(","))) tbInput.Text += ",";
        }
    }
}
