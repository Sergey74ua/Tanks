using System;
using System.Collections.Generic;
using System.Drawing;

namespace Tanks
{
    class Actions
    {
        private readonly Random random = new Random();
        private List<Party> ListParty;
        private Shots ListShots;

        //Перебор всех юнитов
        public void ActUnit(List<Party> ListParty, Shots ListShots)
        {
            this.ListParty = ListParty;
            this.ListShots = ListShots;

            //Перебор действий юнитов
            foreach (Party party in ListParty)
                foreach (dynamic unit in party.ListUnits)
                    if (unit.act != Act.DEAD)
                        SelectAct(unit);
        }

        //Переключатель действий
        private void SelectAct(dynamic unit)
        {
            switch (unit.act)
            {
                case Act.WAIT:  //ожидание
                    ActWait(unit);
                    break;
                case Act.FIND:  //поиск
                    ActFind(unit);
                    break;
                case Act.MOVE:  //подкат
                    ActMove(unit);
                    break;
                case Act.FIRE:  //атака
                    ActFire(unit);
                    break;
                default:        //прочее
                    unit.act = Act.WAIT;
                    break;
            }
        }

        //Определяем действие танка
        private void ActWait(dynamic unit)
        {
            //DEAD - если танк убит
            if (unit.life <= 0.0f)
                unit.RemoveUnit(unit);

            else
            {
                //Поиск ближайшего чужого живого танка
                float findDelta, minDelta = unit.vision * 2;
                
                foreach (Party party in ListParty)
                    foreach (dynamic findUnit in party.ListUnits)
                        if (unit.color != findUnit.color && findUnit.act != Act.DEAD)
                        {
                            findDelta = unit.Delta(unit.position, findUnit.position);
                            if (findDelta < minDelta)
                            {
                                minDelta = findDelta;
                                unit.target = findUnit.position;
                            }
                        }

                //FIRE - атака живой цели в зоне поражения
                if (minDelta < unit.vision)
                    unit.act = Act.FIRE;

                //MOVE - движемся в направлении цели
                else if (minDelta < unit.vision * 2)
                    unit.act = Act.MOVE;

                //FIND - поиск цели и случайный перекат если ее нет
                else
                {
                    unit.target = new PointF(
                        unit.position.X + random.Next(-128, 128),
                        unit.position.Y + random.Next(-128, 128));

                    unit.act = Act.FIND;
                }
            }
        }

        //Процесс движения в случаную точку при отсутствии цели
        private void ActFind(dynamic unit)
        {
            if (unit.Delta(unit.position, unit.target) > unit.speed * 16)
                unit.Move();
            else
                unit.act = Act.WAIT;
        }

        //Процесс сближения с целью
        private void ActMove(dynamic unit)
        {
            if (unit.Delta(unit.position, unit.target) > unit.vision)
            {
                unit.vectorTower = unit.Angle(unit.vectorTower, unit.speed * 2);
                unit.Move();
            }
            else
                unit.act = Act.WAIT;
        }

        //Процесс атаки танка
        private void ActFire(dynamic unit)
        {
            if (unit.timeAction < 120)
            {
                unit.timeAction++;
                unit.vectorTower = unit.Angle(unit.vectorTower, unit.speed * 2);
            }
            else
            {
                unit.timeAction = 0;
                ListShots.NewShot(unit);
                unit.act = Act.WAIT;
            }
        }
    }
}