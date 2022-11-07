using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor
{
    public class Segment : Figure
    {
        public int X2 { get; set; }
        public int Y2 { get; set; }
        
        public Segment(Figure figure) : base(figure)
        {
        }

        public Segment(int x, int y, List<Point> points, Color color) : base(x, y, points, color)
        {
        }

        public Segment()
        {

        }

        public int Length()
        {
            return (int)Math.Sqrt(Math.Pow(X - X2, 2) + Math.Pow(Y - Y2, 2));
        }
    }
}
