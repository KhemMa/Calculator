using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Double value = 0;
        bool op_pressed = false;
        String opt ="";
        bool byzero = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void num_button_Click(object sender, EventArgs e)
        {
            if (result.Text == "0" || op_pressed || byzero) { result.Clear(); if (byzero) byzero = false; }
            op_pressed = false;
            Button b = (Button)sender;
            result.Text = result.Text + b.Text;
        }

        private void opera_button_Click(object sender, EventArgs e)
        {
            if (byzero) return;
            Button o = (Button)sender;
            opt = o.Text;
            op_pressed = true;
            status.Text = o.Text;
            value = Double.Parse(result.Text);
        }

        private void equal_Click(object sender, EventArgs e)
        {
            status.Text = "";
            if (byzero) return;
            switch (opt)
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
                    if (Double.Parse(result.Text) == 0) 
                    {
                        result.Text = "Cannot Divide by Zero";
                        value = 0;
                        byzero = true;
                    }
                    else result.Text = (value / Double.Parse(result.Text)).ToString();
                    break;
                default:
                    break;
            }
        }

        private void dotted(object sender,EventArgs e)
        {
            if (byzero) return;
            if (!result.Text.Contains("."))
            {
                    Button b = (Button)sender;
                    result.Text = result.Text + b.Text;
            }
        }

        private void back_space(object sender, EventArgs e)
        {
            if(byzero) return;
            if (result.Text.Length > 0)
            {
                result.Text = result.Text.Remove(result.Text.Length - 1);
                if (result.Text.Length == 0)
                {
                    result.Text = "0";
                }
            }
            else
            {
                result.Text = "0";

            }
        }

        private void negative(object sender,EventArgs e)
        {
            if (byzero) return;
            if (!result.Text.Contains("-") && result.Text!="0")
            {
                result.Text = "-" + result.Text;
            }
            else
            {
                result.Text = result.Text.Trim('-');
            }

        }

        private void clear_entry_Click(object sender, EventArgs e)
        {
            result.Text = "0";
            byzero = false;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            result.Text = "0";
            value = 0;
            byzero = false;
            op_pressed = false;
            status.Text = "";
        }


    }
}
