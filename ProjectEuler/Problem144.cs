using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ProjectEuler
{
    static class Problem144
    {
        public static long Solve()
        {
            PointF p0 = new PointF(0f, 10.1f);
            PointF p1 = new PointF(1.4f, -9.6f);
            long count = 0;

            while (!p1.IsOut())
            {
                double oriAngle = Math.Atan(GetOriginalAngle(p0, p1));
                double tanAngle = Math.Atan(m(p1));
                double refAngle = tanAngle + Math.PI - (oriAngle - tanAngle);
               
                // Reflection line equation: y = a.x + b
                var a = Math.Tan(refAngle);
                var b = p1.Y - a * p1.X;

                // 4x^2 + y^2 = 100
                // 4x^2 + (a.x + b)^2 = 100
                // (4 + a^2^)x^2 + (2ab)x + (b^2 - 100) = 0
                double A = 4 + a * a;
                double B = 2 * a * b;
                double C = b * b - 100;
                double delta = (float)Math.Sqrt(B * B - 4 * A * C);
                double x0 = (-B + delta) / (2 * A);
                double x1 = (-B - delta) / (2 * A);

                p0 = p1;
                if (Math.Abs(p1.X - x0) > Math.Abs(p1.X - x1))
                    p1 = new PointF((float)x0, (float)a * (float)x0 + (float)b);
                else
                    p1 = new PointF((float)x1, (float)a * (float)x1 + (float)b);

                count++;
            }

            return count;
        }

        private static float m(PointF p)
        {
            return -4 * p.X / p.Y;
        }

        private static bool IsOut(this PointF p)
        {
            return (-0.01f <= p.X && p.X <= 0.01f && p.Y > 9.7f);
        }

        private static float GetOriginalAngle(PointF p0, PointF p1)
        {
            return (p1.Y - p0.Y) / (p1.X - p0.X);
        }

        private static float GetReflectionAngle(float inc, float tan)
        {
            return 0;
        }
    }
}
