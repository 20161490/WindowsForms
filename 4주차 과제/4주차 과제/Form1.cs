using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4주차_과제
{
    public partial class Form1 : Form
    {
        double a11, a12, a13;
        double a21, a22, a23;
        double a31, a32, a33;
        double b11, b12, b13;
        double b21, b22, b23;
        double b31, b32, b33;
        double c11, c12, c13;
        double c21, c22, c23;
        double c31, c32, c33;
        string op;
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedItem = 0;
        }

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

            b11 = double.Parse(textBox10.Text);
            b12 = double.Parse(textBox11.Text);
            b13 = double.Parse(textBox12.Text);
            b21 = double.Parse(textBox13.Text);
            b22 = double.Parse(textBox14.Text);
            b23 = double.Parse(textBox15.Text);
            b31 = double.Parse(textBox16.Text);
            b32 = double.Parse(textBox17.Text);
            b33 = double.Parse(textBox18.Text);

            op = comboBox1.SelectedItem.ToString();

            if (op.Equals("+"))
            {
                c11 = a11 + b11;
                c12 = a12 + b12;
                c13 = a13 + b13;
                c21 = a21 + b21;
                c22 = a22 + b22;
                c23 = a23 + b23;
                c31 = a31 + b31;
                c32 = a32 + b32;
                c33 = a33 + b33;
            }
            else if (op.Equals("-"))
            {
                c11 = a11 - b11;
                c12 = a12 - b12;
                c13 = a13 - b13;
                c21 = a21 - b21;
                c22 = a22 - b22;
                c23 = a23 - b23;
                c31 = a31 - b31;
                c32 = a32 - b32;
                c33 = a33 - b33;
            }
            else if (op.Equals("*"))
            {
                c11 = a11 * b11 + a12 * b21 + a13 * b31;
                c12 = a11 * b12 + a12 * b22 + a13 * b32;
                c13 = a11 * b13 + a12 * b23 + a13 * b33;
                c21 = a21 * b11 + a22 * b21 + a23 * b31;
                c22 = a21 * b12 + a22 * b22 + a23 * b32;
                c23 = a21 * b13 + a22 * b23 + a23 * b33;
                c31 = a31 * b11 + a32 * b21 + a33 * b31;
                c32 = a31 * b12 + a32 * b22 + a33 * b32;
                c33 = a31 * b13 + a32 * b23 + a33 * b33;
            }
            this.textBox19.Text = c11.ToString();
            this.textBox20.Text = c12.ToString();
            this.textBox21.Text = c13.ToString();
            this.textBox22.Text = c21.ToString();
            this.textBox23.Text = c22.ToString();
            this.textBox24.Text = c23.ToString();
            this.textBox25.Text = c31.ToString();
            this.textBox26.Text = c32.ToString();
            this.textBox27.Text = c33.ToString();

            this.Invalidate();

        }
     

       
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
