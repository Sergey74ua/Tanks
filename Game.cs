using System.Drawing;
using System.Collections.Generic;

namespace Tanks
{
    class Game
    {
        private List<Party> ListParty;  //комманды
        private Shots ListShots;        //выстрелы
        private Actions Actions;        //действия
        private Shooting Shooting;      //стрельба
        private const byte count = 3;   //число машин

        /// <summary>
        /// Комманды и снаряды
        /// </summary>
        public Game()
        {
            ListParty = new List<Party>();
            ListShots = new Shots();
            Actions = new Actions();
            Shooting = new Shooting();

            //Добавляем команды в список
            ListParty.Add(new Party(Color.DarkRed, new Point(50, 10), count));
            ListParty.Add(new Party(Color.DarkBlue, new Point(80, 50), count));
            ListParty.Add(new Party(Color.Yellow, new Point(50, 90), count));
            ListParty.Add(new Party(Color.Purple, new Point(20, 50), count));

            //Sound.StarWars();
        }

        //Шаг-кадр игры
        public void StepGame(Graphics g)
        {
            Actions.ActUnit(ListParty, ListShots);
            Shooting.ActShot(ListParty, ListShots);

            ListShots.DrawListCrater(g);
            foreach (Party party in ListParty)
                party.DrawListUnits(g);
            ListShots.DrawListShot(g);
        }

        //Выделяем юнита ******** П Р О Б Н О ********
        public void SelectUnit(Point cursor)
        {
            PointF _target = cursor;

            //Определяем юнита под кликом
            foreach (Party party in ListParty)
                foreach (dynamic unit in party.ListUnits)
                {
                    unit.delta = unit.Delta(unit.position, cursor);
                    if (unit.delta < 16)
                    {
                        unit.color = Color.White;
                        _target = unit.position;
                    }
                    else
                    {
                        _target = cursor;
                    }
                }

            //Определяем юнита как цель
            foreach (Party party in ListParty)
                foreach (dynamic unit in party.ListUnits)
                    unit.target = _target;
        }
    }
}