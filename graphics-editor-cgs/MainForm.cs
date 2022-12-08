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
        private Bitmap buffer;

        private List<PointF> BezierPoints = new List<PointF>(); // Список опорных точек кривой Безье
        private List<PointF> LineSegmentPoints = new List<PointF>(); // Список вершин отрезка

        private List<Figure> FigureList = new List<Figure>(); // Список фигур, находящихся на сцене
        private Figure selectedFigure = null; // Выделенная фигура

        private int indexTMO = -1; // Индекс ТМО
        private int indexFigure = 0; // Индекс фигуры
        private int indexOperation = 0; // Индекс операции

        private PointF lastMouseClickPosition = new Point(); // Последняя позиция клика мыши
        private PointF rotateCenter = new Point(); // Центр вращения
        private float prevRotationAngle = 0; // Предыдущий угол вращения

        private int lastSelectedFigureIndex = -1; // Индекс предыдущей выделенной фигуры
        private int selectedFigureIndex = -1; // Индекс выделенной фигуры

        private bool isMoveMode = false; // Режим перемещения
        private bool isResizeMode = false; // Режим масштабирования
        private bool isRotateMode = false; // Режим вращения

        private Color CurrentColor => currentColorPanel.BackColor; // Выбранный цвет

        private PolygonTMO polygonTMO = new PolygonTMO(); // ТМО-фигура
        private int countOperands = 0; // Количество выделенных операндов для ТМО


        public MainForm()
        {
            InitializeComponent();
            buffer = new Bitmap(scene.Width, scene.Height);
            g = Graphics.FromImage(buffer);
            g.SmoothingMode = SmoothingMode.AntiAlias; // сглаживание
            currentColorPanel.BackColor = Color.Black;
            polygonTMO.Xmin_e = scene.Height;
            polygonTMO.Xmax_e = scene.Width;
        }

        // Очистка области рисования
        private void ClearScene()
        {
            g.Clear(scene.BackColor);

            countOperands = 0;

            FigureList.Clear();
            BezierPoints.Clear();
            LineSegmentPoints.Clear();

            selectedFigure = null;
            polygonTMO = new PolygonTMO(0, scene.Width);

            isMoveMode = false;
            isResizeMode = false;
            isRotateMode = false;

            lastSelectedFigureIndex = -1;
            selectedFigureIndex = -1;

            scene.Image = buffer;
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
            //indexOperation = 2;
            tmoCb.Visible = false;
            rotatoinControlsPanel.Visible = false;
            if (selectedFigureIndex != -1)
            {
                //FigureList.RemoveAt(selectedFigureIndex);
                FigureList.Remove(selectedFigure);
                selectedFigureIndex = -1;
                lastSelectedFigureIndex = -1;
                UpdateScene();
                scene.Image = buffer;
            }
        }

        // Кнопка очистки области рисования 
        private void ClearPanelBtn_Click(object sender, EventArgs e)
        {
            tmoCb.Visible = false;
            rotatoinControlsPanel.Visible = false;
            ClearScene();
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
            indexTMO = tmoCb.SelectedIndex;
        }

        // Перерисовка объектов на сцене
        private void UpdateScene()
        {
            g.Clear(scene.BackColor);
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

        // Построение отрезка
        private void BuildLineSegment(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (LineSegmentPoints.Count)
                {
                    case 0:
                        LineSegmentPoints.Add(lastMouseClickPosition);
                        break;
                    case 1:
                        LineSegmentPoints.Add(lastMouseClickPosition);
                        LineSegment segment = new LineSegment(LineSegmentPoints, CurrentColor);
                        FigureList.Add(segment);
                        DrawLineSegment(segment);
                        LineSegmentPoints.Clear();
                        break;
                }
            }
        }

        // Построение кривой Безье
        private void BuildBezierCurve(MouseEventArgs e)
        {
            // При ЛКМ добавляются опорные точки
            if (e.Button == MouseButtons.Left)
            {
                BezierPoints.Add(lastMouseClickPosition);
            }
            // При ПКМ строиться кривая
            else if (e.Button == MouseButtons.Right)
            {
                if (BezierPoints.Count > 1)
                {
                    BezierCurve curve = Figures.Bezier(BezierPoints, CurrentColor);
                    FigureList.Add(curve);
                    DrawBezier(curve);
                    BezierPoints.Clear();
                }
            }
        }

        // Построение стрелки 1 - стрелка вправо
        private void BuildArrow1(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Polygon arrow = Figures.Arrow1(lastMouseClickPosition, CurrentColor);
                FigureList.Add(arrow);
                DrawPolygon(arrow);
            }
        }

        // Построение стрелки 2 - двунаправленная стрелка
        private void BuildArrow2(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Polygon arrow = Figures.Arrow2(lastMouseClickPosition, CurrentColor);
                FigureList.Add(arrow);
                DrawPolygon(arrow);
            }
        }

        // Добавление выбранной фигуры на сцену
        private void AddChosenFigureToScene(MouseEventArgs e)
        {
            switch (indexFigure)
            {
                case 0: BuildLineSegment(e); break;
                case 1: BuildBezierCurve(e); break;
                case 2: BuildArrow1(e); break;
                case 3: BuildArrow2(e); break;
            }
        }

        // Выделение фигуры на цене
        private void SelectFigureOnScene(MouseEventArgs e)
        {
            lastSelectedFigureIndex = selectedFigureIndex;
            selectedFigureIndex = FindSelectedFigure(lastMouseClickPosition);
            UpdateScene();
            // При ПКМ активируется режим вращения и задается его центр
            if (e.Button == MouseButtons.Right)
            {
                // Если до этого была уже выделена фигура
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
            // При ЛКМ 
            if (e.Button == MouseButtons.Left)
            {
                // Если до этого была уже выделена фигура
                if (lastSelectedFigureIndex != -1)
                {
                    // Активация режима масштабирования
                    if (CheckResize(lastSelectedFigureIndex, e.Location))
                        isResizeMode = true; 
                    else isResizeMode = false;
                }
                // Если сейчас была выделена фигура
                if (selectedFigureIndex != -1)
                {
                    selectedFigure = FigureList[selectedFigureIndex];
                    DrawSelection(selectedFigureIndex);
                    isMoveMode = true; // активация режима перемещения
                }
                else
                    isMoveMode = false;
            }
        }

        // Построение ТМО-фигуры
        private void BuildPolygonTMO()
        {
            switch (countOperands)
            {
                case 0:
                    int index = FindSelectedFigure(lastMouseClickPosition);
                    // Если был выделен многоугольник
                    if (index != -1 && FigureList[index].GetType() == typeof(Polygon))
                    {
                        DrawSelection(index);
                        polygonTMO.Polygon_1 = new Polygon((Polygon)FigureList[index]);
                        FigureList.RemoveAt(index);
                        countOperands++;
                    }
                    break;
                case 1:
                    index = FindSelectedFigure(lastMouseClickPosition);
                    if (index != -1 && FigureList[index].GetType() == typeof(Polygon))
                    {
                        DrawSelection(index);
                        polygonTMO.Polygon_2 = new Polygon((Polygon)FigureList[index]);
                        FigureList.RemoveAt(index);
                        // Выполнение ТМО 
                        polygonTMO.IndexTMO = indexTMO;
                        polygonTMO.MakeTMO();
                        polygonTMO.Color = CurrentColor;
                        FigureList.Add(polygonTMO);
                        UpdateScene();

                        countOperands = 0;
                        polygonTMO = new PolygonTMO(0, scene.Width);
                    }
                    break;
            }
        }

        // Обработчик нажатия кнопки мыши по области рисования
        private void DrawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastMouseClickPosition = new PointF(e.X, e.Y);
            // Проверка операции
            switch (indexOperation)
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
            scene.Image = buffer;
        }

        // Обработчик движения курсора мыши по области рисования
        private void DrawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            // Если включен режим масштабирования
            if (isResizeMode && lastSelectedFigureIndex != -1)
            {
                FigureList[lastSelectedFigureIndex].Resize(e.Location);
                UpdateScene();
                DrawCenter(FigureList[lastSelectedFigureIndex].Center);
                DrawSelection(lastSelectedFigureIndex);
            }
            // Если включен режим перемещения
            if (isMoveMode)
            {
                FigureList[selectedFigureIndex].Move(e.X - lastMouseClickPosition.X, e.Y - lastMouseClickPosition.Y);
                UpdateScene();
            }
            lastMouseClickPosition = e.Location;
            scene.Image = buffer;
        }

        // Обработчик отпускания кнопки мыши
        private void DrawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isMoveMode = false;
            isResizeMode = false;

            if (indexOperation == 0) UpdateScene();

            if (selectedFigureIndex != -1)
                DrawSelection(selectedFigureIndex);
            scene.Image = buffer;
        }

        // Обработчик движения ползунка
        private void RotationTb_Scroll(object sender, EventArgs e)
        {
            if (isRotateMode)
            {
                float rotationAngle = (rotationAngleMode.Checked) ? 30f : rotationTb.Value - prevRotationAngle;

                FigureList[lastSelectedFigureIndex].Rotate(rotationAngle, rotateCenter);
                UpdateScene();

                DrawCenter(rotateCenter);
                DrawSelection(lastSelectedFigureIndex);

            }
            prevRotationAngle = rotationTb.Value;
            scene.Image = buffer;
        }

        // Рисование отрезка
        private void DrawLineSegment(LineSegment lineSegment)
        {
            g.DrawLine(new Pen(lineSegment.Color), lineSegment.VertexList[0], lineSegment.VertexList[1]);
        }

        // Рисование многоугольника
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
        // Рисование ТМО-фигуры
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
        // Рисование кривой Безье
        private void DrawBezier(BezierCurve bezierCurve)
        {
            for (int i = 0; i < bezierCurve.VertexList.Count - 1; i++)
            {
                g.DrawLine(new Pen(bezierCurve.Color), bezierCurve.VertexList[i], bezierCurve.VertexList[i + 1]);
            }

        }
        // Рисование центра - красный крестик
        private void DrawCenter(PointF center)
        {
            //Pen pen1 = new Pen(Color.White);
            Pen pen2 = new Pen(Color.Red);
            g.DrawLine(pen2, center.X - 4, center.Y - 4, center.X + 4, center.Y + 4);
            g.DrawLine(pen2, center.X + 4, center.Y - 4, center.X - 4, center.Y + 4);
        }

        // Рисование знака выделения - прямоугольник с квадратиками для масштабирования
        private void DrawSelection(int index)
        {
            Figure selectedFigure = FigureList[index];
            int Xmin = (int)selectedFigure.Min.X,
                Ymin = (int)selectedFigure.Min.Y;
            int Xmax = (int)selectedFigure.Max.X,
                Ymax = (int)selectedFigure.Max.Y;

            // Рисование квадратиков для масштабирования
            Pen pen = new Pen(Color.Gray);
            g.DrawRectangle(pen, new Rectangle(Xmax, (int)(selectedFigure.Center.Y - 3), 6, 6));
            g.DrawRectangle(pen, new Rectangle(Xmin - 6, (int)(selectedFigure.Center.Y - 3), 6, 6));
            // Рисование прямоугольника выделения
            pen.DashStyle = DashStyle.Dash; // штрихованная линия
            g.DrawRectangle(pen, new Rectangle(Xmin, Ymin, Xmax - Xmin, Ymax - Ymin));
        }

        // Проверка попадания в один из квадратиком масштабирования
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

        // Поиск выделенной фигуры
        private int FindSelectedFigure(PointF mouseClickPoint)
        {
            int index = -1;
            for (int i = 0; i < FigureList.Count; i++)
            {
                if (FigureList[i].Select(mouseClickPoint))
                    index = i;
            }
            return index;
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