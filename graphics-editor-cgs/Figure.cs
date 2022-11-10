using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor_cgs
{
    // Фигура (многоугольник)
    public class Figure
    {
        public List<Point> VertexList { get; set;}


        public Figure(List<Point> vertexList)
        {
            VertexList = vertexList;
        }

        public Figure()
        {
            VertexList = new List<Point>();
        }
        // Перемещение
        public void Move()
        {

        }
        // Масштабирование
        public void Zoom()
        {

        }
        // Поворот
        public void Rotate()
        {

        }

        // Закрашивание фигуры и ее вывод? - разбить на 2 метода
        public void Fill()
        {

        }
        // Выделение фигуры
        public bool Select()
        {
            return true;
        }

        // Центр фигуры
        public Point Center()
        {
            Point center = new Point();
            return center;
        }
    }
}
