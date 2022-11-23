using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor_cgs
{
    public class HorizontalLine
    {
        public float xl;
        public float xr;
        public float y;

        public HorizontalLine(float xl, float xr, float y) : this()
        {
            this.xl = xl;
            this.xr = xr;
            this.y = y;
        }
        public HorizontalLine(HorizontalLine other)
        {
            this.xl = other.xl;
            this.xr = other.xr;
            this.y = other.y;
        }

        public HorizontalLine()
        {
        }
    }
}
