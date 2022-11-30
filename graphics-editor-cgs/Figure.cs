using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor_cgs
{
    public interface Figure
    {
        List<PointF> VertexList { get; set; }
        Color Color { get; set; }
        PointF Center { get; }
        PointF Min { get; }
        PointF Max { get; }

        bool Select(PointF p);
        void Move(float dx, float dy);
        void Resize(PointF mP);
        void Rotate(float angle, PointF center);


        bool CheckResize(float x, float y);
    }
}
