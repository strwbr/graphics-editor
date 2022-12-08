using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor_cgs
{
    public interface Figure
    {
        List<PointF> VertexList { get; set; } // Список вершин
        Color Color { get; set; } // Цвет фигуры
        PointF Center { get; } // Центр фигуры
        PointF Min { get; } // Минимальная точка фигуры
        PointF Max { get; } // Максимальной точка фигуры

        bool Select(PointF p); // Проверка выделения фигуры
        void Move(float dx, float dy); // Плоскопараллельное перемещение
        void Resize(PointF mP); // Масштабирование относительно фентра фигуры по оси Х
        void Rotate(float angle, PointF center); // Вращение относительно заданного центра на угол angle
    }
}
