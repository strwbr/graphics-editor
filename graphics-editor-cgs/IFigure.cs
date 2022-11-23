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
        //public List<HorizontalLine> LinesList { get; set; }
        PointF Pmin { get; set; }
        PointF Pmax { get; set; }
        Color Color { get; set; }

        void GetBorders();
        void Select();
        void Move();
        void Zoom();
        void Rotate();
        PointF Center();
    }
}
