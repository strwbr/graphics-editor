using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor_cgs
{
    public struct Line
    {
        public int xl;
        public int xr;
        public int y;

        public Line(int xl, int xr, int y) : this()
        {
            this.xl = xl;
            this.xr = xr;
            this.y = y;
        }
        public Line(Line other)
        {
            this.xl = other.xl;
            this.xr = other.xr;
            this.y = other.y;
        }
    }

    // Фигура (многоугольник)
    public class Figure
    {
        public List<Point> VertexList { get; set; }
        public List<Line> LinesList { get; set; }
        public Point Pmin;
        public Point Pmax;

        public Figure()
        {
            VertexList = new List<Point>();
            LinesList = new List<Line>();
            Pmin = new Point();
            Pmax = new Point();
        }

        public Figure(List<Point> vertexList, List<Line> linesList) : this()
        {
            VertexList = vertexList;
            LinesList = linesList;
            Pmin = new Point();
            Pmax = new Point();
        }

        // конструктор копии
        public Figure(Figure other) : this()
        {
            VertexList = other.VertexList.ConvertAll(item => new Point(item.X, item.Y));
            LinesList = other.LinesList.ConvertAll(item => new Line(item));

            //for (int i = 0; i < other.VertexList.Count; i++)
            //{
            //    VertexList.Add(other.VertexList[i]);
            //}
            //for(int i = 0; i < other.LinesList.Count; i++)
            //{
            //    LinesList.Add(other.LinesList[i]);
            //}
        }

        public void GetBorders()
        {
            Pmin.X = VertexList.Min(item => item.X);
            Pmin.Y = VertexList.Min(item => item.Y);
            Pmax.X = VertexList.Max(item => item.X);
            Pmax.Y = VertexList.Max(item => item.Y);
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

        // Выделение фигуры
        public bool Select(Point p)
        {
            bool isSelect = false;
            int mX = p.X;
            int mY = p.Y;

            int n = VertexList.Count - 1;
            int k = 0, m = 0;
            Point Pi, Pk;

            for (int i = 0; i <= n; i++)
            {
                if (i < n) k = i + 1;
                else k = 0;
                Pi = VertexList[i];
                Pk = VertexList[k];
                if ((Pi.Y < mY) & (Pk.Y >= mY) | (Pi.Y >= mY) & (Pk.Y < mY))
                    if ((mY - Pi.Y) * (Pk.X - Pi.X) / (Pk.Y - Pi.Y) + Pi.X < mX)
                        m++;
            }
            if (m % 2 == 1) isSelect = true;
            return isSelect;
        }

        // Закрашивание фигуры и ее вывод? - разбить на 2 метода
        public void Fill()
        {
            int Ymin = VertexList.Min(item => item.Y);
            int Ymax = VertexList.Max(item => item.Y);

            List<int> Xb = new List<int>();
            for (int j = Ymin; j <= Ymax; j++)
            {
                Xb.Clear();
                for (int i = 0; i < VertexList.Count; i++)
                {
                    int k;
                    if (i < VertexList.Count - 1)
                        k = i + 1;
                    else k = 0;

                    if ((VertexList[i].Y < j && VertexList[k].Y >= j)
                        || (VertexList[i].Y >= j && VertexList[k].Y < j))
                    {
                        int x = (int)Math.Ceiling((double)(VertexList[k].X - VertexList[i].X)
                            * (j - VertexList[i].Y) / (double)(VertexList[k].Y
                            - VertexList[i].Y) + VertexList[i].X);
                        Xb.Add(x);
                    }
                }
                Xb.Sort();

                for (int i = 0; i < Xb.Count - 1; i += 2)
                {
                    LinesList.Add(new Line(Xb[i], Xb[i + 1], j));
                }
            }
        }

        // Центр фигуры
        public Point Center()
        {
            Point center = new Point();
            center.X = (Pmax.X - Pmin.X) / 2;
            center.Y = (Pmax.Y - Pmin.Y) / 2;
            return center;
        }


        public static List<Point> Bezier(List<Point> points, int n)
        {
            List<Point> bezierPoints = new List<Point>();

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
            for (int i = 0; i < bezierPoints.Count - 1; i += 2)
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
    }
}
