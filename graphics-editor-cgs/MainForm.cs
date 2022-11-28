using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ToolTip = System.Windows.Forms.ToolTip;
using Button = System.Windows.Forms.Button;

namespace graphics_editor_cgs
{
    public partial class MainForm : Form
    {
        private Graphics g;
        private Bitmap myBitmap;

        private List<PointF> BezierPoints = new List<PointF>();
        private int countBezierPoints = 0;
        private List<PointF> LineSegmentPoints = new List<PointF>();
        private int countLineSegmentPoints = 0;

        private List<IFigure> FigureList = new List<IFigure>();
        private IFigure selectedFigure = null;

        private int[] SetQ = new int[] { -1, -1 };

        private int indexTMO = 0;
        private int indexFigure = 0;
        private int indexOperation = 0;

        private PointF mousePoint = new Point();
        private PointF rotateCenter = new Point();
        private float prevRotationAngle = 0;

        private int prevSelectedFigureIndex = -1;
        private int selectedFigureIndex = -1;

        private bool isSelectedFigure = false;
        private bool isMoveMode = false;
        private bool isResizeMode = false;
        private bool isRotateMode = false;

        private Color CurrentColor => currentColorPanel.BackColor;

        private PolygonTMO polygonTMO = new PolygonTMO();
        private int countSelectedFigures = 0;


        public MainForm()
        {
            InitializeComponent();
            myBitmap = new Bitmap(drawingPanel.Width, drawingPanel.Height);
            g = Graphics.FromImage(myBitmap);
            g.SmoothingMode = SmoothingMode.HighQuality;
            currentColorPanel.BackColor = Color.Black;
        }

        private void ClearPanel()
        {
            g.Clear(drawingPanel.BackColor);

            countSelectedFigures = 0;
            countBezierPoints = 0;
            countLineSegmentPoints = 0;

            FigureList.Clear();
            BezierPoints.Clear();
            LineSegmentPoints.Clear();

            selectedFigure = null;
            polygonTMO = new PolygonTMO();

            isSelectedFigure = false;
            isMoveMode = false;
            isResizeMode = false;
            isRotateMode = false;

            prevSelectedFigureIndex = -1;
            selectedFigureIndex = -1;

            drawingPanel.Image = myBitmap;
        }

        // Добавление фигуры = 1
        // Отрезок = 0
        private void SegmentBtn_Click(object sender, EventArgs e)
        {
            indexOperation = 0; // перенести в другой метод, где будет проверять индекс операции (если 4, то отключить)
            indexFigure = 0;
            tmoCb.Enabled = false;
        }
        // Прямая Безье = 1
        private void BezierBtn_Click(object sender, EventArgs e)
        {
            indexOperation = 0;
            indexFigure = 1;
            tmoCb.Enabled = false;
        }
        // Стрелка1 = 2
        private void Arrow1Btn_Click(object sender, EventArgs e)
        {
            indexOperation = 0;
            indexFigure = 2;
            tmoCb.Enabled = false;
        }
        // Стрелка2 = 3
        private void Arrow2Btn_Click(object sender, EventArgs e)
        {
            indexOperation = 0;
            indexFigure = 3;
            tmoCb.Enabled = false;
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
            foreach (IFigure f in FigureList)
            {
                DrawFigure(f);
            }
        }

        private void DrawFigure(IFigure f)
        {
            if (f.GetType() == typeof(Polygon))
                DrawPolygon((Polygon)f);
            else if (f.GetType() == typeof(BezierCurve))
                DrawBezier((BezierCurve)f);
            else if (f.GetType() == typeof(LineSegment))
                DrawLineSegment((LineSegment)f);
            else if (f.GetType() == typeof(PolygonTMO))
                DrawPolygonTMO((PolygonTMO)f);
        }

        private void drawingPanel_MouseClick(object sender, MouseEventArgs e)
        {
            //mousePoint = new Point(e.X, e.Y);
            //switch(indexOperation)
            //{
            //    case 0:

            //        break;
            //}
        }

        private void AddChosenFigure(PointF mP)
        {

        }

