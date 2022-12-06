using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace graphics_editor_cgs
{
    public class Polygon : Figure
    {
        // из интерфейса
        public List<PointF> VertexList { get; set; }
        public Color Color { get; set; }

        public List<InteriorSegment> LinesList { get; set; }

        public Polygon()
        {
            VertexList = new List<PointF>();
            Color = Color.Black; // по умолчанию черный

            LinesList = new List<InteriorSegment>();
        }

        public Polygon(List<PointF> vertexList, List<InteriorSegment> linesList, Color color) : this()
        {
            vertexList = vertexList.ConvertAll(item => new PointF(item.X, item.Y));
            Color = color;
            linesList = linesList.ConvertAll(item => new InteriorSegment(item));
        }

        public Polygon(Polygon other)  /*this(other.VertexList, other.LinesList, other.Color)*/
        {
            VertexList = other.VertexList.ConvertAll(item => new PointF(item.X, item.Y));
            Color = other.Color;
            LinesList = other.LinesList.ConvertAll(item => new InteriorSegment(item));
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

            //for (int i = 0; i < LinesList.Count; i++)
            //{
            //    if (p.Y == LinesList[i].y)
            //    {
            //        if (p.X >= LinesList[i].xl && p.X <= LinesList[i].xr)
            //        {
            //            return true;
            //        }
            //    }
            //}
            //return false;
        }

        // Закрашивание фигуры
        public void Fill()
        {
            LinesList.Clear();
            float Ymin = Min.Y;
            float Ymax = Max.Y;

            List<int> Xb = new List<int>();
            for (int j = (int)Ymin; j <= Ymax; j++)
            {
                Xb.Clear();
                for (int i = 0; i < VertexList.Count; i++)
                {
                    int k;
                    if (i < VertexList.Count - 1) k = i + 1;
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
                    LinesList.Add(new InteriorSegment(Xb[i], Xb[i + 1], j));
                }
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

        public void Move(float dx, float dy)
        {
            for (int i = 0; i < VertexList.Count; i++)
            {
                PointF newPoint = new PointF();
                newPoint.X = VertexList[i].X + dx;
                newPoint.Y = VertexList[i].Y + dy;
                VertexList[i] = newPoint; //new PointF(newPoint.X, newPoint.Y);
            }
            Fill();
        }

        public void Resize(PointF mP)
        {
            PointF center = Center;
            float bx = (mP.X >= Min.X && mP.X <= Max.X) ? -0.02f : 0.02f;
            bx += 1;
            for (int i = 0; i < VertexList.Count; i++)
            {
                PointF newPoint = new PointF();
                newPoint.X = (VertexList[i].X - center.X) * bx + center.X;
                newPoint.Y = VertexList[i].Y;
                VertexList[i] = newPoint;
            }
            Fill();
        }
        public void Resize(PointF mP, PointF center)
        {
            //PointF center = Center;
            float bx = (mP.X >= Min.X && mP.X <= Max.X) ? -0.02f : 0.02f;
            bx += 1;
            for (int i = 0; i < VertexList.Count; i++)
            {
                PointF newPoint = new PointF();
                newPoint.X = (VertexList[i].X - center.X) * bx + center.X;
                newPoint.Y = VertexList[i].Y;
                VertexList[i] = newPoint;
            }

            Fill();
        }
        //public void Resize(PointF mP, PointF center)
        //{
        //    //PointF center = Center;
        //    float bx = (mP.X >= Min.X && mP.X <= Max.X) ? -0.02f : 0.02f;
        //    bx += 1;
        //    for (int i = 0; i < VertexList.Count; i++)
        //    {
        //        PointF newPoint = new PointF();
        //        newPoint.X = (VertexList[i].X - center.X) * bx + center.X;
        //        newPoint.Y = VertexList[i].Y;
        //        VertexList[i] = newPoint;
        //    }
        //    Fill();
        //}

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
                VertexList[i] = new PointF(p.X, p.Y);
            }
            Fill();
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
