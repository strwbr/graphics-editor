using System;
using System.Collections.Generic;
using System.Drawing;

namespace graphics_editor_cgs
{
    public class LineSegment : Figure
    {
        public List<PointF> VertexList { get; set; }
        public Color Color { get; set; }

        public LineSegment()
        {
            VertexList = new List<PointF>();
            Color = Color.Black;
        }

        public LineSegment(List<PointF> vertexList, Color color) : this()
        {
            VertexList = vertexList.ConvertAll(item => new PointF(item.X, item.Y));
            Color = color;
        }

        public LineSegment(Figure other)
        {
            VertexList = other.VertexList.ConvertAll(item => new PointF(item.X, item.Y));
            Color = other.Color;
        }

        public bool Select(PointF p)
        {
            PointF p1 = VertexList[0];
            PointF p2 = VertexList[1];

            float distance1 = (float)Math.Sqrt(Math.Pow(p1.X - p.X, 2) + Math.Pow(p1.Y - p.Y, 2));
            float distance2 = (float)Math.Sqrt(Math.Pow(p2.X - p.X, 2) + Math.Pow(p2.Y - p.Y, 2));
            float distance3 = (float)Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));

            return distance1 + distance2 - distance3 < 1f;
        }

        public void Move(float dx, float dy)
        {
            for (int i = 0; i < VertexList.Count; i++)
            {
                PointF newPoint = new PointF();
                newPoint.X = VertexList[i].X + dx;
                newPoint.Y = VertexList[i].Y + dy;
                VertexList[i] = newPoint; //new PointF(newPoint.X, newPoint.Y);
            }
        }

        public void Resize(PointF mP/*, PointF center*/)
        {
            PointF center = Center;
            float bx = (mP.X >= Min.X && mP.X <= Max.X) ? -0.03f : 0.03f;
            bx += 1;
            for (int i = 0; i < VertexList.Count; i++)
            {
                PointF newPoint = new PointF();
                newPoint.X = (VertexList[i].X - center.X) * bx + center.X;
                newPoint.Y = VertexList[i].Y;
                VertexList[i] = newPoint;
            }
        }

        public void Rotate(float angle, PointF center)
        {
            double cos = Math.Cos(angle * Math.PI / 180);
            double sin = Math.Sin(angle * Math.PI / 180);
            for (int i = 0; i < VertexList.Count; i++)
            {
                PointF p = new PointF();
                p.X = (float)((VertexList[i].X - center.X) * cos - (VertexList[i].Y - center.Y) * sin + center.X);
                p.Y = (float)((VertexList[i].X - center.X) * sin + (VertexList[i].Y - center.Y) * cos + center.Y);
                VertexList[i] = p;
            }
        }

        public PointF Center
        {
            get
            {
                PointF p1 = VertexList[0];
                PointF p2 = VertexList[1];
                return new PointF((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
            }
        }

        public PointF Min
        {
            get
            {
                PointF p = new PointF();
                p.X = (VertexList[0].X < VertexList[1].X) ? VertexList[0].X : VertexList[1].X;
                p.Y = (VertexList[0].Y < VertexList[1].Y) ? VertexList[0].Y : VertexList[1].Y;
                return p;
            }
        }

        public PointF Max
        {
            get
            {
                PointF p = new PointF();
                p.X = VertexList[0].X > VertexList[1].X ? VertexList[0].X : VertexList[1].X;
                p.Y = VertexList[0].Y > VertexList[1].Y ? VertexList[0].Y : VertexList[1].Y;
                return p;
            }
        }

        public bool CheckResize(float x, float y)
        {
            float Xmin = Min.X;
            float Xmax = Max.X;
            float Yc = Center.Y;
            return
                ((x >= Xmin - 10 && x <= Xmin + 4) || (x >= Xmax - 4 && x <= Xmax + 10))
                && (y >= Yc - 7 && y <= Yc + 7);
        }


    }
}
