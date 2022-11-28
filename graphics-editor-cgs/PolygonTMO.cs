using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor_cgs
{
    public class PolygonTMO : IFigure
    {
        //public int[] SetQ { get; set; }
        public int IndexTMO { get; set; }
        public Polygon Polygon_1 { get; set; }
        public Polygon Polygon_2 { get; set; }
        public List<HorizontalLine> ResultLines { get; set; }

        public List<PointF> VertexList { get; set; }
        public Color Color { get; set; }

        public PolygonTMO()
        {
            //SetQ = new int[] { -1, -1 };
            IndexTMO = -1;
            Polygon_1 = new Polygon();
            Polygon_2 = new Polygon();
            ResultLines = new List<HorizontalLine>();
            VertexList = new List<PointF>();
            Color = Color.Black;
        }

        public PolygonTMO(int indexTMO, Polygon polygon_1, Polygon polygon_2, Color color) : this()
        {
            //for (int i = 0; i < setQ.Length; i++)
            //{
            //    SetQ[i] = setQ[i];
            //}
            IndexTMO = indexTMO;
            Polygon_1 = new Polygon(polygon_1);
            Polygon_2 = new Polygon(polygon_2);
            Color = color;
        }

        public PolygonTMO(PolygonTMO other) : this(other.IndexTMO, other.Polygon_1, other.Polygon_2, other.Color)
        {
            //for (int i = 0; i < other.SetQ.Length; i++)
            //{
            //    SetQ[i] = other.SetQ[i];
            //}
            //ParentsPolygons = other.ParentsPolygons.ConvertAll(item => new Polygon(item));
        }

        public int[] SetQ
        {
            get
            {
                int[] setQ = new int[] { -1, -1 };
                switch (IndexTMO)
                {
                    case 0: // Сим разность
                        setQ = new int[] { 1, 2 };
                        break;
                    case 1: // Разность А/В
                        setQ = new int[] { 2, 2 };
                        break;
                    case 2: // Разность В/А
                        setQ = new int[] { 1, 1 };
                        break;
                }
                return setQ;
            }
        }

        public void MakeTMO()
        {
            List<Border> M = new List<Border>();

            float Ymin_1 = Polygon_1.Min().Y;
            float Ymax_1 = Polygon_1.Max().Y;
            float Ymin_2 = Polygon_2.Min().Y;
            float Ymax_2 = Polygon_2.Max().Y;

            float Ymin = Math.Min(Ymin_1, Ymin_2);
            float Ymax = Math.Max(Ymax_1, Ymax_2);

            List<int> Xrl = new List<int>();
            List<int> Xrr = new List<int>();

            int[] setQ = SetQ;

            for (int j = (int)Ymin; j < Ymax; j++)
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
                    //if (M[0].x >= Xmin_e && M[0].dQ < 0)
                    //{
                    //    Xrl.Add(Xmin_e);
                    //    Q = -M[0].dQ;
                    //}
                    int x;
                    for (int i = 0; i < nM; i++)
                    {
                        x = M[i].x;
                        Qnew = Q + M[i].dQ;

                        if ((Q < setQ[0] || Q > setQ[1]) && (Qnew >= setQ[0] && Qnew <= setQ[1]))
                        {
                            Xrl.Add(x);
                        }

                        if ((Q >= setQ[0] && Q <= setQ[1]) && (Qnew < setQ[0] || Qnew > setQ[1]))
                        {
                            Xrr.Add(x);
                        }
                        Q = Qnew;
                    }
                    //if (Q >= SetQ[0] && Q <= SetQ[1])
                    //{
                    //    Xrr.Add(Xmax_e);
                    //}

                    for (int i = 0; i < Xrl.Count; i++)
                    {
                        ResultLines.Add(new HorizontalLine(Xrl[i], Xrr[i], j));
                    }

                }
            }
        }

        public bool Select(PointF p)
        {
            for (int i = 0; i < ResultLines.Count; i++)
            {
                if (p.Y == ResultLines[i].y)
                {
                    if (p.X >= ResultLines[i].xl && p.X <= ResultLines[i].xr)
                        return true;
                }
            }
            return false;
        }

        public void Move(float dx, float dy)
        {
            ResultLines.Clear();
            Polygon_1.Move(dx, dy);
            Polygon_2.Move(dx, dy);
            MakeTMO();
        }

        public void Resize(PointF mP)
        {
            ResultLines.Clear();
            Polygon_1.Resize(mP);
            Polygon_2.Resize(mP);
            MakeTMO();
        }

        public void Rotate(float angle, PointF center)
        {
            ResultLines.Clear();
            Polygon_1.Rotate(angle, center);
            Polygon_2.Rotate(angle, center);
            MakeTMO();
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
            p.X = ResultLines.Min(item => item.xl);
            p.Y = ResultLines.Min(item => item.y);
            return p;
        }

        public PointF Max()
        {
            PointF p = new PointF();
            p.X = ResultLines.Max(item => item.xr);
            p.Y = ResultLines.Max(item => item.y);
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