        private void DrawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new PointF(e.X, e.Y);
            // 0 - Добавление фигуры на сцену
            if (indexOperation == 0)
            {
                IFigure currentFigure;
                switch (indexFigure)
                {
                    case 0:
                        if (e.Button == MouseButtons.Left)
                        {
                            switch (countLineSegmentPoints)
                            {
                                case 0:
                                    LineSegmentPoints.Add(mousePoint);
                                    countLineSegmentPoints++;
                                    break;
                                case 1:
                                    LineSegmentPoints.Add(mousePoint);
                                    currentFigure = new LineSegment(LineSegmentPoints, CurrentColor);
                                    FigureList.Add(currentFigure);
                                    DrawLineSegment((LineSegment)currentFigure);
                                    countLineSegmentPoints = 0;
                                    LineSegmentPoints.Clear();
                                    break;
                            }
                        }
                        break;

                    case 1:
                        if (e.Button == MouseButtons.Left)
                        {
                            // g.DrawEllipse(new Pen(Color.Gray, 1), e.X - 2, e.Y - 2, 5, 5);
                            BezierPoints.Add(mousePoint); // mousePoint!!!
                            countBezierPoints++;
                        }
                        else if (e.Button == MouseButtons.Right)
                        {
                            if (countBezierPoints > 1)
                            {
                                currentFigure = Figures.Bezier(BezierPoints, countBezierPoints - 1, CurrentColor);
                                DrawBezier((BezierCurve)currentFigure);
                                FigureList.Add(currentFigure);
                                countBezierPoints = 0;
                                BezierPoints.Clear();
                            }
                        }
                        break;

                    case 2:
                        currentFigure = Figures.Arrow1(e.Location, CurrentColor);
                        FigureList.Add(currentFigure);
                        DrawPolygon((Polygon)currentFigure); break;
                    case 3:
                        currentFigure = Figures.Arrow2(e.Location, CurrentColor);
                        FigureList.Add(currentFigure);
                        DrawPolygon((Polygon)currentFigure); break;
                }
            }
            // Выделение
            else if (indexOperation == 1)
            {
                prevSelectedFigureIndex = selectedFigureIndex;
                selectedFigureIndex = FindSelectedFigure(e.Location); // mousePoint

                if (e.Button == MouseButtons.Right)
                {
                    rotateCenter = e.Location;
                    DrawCenter(rotateCenter);
                    isRotateMode = true;
                    rotationTb.Enabled = true;
                }

                if (e.Button == MouseButtons.Left)
                {
                    isRotateMode = false;
                    // Если до этого была уже выделена фигура
                    if (prevSelectedFigureIndex != -1)
                    {
                        // то перерисовываем об-ть рис-я без выделения
                        UpdateDrawingPanel();
                        if (FigureList[prevSelectedFigureIndex].CheckResize(e.X, e.Y)) isResizeMode = true;
                        else isResizeMode = false;
                    }
                    if (selectedFigureIndex != -1)
                    {
                        selectedFigure = FigureList[selectedFigureIndex];
                        DrawSelection(selectedFigure);
                        isSelectedFigure = true;
                        isMoveMode = true;
                    }
                    else
                    {
                        isSelectedFigure = false;
                        isMoveMode = false;
                    }
                }
            }
            // ТМО
            else if (indexOperation == 4)
            {
                // Добавить проверку на тип выбранного элемента
                switch (countSelectedFigures)
                {
                    case 0:
                        int index = FindSelectedFigure(mousePoint);
                        if (index != -1)
                        {
                            DrawSelection(FigureList[index]);
                            polygonTMO.Polygon_1 = new Polygon((Polygon)FigureList[index]);
                            FigureList.RemoveAt(index);
                            countSelectedFigures++;
                        }
                        break;
                    case 1:
                        index = FindSelectedFigure(mousePoint);
                        if (index != -1)
                        {
                            DrawSelection(FigureList[index]);
                            polygonTMO.Polygon_2 = new Polygon((Polygon)FigureList[index]);
                            FigureList.RemoveAt(index);
                            if (SetQ[0] != -1)
                            {
                                polygonTMO.SetQ = SetQ;
                                polygonTMO.MakeTMO();
                                polygonTMO.Color = CurrentColor;
                                FigureList.Add(polygonTMO);
                                UpdateDrawingPanel();
                            }
                            countSelectedFigures = 0;
                            polygonTMO = new PolygonTMO();
                        }
                        break;
                }
            }
            drawingPanel.Image = myBitmap;
        }

        

        private void DrawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
           
            if (isResizeMode && prevSelectedFigureIndex != -1)
            {
                FigureList[prevSelectedFigureIndex].Resize(e.Location);
                UpdateDrawingPanel();
                DrawCenter(FigureList[prevSelectedFigureIndex].Center());

            }

