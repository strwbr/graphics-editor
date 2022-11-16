using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor_cgs
{
    public class BezierCurve : Figure
    {
        public BezierCurve()
        {
        }

        public BezierCurve(List<Point> vertexList) : base(vertexList)
        {
        }

        public BezierCurve(Figure other) : base(other)
        {
        }



        
    }

     
}
