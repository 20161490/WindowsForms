using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6주_12번
{
    public partial class Form1 : Form
    {
        private double a;
        private double v;
        private int fr;
        static double g = 9.8;
        double x;
        double y;

        private bool continueCheck;
        public Form1()
        {
            x = 0;
            y = this.Height / 2 - 5;
            fr = 0;

            continueCheck = false;

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            a = double.Parse(textBox1.Text);
            v = double.Parse(textBox2.Text);


            if (radioButton1.Checked == true)
            {
                continueCheck = true;

                timer1.Start();

            }
            else if (radioButton1.Checked == false)
            {
                continueCheck = false;

                timer1.Start();
            }
        }
        int tick = 0;
        int count = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tick / (int)(1000 / fr) != count)
            {
                this.Invalidate();
                count = tick / (int)(1000 / fr);
            }

            x = v * Math.Cos(a * Math.PI / 180) * (tick / 1000.0);
            y = (this.Height / 2 - 5) - (v * Math.Sin(a * Math.PI / 180) * (tick / 1000.0) - (g * Math.Pow((tick / 1000.0), 2) / 2));
            this.Invalidate();

            if (x > this.ClientSize.Width || y >= (this.Height / 2 - 5))
            {
                x = 0;
                y = this.Height / 2 - 5;
                tick = 0;

                if (continueCheck == false) { timer1.Stop(); }
            }
            tick += 16;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = CreateGraphics();
            Pen p = new Pen(Color.Black, 3);
            Pen p2 = new Pen(Color.Black, 1);
            g.Clear(Color.FromArgb(240, 240, 240));


            g.DrawLine(p2, 0, this.Height / 2, this.Width, this.Height / 2);
            g.DrawRectangle(p, (float)x, (float)y, 10, 10);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            x = 0;
            y = this.Height / 2 - 5;
            this.Invalidate();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fr = int.Parse(comboBox1.Text);
            timer1.Interval = 1000 / fr;
        }
    }
}
