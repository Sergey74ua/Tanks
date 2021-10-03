using System.Drawing;

namespace Tanks
{
    class Crater
    {
        public PointF position;     //позиция
        public ushort timeAction;   //время действия

        /// <summary>
        /// Воронка : рассчитывается из взрыва
        /// </summary>
        public Crater(PointF position)
        {
            this.position = position;
            timeAction = 0;
        }

        //Отрисовывка взрыва
        public void DrawCrater(Graphics g)
        {
            g.TranslateTransform(position.X, position.Y);
            g.FillEllipse(new SolidBrush(Color.FromArgb(64 / timeAction + 16, 32, 16, 0)),
                new RectangleF(-32, -32, 64, 64));
            g.ResetTransform();
        }
    }
}