
namespace graphics_editor_cgs
{
    // Закрашиваемый сегмент многоугольника
    public class InteriorSegment
    {
        public int Xl; // левая граница сегмента
        public int Xr; // правая граница сегмента
        public int Y; // строка

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
