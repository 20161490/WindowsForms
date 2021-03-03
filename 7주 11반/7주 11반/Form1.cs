using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7주_11반
{
    public partial class Form1 : Form
    {
        double a, b, c, d;
        Point p;
        Brush brush;
        Pen pen;
        int size;
        int x, y;
        int w, h;
        public Form1()
        {
            InitializeComponent();
            p = new Point();
            brush = new SolidBrush(Color.Red);
            pen = new Pen(Color.Blue);
            size = 15;
            w = this.ClientSize.Width;
            h = this.ClientSize.Height;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            a = double.Parse(textBox1.Text);
            b = double.Parse(textBox2.Text);
            c = double.Parse(textBox3.Text);
            d = double.Parse(textBox4.Text);

            p.X = (int)d;
            p.Y = (int)(a * d * d + b * d + c);
            x = p.X * 10;
            y = p.Y / 10;
            g.FillEllipse(brush, x, y, 2 * size, 2 * size);
            g.DrawLine(pen, (x + size), 0, (x + size), h);
            g.DrawLine(pen, 0, (y + size), w, (y + size));
            MessageBox.Show("좌표값: " + p.X + ", " + p.Y);
            this.Invalidate();

        }
    }
}
