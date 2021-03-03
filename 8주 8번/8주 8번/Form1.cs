using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8주_8번
{
    public partial class Form1 : Form
    {
        float X, Y;
        int H;
        Boolean click;
        public Form1()
        {
            InitializeComponent();
            click = true;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if(click == true)
            {
                click = false;
            }
            else
            {
                click = true;
            }
        }

        protected void Draw_line(Graphics g)
        {
            Pen pen = new Pen(Color.Red);
            H = this.ClientSize.Height;
            g.DrawLine(pen, 0, Height, X, Y);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Draw_line(g);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(click == true)
            {
                X = e.X;
                Y = e.Y;
                label3.Text = X.ToString();
                label4.Text = (H-Y).ToString();
                this.Invalidate();
            }
            else { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
