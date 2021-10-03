using System;
using System.Drawing;
using System.Collections.Generic;

namespace Tanks
{
    class Party
    {
        private readonly Random random = new Random();
        private readonly int width = Tanks.window.Width;
        private readonly int height = Tanks.window.Height;
        public List<object> ListUnits = new List<object>();
        private ushort range; //разброс на старте

        /// <summary> Команда : без параметров (случайно). </summary>
        public Party()
        {
            Color color = Color.FromArgb(255, Color.FromArgb(random.Next(0xFFFFFF + 1)));
            Point start = new Point(random.Next(80) + 10, random.Next(80) + 10);
            byte unit = (byte)random.Next(8);
            range = 256;
            NewParty(color, start, unit, unit);
        }

        /// <summary> Команда : цвет флага, число танков/машин. </summary>
        public Party(Color color, byte unit)
        {
            Point start = new Point(random.Next(80)+10, random.Next(80)+10);
            range = 256;
            NewParty(color, start, unit, unit);
        }

        /// <summary> Команда : цвет флага, стартовая позиция(X,Y) в %, число танков/машин. </summary>
        public Party(Color color, Point start, byte unit)
        {
            range = 128;
            NewParty(color, start, unit, unit);
        }

        /// <summary> Команда : цвет флага, стартовая позиция(X,Y) в %, число танков, число машин. </summary>
        public Party(Color color, Point start, byte tank, byte car)
        {
            range = 128;
            NewParty(color, start, tank, car);
        }

        //Отрисовываем юнитов по списку
        public void DrawListUnits(Graphics g)
        {
            foreach (dynamic unit in ListUnits)
                unit.DrawUnit(g, unit.color);
        }

        //Новая команда
        private void NewParty(Color color, Point start, byte tank, byte car)
        {
            for (byte i = 0; i < tank; i++)
                NewUnit(new Tank(color), start);

            for (byte i = 0; i < car; i++)
                NewUnit(new Car(color), start);
        }

        //Добавляем юнита в список
        private void NewUnit(dynamic unit, Point start)
        {
            ListUnits.Add(unit);
            unit.position = Start(start);
            unit.target = new Point(width / 2, height / 2);
            unit.vector = (float)(unit.Vector() * 180 / Math.PI + 90) + random.Next(-16, 16);
            if (unit.vector < 0) unit.vector += 360;
            unit.vectorTower = unit.vector + random.Next(-16, 16);
        }

        //Начальная случайная позиция
        private PointF Start(Point point)
        {
            if (range <= 0) range = 256;
            point.X = width * point.X / 100 + random.Next(-range, range);
            point.Y = height * point.Y / 100 + random.Next(-range, range);

            return point;
        }
    }
}