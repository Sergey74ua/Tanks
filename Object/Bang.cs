using System.Drawing;

namespace Tanks
{
    class Bang
    {
        public PointF position;    //позиция
        public byte timeAction;    //время действия

        /// <summary>
        /// Взрыв : рассчитывается из выстрела
        /// </summary>
        public Bang(PointF position)
        {
            this.position = position;
            timeAction = 0;
            Sound.Bang();
        }

        //Отрисовывка взрыва
        public void DrawBang(Graphics g)
        {
            g.TranslateTransform(position.X, position.Y);
            g.FillEllipse(new SolidBrush(Color.FromArgb(192 - timeAction, timeAction + 128, timeAction, 0)),
                new RectangleF(-timeAction / 2, -timeAction / 2, timeAction, timeAction));
            g.ResetTransform();
        }
    }
}