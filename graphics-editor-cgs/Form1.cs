using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace graphics_editor_cgs
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap myBitmap;
        Figure figure = new Figure();
        List<Point> VertexList = new List<Point>();
        List<Figure> FigureList = new List<Figure>();

        private int[] SetQ = new int[] { -1, -1 };

        private int indexTMO = 0;
        private int indexFigure = 0;
        private int indexOperation = 0;

        private Color CurrentColor => currentColorPanel.BackColor;
        private Pen CurrentPen => new Pen(CurrentColor);


        public Form1()
        {
            InitializeComponent();
            myBitmap = new Bitmap(drawingPanel.Width, drawingPanel.Height);
            g = drawingPanel.CreateGraphics();
            currentColorPanel.BackColor = Color.Black;
        }

        // Добавление фигуры = 1
        // Отрезок = 0
        private void SegmentBtn_Click(object sender, EventArgs e)
        {
            indexOperation = 0; // перенести в другой метод, где будет проверять индекс операции (если 4, то отключить)
            indexFigure = 0;
            tmoCb.Enabled = false;
            debugLabel.Text = $"Отрезок = {indexFigure} | [{indexOperation}]";
        }
        // Прямая Безье = 1
        private void BezierBtn_Click(object sender, EventArgs e)
        {
            indexOperation = 0;
            indexFigure = 1;
            tmoCb.Enabled = false;
            debugLabel.Text = $"Безье = {indexFigure} | [{indexOperation}]";
        }
        // Стрелка1 = 2
        private void Arrow1Btn_Click(object sender, EventArgs e)
        {
            indexOperation = 0;
            indexFigure = 2;
            tmoCb.Enabled = false;
            debugLabel.Text = $"Стрелка1 = {indexFigure} | [{indexOperation}]";
        }
        // Стрелка2 = 3
        private void Arrow2Btn_Click(object sender, EventArgs e)
        {
            indexOperation = 0;
            indexFigure = 3;
            tmoCb.Enabled = false;
            debugLabel.Text = $"Стрелка2 = {indexFigure} | [{indexOperation}]";
        }

        // Выделение фигуры = 1
        private void SelectFigureBtn_Click(object sender, EventArgs e)
        {
            indexOperation = 1;


        }

        // Удаление фигуры = 2
        private void DeleteFigureBtn_Click(object sender, EventArgs e) => indexOperation = 2;
        // Очистка области рисования = 3
        private void ClearPanelBtn_Click(object sender, EventArgs e)
        {
            indexOperation = 3;
            ClearPanel();
        }
        // ТМО = 4
        private void TmoBtn_Click(object sender, EventArgs e)
        {
            tmoCb.Enabled = true;
            indexOperation = 4;
        }
        // Выбор ТМО
        private void TmoCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tmoCb.SelectedIndex)
            {
                case 0: // Сим разность
                    SetQ = new int[] { 1, 2 };
                    indexTMO = 0;
                    break;
                case 1: // Разность А/В
                    SetQ = new int[] { 2, 2 };
                    indexTMO = 1;
                    break;
                case 2: // Разность В/А
                    SetQ = new int[] { 1, 1 };
                    indexTMO = 2;
                    break;
            }
        }

        private void drawingPanel_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void drawingPanel_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void drawingPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (indexOperation == 0)
            {
                Figure currentFigure = null;
                switch (indexFigure)
                {
                    case 0: debugLabel.Text = $"indexFigure = {indexFigure}"; break;
                    case 1: debugLabel.Text = $"indexFigure = {indexFigure}"; break;
                    case 2:
                        currentFigure = Figures.Arrow1(e.Location);
                        DrawPolygon((Polygon)currentFigure); break;
                    case 3:
                        currentFigure = Figures.Arrow2(e.Location);
                        DrawPolygon((Polygon)currentFigure); break;
                }
                FigureList.Add(currentFigure);
                debugLabel.Text = FigureList.Count.ToString();
            }
            else if (indexOperation == 1)
            {
                for (int i = 0; i < FigureList.Count; i++)
                {
                    if (FigureList[i].Select(e.Location))
                    {
                        DrawSelection(FigureList[i].Pmin, FigureList[i].Pmax);
                        DrawCenter(FigureList[i].Center());
                    }
                }
            }
        }

        private void DrawSelection(Point Pmin, Point Pmax)
        {
            int Xmin = Pmin.X,
                Ymin = Pmin.Y;
            int Xmax = Pmax.X,
                Ymax = Pmax.Y;

            Pen pen = new Pen(Color.Gray);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash; // штрихованная линия
            g.DrawRectangle(pen, new Rectangle(Xmin, Ymin, Math.Abs(Xmax - Xmin), Math.Abs(Ymax - Ymin)));
        }

        private void DrawPolygon(Polygon polygon)
        {
            for (int i = 0; i < polygon.LinesList.Count - 1; i++)
            {
                int xl = polygon.LinesList[i].xl;
                int xr = polygon.LinesList[i].xr;
                int y = polygon.LinesList[i].y;

                g.DrawLine(CurrentPen, new Point(xl, y), new Point(xr, y));
            }
        }

        private void DrawCenter(Point center)
        {
            Pen pen = new Pen(Color.Red);
            g.DrawLine(pen, center.X - 2, center.Y - 2, center.X + 2, center.Y + 2);
            g.DrawLine(pen, center.X + 2, center.Y - 2, center.X - 2, center.Y + 2);
        }

        private void ClearPanel()
        {
            FigureList.Clear();
            g.Clear(drawingPanel.BackColor);
        }

        // Получение выбранного пользователем цвета из спец ДО
        private void ColorDialogBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
                currentColorPanel.BackColor = colorDialog.Color;
        }

        private void RedBtn_Click(object sender, EventArgs e) => currentColorPanel.BackColor = redBtn.BackColor;

        private void YellowBtn_Click(object sender, EventArgs e) => currentColorPanel.BackColor = yellowBtn.BackColor;

        private void GreenBtn_Click(object sender, EventArgs e) => currentColorPanel.BackColor = greenBtn.BackColor;

        private void BlueBtn_Click(object sender, EventArgs e) => currentColorPanel.BackColor = blueBtn.BackColor;

        private void WhiteBtn_Click(object sender, EventArgs e) => currentColorPanel.BackColor = whiteBtn.BackColor;


    }
}