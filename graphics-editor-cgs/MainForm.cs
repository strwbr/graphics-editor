using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Drawing.Drawing2D;
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

        private List<Figure> FigureList = new List<Figure>();
        private Figure selectedFigure = null;

        private int indexTMO = -1;
        private int indexFigure = 0;
        private int indexOperation = 0;

        private PointF lastMouseClickPosition = new Point();
        private PointF rotateCenter = new Point();
        private float prevRotationAngle = 0;

        private int lastSelectedFigureIndex = -1;
        private int selectedFigureIndex = -1;

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
            g.SmoothingMode = SmoothingMode.AntiAlias;
            currentColorPanel.BackColor = Color.Black;
            polygonTMO.Xmin_e = drawingPanel.Height;
            polygonTMO.Xmax_e = drawingPanel.Width;
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
            polygonTMO = new PolygonTMO(0, drawingPanel.Width);

            //isSelectedFigure = false;
            isMoveMode = false;
            isResizeMode = false;
            isRotateMode = false;

            lastSelectedFigureIndex = -1;
            selectedFigureIndex = -1;

            drawingPanel.Image = myBitmap;
        }

        // Добавление фигуры = 1
        // Отрезок = 0
        private void SegmentBtn_Click(object sender, EventArgs e)
        {
            indexOperation = 0; // перенести в другой метод, где будет проверять индекс операции (если 4, то отключить)
            indexFigure = 0;
            tmoCb.Visible = false;
            rotatoinControlsPanel.Visible = false;
        }
        // Прямая Безье = 1
        private void BezierBtn_Click(object sender, EventArgs e)
        {
            indexOperation = 0;
            indexFigure = 1;
            tmoCb.Visible = false;
            rotatoinControlsPanel.Visible = false;
        }
        // Стрелка1 = 2
        private void Arrow1Btn_Click(object sender, EventArgs e)
        {
            indexOperation = 0;
            indexFigure = 2;
            tmoCb.Visible = false;
            rotatoinControlsPanel.Visible = false;
        }
        // Стрелка2 = 3
        private void Arrow2Btn_Click(object sender, EventArgs e)
        {
            indexOperation = 0;
            indexFigure = 3;
            tmoCb.Visible = false;
            rotatoinControlsPanel.Visible = false;
        }

        // Выделение фигуры = 1
        private void SelectFigureBtn_Click(object sender, EventArgs e)
        {
            indexOperation = 1;
            tmoCb.Visible = false;
            rotatoinControlsPanel.Visible = false;
        }

        // Удаление фигуры
        private void DeleteFigureBtn_Click(object sender, EventArgs e)
        {
            indexOperation = 2;
            tmoCb.Visible = false;
            rotatoinControlsPanel.Visible = false;
            if (selectedFigureIndex != -1)
            {
                //FigureList.RemoveAt(selectedFigureIndex);
                FigureList.Remove(selectedFigure);
                selectedFigureIndex = -1;
                lastSelectedFigureIndex = -1;
                UpdateScene();
                drawingPanel.Image = myBitmap;
            }
        }

        private void ClearPanelBtn_Click(object sender, EventArgs e)
        {
            tmoCb.Visible = false;
            rotatoinControlsPanel.Visible = false;
            ClearPanel();
        }

        // ТМО = 2
        private void TmoBtn_Click(object sender, EventArgs e)
        {
            tmoCb.Visible = true;
            indexOperation = 2;
        }

        // Выбор ТМО
        private void TmoCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tmoCb.SelectedIndex)
            {
                case 0: // Сим разность
                    indexTMO = 0;
                    break;
                case 1: // Разность А/В
                    indexTMO = 1;
                    break;
                case 2: // Разность В/А
                    indexTMO = 2;
                    break;
            }
        }

        // Перерисовка объектов на сцене (обозначение выделения и центра не перерисовываются)
        private void UpdateScene()
        {
            g.Clear(drawingPanel.BackColor);
            foreach (Figure f in FigureList)
            {
                DrawFigure(f);
            }
        }

        // Рисование фигуры
        private void DrawFigure(Figure f)
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

        private void BuildLineSegment(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (countLineSegmentPoints)
                {
                    case 0:
                        LineSegmentPoints.Add(lastMouseClickPosition);
                        countLineSegmentPoints++;
                        break;
                    case 1:
                        LineSegmentPoints.Add(lastMouseClickPosition);
                        LineSegment segment = new LineSegment(LineSegmentPoints, CurrentColor);
                        FigureList.Add(segment);
                        DrawLineSegment(segment);
                        countLineSegmentPoints = 0;
                        LineSegmentPoints.Clear();
                        break;
                }
            }
        }

        private void BuildBezierCurve(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BezierPoints.Add(lastMouseClickPosition); // mousePoint!!!
                countBezierPoints++;
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (countBezierPoints > 1)
                {
                    BezierCurve curve = Figures.Bezier(BezierPoints, countBezierPoints - 1, CurrentColor);
                    FigureList.Add(curve);
                    DrawBezier(curve);
                    countBezierPoints = 0;
                    BezierPoints.Clear();
                }
            }
        }

        private void BuildArrow1(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Polygon arrow = Figures.Arrow1(lastMouseClickPosition, CurrentColor);
                FigureList.Add(arrow);
                DrawPolygon(arrow);
            }
        }

        private void BuildArrow2(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Polygon arrow = Figures.Arrow2(lastMouseClickPosition, CurrentColor);
                FigureList.Add(arrow);
                DrawPolygon(arrow);
            }
        }

        private void AddChosenFigureToScene(MouseEventArgs e)
        {
            switch (indexFigure)
            {
                case 0:
                    BuildLineSegment(e);
                    break;
                case 1:
                    BuildBezierCurve(e);
                    break;
                case 2:
                    BuildArrow1(e);
                    break;
                case 3:
                    BuildArrow2(e);
                    break;
            }
        }

        private void SelectFigureOnScene(MouseEventArgs e)
        {
            lastSelectedFigureIndex = selectedFigureIndex;
            selectedFigureIndex = FindSelectedFigure(lastMouseClickPosition);
            UpdateScene();
            if (e.Button == MouseButtons.Right)
            {
                if (lastSelectedFigureIndex != -1)
                {
                    rotateCenter = e.Location;

                    //UpdateScene();
                    DrawSelection(lastSelectedFigureIndex);
                    DrawCenter(rotateCenter);
                    isRotateMode = true;
                    rotatoinControlsPanel.Visible = true;
                    rotationTb.Value = 0;
                    prevRotationAngle = 0;
                }
            }

            if (e.Button == MouseButtons.Left)
            {
                //isRotateMode = false;

                // Если до этого была уже выделена фигура
                if (lastSelectedFigureIndex != -1)
                {
                    if (CheckResize(lastSelectedFigureIndex, e.Location))
                        isResizeMode = true; // тут происходит что-то странное (вроде исправила лол)
                    else isResizeMode = false;
                }
                if (selectedFigureIndex != -1)
                {
                    selectedFigure = FigureList[selectedFigureIndex];
                    //UpdateScene();
                    DrawSelection(selectedFigureIndex);
                    //isSelectedFigure = true;
                    isMoveMode = true;
                }
                else
                {
                    //isSelectedFigure = false;
                    isMoveMode = false;
                }
            }
        }

        private void BuildPolygonTMO()
        {
            switch (countSelectedFigures)
            {
                case 0:
                    int index = FindSelectedFigure(lastMouseClickPosition);
                    if (index != -1 && FigureList[index].GetType() == typeof(Polygon))
                    {
                        DrawSelection(index);
                        polygonTMO.Polygon_1 = new Polygon((Polygon)FigureList[index]);
                        FigureList.RemoveAt(index);
                        countSelectedFigures++;
                    }
                    break;
                case 1:
                    index = FindSelectedFigure(lastMouseClickPosition);
                    if (index != -1 && FigureList[index].GetType() == typeof(Polygon))
                    {
                        DrawSelection(index);
                        polygonTMO.Polygon_2 = new Polygon((Polygon)FigureList[index]);
                        FigureList.RemoveAt(index);

                        polygonTMO.IndexTMO = indexTMO;
                        polygonTMO.MakeTMO();
                        polygonTMO.Color = CurrentColor;
                        FigureList.Add(polygonTMO);
                        UpdateScene();

                        countSelectedFigures = 0;
                        polygonTMO = new PolygonTMO(0, drawingPanel.Width);
                    }
                    break;
            }
        }

        private void DrawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastMouseClickPosition = new PointF(e.X, e.Y);
            switch(indexOperation)
            {
                case 0: AddChosenFigureToScene(e); break;
                case 1: SelectFigureOnScene(e); break;
                case 2:
                    lastSelectedFigureIndex = -1;
                    selectedFigureIndex = -1;

                    if (indexTMO != -1)
                        BuildPolygonTMO();
                    else MessageBox.Show("Выберите тип ТМО", "Не выбран тип ТМО",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
            
            //// 0 - Добавление фигуры на сцену
            //if (indexOperation == 0)
            //{
            //    AddChosenFigureToScene(e);
            //}
            //// 1 - Выделение
            //else if (indexOperation == 1)
            //{
            //    SelectFigureOnScene(e);
            //}
            //// 2 - ТМО
            //else if (indexOperation == 2)
            //{
            //    lastSelectedFigureIndex = -1;
            //    selectedFigureIndex = -1;

            //    if (indexTMO != -1)
            //        BuildPolygonTMO();
            //    else MessageBox.Show("Выберите тип ТМО", "Не выбран тип ТМО",
            //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            drawingPanel.Image = myBitmap;
        }

        private void DrawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isResizeMode && lastSelectedFigureIndex != -1)
            {
                FigureList[lastSelectedFigureIndex].Resize(e.Location);
                UpdateScene();
                DrawCenter(FigureList[lastSelectedFigureIndex].Center);
                //DrawSelection(lastSelectedFigureIndex);
                //DrawSelection(FigureList[lastSelectedFigureIndex]);
            }

            if (isMoveMode)
            {
                FigureList[selectedFigureIndex].Move(e.X - lastMouseClickPosition.X, e.Y - lastMouseClickPosition.Y);
                //if (FigureList[selectedFigureIndex].GetType() == typeof(Polygon))
                //    ((Polygon)FigureList[selectedFigureIndex]).Fill();
                UpdateScene();
            }
            lastMouseClickPosition = e.Location;
            drawingPanel.Image = myBitmap;
        }

        private void DrawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isMoveMode = false;
            isResizeMode = false;

            if (indexOperation == 0) UpdateScene();

            if (selectedFigureIndex != -1)
                DrawSelection(selectedFigureIndex);
            //DrawSelection(FigureList[selectedFigureIndex]);
            drawingPanel.Image = myBitmap;

            //if (rotateCenter != null)
            //    DrawCenter(rotateCenter);

        }

        private void RotationTb_Scroll(object sender, EventArgs e)
        {
            if (isRotateMode /*&& lastSelectedFigureIndex != -1*/)
            {
                float rotationAngle = (rotationAngleMode.Checked) ? 30f : rotationTb.Value - prevRotationAngle;

                FigureList[lastSelectedFigureIndex].Rotate(rotationAngle, rotateCenter);
                UpdateScene();


                DrawCenter(rotateCenter);
                //DrawSelection(FigureList[lastSelectedFigureIndex]);
                DrawSelection(lastSelectedFigureIndex);

            }
            prevRotationAngle = rotationTb.Value;
            drawingPanel.Image = myBitmap;
        }

        private void DrawLineSegment(LineSegment lineSegment)
        {
            g.DrawLine(new Pen(lineSegment.Color), lineSegment.VertexList[0], lineSegment.VertexList[1]);
        }

        private bool CheckResize(int index, PointF p)
        {
            Figure selected = FigureList[index];
            float Xmin = selected.Min.X;
            float Xmax = selected.Max.X;
            float Yc = selected.Center.Y;
            return
                ((p.X >= Xmin - 10 && p.X <= Xmin + 4) || (p.X >= Xmax - 4 && p.X <= Xmax + 10))
                && (p.Y >= Yc - 7 && p.Y <= Yc + 7);
        }

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

        private void DrawSelection(int index)
        {
            Figure selectedFigure = FigureList[index];
            int Xmin = (int)selectedFigure.Min.X,
                Ymin = (int)selectedFigure.Min.Y;
            int Xmax = (int)selectedFigure.Max.X,
                Ymax = (int)selectedFigure.Max.Y;

            Pen pen = new Pen(Color.Gray);
            g.DrawRectangle(pen, new Rectangle(Xmax, (int)(selectedFigure.Center.Y - 3), 6, 6));
            g.DrawRectangle(pen, new Rectangle(Xmin - 6, (int)(selectedFigure.Center.Y - 3), 6, 6));
            pen.DashStyle = DashStyle.Dash; // штрихованная линия
            g.DrawRectangle(pen, new Rectangle(Xmin, Ymin, Xmax - Xmin, Ymax - Ymin));
        }

        private void DrawPolygon(Polygon polygon)
        {
            for (int i = 0; i < polygon.LinesList.Count - 1; i++)
            {
                float xl = polygon.LinesList[i].Xl;
                float xr = polygon.LinesList[i].Xr;
                float y = polygon.LinesList[i].Y;

                g.DrawLine(new Pen(polygon.Color), new PointF(xl, y), new PointF(xr, y));
            }
        }

        private void DrawPolygonTMO(PolygonTMO polygon)
        {
            for (int i = 0; i < polygon.ResultLines.Count - 1; i++)
            {
                float xl = polygon.ResultLines[i].Xl;
                float xr = polygon.ResultLines[i].Xr;
                float y = polygon.ResultLines[i].Y;

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