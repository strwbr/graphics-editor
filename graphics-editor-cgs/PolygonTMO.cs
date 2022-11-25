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
        public int[] SetQ { get; set; }
        public List<Polygon> ParentsPolygons { get; set; }
        public List<HorizontalLine> ResultLines { get; set; }

        public List<PointF> VertexList { get; set; }
        public Color Color { get; set; }

        public PolygonTMO()
        {
            SetQ = new int[0];
            ParentsPolygons = new List<Polygon>();
            ResultLines = new List<HorizontalLine>();
            VertexList = new List<PointF>();
            Color = Color.Black;
        }

        public PolygonTMO(int[] setQ, List<Polygon> parentsPolygons, Color color) : this()
        {
            for (int i = 0; i < setQ.Length; i++)
            {
                SetQ[i] = setQ[i];
            }
            ParentsPolygons = parentsPolygons.ConvertAll(item => new Polygon(item));
            Color = color;
        }

        public PolygonTMO(PolygonTMO other): this(other.SetQ, other.ParentsPolygons, other.Color)
        {
            //for (int i = 0; i < other.SetQ.Length; i++)
            //{
            //    SetQ[i] = other.SetQ[i];
            //}
            //ParentsPolygons = other.ParentsPolygons.ConvertAll(item => new Polygon(item));
        }

        public bool Select(PointF p)
        {
            for (int i = 0; i < ResultLines.Count; i++)
            {
                if (p.Y == ResultLines[i].y)
                {
                    if (p.X >= ResultLines[i].xl && p.X <= ResultLines[i].xr)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void Move(float dx, float dy)
        {
            throw new NotImplementedException();
        }

        public void Resize(PointF mP, PointF center)
        {
            throw new NotImplementedException();
        }

        public void Rotate(float angle, PointF center)
        {
            throw new NotImplementedException();
        }

        public PointF Center()
        {
            throw new NotImplementedException();
        }

        public PointF Min()
        {
            throw new NotImplementedException();
        }

        public PointF Max()
        {
            throw new NotImplementedException();
        }

        public bool CheckResize(float x, float y)
        {
            throw new NotImplementedException();
        }
    }
}
