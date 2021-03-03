using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7주_12번
{
    public partial class Form1 : Form
    {
        Point p1;
        Point p2;
        double y1, y2;
        int i;
        int n;
        Pen pen1, pen2;
        Brush brush;
        FontFamily font;
        Font myfont;
        int line;
        int w,h;



        public Form1()
        {
            InitializeComponent();
            p1 = new Point();
            p2 = new Point();
            pen1 = new Pen(Color.Red);
            pen2 = new Pen(Color.Blue);
            brush = new SolidBrush(Color.Black);
            font = new FontFamily("굴림");
            myfont = new Font(font, 15, FontStyle.Regular,GraphicsUnit.Pixel);
            w = this.ClientSize.Width;
            h = this.ClientSize.Height;
            line = h - 272;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            g.Clear(Color.White);
            n = int.Parse(textBox1.Text);
            g.DrawLine(pen1, 0, line, w, line);
            for(i=1;i<n;i++)
            {
                y1 = Math.Pow((1 + 1.0 / i), i);
                y2 = Math.Pow((1 + 1.0 / (i + 1)), (i + 1));
                p1.X = 10 * i;
                p1.Y = (int)(y1 * 100);
                p2.X = (i + 1) * 10;
                p2.Y = (int)(y2 * 100);
                g.DrawLine(pen2, p1.X, h - p1.Y, p2.X, h - p2.Y);
            }
            g.DrawString("e=2.71", myfont, brush, w / 2, line - 25);
            MessageBox.Show("n= " + n + ": " + y2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
