using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cayley
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Graphics graphics;
        int nn = 10;
        double leng = 10;
        double th1 = 1;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        int r = 0;
        int g = 0;
        int b = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            nn = Int32.Parse(this.textBox1.Text);
            leng = Double.Parse(this.textBox2.Text);
            per2 = Double.Parse(this.textBox3.Text);
            per1 = Double.Parse(this.textBox4.Text);
            th1 = Double.Parse(this.textBox5.Text);
            th2 = Double.Parse(this.textBox6.Text);
            r = Int32.Parse(this.textBox7.Text);
            g = Int32.Parse(this.textBox8.Text); ;
            b = Int32.Parse(this.textBox9.Text); ;
            if (graphics == null) graphics = flowLayoutPanel1.CreateGraphics();
            drawCarleyTree(nn, 250, 350, leng, -Math.PI / 2, r, g, b);
        }

        void drawCarleyTree(int n, double x0, double y0, double leng, double th, int r, int g, int b)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine(x0, y0, x1, y1, r, g, b);
            drawCarleyTree(n - 1, x1, y1, per1 * leng, th + th1, r, g, b);
            drawCarleyTree(n - 1, x1, y1, per2 * leng, th - th2, r, g, b);

        }
        void drawLine(double x0, double y0, double x1, double y1, int r, int g, int b)
        {
            Pen pen = new Pen(Color.FromArgb(r, g, b));
            graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        
    }
}
