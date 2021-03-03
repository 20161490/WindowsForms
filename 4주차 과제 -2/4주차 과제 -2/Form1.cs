using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4주차_과제__2
{
    public partial class Form1 : Form
    {
        double a11, a12, a13;
        double a21, a22, a23;
        double a31, a32, a33;
        double b11, b12, b13;
        double b21, b22, b23;
        double b31, b32, b33;

        private void button1_Click(object sender, EventArgs e)
        {
            a11 = double.Parse(textBox1.Text);
            a12 = double.Parse(textBox2.Text);
            a13 = double.Parse(textBox3.Text);
            a21 = double.Parse(textBox4.Text);
            a22 = double.Parse(textBox5.Text);
            a23 = double.Parse(textBox6.Text);
            a31 = double.Parse(textBox7.Text);
            a32 = double.Parse(textBox8.Text);
            a33 = double.Parse(textBox9.Text);

            b11 = a11;
            b12 = a21;
            b13 = a31;
            b21 = a12;
            b22 = a22;
            b23 = a32;
            b31 = a13;
            b32 = a23;
            b33 = a33;
            this.textBox10.Text = b11.ToString();
            this.textBox11.Text = b12.ToString();
            this.textBox12.Text = b13.ToString();
            this.textBox13.Text = b21.ToString();
            this.textBox14.Text = b22.ToString();
            this.textBox15.Text = b23.ToString();
            this.textBox16.Text = b31.ToString();
            this.textBox17.Text = b32.ToString();
            this.textBox18.Text = b33.ToString();

            this.Invalidate();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
