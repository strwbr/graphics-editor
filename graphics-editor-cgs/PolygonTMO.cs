using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace graphics_editor_cgs
{
    public class PolygonTMO : Figure
    {
        public int IndexTMO { private get; set; } // Индекс вида ТМО
        public Polygon Polygon_1 { private get; set; } // 1-я фигура
        public Polygon Polygon_2 { private get; set; } // 2-я фигура
        public List<InteriorSegment> ResultLines { get; set; } // Список результирующих сегментов ТМО
        
        public int Xmin_e { private get; set; } // Мин граница области рисования
        public int Xmax_e { private get; set; } // Макс граница области рисования

        public List<PointF> VertexList { get; set; }
        public Color Color { get; set; }

        public PolygonTMO()
        {
            IndexTMO = -1;
            Polygon_1 = new Polygon();
            Polygon_2 = new Polygon();
            ResultLines = new List<InteriorSegment>();
            VertexList = new List<PointF>();
            Color = Color.Black;
        }

        public PolygonTMO(int xmin_e, int xmax_e) : this()
        {
            Xmin_e = xmin_e;
            Xmax_e = xmax_e;
        }

        public PolygonTMO(int indexTMO, Polygon polygon_1, Polygon polygon_2, Color color) : this()
        {
            IndexTMO = indexTMO;
            Polygon_1 = new Polygon(polygon_1);
            Polygon_2 = new Polygon(polygon_2);
            Color = color;
        }

        public PolygonTMO(PolygonTMO other) : this(other.IndexTMO, other.Polygon_1, other.Polygon_2, other.Color)
        {
        }

        // Множество значений суммы Q
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
                p.X = ResultLines.Min(item => item.Xl);
                p.Y = ResultLines.Min(item => item.Y);
                return p;
            }
        }

        public PointF Max
        {
            get
            {
                PointF p = new PointF();
                p.X = ResultLines.Max(item => item.Xr);
                p.Y = ResultLines.Max(item => item.Y);
                return p;
            }
        }

        public void MakeTMO()
        {
            List<SegmentTMO> M = new List<SegmentTMO>();

            float Ymin = Math.Min(Polygon_1.Min.Y, Polygon_2.Min.Y);
            float Ymax = Math.Max(Polygon_1.Max.Y, Polygon_2.Max.Y);

            List<int> Xrl = new List<int>();
            List<int> Xrr = new List<int>();

            int[] setQ = SetQ;

            for (int j = (int)Ymin; j < Ymax; j++)
            {
                List<InteriorSegment> Xlines_1 = new List<InteriorSegment>();
                List<InteriorSegment> Xlines_2 = new List<InteriorSegment>();

                M.Clear();
                // Поиск закрашиваемых сегментов, лежащих на строке Y
                // у 1-й фигуры
                if (Polygon_1.LinesList.Any(item => item.Y == j))
                {
                    Xlines_1 = Polygon_1.LinesList.FindAll(item => item.Y == j);
                }
                // у 2-й фигуры
                if (Polygon_2.LinesList.Any(item => item.Y == j))
                {
                    Xlines_2 = Polygon_2.LinesList.FindAll(item => item.Y == j);
                }
                // Заполнение массива М
                // для 1-й фигуры
                for (int i = 0; i < Xlines_1.Count; i++)
                {
                    M.Add(new SegmentTMO(Xlines_1[i].Xl, 2));
                    M.Add(new SegmentTMO(Xlines_1[i].Xr, -2));
                }
                // для 2-й фигуры
                for (int i = 0; i < Xlines_2.Count; i++)
                {
                    M.Add(new SegmentTMO(Xlines_2[i].Xl, 1));
                    M.Add(new SegmentTMO(Xlines_2[i].Xr, -1));
                }
                
                // Сортировка массива М по возрастанию
                M.Sort((e1, e2) => e1.x.CompareTo(e2.x));
                int Q = 0; // предыдущее значение суммы Q
                int Qnew = 0; // текущее (новое) значение суммы Q
                Xrl.Clear();
                Xrr.Clear();
               
                if (M.Count > 0)
                {
                    // Если 1-й элемент массива - правая граница 
                    if (M[0].x >= Xmin_e && M[0].dQ < 0)
                    {
                        Xrl.Add(Xmin_e);
                        Q = -M[0].dQ;
                    }
                    int x;
                    for (int i = 0; i < M.Count; i++)
                    {
                        x = M[i].x;
                        Qnew = Q + M[i].dQ;

                        // Левая граница сегмента ТМО
                        if ((Q < setQ[0] || Q > setQ[1]) && (Qnew >= setQ[0] && Qnew <= setQ[1]))
                        {
                            Xrl.Add(x);
                        }
                        // Правая граница сегмента ТМО
                        if ((Q >= setQ[0] && Q <= setQ[1]) && (Qnew < setQ[0] || Qnew > setQ[1]))
                        {
                            Xrr.Add(x);
                        }
                        Q = Qnew;
                    }
                    // Если не найдена правая граница для последнего сегмента
                    if (Q >= SetQ[0] && Q <= SetQ[1])
                    {
                        Xrr.Add(Xmax_e);
                    }
                    // Заполнение поля результирующих сегментов ТМО
                    for (int i = 0; i < Xrl.Count; i++)
                    {
                        ResultLines.Add(new InteriorSegment(Xrl[i], Xrr[i], j));
                    }
                }
            }
        }

        public bool Select(PointF p)
        {
            for (int i = 0; i < ResultLines.Count; i++)
            {
                if (p.Y == ResultLines[i].Y)
                {
                    if (p.X >= ResultLines[i].Xl && p.X <= ResultLines[i].Xr)
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
            float xc = (Polygon_1.Center.X + Polygon_2.Center.X) / 2;
            float yc = (Polygon_1.Center.Y + Polygon_2.Center.Y) / 2;
            PointF c = new PointF(xc, yc);
            Polygon_1.Resize(mP, c);
            Polygon_2.Resize(mP, c);
            MakeTMO();
        }
        
        public void Rotate(float angle, PointF center)
        {
            ResultLines.Clear();
            Polygon_1.Rotate(angle, center);
            Polygon_2.Rotate(angle, center);
            MakeTMO();
        }
    }
}
