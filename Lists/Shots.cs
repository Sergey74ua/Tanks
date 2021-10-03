using System.Collections.Generic;
using System.Drawing;

namespace Tanks
{
    class Shots
    {
        public List<Shot> ListShot = new List<Shot>();
        public List<Bang> ListBang = new List<Bang>();
        public List<Crater> ListCrater = new List<Crater>();

        //Добавляем выстрел
        public void NewShot(dynamic unit)
        {
            ListShot.Add(new Shot(unit));
        }

        //Удаляем выстрел / добавляем взрыв
        public void RemoveShot(Shot shot)
        {
            ListBang.Add(new Bang(shot.position));
            ListShot.Remove(shot);
        }

        //Удаляем взрыв / добавляем кратер
        public void RemoveBang(Bang bang)
        {
            ListCrater.Add(new Crater(bang.position));
            ListBang.Remove(bang);
        }

        //Удаляем кратер
        public void RemoveCrater(Crater crater)
        {
            ListCrater.Remove(crater);
        }

        //Отрисовываем и выстрелы и взрывы 
        public void DrawListShot(Graphics g)
        {
            foreach (Shot shot in ListShot)
                shot.DrawShot(g);

            foreach (Bang bang in ListBang)
                bang.DrawBang(g);
        }

        //Отрисовываем воронки 
        public void DrawListCrater(Graphics g)
        {
            foreach (Crater crater in ListCrater)
                crater.DrawCrater(g);
        }
    }
}