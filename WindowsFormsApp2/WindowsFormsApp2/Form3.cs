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

    public partial class Form3 : Form
    {
        private List<Point> points;

        public Form3()
        {
            InitializeComponent();
        }

        public List<Point> Points { get => points; set => points = value; }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            int count = points.Count;
            if (count <= 1) return;
            Pen pen = new Pen(Color.Black);
            e.Graphics.DrawPolygon(pen, points.ToArray());
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
