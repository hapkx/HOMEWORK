using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm1
{
    public partial class Form1 : Form
    {
        double a, b, ans = 0;
        char op;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sa = textBox1.Text;
            a = Double.Parse(sa);
            string sb = textBox2.Text;
            b = Double.Parse(sb);
            string sop = textBox3.Text;
            op = Char.Parse(sop);

            if (op != '+' && op != '-' && op != '*' && op != '/')
            {
                label7.Text = "运算符不合法，\n 请重新输入！";
                label11.Text = $"{a} {op} {b} = ?";
            }            
            else
            {
                switch (op)
                {
                    case '+':
                        ans = a + b;
                        break;
                    case '-':
                        ans = a - b;
                        break;
                    case '*':
                        ans = a * b;
                        break;
                    case '/':
                        ans = a / b;
                        break;
                    default:
                        break;
                }
                label7.Text = "运算结果在这里~";
                label11.Text = $"{a} {op} {b} = {ans}";
            }                       
        }
    }
}
