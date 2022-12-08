namespace graphics_editor_cgs
{
    // Для хранения границ сегментов и приращений пороговых функций
    public struct SegmentTMO
    {
        public int x;
        public int dQ;

        public SegmentTMO(int x, int dQ) : this()
        {
            this.x = x;
            this.dQ = dQ;
        }
    }
}