            if (isMoveMode)
            {
                FigureList[selectedFigureIndex].Move(e.X - mousePoint.X, e.Y - mousePoint.Y);
                //if (FigureList[selectedFigureIndex].GetType() == typeof(Polygon))
                //    ((Polygon)FigureList[selectedFigureIndex]).Fill();
                UpdateDrawingPanel();
            }
            mousePoint = e.Location;
            drawingPanel.Image = myBitmap;
        }

        private void DrawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isMoveMode = false;
            isResizeMode = false;
        }

        private void RotationTb_Scroll(object sender, EventArgs e)
        {
            if (isRotateMode && prevSelectedFigureIndex != -1)
            {
                float rotationAngle = (rotationAngleMode.Checked) ? 30f : rotationTb.Value - prevRotationAngle;

                //DrawPolygon(((PolygonTMO)FigureList[prevSelectedFigureIndex]).Polygon_1);
                //DrawPolygon(((PolygonTMO)FigureList[prevSelectedFigureIndex]).Polygon_2);
                FigureList[prevSelectedFigureIndex].Rotate(rotationAngle, rotateCenter);
                UpdateDrawingPanel();


                DrawCenter(rotateCenter);

            }
            prevRotationAngle = rotationTb.Value;
            drawingPanel.Image = myBitmap;
        }

        private void DrawLineSegment(LineSegment lineSegment)
        {
            g.DrawLine(new Pen(lineSegment.Color), lineSegment.VertexList[0], lineSegment.VertexList[1]);
        }

        //private bool CheckResize(float x, float y)
        //{
        //    //Figure selectedFigure = FigureList[selectedFigureIndex];
        //    float Xmin = FigureList[selectedFigureIndex].Min().X;
        //    float Xmax = FigureList[selectedFigureIndex].Min().X;
        //    float Yc = FigureList[selectedFigureIndex].Center().Y;
        //    return
        //        ((x >= Xmin - 10 && x <= Xmin + 4) || (x >= Xmax - 4 && x <= Xmax + 10))
        //        && (y >= Yc - 7 && y <= Yc + 7);
        //}

        private int FindSelectedFigure(PointF mouseClickPoint)
        {
            int index = -1;
            for (int i = 0; i < FigureList.Count; i++)
            {
                if (FigureList[i].Select(mouseClickPoint))
                {
                    index = i;
                }
            }
            return index;
        }

        private void DrawSelection(IFigure selectedFigure)
        {
            int Xmin = (int)selectedFigure.Min().X,
                Ymin = (int)selectedFigure.Min().Y;
            int Xmax = (int)selectedFigure.Max().X,
                Ymax = (int)selectedFigure.Max().Y;

            Pen pen = new Pen(Color.Gray);
            g.DrawRectangle(pen, new Rectangle(Xmax, (int)(selectedFigure.Center().Y - 3), 6, 6));
            g.DrawRectangle(pen, new Rectangle(Xmin - 6, (int)(selectedFigure.Center().Y - 3), 6, 6));
            pen.DashStyle = DashStyle.Dash; // штрихованная линия
            g.DrawRectangle(pen, new Rectangle(Xmin, Ymin, Xmax - Xmin, Ymax - Ymin));
        }

        private void DrawPolygon(Polygon polygon)
        {
            for (int i = 0; i < polygon.LinesList.Count - 1; i++)
            {
                float xl = polygon.LinesList[i].xl;
                float xr = polygon.LinesList[i].xr;
                float y = polygon.LinesList[i].y;

                g.DrawLine(new Pen(polygon.Color), new PointF(xl, y), new PointF(xr, y));
            }
        }

        private void DrawPolygonTMO(PolygonTMO polygon)
        {
            for (int i = 0; i < polygon.ResultLines.Count - 1; i++)
            {
                float xl = polygon.ResultLines[i].xl;
                float xr = polygon.ResultLines[i].xr;
                float y = polygon.ResultLines[i].y;

                g.DrawLine(new Pen(polygon.Color), new PointF(xl, y), new PointF(xr, y));
            }
        }

        // МБ ПЕРЕНЕСТИ ЭТИ МЕТОДЫ В КЛАССЫ 
        private void DrawBezier(BezierCurve bezierCurve)
        {
            for (int i = 0; i < bezierCurve.VertexList.Count - 1; i++)
            {
                g.DrawLine(new Pen(bezierCurve.Color), bezierCurve.VertexList[i], bezierCurve.VertexList[i + 1]);
            }

        }

        private void DrawCenter(PointF center)
        {
            //Pen pen1 = new Pen(Color.White);
            Pen pen2 = new Pen(Color.Red);
            g.DrawLine(pen2, center.X - 4, center.Y - 4, center.X + 4, center.Y + 4);
            g.DrawLine(pen2, center.X + 4, center.Y - 4, center.X - 4, center.Y + 4);
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

        private void BlackBtn_Click(object sender, EventArgs e) => currentColorPanel.BackColor = blackBtn.BackColor;


        private void SegmentBtn_MouseEnter(object sender, EventArgs e) => CreateToolTip(segmentBtn, "Отрезок");

        private void BezierBtn_MouseEnter(object sender, EventArgs e) => CreateToolTip(bezierBtn, "Кривая Безье");

        private void Arrow1Btn_MouseEnter(object sender, EventArgs e) => CreateToolTip(arrow1Btn, "Стрелка вправо");

        private void Arrow2Btn_MouseEnter(object sender, EventArgs e) => CreateToolTip(arrow2Btn, "Двунаправленная стрелка");

        private void SelectFigureBtn_MouseEnter(object sender, EventArgs e) => CreateToolTip(selectFigureBtn, "Выделить фигуру");

        private void DeleteFigureBtn_MouseEnter(object sender, EventArgs e) => CreateToolTip(deleteFigureBtn, "Удалить фигуру");

        private void ClearPanelBtn_MouseEnter(object sender, EventArgs e) => CreateToolTip(clearPanelBtn, "Очистить область рисования");

        /* Создание всплывающей подсказки при наведении на кнопку btn */
        private void CreateToolTip(Button btn, string text)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(btn, text);
        }

        
    }
}