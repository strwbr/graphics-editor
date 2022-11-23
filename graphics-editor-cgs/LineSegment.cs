using System;
using System.Collections.Generic;
using System.Drawing;

namespace graphics_editor_cgs
{
    public class LineSegment : IFigure
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
            throw new NotImplementedException();
        }

        public void Move(float dx, float dy)
        {
            throw new NotImplementedException();
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
            PointF p1 = VertexList[0];
            PointF p2 = VertexList[1];
            return new PointF((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
        }

        public PointF Min()
        {
            PointF p = new PointF();
            p.X = VertexList[0].X < VertexList[1].X ? VertexList[0].X : VertexList[1].X;
            p.Y = VertexList[0].Y < VertexList[1].Y ? VertexList[0].Y : VertexList[1].Y;
            return p;
        }

        public PointF Max()
        {
            PointF p = new PointF();
            p.X = VertexList[0].X > VertexList[1].X ? VertexList[0].X : VertexList[1].X;
            p.Y = VertexList[0].Y > VertexList[1].Y ? VertexList[0].Y : VertexList[1].Y;
            return p;
        }
    }
}
