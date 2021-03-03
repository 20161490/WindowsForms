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
    public partial class Form1 : Form
    {
        Form2 form2;
        Form3 form3;
        List<Point> points;
        List<Point> points1 = new List<Point>();
        double dx, dy;
        double Sx, Sy;
        double Cx, Cy;
        double theta;
        double[,] transform = new double[3, 3];
        int[,] shift = new int[3, 3];
        int[,] inv_shift = new int[3, 3];
        double xcm, ycm;
        public Form1()
        {
            InitializeComponent();
            form2 = new Form2();
            form2.Show();
            form3 = new Form3();
            //form2.Parent = this;
            //form3.Parent = this;
        }

        public void GetPointsTransform()
        {
            points = form2.GetPoints();
            AffineTransform();            
            form3.Points = points1;
            form3.Show();
            form3.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.GetPointsTransform();
        }
        private void GetCenterOfMass()
        {
            int count = points.Count;
            xcm = 0.0;
            ycm = 0.0;
            for (int i = 0; i < count; i++)
            {
                xcm += points[i].X;
                ycm += points[i].Y;
            }
            xcm /= count;
            ycm /= count;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    shift[i, j] = 0;
                    inv_shift[i, j] = 0;
                }
            shift[0, 2] = (int)xcm;
            shift[1, 2] = (int)ycm;
            inv_shift[0, 2] = -shift[0, 2];
            inv_shift[1, 2] = -shift[1, 2];
        }
        private Point TransformPoint(Point p1)
        {
            Point p2 = new Point();
            /* shift to center of mass */
            p2.X = p1.X + inv_shift[0, 2];
            p2.Y = p1.Y + inv_shift[1, 2];
            //MessageBox.Show("1 " + p1.X.ToString() + "," + p1.Y.ToString() + "->" + p2.X.ToString() + "," + p2.Y.ToString());
            /* apply affine transform */
            int tmp = p2.X;
            p2.X = (int)(transform[0, 0] * tmp + transform[0, 1] * p2.Y + transform[0, 2]);
            p2.Y = (int)(transform[1, 0] * tmp + transform[1, 1] * p2.Y + transform[1, 2]);
            MessageBox.Show("2 " + p1.X.ToString() + "," + p1.Y.ToString() + "->" + p2.X.ToString() + "," + p2.Y.ToString());
            /* shift back to original position */
            p2.X = p2.X + shift[0, 2];
            p2.Y = p2.Y + shift[1, 2];
            //MessageBox.Show("3 "+p1.X.ToString()+","+p1.Y.ToString()+"->"+p2.X.ToString() + "," + p2.Y.ToString());

            return p2;
        }
        private void AffineTransform()
        {
            int count = points.Count;
            GetCenterOfMass();
            points1.Clear();
            for (int i = 0; i < count; i++)
            {
                points1.Add(TransformPoint(points[i]));
                MessageBox.Show("affine "+points[i].X.ToString() + "," + points[i].Y.ToString() + "->" + points1[i].X.ToString() + "," + points1[i].Y.ToString());
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dx = double.Parse(textBox1.Text.ToString());
                setMatrixTranslate();
            }
            catch (Exception e1)
            {
                e1.ToString();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dy = double.Parse(textBox5.Text.ToString());
                setMatrixTranslate();
            }
            catch (Exception e1)
            {
                e1.ToString();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Sx = double.Parse(textBox2.Text.ToString());
                setMatrixScale();
            }
            catch (Exception e1)
            {
                e1.ToString();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Sy = double.Parse(textBox6.Text.ToString());
                setMatrixScale();
            }
            catch (Exception e1)
            {
                e1.ToString();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Cx = double.Parse(textBox3.Text.ToString());
                setMatrixShear();
            }
            catch (Exception e1)
            {
                e1.ToString();
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Cy = double.Parse(textBox7.Text.ToString());
                setMatrixShear();
            }
            catch (Exception e1)
            {
                e1.ToString();
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                theta = Math.PI * (double.Parse(textBox4.Text.ToString()) / 180.0);          
                setMatrixRotate();
            }
            catch (Exception e1)
            {
                e1.ToString();
            }
        }
        private void setMatrixScale()
        {
            transform[0, 0] = Sx;
            transform[0, 1] = 0;
            transform[0, 2] = 0;
            transform[1, 0] = 0;
            transform[1, 1] = Sy;
            transform[1, 2] = 0;
            transform[2, 0] = 0;
            transform[2, 1] = 0;
            transform[2, 2] = 1;
            textBox8.Text = (textBox6.Text.Equals("") ? "1" : transform[0, 0].ToString());
            textBox11.Text = (textBox6.Text.Equals("") ? "0" : transform[0, 1].ToString());
            textBox14.Text = (textBox6.Text.Equals("") ? "0" : transform[0, 2].ToString());
            textBox9.Text = (textBox2.Text.Equals("") ? "0" : transform[1, 0].ToString());
            textBox12.Text = (textBox2.Text.Equals("") ? "1" : transform[1, 1].ToString());
            textBox15.Text = (textBox2.Text.Equals("") ? "0" : transform[1, 2].ToString());
            textBox10.Text = (textBox6.Text.Equals("") ? "0" : transform[2, 0].ToString());
            textBox13.Text = (textBox6.Text.Equals("") ? "0" : transform[2, 1].ToString());
            textBox16.Text = (textBox6.Text.Equals("") ? "1" : transform[2, 2].ToString());
        }
        private void setMatrixTranslate()
        {
            transform[0, 0] = 1;
            transform[0, 1] = 0;
            transform[0, 2] = dx;
            transform[1, 0] = 0;
            transform[1, 1] = 1;
            transform[1, 2] = dy;
            transform[2, 0] = 0;
            transform[2, 1] = 0;
            transform[2, 2] = 1;
            textBox8.Text = (textBox1.Text.Equals("") ? "1" : transform[0, 0].ToString());
            textBox11.Text = (textBox1.Text.Equals("") ? "0" : transform[0, 1].ToString());
            textBox14.Text = (textBox1.Text.Equals("") ? "0" : transform[0, 2].ToString());
            textBox9.Text = (textBox2.Text.Equals("") ? "0" : transform[1, 0].ToString());
            textBox12.Text = (textBox2.Text.Equals("") ? "1" : transform[1, 1].ToString());
            textBox15.Text = (textBox2.Text.Equals("") ? "0" : transform[1, 2].ToString());
            textBox10.Text = (textBox1.Text.Equals("") ? "0" : transform[2, 0].ToString());
            textBox13.Text = (textBox1.Text.Equals("") ? "0" : transform[2, 1].ToString());
            textBox16.Text = (textBox1.Text.Equals("") ? "1" : transform[2, 2].ToString());
        }
        private void setMatrixShear()
        {
            transform[0, 0] = 1;
            transform[0, 1] = Cx;
            transform[0, 2] = 0;
            transform[1, 0] = Cy;
            transform[1, 1] = 1;
            transform[1, 2] = 0;
            transform[2, 0] = 0;
            transform[2, 1] = 0;
            transform[2, 2] = 1;
            textBox8.Text = (textBox6.Text.Equals("") ? "1" : transform[0, 0].ToString());
            textBox11.Text = (textBox6.Text.Equals("") ? "0" : transform[0, 1].ToString());
            textBox14.Text = (textBox5.Text.Equals("") ? "0" : transform[0, 2].ToString());
            textBox9.Text = (textBox5.Text.Equals("") ? "0" : transform[1, 0].ToString());
            textBox12.Text = (textBox6.Text.Equals("") ? "1" : transform[1, 1].ToString());
            textBox15.Text = (textBox6.Text.Equals("") ? "0" : transform[1, 2].ToString());
            textBox10.Text = (textBox6.Text.Equals("") ? "0" : transform[2, 0].ToString());
            textBox13.Text = (textBox6.Text.Equals("") ? "0" : transform[2, 1].ToString());
            textBox16.Text = (textBox6.Text.Equals("") ? "1" : transform[2, 2].ToString());
        }
        private void setMatrixRotate()
        {
            transform[0, 0] = Math.Cos(theta);
            transform[0, 1] = Math.Sin(theta);
            transform[0, 2] = 0;
            transform[1, 0] = -Math.Sin(theta);
            transform[1, 1] = Math.Cos(theta);
            transform[1, 2] = 0;
            transform[2, 0] = 0;
            transform[2, 1] = 0;
            transform[2, 2] = 1;
            textBox8.Text = (textBox4.Text.Equals("") ? "1" : transform[0, 0].ToString());
            textBox11.Text = (textBox4.Text.Equals("") ? "0" : transform[0, 1].ToString());
            textBox14.Text = (textBox4.Text.Equals("") ? "0" : transform[0, 2].ToString());
            textBox9.Text = (textBox4.Text.Equals("") ? "0" : transform[1, 0].ToString());
            textBox12.Text = (textBox4.Text.Equals("") ? "1" : transform[1, 1].ToString());
            textBox15.Text = (textBox4.Text.Equals("") ? "0" : transform[1, 2].ToString());
            textBox10.Text = (textBox4.Text.Equals("") ? "0" : transform[2, 0].ToString());
            textBox13.Text = (textBox4.Text.Equals("") ? "0" : transform[2, 1].ToString());
            textBox16.Text = (textBox4.Text.Equals("") ? "1" : transform[2, 2].ToString());
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
