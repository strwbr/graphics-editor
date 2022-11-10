using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor_cgs
{
    // Фигура (многоугольник)
    public class Figure
    {
        public List<Point> VertexList { get; set; }


        public Figure(List<Point> vertexList)
        {
            VertexList = vertexList;
        }

        public Figure()
        {
            VertexList = new List<Point>();
        }

        public static List<Point> Arrow1(Point p0)
        {
            List<Point> arrowPoints = new List<Point>();
            arrowPoints.Add(p0);

            int x0 = p0.X;
            int y0 = p0.Y;
            const int w = 60;
            const int h = 20;

            Point p1 = new Point(x0 + 2 * w / 3, y0); arrowPoints.Add(p1);
            Point p2 = new Point(x0 + 2 * w / 3, y0 - h / 2); arrowPoints.Add(p2);
            Point p3 = new Point(x0 + w, y0 + h / 2); arrowPoints.Add(p3);
            Point p4 = new Point(x0 + 2 * w / 3, y0 + 3 * h / 2); arrowPoints.Add(p4);
            Point p5 = new Point(x0 + 2 * w / 3, y0 + h); arrowPoints.Add(p5);
            Point p6 = new Point(x0, y0 + h); arrowPoints.Add(p6);

            return arrowPoints;
        }

        public static List<Point> Arrow2(Point p0)
        {
            List<Point> arrowPoints = new List<Point>();
            arrowPoints = Arrow1(p0);

            int x0 = p0.X;
            int y0 = p0.Y;
            const int w = 60;
            const int h = 20;

            Point p7 = new Point(x0, y0 + 3 * h / 2); arrowPoints.Add(p7);
            Point p8 = new Point(x0 - w / 3, y0 + h / 2); arrowPoints.Add(p8);
            Point p9 = new Point(x0, y0 - h / 2); arrowPoints.Add(p9);

            return arrowPoints;
        }

        // param n скорее всего можно убрать
        public static List<Point> Bezier(List<Point> points, int n)
        {
            List<Point> bezierPoints = new List<Point> ();

            double nFactorial = Factorial(n);
            const double dt = 0.001;
            double t = dt;

            Point Ppred = new Point(points[0].X, points[0].Y);
            Point Pt = new Point();

            while (t < 1 + dt / 2)
            {
                double xt = 0;
                double yt = 0;
                int i = 0;
                while (i <= n)
                {
                    double J = Math.Pow(t, i) * Math.Pow((1 - t), n - i) * nFactorial / (Factorial(i) * Factorial(n - i));
                    xt += points[i].X * J;
                    yt += points[i].Y * J;
                    i++;
                }
                Pt.X = (int)Math.Round(xt);
                Pt.Y = (int)Math.Round(yt);

                // ----
                bezierPoints.Add(Pt);

                t += dt;
                // ???
                Ppred.X = (int)Math.Round(xt); // = Pt.X
                Ppred.Y = (int)Math.Round(yt); // = Pt.Y

            }
            return bezierPoints;
        }

        public static Graphics DrawBezier(Graphics g, Pen color, List<Point> bezierPoints)
        {
            Graphics temp = g;
            for(int i = 0; i < bezierPoints.Count-1; i+=2)
            {
                temp.DrawLine(color, bezierPoints[i], bezierPoints[i + 1]);
            }
            return temp;
        }

        private static double Factorial(int n)
        {
            double x = 1;
            for (int i = 1; i <= n; i++)
                x *= i;
            return x;
        }


        // Перемещение
        public void Move()
        {

        }
        // Масштабирование
        public void Zoom()
        {

        }
        // Поворот
        public void Rotate()
        {

        }

        // Закрашивание фигуры и ее вывод? - разбить на 2 метода
        public void Fill()
        {

        }
        // Выделение фигуры
        public bool Select()
        {
            return true;
        }

        // Центр фигуры
        public Point Center()
        {
            Point center = new Point();
            return center;
        }
    }
}
