using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace graphics_editor_cgs
{
    public class Polygon : Figure
    {
        public List<HorizontalLine> LinesList { get; set; }
        //public Point Pmin { get; set; }
        //public Point Pmax { get; set; }

        public Polygon() : base()
        {
            LinesList = new List<HorizontalLine>();
            //Pmin = new Point();
            //Pmax = new Point();
        }

        public Polygon(List<Point> VertexList, List<HorizontalLine> LinesList/*, Point Pmin, Point Pmax*/) : base(VertexList)
        {
            this.LinesList = LinesList;
            //this.Pmin = Pmin;
            //this.Pmax = Pmax;
        }

        public Polygon(Polygon other) : base(other)
        {
            LinesList = other.LinesList.ConvertAll(item => new HorizontalLine(item));
            //Pmin = new Point(other.Pmin.X, other.Pmin.Y);
            //Pmax = new Point(other.Pmax.X, other.Pmax.Y);

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
                    LinesList.Add(new HorizontalLine(Xb[i], Xb[i + 1], j));
                }
            }
        }
    }
}
