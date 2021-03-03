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
        int OFFX = 50;
        int OFFY = 100;
        double g = 9.8;
        double x;
        double y;
        double time;
        double a;
        double v;
        public Form1()
        {
            InitializeComponent();
            x = y = 0.0;
            time = 0.0;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        protected void draw_axes(Graphics g)
        {
            Pen pen = new Pen(new SolidBrush(Color.Black));
            int Height = this.ClientSize.Height;
            int Width = this.ClientSize.Width;
            g.DrawLine(pen, OFFX, 0, OFFX, Height - OFFY);
            g.DrawLine(pen, OFFX, Height - OFFY, Width, Height - OFFY);
        }
        protected void draw_ball(Graphics g)
        {
            float X, Y;
            int Height = this.ClientSize.Height;
            int Width = this.ClientSize.Width;
            X = (float)(((float)Width - OFFX) / 20.0 * x + OFFX);
            Y = (float)(-((float)Height - OFFY) / 10.0 * y + ((float)Height - OFFY));
            g.FillEllipse(new SolidBrush(Color.Blue), X - 5, Y - 5, 10, 10);
            if (y < 0.0)
            {
                timer1.Stop();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            draw_axes(g);
            draw_ball(g);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a = double.Parse(textBox1.Text.ToString()) * Math.PI / 180.0;
            v = double.Parse(textBox2.Text.ToString());
            x = y = time = 0.0;
            timer1.Interval = 50;
            timer1.Start();
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            time += timer1.Interval / 2000.0;
            x = v*Math.Cos(a) * time;
            y = v*Math.Sin(a) * time - 0.5 * g * time * time;
            this.Invalidate();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }
    }
}
