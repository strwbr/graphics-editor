using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor_cgs
{
    public class Figures
    {
        public static Polygon Arrow1(Point p0)
        {
            Polygon arrow = new Polygon();
            int x0 = p0.X;
            int y0 = p0.Y;
            const int w = 60;
            const int h = 20;
            arrow.VertexList.Add(p0);

            Point p1 = new Point(x0 + w, y0); arrow.VertexList.Add(p1);
            Point p2 = new Point(x0 + w, y0 - h / 2); arrow.VertexList.Add(p2);
            Point p3 = new Point(x0 + 4 * w / 3, y0 + h / 2); arrow.VertexList.Add(p3);
            Point p4 = new Point(x0 + w, y0 + 3 * h / 2); arrow.VertexList.Add(p4);
            Point p5 = new Point(x0 + w, y0 + h); arrow.VertexList.Add(p5);
            Point p6 = new Point(x0, y0 + h); arrow.VertexList.Add(p6);

            arrow.Fill();
            arrow.GetBorders();
            return arrow;
        }

        public static Polygon Arrow2(Point p0)
        {
            Polygon arrow = new Polygon(Arrow1(p0));
            int x0 = p0.X;
            int y0 = p0.Y;
            const int w = 60;
            const int h = 20;

            Point p7 = new Point(x0, y0 + 3 * h / 2); arrow.VertexList.Add(p7);
            Point p8 = new Point(x0 - w / 3, y0 + h / 2); arrow.VertexList.Add(p8);
            Point p9 = new Point(x0, y0 - h / 2); arrow.VertexList.Add(p9);

            arrow.Fill();
            arrow.GetBorders();
            return arrow;
        }
    }
}
