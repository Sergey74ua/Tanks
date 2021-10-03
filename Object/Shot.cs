using System.Drawing;

namespace Tanks
{
    class Shot : AObject
    {
        public PointF _position;    //хвост снаряда
        private readonly Pen pen;   //перо для снаряда (для пулеметов можно сделать другой)

        /// <summary>
        /// Выстрел : рассчитывается из объекта.
        /// </summary>
        public Shot(dynamic unit)
        {
            color = unit.color;
            pen = new Pen(ColorShot(color), 3);
            position = unit.position;
            target = unit.target;
            vector = Vector();
            speed = 16.0f;
            Sound.Shot();
        }

        //Цвет выстрела
        private Color ColorShot(Color color)
        {
            color = Color.FromArgb
            (
                color.R + (255 - color.R) / 4,
                color.G + (255 - color.G) / 8,
                color.B + (255 - color.B) / 4
            );

            return color;
        }

        //Рассчет полета снаряда
        public void Move()
        {
            timeAction++;
            _position = position;
            position = Position();
            speed *= 0.98f;
        }

        //Отрисовка снаряда
        public void DrawShot(Graphics g)
        {
            g.DrawLine(pen, position, _position);
        }
    }
}