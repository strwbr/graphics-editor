﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor_cgs
{
    // Для хранения границ сегментов и приращений пороговых функций
    public struct Border
    {
        public float x;
        public int dQ;

        public Border(float x, int dQ) : this()
        {
            this.x = x;
            this.dQ = dQ;
        }
    }

    public class TMO
    {
        public Polygon Polygon_1 { get; set; }
        public Polygon Polygon_2 { get; set; }
        public Polygon PolygonResult { get; set; }

        public int[] SetQ;

        public TMO()
        {
            Polygon_1 = new Polygon();
            Polygon_2 = new Polygon();
            PolygonResult = new Polygon();
            SetQ = new int[] { -1, -1 };
        }

        public TMO(Polygon polygon1, Polygon polygon2) : this()
        {
            Polygon_1 = new Polygon(polygon1);
            Polygon_2 = new Polygon(polygon2);
        }

        public TMO(Polygon polygon1, Polygon polygon2, int[] setQ) : this(polygon1, polygon2)
        {
            SetQ = setQ;
        }

        //private int MinY(List<HorizontalLine> lines)
        //{
        //    int min = lines[0].y;
        //    for(int i =0; i < lines.Count; i++)
        //    {
        //        if (lines[i].y < min)
        //            min = lines[i].y;
        //    }
        //    return min;
        //}

        //private int MaxY(List<HorizontalLine> lines)
        //{
        //    int max = lines[0].y;
        //    for (int i = 0; i < lines.Count; i++)
        //    {
        //        if (lines[i].y > max)
        //            max = lines[i].y;
        //    }
        //    return max;
        //}

        public Polygon MakeTMO(float Xmin_e, float Xmax_e)
        {
            Polygon result = new Polygon();
            List<Border> M = new List<Border>();

            //int Ymin_1 = MinY(Polygon_1.LinesList);
            //int Ymin_2 = MinY(Polygon_2.LinesList);
            //int Ymax_1 = MaxY(Polygon_1.LinesList);
            //int Ymax_2 = MaxY(Polygon_2.LinesList);


            float Ymin_1 = Polygon_1.LinesList.Min(item => item.y);
            float Ymax_1 = Polygon_1.LinesList.Max(item => item.y);
            float Ymin_2 = Polygon_2.LinesList.Min(item => item.y);
            float Ymax_2 = Polygon_2.LinesList.Max(item => item.y);

            float Ymin = Math.Min(Ymin_1, Ymin_2);
            float Ymax = Math.Max(Ymax_1, Ymax_2);

            List<float> Xrl = new List<float>();
            List<float> Xrr = new List<float>();

            for (float j = Ymin; j < Ymax; j++)
            {
                List<HorizontalLine> Xlines_1 = new List<HorizontalLine>();
                List<HorizontalLine> Xlines_2 = new List<HorizontalLine>();

                M.Clear();

                if (Polygon_1.LinesList.Any(item => item.y == j))
                {
                    Xlines_1 = Polygon_1.LinesList.FindAll(item => item.y == j);
                }
                if (Polygon_2.LinesList.Any(item => item.y == j))
                {
                    Xlines_2 = Polygon_2.LinesList.FindAll(item => item.y == j);
                }
                int n = Xlines_1.Count;

                for (int i = 0; i < n; i++)
                {
                    M.Add(new Border(Xlines_1[i].xl, 2));
                }
                int nM = n;
                for (int i = 0; i < n; i++)
                {
                    M.Add(new Border(Xlines_1[i].xr, -2));
                }
                nM += n;
                n = Xlines_2.Count;
                for (int i = 0; i < n; i++)
                {
                    M.Add(new Border(Xlines_2[i].xl, 1));
                }
                nM += n;
                for (int i = 0; i < n; i++)
                {
                    M.Add(new Border(Xlines_2[i].xr, -1));
                }
                nM += n;

                M.Sort((e1, e2) => e1.x.CompareTo(e2.x));
                int Q = 0;
                int Qnew = 0;
                Xrl.Clear();
                Xrr.Clear();

                if (nM > 0)
                {
                    if (M[0].x >= Xmin_e && M[0].dQ < 0)
                    {
                        Xrl.Add(Xmin_e);
                        Q = -M[0].dQ;
                    }
                    float x;
                    for (int i = 0; i < nM; i++)
                    {
                        x = M[i].x;
                        Qnew = Q + M[i].dQ;

                        if ((Q < SetQ[0] || Q > SetQ[1]) && (Qnew >= SetQ[0] && Qnew <= SetQ[1]))
                        {
                            Xrl.Add(x);
                        }

                        if ((Q >= SetQ[0] && Q <= SetQ[1]) && (Qnew < SetQ[0] || Qnew > SetQ[1]))
                        {
                            Xrr.Add(x);
                        }
                        Q = Qnew;
                    }
                    if (Q >= SetQ[0] && Q <= SetQ[1])
                    {
                        Xrr.Add(Xmax_e);
                    }

                    for (int i = 0; i < Xrl.Count; i++)
                    {
                        result.LinesList.Add(new HorizontalLine(Xrl[i], Xrr[i], j));
                    }

                }
            }
            return result;
        }
    }
}
