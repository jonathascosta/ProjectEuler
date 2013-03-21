using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace DrawingTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static long Solve(PaintEventArgs e)
        {
            PointF p0 = new PointF(0f, 10.1f);
            PointF p1 = new PointF(1.4f, -9.6f);
            int count = 0;

            e.Graphics.DrawEllipse(new Pen(Color.Black, 1f), 100f, 0f, 200f, 400f);

            while (!(-0.01f <= p1.X && p1.X <= 0.01f && p1.Y > 9.7f))
            {
                e.Graphics.DrawLine(new Pen(Color.Red, 2f), (p0.X * 20 + 200), 400 - (p0.Y * 20 + 200), p1.X * 20 + 200, 400 - (p1.Y * 20 + 200));

                float angInc = (p1.Y - p0.Y) / (p1.X - p0.X);
                float dydx = m(p1);

                if (angInc < dydx)
                    angInc += (float)Math.PI;

                float angRef = (float)(dydx + Math.PI - (Math.Atan(angInc) - Math.Atan(dydx)));

                float a = (float)Math.Tan(angRef);
                float b = -a * p1.X + p1.Y;

                float A = 4 + a * a;
                float B = 2 * a * b;
                float C = b * b - 100;
                float delta = (float)Math.Sqrt(B * B - 4 * A * C);
                float x0 = (-B + delta) / (2 * A);
                float x1 = (-B - delta) / (2 * A);

                p0 = p1;
                if (Math.Abs(p1.X - x0) > Math.Abs(p1.X - x1))
                    p1 = new PointF(x0, a * x0 + b);
                else
                    p1 = new PointF(x1, a * x1 + b);

                Thread.Sleep(1500);

                count++;
            }


            return count;
        }

        private static float m(PointF p)
        {
            return -4 * p.X / p.Y;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Solve(e);
        }
    }
}
