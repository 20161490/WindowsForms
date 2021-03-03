using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 과제_6주차
{
    
    public partial class Form1 : Form
    {
        int size;
        bool stop = true;
        Point pt;
        Pen pen;
        Brush brush;
        public Form1()
        {

            InitializeComponent();
            pen = new Pen(Color.Red);
            brush = new SolidBrush(Color.Red);
            size = 20;
            pt = new Point(5 * size, size + 5);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillEllipse(brush, pt.X - size, pt.Y - size, 2 * size, 2 * size);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            stop = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (stop) return;
            pt.Y += size / 4;
            if(pt.Y + size >= this.ClientSize.Height)
            {
                this.timer1.Stop();
            }
            this.Invalidate();
        }
    }
}
