using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace graphics_editor_cgs
{
    public class BezierCurve : IFigure
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

        public bool Select(PointF p)
        {
            //for(int i = 0; i < VertexList.Count-1; i++)
            //{
            //    PointF p1 = VertexList[i];
            //    PointF p2 = VertexList[i + 1];
            //    float distance1 = (float)Math.Sqrt(Math.Pow(p1.X - p.X, 2) + Math.Pow(p1.Y - p.Y, 2));
            //    float distance2 = (float)Math.Sqrt(Math.Pow(p2.X - p.X, 2) + Math.Pow(p2.Y - p.Y, 2));
            //    float distance3 = (float)Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
            //    if(distance1 + distance2 - distance3 < 1f) return true;
            //}
            float xmin = Min().X;
            float xmax = Max().X;
            float ymin = Min().Y;
            float ymax = Max().Y;

            //if(p.X>=xmin && p.X <=xmax)
            //    if(p.Y>=ymin && p.Y <=ymax)
            //        return true;
            // Клик попал в описанный прямоугольник
            return p.X >= xmin && p.X <= xmax && p.Y >= ymin && p.Y <= ymax;
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

        public void Resize(PointF mP)
        {
            PointF center = Center();
            float bx = (mP.X >= Min().X && mP.X <= Max().X) ? -0.03f : 0.03f;
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
            //double cos = Math.Cos(angle);
            double cos = Math.Cos(angle * Math.PI / 180);
            //double sin = Math.Sin(angle);
            double sin = Math.Sin(angle * Math.PI / 180);
            for (int i = 0; i < VertexList.Count; i++)
            {
                PointF p = new PointF();
                p.X = (float)((VertexList[i].X - center.X) * cos - (VertexList[i].Y - center.Y) * sin + center.X);
                p.Y = (float)((VertexList[i].X - center.X) * sin + (VertexList[i].Y - center.Y) * cos + center.Y);
                VertexList[i] = p;
            }
        }

        public PointF Center()
        {
            PointF Pmin = Min();
            PointF Pmax = Max();
            return new PointF((Pmax.X + Pmin.X) / 2, (Pmax.Y + Pmin.Y) / 2);
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

        public bool CheckResize(float x, float y)
        {
            float Xmin = Min().X;
            float Xmax = Max().X;
            float Yc = Center().Y;
            return
                ((x >= Xmin - 10 && x <= Xmin + 4) || (x >= Xmax - 4 && x <= Xmax + 10))
                && (y >= Yc - 7 && y <= Yc + 7);
        }

        
    }

     
}
