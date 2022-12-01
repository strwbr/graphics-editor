
namespace graphics_editor_cgs
{
    public class InteriorSegment
    {
        public int Xl;
        public int Xr;
        public int Y;

        public InteriorSegment(int xl, int xr, int y) : this()
        {
            this.Xl = xl;
            this.Xr = xr;
            this.Y = y;
        }
        public InteriorSegment(InteriorSegment other)
        {
            this.Xl = other.Xl;
            this.Xr = other.Xr;
            this.Y = other.Y;
        }

        public InteriorSegment()
        {
        }
    }
}
