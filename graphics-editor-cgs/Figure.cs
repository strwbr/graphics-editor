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
        //public List<HorizontalLine> LinesList { get; set; }
        public Point Pmin;
        public Point Pmax;
        public Color Color { get; set; }

        public Figure()
        {
            VertexList = new List<Point>();
            //LinesList = new List<HorizontalLine>();
            Pmin = new Point();
            Pmax = new Point();
            Color = new Color();
        }

        public Figure(List<Point> vertexList, Color color/*, List<HorizontalLine> linesList*/) : this()
        {
            VertexList = vertexList.ConvertAll(item => new Point(item.X, item.Y));
            //VertexList = vertexList;
            //LinesList = linesList;
            Pmin = new Point();
            Pmax = new Point();
            Color = color; //мб вылезет неглубокое копирование
        }

        // конструктор копии
        public Figure(Figure other) : this()
        {
            VertexList = other.VertexList.ConvertAll(item => new Point(item.X, item.Y));
            //LinesList = other.LinesList.ConvertAll(item => new HorizontalLine(item));
            Pmin = new Point(other.Pmin.X, other.Pmin.Y);
            Pmax = new Point(other.Pmax.X, other.Pmax.Y);
            Color = other.Color;
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
        public void Move(int dx)
        {
            Point p = new Point();
            for(int i = 0; i < VertexList.Count; i++)
            {
                p.X = VertexList[i].X + dx;
                p.Y = VertexList[i].Y;
                VertexList[i] = p;
            }
            GetBorders();
        }
        // Масштабирование
        public void Zoom()
        {

        }
        // Поворот
        public void Rotate()
        {

        }

        

        // Центр фигуры
        public Point Center()
        {
            Point center = new Point();
            center.X =  (Pmax.X + Pmin.X) / 2;
            center.Y = (Pmax.Y + Pmin.Y) / 2;
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
