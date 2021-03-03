using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8주_6번
{
    public partial class Form1 : Form
    {
        int H, W;
        double x, y;
        float X, Y;
        double time;
        double w;

        public Form1()
        {
            InitializeComponent();
            x = y = 0.0;
            time = 0.0;
        }
        private void draw_axes(Graphics g)
        {
            Pen pen = new Pen(Color.Red);
            H = this.ClientSize.Height;
            W = this.ClientSize.Width;
            g.DrawLine(pen, 0, H / 2, W, H / 2);
            g.DrawLine(pen, W / 2, 0, W / 2, H);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            w = double.Parse(textBox1.Text);
            time = double.Parse(textBox2.Text);
            x = time * Math.Cos(w * time);
            y = time * time * Math.Sin(w * time);
            label3.Text = x.ToString();
            label4.Text = y.ToString();
            this.Invalidate();
        }
        private void draw_ball(Graphics g)
        {
            X = (float)((W / 2) / 200.0 * x + (W / 2));
            Y = (float)(-(H / 2) / 100.0 * y + (H / 2));
            g.FillEllipse(new SolidBrush(Color.Blue), X - 10, Y - 10, 20, 20);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            draw_axes(g);
            draw_ball(g);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
