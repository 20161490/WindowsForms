using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6_주_11번
{
    public partial class Form1 : Form
    {
        private double x;
        private double vx;
        private int fr;

        private bool continueCheck;
        public Form1()
        {
            x = 0;
            vx = 0;
            fr = 0;

            continueCheck = false;

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            vx = double.Parse(textBox1.Text);


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

        private void timer1_Tick(object sender, EventArgs e)
        {
            x = x + vx * (1.0 / fr);
            this.Invalidate();

            if (x > this.ClientSize.Width)
            {
                x = 0;

                if (continueCheck == false) { timer1.Stop(); }
            }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Brush pen = new SolidBrush(Color.Blue);
            e.Graphics.FillRectangle(pen, (int)(x - 5), 200, 30, 30);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            x = 0;
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
