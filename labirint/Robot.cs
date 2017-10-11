using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labirint
{
    class Robot
    {
        int nom; // номер
        bool stat; // статус тру свободен фолс занят
        int[] locasion = new int[2]; // положение в 3д зависит от карты
        int[] lastlocasion = new int[2]; // прошлое положение
        int Crosstupe; // 1 - тупик 2 - дорога 3 - перекресток.
        int Taskcounter = 0;
        int roadway = 0;// направления дорог
        int[,] Track; // локальная карта робота места где он ходил. надо слиять с глобальной картой что бы остальных орентировать.
       public void SetPoz(RealMap realMap, int i) // Инициализация робота 
        {
            locasion[0] = realMap.GetStart()[0];
            locasion[1] = realMap.GetStart()[1];
            Crosstupe = 1;
            Track = new int[realMap.GetXSize(), realMap.GetYSize()];
            if (realMap.Look(locasion[0] + 1, locasion[0]) == 0) { lastlocasion[0] = locasion[0] + 1; }
            if (realMap.Look(locasion[0] - 1, locasion[0]) == 0) { lastlocasion[0] = locasion[0] - 1; }
            if (realMap.Look(locasion[1] + 1, locasion[1]) == 0) { lastlocasion[1] = locasion[1] + 1; }
            if (realMap.Look(locasion[1] - 1, locasion[1]) == 0) { lastlocasion[1] = locasion[1] + 1; }

            nom = i;

            /*
             *Робот появляется в тупике
             * 
             */
        }
       
        public void Mowe (int x, int y)  //  1 такт 1 ход принимает только +-1
        {
            lastlocasion = locasion;
            locasion[0] = locasion[0] + x;
            locasion[1] = locasion[1] + y;
            TrackUpd();
        }
  // движение по командам вверх вниз  нужны для старта квеста, пускаем по дороге далее он исследует Explove.

        public int Explove(RealMap realMap)  // исследование смотрит на карту определяет квадраты +-1 от себя действует.
        {
            lookaround(realMap);
            //тупик
            if (Crosstupe == 1) // если в тупике - выйти из тупика 
            {   int save;
                save = locasion[0];
                locasion[0] = lastlocasion[0];
                lastlocasion[0] = save;
                save = locasion[1];
                locasion[1] = lastlocasion[1];
                lastlocasion[1] = save;
                TrackUpd();
                return 0;
            }
            // дорога
            if (Crosstupe == 2) // если на дороге определить куда она идет.
            {
                switch (roadway)
                {
                    case 11: //верх низ
                        if (locasion[0] - 1 == lastlocasion[0])
                        {
                            locasion[0]++;  //верх
                            lastlocasion[0]++;
                        } 
                        else
                        {
                            locasion[0]--; //низ
                            lastlocasion[0]--;
                        }
                        break; //верх право
                    case 101:

                        if (locasion[0] - 1 == lastlocasion[0])
                        {
                            locasion[0]++;  //верх
                            lastlocasion[0]++;
                        }
                        else
                        {
                            locasion[1]++;  // движение вправо
                            lastlocasion[1]++;
                        }
                        break; //верх лево
                    case 1001:

                        if (locasion[0] - 1 == lastlocasion[0])
                        {
                            locasion[0]++;  //верх
                            lastlocasion[0]++;
                        }
                        else
                        {
                            locasion[1]--;  // движение влево
                            lastlocasion[1]--;
                        }

                        break; //низ право
                    case 110:

                        if (locasion[0] + 1 == lastlocasion[0])
                        {
                            locasion[0]--;  // вниз
                            lastlocasion[0]--;
                        }
                        else
                        {
                            locasion[1]++;  // движение вправо
                            lastlocasion[1]++;
                        }

                        break; // низ лево
                    case 1010:

                        if (locasion[0] + 1 == lastlocasion[0])
                        {
                            locasion[0]--;  // вниз
                            lastlocasion[0]--;
                        }
                        else
                        {
                            locasion[1]--;     // движение влево
                            lastlocasion[1]--;
                        }
                        break; //право лево
                    case 1100:

                        if (locasion[1] - 1 == lastlocasion[1])
                        {
                            locasion[1]++;  // движение вправо
                            lastlocasion[1]++;
                        }
                        else
                        {
                            locasion[1]--;     // движение влево
                            lastlocasion[1]--;
                        }
                        break;

                    default:
                        Console.Write("Error");
                        break;
                }
                TrackUpd();
                return 0;
            }
            //перекресток
            if (Crosstupe >= 3)
            {

                /* 
                 * он попал в перекресток, два варианта 
                 *он закончил исследование
                 *он шляется в поисках квеста
                 *при шляется в поисках квеста надо вести его к следующему перекрестку с квестами  
                */

                if (!stat)
                {
                    stat = true; // исследование закончено 
                    Taskcounter++;
                    //передача трека для создания общей карты навигации. (100% узнал новую дорогу)
                }
                TrackUpd();
                return roadway;
                // запрашивает путь к следующему заданию управление через муве Х У (функции в комменте)    
            }
            Console.WriteLine("Error Explove");
            return 0;
        }

        public void lookaround(RealMap realMap) // определяет где он и куда может пойти
        {
            int Crosstupe = 1;
            roadway = 0;
            if (realMap.Look(locasion[0] + 1, locasion[0]) == 0) { Crosstupe++; roadway += 1; } //вверх
            if (realMap.Look(locasion[0] - 1, locasion[0]) == 0) { Crosstupe++; roadway += 10; } //вниз
            if (realMap.Look(locasion[1] + 1, locasion[1]) == 0) { Crosstupe++; roadway += 100; } //вправо
            if (realMap.Look(locasion[1] - 1, locasion[1]) == 0) { Crosstupe++; roadway += 1000; } //влево
            
        }
    
        void TrackUpd() // запись трека для определения того где был робот (не учитывает повторный проход)
        {

        Track[locasion[0], locasion[1]] = 1;  
         // Track[locasion[0], locasion[1]] += 1; //учитывает повторный проход
        }

        public int[] Locasion() // Передает где он
        {
            return locasion;
        }

        public int LastStep() // передает как туда пришел
        {
            if (lastlocasion[0] - locasion[0] ==-1) { return (2); } //снизу
            if (lastlocasion[0] - locasion[0] == 1) { return (1); } //сверху
            if (lastlocasion[1] - locasion[1] ==-1) { return (4); } //влево
            if (lastlocasion[1] - locasion[1] == 1) { return (3); } //вправо
            return (-1);
        }

        public int[,] GetTrack()
        {
            return Track;
        } // передает трек

        public bool Status()
        {
            return stat;
        } // передает наличие задачи

        public void SetActive()
        {
            stat = false;
        } // получает задачу

        public int Roadway() // направления дорог в пространстве
        {
            return roadway;
        }
    }

}
