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
        List<int> CrossWayUnk = new List<int>(); // направления неисследованных дорог
        /*
         * 1 вверх
         * 2 вниз
         * 3 вправо
         * 4 влево
         * 5 вверх вниз
         * 6 вверх влево
         * 7 вверх вправо
         * 8 вниз влево
         * 9 вниз вправо
         * 10 влево вправо
         * 11 не верх
         * 12 не низ
         * 13 не лево
         * 14 не право
         * 
         */ 

      
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
            if (CrossTask[k] != 0) // робот в перекрестке с квестом
            {
                robots[n].SetActive();
                // послать его в неизведанную часть мы не знаем куда из перекрестка ехать
                switch (CrossWayUnk[k])
                {
                    case 14:
                        robots[n].Mowe(0,-1);
                        CrossWayUnk[k] = 5;
                        CrossTask[k]--;

                        break;

                    case 13:
                        robots[n].Mowe(0, 1);
                        CrossWayUnk[k] = 5;
                        CrossTask[k]--;
                        break;
                    case 12:
                        robots[n].Mowe(1,0);
                        CrossWayUnk[k] = 10;
                        CrossTask[k]--;
                        break;
                    case 11:
                        robots[n].Mowe(-1, 0);
                        CrossWayUnk[k] = 10;
                        CrossTask[k]--;
                        break;
                    case 10:
                        robots[n].Mowe(0, 1);
                        CrossWayUnk[k] = 4;
                        CrossTask[k]--;
                        break;
                    case 9:
                        robots[n].Mowe(0,1);
                        CrossWayUnk[k] = 2;
                        CrossTask[k]--;
                        break;
                    case 8:
                        robots[n].Mowe(0,-1);
                        CrossWayUnk[k] = 2;
                        CrossTask[k]--;
                        break;
                    case 7:
                        robots[n].Mowe(0, 1);
                        CrossWayUnk[k] = 1;
                        CrossTask[k]--;
                        break;
                    case 6:
                        robots[n].Mowe(0, -1);
                        CrossWayUnk[k] = 1;
                        CrossTask[k]--;
                        break;
                    case 5:
                        robots[n].Mowe(1, 0);
                        CrossWayUnk[k] = 2;
                        CrossTask[k]--;
                        break;
                    case 4:
                        robots[n].Mowe(0, 1);
                        CrossTask[k]--;
                        break;
                    case 3:
                        robots[n].Mowe(0, 1);
                        CrossTask[k]--;
                        break;
                    case 2:
                        robots[n].Mowe(-1, 0);
                        CrossTask[k]--;
                        break;
                    case 1:
                        robots[n].Mowe(1,0);
                        CrossTask[k]--;
                        break;
                    default:
                        Console.Write("Error WereIm");
                        break;
                }
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
                        Console.Write("Error WereIm 2");
                        break;
                }

            }
        }

       int WhatWay(int[] start, int[] finich)
        {
            //достаем карту и ищем путь из старта в финиш и возвращаем куда поверуть с перекрестка 1 2 3 4 = верх низ право лево

            return 0;
        }

        void NewCross(int n)
        {
            if (!Cross.Contains(robots[n].Locasion()))
            {  
        /*
         * 1 вверх
         * 2 вниз
         * 3 вправо
         * 4 влево
         * 5 вверх вниз
         * 6 вверх влево
         * 7 вверх вправо
         * 8 вниз влево
         * 9 вниз вправо
         * 10 влево вправо
         * 11 не верх
         * 12 не низ
         * 13 не лево
         * 14 не право
         * 
         */
                Cross.Add(robots[n].Locasion());
                switch (robots[n].LastStep())
                {
                    case 1: // верх 11 10 9 8
                        switch (robots[n].Roadway())
                        {
                            case 1111: // 4 дороги
                                CrossTask.Add(3);
                                CrossWayUnk.Add(11);
                                break;
                            case 1101: // 3 дороги не низ
                                CrossTask.Add(2);
                                CrossWayUnk.Add(10);
                                break;
                            case 1011: // 3 дороги не право
                                CrossTask.Add(2);
                                CrossWayUnk.Add(8);
                                break;
                            case 0111: // 3 дороги не лево
                                CrossTask.Add(2);
                                CrossWayUnk.Add(9);
                                break;
                            default:
                                Console.Write("Error  NewCross");
                                break;
                        }
                        break;
                    case 2: // низ 12 10 7 6 
                        switch (robots[n].Roadway())
                        {
                            case 1111: // 4 дороги
                                CrossTask.Add(3);
                                CrossWayUnk.Add(12);
                                break;
                            case 1110: // 3 дороги не верх
                                CrossTask.Add(2);
                                CrossWayUnk.Add(5);
                                break;
                            case 1011: // 3 дороги не право
                                CrossTask.Add(2);
                                CrossWayUnk.Add(6);
                                break;
                            case 0111: // 3 дороги не лево
                                CrossTask.Add(2);
                                CrossWayUnk.Add(7);
                                break;
                            default:
                                Console.Write("Error  NewCross");
                                break;
                        }
                        break;
                    case 3: // право 14 5 8 6
                        switch (robots[n].Roadway())
                        {
                            case 1111: // 4 дороги
                                CrossTask.Add(3);
                                CrossWayUnk.Add(14);
                                break;
                            case 1110: // 3 дороги не верх
                                CrossTask.Add(2);
                                CrossWayUnk.Add(7);
                                break;
                            case 1101: // 3 дороги не низ
                                CrossTask.Add(2);
                                CrossWayUnk.Add(6);
                                break;
                            case 0111: // 3 дороги не лево
                                CrossTask.Add(2);
                                CrossWayUnk.Add(10);
                                break;
                            default:
                                Console.Write("Error  NewCross");
                                break;
                        }
                        break;
                    case 4:  // лево 13 5 7 9
                        switch (robots[n].Roadway())
                        {
                            case 1111: // 4 дороги
                                CrossTask.Add(3);
                                CrossWayUnk.Add(11);
                                break;
                            case 1110: // 3 дороги не верх
                                CrossTask.Add(2);
                                CrossWayUnk.Add(9);
                                break;
                            case 1101: // 3 дороги не низ
                                CrossTask.Add(2);
                                CrossWayUnk.Add(7);
                                break;
                            case 1011: // 3 дороги не право
                                CrossTask.Add(2);
                                CrossWayUnk.Add(5);
                                break;
                            default:
                                Console.Write("Error  NewCross");
                                break;
                        }
                        break;
                    default:
                        Console.Write("Error  NewCross");
                        break;
                }

                }
            else {
                int k = Cross.IndexOf(robots[n].Locasion());
              

                switch (robots[n].LastStep())
                {
                    case 1: // верх 10 9 8 4 3 2 ( уточняем 1 5 6 7 12 13 14)
                        switch (CrossWayUnk[k])
                        {
                            case 1:
                                CrossTask[k]--;
                                // cbvvtnhbz xnj, ukfp yt htpfkj
                                break;
                            case 5:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 2;
                                break;
                            case 6:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 4;
                                break;
                            case 7:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 3;
                                break;
                            case 12:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 10;
                                break;
                            case 13:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 5;
                                break;
                            case 14:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 5;
                                break;
                            default:
                                break;
                        } 
 
                        break;
                    case 2: // низ 10 7 6 4 3 1 ( уточняем 2 5 8 9 11 13 14)
                        switch (CrossWayUnk[k]) 
                        {
                            case 2:
                                CrossTask[k]--;
                                // cbvvtnhbz xnj, ukfp yt htpfkj
                                break;
                            case 5:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 1;
                                break;
                            case 8:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 4;
                                break;
                            case 9:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 3;
                                break;
                            case 11:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 10;
                                break;
                            case 13:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 5;
                                break;
                            case 14:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 5;
                                break;
                            default:
                                break;
                        }

                        break;
                    case 3: // право 1 2 4 5 6 8  ( уточняем 3 7 9 10 11 12 13)
                        switch (CrossWayUnk[k])
                        {
                            case 3:
                                CrossTask[k]--;
                                // cbvvtnhbz xnj, ukfp yt htpfkj
                                break;
                            case 7:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 2;
                                break;
                            case 9:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 4;
                                break;
                            case 10:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 3;
                                break;
                            case 11:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 10;
                                break;
                            case 12:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 5;
                                break;
                            case 13:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 5;
                                break;
                            default:
                                break;
                        }

                        break;
                    case 4: // лево 1 2 3 5 7 9 ( уточняем 4 6 8 10 11 12 14)
                        switch (CrossWayUnk[k])
                        {
                            case 4:
                                CrossTask[k]--;
                                // cbvvtnhbz xnj, ukfp yt htpfkj
                                break;
                            case 6:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 2;
                                break;
                            case 8:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 4;
                                break;
                            case 10:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 3;
                                break;
                            case 11:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 10;
                                break;
                            case 12:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 5;
                                break;
                            case 14:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 5;
                                break;
                            default:
                                break;
                        }

                        break;
                    
                    default:
                        Console.Write("Error  NewCross");
                        break;
                }
                if (CrossWayUnk[k] == 14 && robots[n].LastStep() !=4 ){
                    CrossTask[k]--;
                }
                if (CrossWayUnk[k] == 13 && robots[n].LastStep() != 3){
                    CrossTask[k]--;
                }
                if (CrossWayUnk[k] == 12 && robots[n].LastStep() != 1){
                    CrossTask[k]--;
                }
                if (CrossWayUnk[k] == 11 && robots[n].LastStep() != 2){
                    CrossTask[k]--;
                }
                //перезаполнить списки с количеством задач и направлений.
            }
        }

        void NewCrossTupe(int n)
        {

        }


        public void Loop (RealMap realMap)
        {





        }

        public int[,] MAP()
        {
            return localMap;
        }


    }
}
