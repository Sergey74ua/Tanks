using System;
using System.Drawing;

namespace Tanks
{
    abstract class AObject
    {
        public Color color;     //команда
        public PointF position; //позиция
        public PointF target;   //цель
        public float vector;    //вектор
        public float speed;     //скорость
        public uint timeAction; //таймер

        private float catetX, catetY;

        //Рассчет координат при перемещении
        public PointF Position()
        {
            position.X += speed * (float)Math.Cos(vector);
            position.Y += speed * (float)Math.Sin(vector);

            return position;
        }

        //Рассчет угла на цель
        public float Vector()
        {
            float vector = (float)Math.Atan2(target.Y - position.Y, target.X - position.X);

            return vector;
        }

        // Рассчет расстояния до цели (откуда X/Y, куда X/Y)
        public float Delta(PointF position, PointF target)
        {
            catetX = target.X - position.X;
            catetY = target.Y - position.Y;
            return (float)Math.Sqrt(catetX * catetX + catetY * catetY);
        }
    }
}