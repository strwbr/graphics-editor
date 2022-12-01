
namespace graphics_editor_cgs
{
    public class InteriorSegment
    {
        public int xl;
        public int xr;
        public int y;

        public InteriorSegment(int xl, int xr, int y) : this()
        {
            this.xl = xl;
            this.xr = xr;
            this.y = y;
        }
        public InteriorSegment(InteriorSegment other)
        {
            this.xl = other.xl;
            this.xr = other.xr;
            this.y = other.y;
        }

        public InteriorSegment()
        {
        }
    }
}
