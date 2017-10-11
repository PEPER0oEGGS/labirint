using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labirint
{
    class COOPAI
    {
        Robot[] robots;
        int[,] localMap;
        List<int[]> Cross = new List<int[]>(); // перекрестки
        List<int> CrossTask = new List<int>(); // Количество квестов на перекрестке
        List<int> CrossWayUnk = new List<int>(); // направления неисследованных дорог надо думать как задать иначе 24 варианта
       public void StartAI(int N, RealMap realMap)
        {
            robots = new Robot[N];  // узнали сколько роботов
            for (int i=0;i<N; i++){    robots[i] = new Robot();  } // создали роботов
            for (int i = 0; i < N; i++)  { robots[i].SetPoz(realMap, i); } // инициализировали роботов
            localMap = robots[0].GetTrack();// получили размер карты
            // теперь надо одного пустить в лабиринт а остальных заставить ждать ( они заедут в нутрь в первый перекресток и будут ждать команд)
            robots[0].SetActive();
        }

       public void WereIm(int n)
        {
            //перекресток с роботом
            int[] start = robots[n].Locasion();
            int k = Cross.IndexOf(start);
            if (k != 0) // робот в перекрестке с квестом
            {
                robots[n].SetActive();
                // послать его в неизведанную часть мы не знаем куда из перекрестка ехать

            }
            k = CrossTask.IndexOf(3);
            if (k == 0) { k = CrossTask.IndexOf(2);}
            if (k == 0) { k = CrossTask.IndexOf(1); }
            if (k != 0) // робот гдето и ищет перекресток с максимальным количеством квестов
            {
                int[] finich = Cross.ElementAt(k);

                switch (WhatWay(start, finich)) // значение куда повернуть из перекрестка
                {
                    case 1:
                        robots[n].Mowe(1,0);

                        break;
                    case 2:
                        robots[n].Mowe(-1, 0);

                        break;
                    case 3:
                        robots[n].Mowe(0, 1);

                        break;
                    case 4:
                        robots[n].Mowe(0, -1);

                        break;
                    default:
                        Console.Write("Error");
                        break;
                }

            }
        }

       int WhatWay(int[] start, int[] finich)
        {
            //достаем карту и ищем путь из старта в финиш и возвращаем куда поверуть с перекрестка 1 2 3 4 = верх низ право лево

            return 0;
        }

        public void NewCross(int n)
        {
            int[] locasion = robots[n].Locasion();
            if (!Cross.Contains(locasion))
            {
                Cross.Add(locasion);
                // так же заполнить списки с количеством задач и направлений.
            }
            else {
                int k = Cross.IndexOf(locasion);
                //перезаполнить списки с количеством задач и направлений.
            }
        }

        public void loop (RealMap realMap)
        {
            for (int i=0;i<robots.Length ; i++)
            {  
                robots[i].Explove(realMap);
            }

        }
    }
}
