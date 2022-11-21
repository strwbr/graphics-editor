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
        //public static Polygon Arrow1(Point p0)
        //{
        //    Polygon arrow = new Polygon();
        //    int x0 = p0.X;
        //    int y0 = p0.Y;
        //    const int w = 90;
        //    const int h = 30;
        //    arrow.VertexList.Add(p0);

        //    Point p1 = new Point(x0 + w, y0); arrow.VertexList.Add(p1);
        //    Point p2 = new Point(x0 + w, y0 - h / 2); arrow.VertexList.Add(p2);
        //    Point p3 = new Point(x0 + 4 * w / 3, y0 + h / 2); arrow.VertexList.Add(p3);
        //    Point p4 = new Point(x0 + w, y0 + 3 * h / 2); arrow.VertexList.Add(p4);
        //    Point p5 = new Point(x0 + w, y0 + h); arrow.VertexList.Add(p5);
        //    Point p6 = new Point(x0, y0 + h); arrow.VertexList.Add(p6);

        //    arrow.Fill();
        //    arrow.GetBorders();
        //    return arrow;
        //}



        //public static Polygon Arrow2(Point p0)
        //{
        //    Polygon arrow = new Polygon();
        //    int x0 = p0.X;
        //    int y0 = p0.Y;
        //    const int w = 90;
        //    const int h = 30;
        //    arrow.VertexList.Add(p0);


        //    Point p1 = new Point(x0 + w, y0); arrow.VertexList.Add(p1);
        //    Point p2 = new Point(x0 + w, y0 - h / 2); arrow.VertexList.Add(p2);
        //    Point p3 = new Point(x0 + 4 * w / 3, y0 + h / 2); arrow.VertexList.Add(p3);
        //    Point p4 = new Point(x0 + w, y0 + 3 * h / 2); arrow.VertexList.Add(p4);
        //    Point p5 = new Point(x0 + w, y0 + h); arrow.VertexList.Add(p5);
        //    Point p6 = new Point(x0, y0 + h); arrow.VertexList.Add(p6);
        //    Point p7 = new Point(x0, y0 + 3 * h / 2); arrow.VertexList.Add(p7);
        //    Point p8 = new Point(x0 - w / 3, y0 + h / 2); arrow.VertexList.Add(p8);
        //    Point p9 = new Point(x0, y0 - h / 2); arrow.VertexList.Add(p9);

        //    arrow.Fill();
        //    arrow.GetBorders();
        //    return arrow;
        //} 

        public static Polygon Arrow1(Point Pcenter)
        {
            Polygon arrow = new Polygon();
            const int w = 90;
            const int h = 60;

            int xc = Pcenter.X;
            int yc = Pcenter.Y;

            Point p1 = new Point(xc - w / 2, yc - h / 4); arrow.VertexList.Add(p1);
            Point p2 = new Point(xc + w / 6, yc - h / 4); arrow.VertexList.Add(p2);
            Point p3 = new Point(xc + w / 6, yc - h / 2); arrow.VertexList.Add(p3);
            Point p4 = new Point(xc + w / 2, yc);         arrow.VertexList.Add(p4);
            Point p5 = new Point(xc + w / 6, yc + h / 2); arrow.VertexList.Add(p5);
            Point p6 = new Point(xc + w / 6, yc + h / 4); arrow.VertexList.Add(p6);
            Point p7 = new Point(xc - w / 2, yc + h / 4); arrow.VertexList.Add(p7);

            arrow.Fill();
            arrow.GetBorders();
            return arrow;
        }

        public static Polygon Arrow2(Point Pcenter)
        {
            Polygon arrow = new Polygon();
            const int w = 120;
            const int h = 60;

            int xc = Pcenter.X;
            int yc = Pcenter.Y;

            Point p1 = new Point(xc - w / 2, yc);         arrow.VertexList.Add(p1);
            Point p2 = new Point(xc - w / 6, yc - h / 2); arrow.VertexList.Add(p2);
            Point p3 = new Point(xc - w / 6, yc - h / 4); arrow.VertexList.Add(p3);
            Point p4 = new Point(xc + w / 6, yc - h / 4); arrow.VertexList.Add(p4);
            Point p5 = new Point(xc + w / 6, yc - h / 2); arrow.VertexList.Add(p5);
            Point p6 = new Point(xc + w / 2, yc);         arrow.VertexList.Add(p6);
            Point p7 = new Point(xc + w / 6, yc + h / 2); arrow.VertexList.Add(p7);
            Point p8 = new Point(xc + w / 6, yc + h / 4); arrow.VertexList.Add(p8);
            Point p9 = new Point(xc - w / 6, yc + h / 4); arrow.VertexList.Add(p9);
            Point p10 = new Point(xc - w / 6, yc + h / 2); arrow.VertexList.Add(p10);

            arrow.Fill();
            arrow.GetBorders();
            return arrow;
        }

        public static BezierCurve Bezier(List<Point> userPoints, int n)
        {
            BezierCurve curve = new BezierCurve();

            double nFact = Factorial(n);

            const double dt = 0.0001;
            // Постоянный шаг табуляции
            double t = dt;
            Point Ppred = new Point();
            Ppred.X = userPoints[0].X;
            Ppred.Y = userPoints[0].Y;
            Point Pt = new Point();

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
                Pt.X = (int)Math.Round(xt);
                Pt.Y = (int)Math.Round(yt);
                curve.VertexList.Add(Pt);

                t += dt;
                Ppred.X = (int)Math.Round(xt);
                Ppred.Y = (int)Math.Round(yt);
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
