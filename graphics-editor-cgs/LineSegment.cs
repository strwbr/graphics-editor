using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor_cgs
{
    public class LineSegment:Figure
    {
        public LineSegment()
        {
        }

        public LineSegment(List<PointF> vertexList, Color color) : base(vertexList, color)
        {
            GetBorders();
        }

        public LineSegment(Figure other) : base(other)
        {
        }
    }
}
