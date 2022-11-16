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
        List<Point> BezierPoints = new List<Point>();
        int countBezierPoints = 0;

        List<Figure> FigureList = new List<Figure>();
        List<Figure> SelectedFiguresList = new List<Figure>();
        Figure selectedFigure = null;

        private int[] SetQ = new int[] { -1, -1 };

        private int indexTMO = 0;
        private int indexFigure = 0;
        private int indexOperation = 0;

        private Point mousePoint = new Point();

        private int prevSelectedFigureIndex = -1;
        private int selectedFigureIndex = -1;

        private bool isSelectedFigure = false;
        private bool isResizeMode = false;

        private Color CurrentColor => currentColorPanel.BackColor;
        private Pen CurrentPen => new Pen(CurrentColor);


        public Form1()
        {
            InitializeComponent();
            myBitmap = new Bitmap(drawingPanel.Width, drawingPanel.Height);
            g = Graphics.FromImage(myBitmap);
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
        private void DeleteFigureBtn_Click(object sender, EventArgs e)
        {
            indexOperation = 2;
            if (isSelectedFigure)
            {
                //FigureList.RemoveAt(selectedFigureIndex);
                FigureList.Remove(selectedFigure);
                UpdateDrawingPanel();
                drawingPanel.Image = myBitmap;
            }
        }

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

        private void UpdateDrawingPanel()
        {
            g.Clear(drawingPanel.BackColor);
            foreach (Figure f in FigureList)
            {
                if (f.GetType() == typeof(Polygon))
                {
                    DrawPolygon((Polygon)f);
                }
                else
                    DrawBezier((BezierCurve)f);
            }
        }

        private void DrawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
            if (indexOperation == 0)
            {
                Figure currentFigure;
                switch (indexFigure)
                {
                    case 0: debugLabel.Text = $"indexFigure = {indexFigure}"; break;
                    case 1:
                        if (e.Button == MouseButtons.Left)
                        {
                            // g.DrawEllipse(new Pen(Color.Gray, 1), e.X - 2, e.Y - 2, 5, 5);
                            BezierPoints.Add(e.Location);
                            countBezierPoints++;
                        }
                        else if (e.Button == MouseButtons.Right)
                        {
                            if (countBezierPoints > 1)
                            {
                                currentFigure = Figures.Bezier(BezierPoints, countBezierPoints - 1);
                                DrawBezier((BezierCurve)currentFigure);
                                FigureList.Add(currentFigure);
                                countBezierPoints = 0;
                                BezierPoints.Clear();
                            }
                        }
                        break;

                    case 2:
                        currentFigure = Figures.Arrow1(e.Location);
                        FigureList.Add(currentFigure);
                        DrawPolygon((Polygon)currentFigure); break;
                    case 3:
                        currentFigure = Figures.Arrow2(e.Location);
                        FigureList.Add(currentFigure);
                        DrawPolygon((Polygon)currentFigure); break;
                }
            }
            // Выделение
            else if (indexOperation == 1)
            {
                prevSelectedFigureIndex = selectedFigureIndex;
                selectedFigureIndex = FindSelectedFigure(e.Location);
                // Если до этого была уже выделена фигура
                if (prevSelectedFigureIndex != -1)
                {
                    // то перерисовываем об-ть рис-я без выделения
                    UpdateDrawingPanel();
                }
                if (selectedFigureIndex != -1)
                {
                    selectedFigure = FigureList[selectedFigureIndex];
                    DrawSelection(selectedFigure);
                    isSelectedFigure = true;
                    if (CheckResize(e.X, e.Y)) isResizeMode = true;
                    else isResizeMode = false;
                }
                else isSelectedFigure = false;
            }
            drawingPanel.Image = myBitmap;
        }


        private void DrawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.Location.X;
            int y = e.Location.Y;

            if (indexOperation == 1)
            {
                if (selectedFigureIndex != -1)
                {
                    selectedFigure.Move(x - mousePoint.X);
                }

                ////Cursor.Current = Cursors.SizeWE;
                //if (isResizeMode)
                //{
                //    selectedFigure.Zoom();
                //}
                UpdateDrawingPanel();
                // отрисовавать фигуру заново!!!!!!!!!!!!
                //DrawSelection(selectedFigure);
                drawingPanel.Image = myBitmap;

            }

            Cursor.Current = Cursors.Default;
            mousePoint = new Point(x, y);
        }

        private void drawingPanel_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private bool CheckResize(int x, int y)
        {
            //Figure selectedFigure = FigureList[selectedFigureIndex];
            int Xmin = selectedFigure.Pmin.X;
            int Xmax = selectedFigure.Pmax.X;
            int Yc = selectedFigure.Center().Y;
            return
                ((x >= Xmin - 10 && x <= Xmin + 4) || (x >= Xmax - 4 && x <= Xmax + 10))
                && (y >= Yc - 7 && y <= Yc + 7);
        }

        private int FindSelectedFigure(Point mouseClickPoint)
        {
            int index = -1;
            for (int i = 0; i < FigureList.Count; i++)
            {
                if (FigureList[i].GetType() == typeof(Polygon))
                {
                    if (((Polygon)(FigureList[i])).Select(mouseClickPoint))
                    {
                        index = i;
                    }
                }
            }
            return index;
        }

        private void DrawSelection(Figure selectedFigure)
        {
            int Xmin = selectedFigure.Pmin.X,
                Ymin = selectedFigure.Pmin.Y;
            int Xmax = selectedFigure.Pmax.X,
                Ymax = selectedFigure.Pmax.Y;

            Pen pen = new Pen(Color.Gray);
            g.DrawRectangle(pen, new Rectangle(Xmax, selectedFigure.Center().Y - 3, 6, 6));
            g.DrawRectangle(pen, new Rectangle(Xmin - 6, selectedFigure.Center().Y - 3, 6, 6));
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash; // штрихованная линия
            g.DrawRectangle(pen, new Rectangle(Xmin, Ymin, Xmax - Xmin, Ymax - Ymin));
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

        // МБ ПЕРЕНЕСТИ ЭТИ МЕТОДЫ В КЛАССЫ 
        private void DrawBezier(BezierCurve bezierCurve)
        {
            for (int i = 0; i < bezierCurve.VertexList.Count - 1; i++)
            {
                g.DrawLine(CurrentPen, bezierCurve.VertexList[i], bezierCurve.VertexList[i + 1]);
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
            g.Clear(drawingPanel.BackColor);
            FigureList.Clear();
            BezierPoints.Clear();
            countBezierPoints = 0;
            drawingPanel.Image = myBitmap;

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