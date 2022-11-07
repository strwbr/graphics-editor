namespace graphics_editor
{
    public partial class Form1 : Form
    {
        Graphics g;
        List<Point> points = new List<Point>();
        Segment Segment = new Segment();
        HorizontalLine Line = new HorizontalLine();
        bool drawSegment = false;

        public Form1()
        {
            InitializeComponent();
            g = drawingPanel.CreateGraphics();
            currentColorPanel.BackColor = Color.Black;
        }

        private void ColorDialogBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
                currentColorPanel.BackColor = colorDialog.Color;
        }

        private Color GetColor()
        {
            return currentColorPanel.BackColor;
        }

        private void RedBtn_Click(object sender, EventArgs e)
        {
            currentColorPanel.BackColor = redBtn.BackColor;
        }

        private void YellowBtn_Click(object sender, EventArgs e)
        {
            currentColorPanel.BackColor = yellowBtn.BackColor;
        }

        private void GreenBtn_Click(object sender, EventArgs e)
        {
            currentColorPanel.BackColor = greenBtn.BackColor;
        }

        private void BlueBtn_Click(object sender, EventArgs e)
        {
            currentColorPanel.BackColor = blueBtn.BackColor;
        }

        private void WhiteBtn_Click(object sender, EventArgs e)
        {
            currentColorPanel.BackColor = whiteBtn.BackColor;
        }

        private void DrawSegmentBtn_Click(object sender, EventArgs e)
        {
            drawSegment = true;
        }

        private void drawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (drawSegment)
            {
                Segment.X = e.Location.X;
                Segment.Y = e.Location.Y;
            }
        }

        private void drawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (drawSegment)
            {
                Segment.X2 = e.Location.X;
                Segment.Y2 = e.Location.Y;
                g.DrawLine(new Pen(GetColor()), new Point(Segment.X, Segment.Y), new Point(Segment.X2, Segment.Y2));
            }
        }

    }

    struct HorizontalLine
    {
        public int x1;
        public int x2;
        public int y;

        public HorizontalLine(int x1, int x2, int y) : this()
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y = y;
        }

        public HorizontalLine(HorizontalLine line) : this()
        {
            x1 = line.x1;
            x2 = line.x2;
            y = line.y;
        }
    }

    //struct Figure
    //{
    //    Point[] points;
    //    Color color;

    //    public Figure(Point[] points, Color color):this()
    //    {
    //        this.points = points;
    //        this.color = color;
    //    }
    //}

}