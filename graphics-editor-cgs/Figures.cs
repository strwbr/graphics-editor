using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor_cgs
{
    public class Figures
    {
        public static Polygon Arrow1(PointF Pcenter, Color color)
        {
            Polygon arrow = new Polygon();
            arrow.Color = color;
            const int w = 90;
            const int h = 60;

            float xc = Pcenter.X;
            float yc = Pcenter.Y;

            PointF p1 = new PointF(xc - w / 2, yc - h / 4); arrow.VertexList.Add(p1);
            PointF p2 = new PointF(xc + w / 6, yc - h / 4); arrow.VertexList.Add(p2);
            PointF p3 = new PointF(xc + w / 6, yc - h / 2); arrow.VertexList.Add(p3);
            PointF p4 = new PointF(xc + w / 2, yc);         arrow.VertexList.Add(p4);
            PointF p5 = new PointF(xc + w / 6, yc + h / 2); arrow.VertexList.Add(p5);
            PointF p6 = new PointF(xc + w / 6, yc + h / 4); arrow.VertexList.Add(p6);
            PointF p7 = new PointF(xc - w / 2, yc + h / 4); arrow.VertexList.Add(p7);

            arrow.Fill();
            return arrow;
        }

        public static Polygon Arrow2(PointF Pcenter, Color color)
        {
            Polygon arrow = new Polygon();
            arrow.Color = color;

            const int w = 90;
            const int h = 60;

            float xc = Pcenter.X;
            float yc = Pcenter.Y;

            PointF p1 = new PointF(xc - w / 2, yc);         arrow.VertexList.Add(p1);
            PointF p2 = new PointF(xc - w / 6, yc - h / 2); arrow.VertexList.Add(p2);
            PointF p3 = new PointF(xc - w / 6, yc - h / 4); arrow.VertexList.Add(p3);
            PointF p4 = new PointF(xc + w / 6, yc - h / 4); arrow.VertexList.Add(p4);
            PointF p5 = new PointF(xc + w / 6, yc - h / 2); arrow.VertexList.Add(p5);
            PointF p6 = new PointF(xc + w / 2, yc);         arrow.VertexList.Add(p6);
            PointF p7 = new PointF(xc + w / 6, yc + h / 2); arrow.VertexList.Add(p7);
            PointF p8 = new PointF(xc + w / 6, yc + h / 4); arrow.VertexList.Add(p8);
            PointF p9 = new PointF(xc - w / 6, yc + h / 4); arrow.VertexList.Add(p9);
            PointF p10 = new PointF(xc - w / 6, yc + h / 2); arrow.VertexList.Add(p10);

            arrow.Fill();
            return arrow;
        }

        public static BezierCurve Bezier(List<PointF> userPoints, int n, Color color)
        {
            BezierCurve curve = new BezierCurve();
            curve.Color = color;

            double nFact = Factorial(n);

            const double dt = 0.0001;
            // Постоянный шаг табуляции
            double t = dt;
            PointF Ppred = new PointF();
            Ppred.X = userPoints[0].X;
            Ppred.Y = userPoints[0].Y;
            PointF Pt = new PointF();

            while (t < 1 + dt / 2)
            {
                double xt = 0;
                double yt = 0;
                int i = 0;

                while (i <= n)
                {
                    // Интерполяционый полином Бернштейна
                    double J = Math.Pow(t, i) * Math.Pow((1 - t), n - i) * nFact / (Factorial(i) * Factorial(n - i));
                    xt += userPoints[i].X * J;
                    yt += userPoints[i].Y * J;
                    i++;
                }
                Pt.X = (float)Math.Round(xt);
                Pt.Y = (float)Math.Round(yt);
                curve.VertexList.Add(Pt);

                t += dt;
                Ppred.X = (float)Math.Round(xt);
                Ppred.Y = (float)Math.Round(yt);
            }
            return curve;
        }
        private static double Factorial(int n)
        {
            double x = 1;
            for (int i = 1; i <= n; i++)
                x *= i;
            return x;
        }
    }
}
