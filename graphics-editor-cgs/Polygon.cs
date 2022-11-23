using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace graphics_editor_cgs
{
    public class Polygon : IFigure
    {
        // из интерфейса
        public List<PointF> VertexList { get; set; }
        public Color Color { get; set; }

        public List<HorizontalLine> LinesList { get; set; }

        public Polygon()
        {
            VertexList = new List<PointF>();
            Color = Color.Black; // по умолчанию черный

            LinesList = new List<HorizontalLine>();
        }

        public Polygon(List<PointF> vertexList, List<HorizontalLine> linesList, Color color) : this()
        {
            vertexList = vertexList.ConvertAll(item => new PointF(item.X, item.Y));
            Color = color;
            linesList = linesList.ConvertAll(item => new HorizontalLine(item));
        }

        public Polygon(Polygon other)
        {
            VertexList = other.VertexList.ConvertAll(item => new PointF(item.X, item.Y));
            Color = other.Color;
            LinesList = other.LinesList.ConvertAll(item => new HorizontalLine(item));
        }

        // Выделение фигуры
        public bool Select(PointF p)
        {
            bool isSelect = false;
            float mX = p.X;
            float mY = p.Y;

            int n = VertexList.Count - 1;
            int k = 0, m = 0;
            PointF Pi, Pk;

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

        // Закрашивание фигуры
        public void Fill()
        {
            LinesList.Clear();
            float Ymin = Min().Y;
            float Ymax = Max().Y;

            List<int> Xb = new List<int>();
            for (float j = Ymin; j <= Ymax; j++)
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

        public PointF Min()
        {
            PointF p = new PointF();
            p.X = VertexList.Min(item => item.X);
            p.Y = VertexList.Min(item => item.Y);
            return p;
        }

        public PointF Max()
        {
            PointF p = new PointF();
            p.X = VertexList.Max(item => item.X);
            p.Y = VertexList.Max(item => item.Y);
            return p;
        }

        public void Move(float dx, float dy)
        {
            PointF p = new PointF();
            for (int i = 0; i < VertexList.Count; i++)
            {
                p.X = VertexList[i].X + dx;
                p.Y = VertexList[i].Y + dy;
                VertexList[i] = new PointF(p.X, p.Y);
            }
        }

        public void Zoom()
        {
            throw new NotImplementedException();
        }

        public void Rotate()
        {
            throw new NotImplementedException();
        }

        public PointF Center()
        {
            PointF center = new PointF();
            PointF Pmin = Min();
            PointF Pmax = Max();
            center.X = (Pmax.X + Pmin.X) / 2;
            center.Y = (Pmax.Y + Pmin.Y) / 2;
            return center;
        }
    }
}
