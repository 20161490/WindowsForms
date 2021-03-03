using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8주_10_번
{
    public partial class Form1 : Form
    {
        int OFFX = 10;
        int OFFY = 15;
        float X, Y;
        double x, y;
        int radx, rady, radw, radh;
        float ballx, bally;
        float objx, objy;
        int W;
        int H;
        double time;
        double degree;
        double radian;
        double velocity;
        double g = 9.8;
        double length;
        Boolean click;
        Random random = new Random();

        int random_number, rad1, rad2;

        public Form1()
        {
            InitializeComponent();
            x = y = 0.0;
            click = true;
            random_number = random.Next(0, 15);
            rad1 = random.Next(-250, 250);
            rad2 = random.Next(-50, 50);
        }

        protected void draw_line(Graphics g)
        {
            H = this.ClientSize.Height;
            Pen pen = new Pen(Color.Red);
            g.DrawLine(pen, OFFX, H - OFFY, X, Y);
        }

        protected void draw_axes(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            H = this.ClientSize.Height;
            W = this.ClientSize.Width;
            g.DrawLine(pen, OFFX, 0, OFFX, H - OFFY);
            g.DrawLine(pen, OFFX, H - OFFY, W, H - OFFY);
        }

        protected void draw_ball(Graphics g)
        {
            ballx = (float)((W - OFFX) / 200.0 * x + OFFX);
            bally = (float)(-(H - OFFY) / 100.0 * y + (H - OFFY));
            g.FillEllipse(new SolidBrush(Color.Blue), ballx - 10, bally - 10, 20, 20);
            length = Math.Sqrt(Math.Pow((objx - ballx), 2) + Math.Pow((objy - bally), 2));
            if( y < 0.0 || ballx + 20 >= W)
            {
                time = 0.0;
                x = OFFX;
                y = H - OFFY;
                timer1.Stop();
            }    
            else if(length <=20)
            {
                time = 0.0;
                x = OFFX;
                y = H - OFFY;
                timer1.Stop();
                MessageBox.Show("명중입니다.");
            }
        }

        protected void draw_object(Graphics g)
        {
            radw = radh = random_number;
            radx = (int)(radh * Math.Cos(radw * radh));
            rady = (int)(radh * radh * Math.Sin(radw * radh));
            objx = (float)((W / 2 - rad1) / 200.0 * radx + (W / 2 - rad1));
            objy = (float)(-(H / 2 - rad2) / 100.0 * rady + (H / 2 - rad2));
            g.FillEllipse(new SolidBrush(Color.Orange), objx - 13, objy - 13, 25, 25);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            draw_line(g);
            draw_axes(g);
            draw_ball(g);
            draw_object(g);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 30;
            time += timer1.Interval / 1000.0;
            velocity = X / 10.0;
            x = velocity * Math.Cos(radian) * time;
            y = velocity * Math.Sin(radian) * time - 0.5 * g * time * time;
            this.Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(click == true)
            {
                X = e.X;
                Y = e.Y;
                velocity = X / 10.0;
                radian = Math.Atan2(((H - OFFY) - Y), (X - OFFX));
                degree = Math.Atan2(((H - OFFY) - Y), (X - OFFX)) * 180 / Math.PI;
                label1.Text = X.ToString();
                label2.Text = Y.ToString();
                label3.Text = degree.ToString();
                label4.Text = velocity.ToString();
                this.Invalidate();
            }
            else { }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if(click == true)
            {
                click = false;
                time = 0.0;
                x = OFFX;
                y = H - OFFY;
                timer1.Start();
            }
            else
            {
                click = true;
                timer1.Stop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            random_number = random.Next(0, 15);
            rad1 = random.Next(-250, 250);
            rad2 = random.Next(-50, 50);
            this.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
