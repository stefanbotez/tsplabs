using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        double value = 0;
        String operation = "";
        bool clear_next = false;
        bool clear_label_next = false;
        bool decimal_pressed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Handle_Number(((Button)sender).Text);
        }

        private void clear_Entry_Click(object sender, EventArgs e)
        {
            result.Text = "0";
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Handle_Operation(((Button)sender).Text);
        }

        private void equal_Click(object sender, EventArgs e)
        {
            Handle_Equal();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            result.Text = "0";
            value = 0;
        }


        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == '.')
            {
                Handle_Number("" + e.KeyChar);
            }
            if(e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '*' || e.KeyChar == '/')
            {
                Handle_Operation("" + e.KeyChar);
            }
            if(e.KeyChar == '=' || e.KeyChar == (char)Keys.Enter)
            {
                Handle_Equal();
            }
        }

        private void Handle_Equal()
        {
            switch (operation)
            {
                case "+":
                    result.Text = (value + Double.Parse(result.Text)).ToString();
                    break;
                case "-":
                    result.Text = (value - Double.Parse(result.Text)).ToString();
                    break;
                case "*":
                    result.Text = (value * Double.Parse(result.Text)).ToString();
                    break;
                case "/":
                    result.Text = (value / Double.Parse(result.Text)).ToString();
                    break;
                default:
                    break;
            }
            label.Text = label.Text + '=';
            clear_next = true;
            clear_label_next = true;
        }

        private void Handle_Operation(String op)
        {
            if (clear_label_next == true)
            {
                label.Text = "";
            }
            if (result.Text != "-")
            {
                value = Double.Parse(result.Text);
                clear_next = true;
                operation = op;
                label.Text += op;
            }

            if (result.Text == "0" && op == "-")
            {
                result.Clear();
                result.Text = result.Text + op;
                clear_next = false;
                label.Text += "(-)";
            }
        }

        private void Handle_Number(String nr)
        {
            if (clear_label_next == true)
            {
                label.Text = "";
            }
            if (result.Text == "0" || clear_next)
            {
                result.Clear();
            }
            if (decimal_pressed && nr == "."){}
            else
            {
                result.Text = result.Text + nr;
                label.Text += nr;
                if (nr == ".")
                    decimal_pressed = true;
            }
            clear_next = false;
        }

        private void PlusMinus_Click(object sender, EventArgs e)
        {
            double val = Double.Parse(result.Text);
            val = -val;
            result.Text = val.ToString();
        }
    }
}
