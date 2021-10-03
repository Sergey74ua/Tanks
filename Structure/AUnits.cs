using System;
using System.Drawing;

namespace Tanks
{
    abstract class AUnits : AObject
    {
        private static uint ID;

        public uint id = ++ID;      //имя
        public Act act;             //действие
        public float vectorTower;   //вектор башни
        public float vision;        //обзор
        public float life;          //жизнь

        protected SolidBrush solidBrush;
        protected float lifeLine;
        private float line = 64.0f;
        private float angle;

        private readonly SolidBrush solidBrushFont = new SolidBrush(Color.LightGreen);
        private readonly Font font = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point);
        private readonly Pen penGrn = new Pen(Color.Green, 2);
        private readonly Pen penRed = new Pen(Color.Red, 2);

        //Отрисовка имени и жизни
        protected void DrawInfo(Graphics g)
        {
            //Наименование и полоса жизни ******** в классе Graphics взять метод замера строки ********
            g.TranslateTransform(position.X, position.Y);
            g.DrawString("= " + id.ToString()  + " - " + act.ToString() + " =", font, solidBrushFont, -20, -42);
            g.DrawLine(penGrn, -line / 2, -26, lifeLine, -26);
            g.DrawLine(penRed, lifeLine, -26, line / 2, -26);
            g.ResetTransform();
        }

        //Движения юнита к цели ********  Р А З Д Е Л И Т Ь   Н А   2   М Е Т О Д А  ********
        public void Move()
        {
            vector = Angle(vector, speed);
            vectorTower = Angle(vectorTower, speed * 2);

            if (vector == angle)
                position = Position();
        }

        //Направление юнита
        public float Angle(float vector, float speed)
        {
            //Расстояние и угол к цели
            angle = (float)(Vector() * 180 / Math.PI + 90);
            if (angle < 0) angle += 360;

            //Текущий угол поворота к цели
            if (Math.Abs(vector - angle) > speed)
            {
                if ((vector < angle && (angle - vector) < 180) ^ (angle - vector) > -180)
                    vector = (vector - speed + 360) % 360;
                else
                    vector = (vector + speed) % 360;
            }
            else
                vector = angle;

            return vector;
        }

        //Уничтожение юнита
        public void RemoveUnit(dynamic unit)
        {
            unit.color = Color.Black;
            unit.act = Act.DEAD;
            unit.speed = 0.0f;
            unit.life = 0.0f;
        }
    }
}