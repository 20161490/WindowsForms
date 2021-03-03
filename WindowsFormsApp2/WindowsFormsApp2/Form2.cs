using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        private List<Point> points = new List<Point>();
        
        public Form2()
        {
            InitializeComponent();
        }

        protected List<Point> Points { get => points; set => points = value; }


        private void Form2_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            points.Add(p);
            Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = points.Count;
            for(int i= count-1; i>=0; i--)
            {
                points.RemoveAt(i);
            }
            Invalidate();
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black);
            int count = points.Count;
            if (count <= 1) return;
            for (int i = 0; i < count; i++)
            {
                e.Graphics.DrawPolygon(pen, points.ToArray());
            }
        }
        public List<Point> GetPoints() => points;

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
