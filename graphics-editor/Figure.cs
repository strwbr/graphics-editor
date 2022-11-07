using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor
{
    public class Figure
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }
        public List<Point> Points { get; set; } // вынести в еще один класс, к-ый будет наследоваться от Figure
        public bool Checked { get; set; } // выделена ли фигура

        public Figure()
        {
            Points = new List<Point>();
        }

        public Figure(int x, int y, List<Point> points, Color color)
        {
            X = x;
            Y = y;
            Points = points;
            Color = color;
        }

        public Figure(Figure figure)
        {
            X = figure.X;
            Y = figure.Y;
            Points = new List<Point>();
            foreach (Point p in figure.Points)// мб здесь неглубокое копирование
            {
                Points.Add(p);
            }
            Color = figure.Color;
        }
    }
}
