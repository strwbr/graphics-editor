using System;
using System.Collections.Generic;
using System.Drawing;

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
    }

     
}
