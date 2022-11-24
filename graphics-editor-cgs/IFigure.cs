using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor_cgs
{
    public interface IFigure
    {
        List<PointF> VertexList { get; set; }
        Color Color { get; set; }

        bool Select(PointF p);
        void Move(float dx, float dy);
        void Resize(PointF mP, PointF center);
        void Rotate();
        PointF Center();
        PointF Min();
        PointF Max();

        bool CheckResize(float x, float y);
    }
}
