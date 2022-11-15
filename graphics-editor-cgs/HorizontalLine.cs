using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor_cgs
{
    public class HorizontalLine
    {
        public int xl;
        public int xr;
        public int y;

        public HorizontalLine(int xl, int xr, int y) : this()
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
