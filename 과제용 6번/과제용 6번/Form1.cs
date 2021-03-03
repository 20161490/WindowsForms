using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 과제용_6번
{
    public partial class Form1 : Form
    {
        int W;
        int H;
        int I;
        Point p1;
        Point p2;
        int OFFX = 17;
        double delta_x;

        public Form1()
        {
            InitializeComponent();
            p1 = new Point();
            p2 = new Point();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            W = this.ClientSize.Width;
            H = this.ClientSize.Height;
            delta_x = 2 * Math.PI / (W-OFFX);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen pen1 = new Pen(Color.Red, 3);
            Pen pen2 = new Pen(Color.Blue, 5);
            Pen pen3 = new Pen(Color.Yellow, 7);
            Pen pen4 = new Pen(Color.Green, 7);
            graphics.DrawLine(pen1, 0, H / 2, W, H / 2);
            graphics.DrawLine(pen1, OFFX, 0, OFFX, H);

            for (I = 0; I <= (W - 1); I++)
            {
                p1.X = (int)((W - OFFX) / (2 * Math.PI) * I * delta_x + OFFX);
                p1.Y = (int)((-H / 2) * Math.Sin(I * delta_x) + H / 2);
                p2.X = (int)((W - OFFX) / (2 * Math.PI) * (I + 1) * delta_x + OFFX);
                p2.Y = (int)((-H / 2) * Math.Sin((I + 1) * delta_x) + H / 2);
                graphics.DrawLine(pen2, p1.X, p1.Y, p2.X, p2.Y);
            }
            for (I = 0; I <= (W - 1); I++)
            {
                p1.X = (int)((W - OFFX) / (2 * Math.PI) * I * delta_x + OFFX);
                p1.Y = (int)((-H / 2) * Math.Cos(I * delta_x) + H / 2);
                p2.X = (int)((W - OFFX) / (2 * Math.PI) * (I + 1) * delta_x + OFFX);
                p2.Y = (int)((-H / 2) * Math.Cos((I + 1) * delta_x) + H / 2);
                graphics.DrawLine(pen3, p1.X, p1.Y, p2.X, p2.Y);
            }
            for (I = 0; I <= (W / 8); I++)
            {
                p1.X = (int)((W - OFFX) / (2 * Math.PI) * I * delta_x + OFFX);
                p1.Y = (int)((-H / 2) * Math.Tan(I * delta_x) + H / 2);
                p2.X = (int)((W - OFFX) / (2 * Math.PI) * (I + 1) * delta_x + OFFX);
                p2.Y = (int)((-H / 2) * Math.Tan((I + 1) * delta_x) + H / 2);
                graphics.DrawLine(pen4, p1.X, p1.Y, p2.X, p2.Y);
            }
            for (I = 3*(W-OFFX)/8; I <= (5*W / 8); I++)
            {
                p1.X = (int)((W - OFFX) / (2 * Math.PI) * I * delta_x + OFFX);
                p1.Y = (int)((-H / 2) * Math.Tan(I * delta_x) + H / 2);
                p2.X = (int)((W - OFFX) / (2 * Math.PI) * (I + 1) * delta_x + OFFX);
                p2.Y = (int)((-H / 2) * Math.Tan((I + 1) * delta_x) + H / 2);
                graphics.DrawLine(pen4, p1.X, p1.Y, p2.X, p2.Y);
            }
            for (I = 7 * (W-OFFX) / 8; I <= (W - 1); I++)
            {
                p1.X = (int)((W - OFFX) / (2 * Math.PI) * I * delta_x + OFFX);
                p1.Y = (int)((-H / 2) * Math.Tan(I * delta_x) + H / 2);
                p2.X = (int)((W - OFFX) / (2 * Math.PI) * (I + 1) * delta_x + OFFX);
                p2.Y = (int)((-H / 2) * Math.Tan((I + 1) * delta_x) + H / 2);
                graphics.DrawLine(pen4, p1.X, p1.Y, p2.X, p2.Y);
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            W = this.ClientSize.Width;
            H = this.ClientSize.Height;
            this.Invalidate();
        }
    }
}
