using System.Drawing;

namespace Tanks
{
    class Tank : AUnits, IDrawn
    {
        private static Size size = new Size(128, 128);

        //Изображение танка
        private readonly Bitmap bitmap = new Bitmap(Properties.Resources.tank4);
        private readonly Rectangle body = new Rectangle(new Point(0, 0), size);
        private readonly Rectangle tower = new Rectangle(new Point(128, 0), size);
        private readonly Rectangle bodyShadow = new Rectangle(new Point(0, 128), size);
        private readonly Rectangle towerShadow = new Rectangle(new Point(128, 128), size);
        private readonly byte shadow = Tanks.shadow;

        /// <summary> Конструктор танка : цвет команды </summary>
        public Tank(Color color)
        {
            this.color = color;
            act = Act.WAIT;
            speed = 0.5f;
            vision = 512;
            timeAction = 60;
            life = 40;
        }

        //Отрисовка танка
        public void DrawUnit(Graphics g, Color party)
        {
            solidBrush = new SolidBrush(party);

            #region ** Этапы отрисовки танка **
            //Тень корпуса
            g.TranslateTransform(position.X + shadow, position.Y + shadow);
            g.RotateTransform(vector);
            g.DrawImage(bitmap, -64, -64, bodyShadow, GraphicsUnit.Pixel);
            g.ResetTransform();
            //Цвет команды
            g.TranslateTransform(position.X, position.Y);
            g.RotateTransform(vector);
            g.FillRectangle(solidBrush, -26, -52, 52, 100);
            //Корпус
            g.DrawImage(bitmap, -64, -64, body, GraphicsUnit.Pixel);
            g.ResetTransform();
            //Тень башни
            g.TranslateTransform(position.X + shadow, position.Y + shadow);
            g.RotateTransform(vectorTower);
            g.DrawImage(bitmap, -64, -98, towerShadow, GraphicsUnit.Pixel);
            g.ResetTransform();
            //Башня
            g.TranslateTransform(position.X, position.Y);
            g.RotateTransform(vectorTower);
            g.DrawImage(bitmap, -64, -98, tower, GraphicsUnit.Pixel);
            g.ResetTransform();
            #endregion

            lifeLine = life * 64 / 40 - 32;
            DrawInfo(g);
        }
    }
}