using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace graphics_editor_cgs
{
    public class BezierCurve : Figure
    {
        public List<PointF> VertexList { get; set; }
        public Color Color { get; set; }

        public BezierCurve()
        {
            VertexList = new List<PointF>();
            Color = Color.Black;
        }

        public BezierCurve(List<PointF> vertexList, Color color)
        {
            VertexList = vertexList.ConvertAll(item => new PointF(item.X, item.Y));
            Color = color;
        }

        public BezierCurve(Figure other)
        {
            VertexList = other.VertexList.ConvertAll(item => new PointF(item.X, item.Y));
            Color = other.Color;
        }

        public PointF Center
        {
            get
            {
                PointF Pmin = Min;
                PointF Pmax = Max;
                return new PointF((Pmax.X + Pmin.X) / 2, (Pmax.Y + Pmin.Y) / 2);
            }
        }

        public PointF Min
        {
            get
            {
                PointF p = new PointF();
                p.X = VertexList.Min(item => item.X);
                p.Y = VertexList.Min(item => item.Y);
                return p;
            }
        }

        public PointF Max
        {
            get
            {
                PointF p = new PointF();
                p.X = VertexList.Max(item => item.X);
                p.Y = VertexList.Max(item => item.Y);
                return p;
            }
        }

        // Проверка попадания в прямоугольник
        private bool CheckHitting(PointF p1, PointF p2, PointF pClick)
        {
            float xmin = p1.X > p2.X ? p2.X : p1.X;
            float ymin = p1.Y > p2.Y ? p2.Y : p1.Y;
            float xmax = p1.X < p2.X ? p2.X : p1.X;
            float ymax = p1.Y < p2.Y ? p2.Y : p1.Y;

            return (Math.Abs(pClick.X - xmin) < 3f || Math.Abs(pClick.X - xmax) < 3f)
                && (Math.Abs(pClick.Y - ymin) < 3f || Math.Abs(pClick.Y - ymax) < 3f);
        }

        public bool Select(PointF p)
        {
            // Точка p должна лежать внутри прямоугольника, образуемого двумя соседними вершинами
            for (int i = 0; i < VertexList.Count - 1; i++)
            {
                if (VertexList[i].X == p.X && VertexList[i].Y == p.Y) 
                    return true;

                if (CheckHitting(VertexList[i], VertexList[i+1], p))
                    return true;
            }
            return false;

        }

        public void Move(float dx, float dy)
        {
            for (int i = 0; i < VertexList.Count; i++)
            {
                PointF newPoint = new PointF();
                newPoint.X = VertexList[i].X + dx;
                newPoint.Y = VertexList[i].Y + dy;
                VertexList[i] = newPoint; 
            }
        }

        public void Resize(PointF mP)
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
    }
}
