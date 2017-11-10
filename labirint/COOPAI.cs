using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labirint
{
    public class COOPAI // не умеет искать квесты (WhatWay)
    {
        public Robot[] robots;
       public int[,] localMap;
        int[,] WayMap;
        public int takts = 0;
        List<int> CrossX = new List<int>(1000); // перекрестки 
        List<int> CrossY = new List<int>(1000); // перекрестки 
        List<int> CrossTask = new List<int>(1000); // Количество квестов на перекрестке
        List<int> CrossWayUnk = new List<int>(1000); // направления неисследованных дорог

        /*
         * 0 все исследованно
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
            for (int i = 0; i < N; i++) { robots[i] = new Robot(); } // создали роботов
            for (int i = 0; i < N; i++) { robots[i].SetPoz(realMap, i); } // инициализировали роботов
            localMap = new int[robots[0].GetTrack().GetLength(0), robots[0].GetTrack().GetLength(1)]; localMap = new int[robots[0].GetTrack().GetLength(0), robots[0].GetTrack().GetLength(1)];// получили размер карты
            WayMap = new int[robots[0].GetTrack().GetLength(0), robots[0].GetTrack().GetLength(1)];
            // теперь надо одного пустить в лабиринт а остальных заставить ждать ( они заедут в нутрь в первый перекресток и будут ждать команд)
            robots[0].SetActive();
        }

        public void WereIm(int n)
        {
            int k = 0;
            for (; true; k++) { if (CrossX[k] == robots[n].Locasion()[0] && CrossY[k] == robots[n].Locasion()[1]) { break; } }
            if (CrossTask[k] != 0) // робот в перекрестке с квестом
            {// послать его в неизведанную часть мы не знаем куда из перекрестка ехать
                robots[n].SetActive();
                switch (CrossWayUnk[k])
                {
                    case 14:
                        robots[n].Mowe(0, -1);
                        CrossWayUnk[k] = 5;
                        CrossTask[k]--;
                        break;
                    case 13:
                        robots[n].Mowe(0, 1);
                        CrossWayUnk[k] = 5;
                        CrossTask[k]--;
                        break;
                    case 12:
                        robots[n].Mowe(-1, 0);
                        CrossWayUnk[k] = 10;
                        CrossTask[k]--;
                        break;
                    case 11:
                        robots[n].Mowe(1, 0);
                        CrossWayUnk[k] = 10;
                        CrossTask[k]--;
                        break;
                    case 10:
                        robots[n].Mowe(0, 1);
                        CrossWayUnk[k] = 4;
                        CrossTask[k]--;
                        break;
                    case 9:
                        robots[n].Mowe(0, 1);
                        CrossWayUnk[k] = 2;
                        CrossTask[k]--;
                        break;
                    case 8:
                        robots[n].Mowe(0, -1);
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
                        robots[n].Mowe(-1, 0);
                        CrossWayUnk[k] = 2;
                        CrossTask[k]--;
                        break;
                    case 4:
                        robots[n].Mowe(0, -1);
                        CrossTask[k]--;
                        CrossWayUnk[k] = 0;
                        break;
                    case 3:
                        robots[n].Mowe(0, 1);
                        CrossWayUnk[k] = 0;
                        CrossTask[k]--;
                        break;
                    case 2:
                        robots[n].Mowe(1, 0);
                        CrossWayUnk[k] = 0;
                        CrossTask[k]--;
                        break;
                    case 1:
                        robots[n].Mowe(-1, 0);
                        CrossWayUnk[k] = 0;
                        CrossTask[k]--;
                        break;
                    default:
                        Console.Write("Error WereIm");
                        break;
                }
            }
            else
            {
               /* switch (robots[n].LastStep())
                {
                    case 1: // вверх = лево или прямо
                        if (robots[n].Roadway() == 0111) { robots[n].Mowe(1, 0); } else { robots[n].Mowe(0, -1); }
                        break;
                    case 2: // вниз = право или прямо
                        if (robots[n].Roadway() == 1011) { robots[n].Mowe(-1, 0); } else { robots[n].Mowe(0, 1); }
                        break;
                    case 3: // право вверх или прямо
                        if (robots[n].Roadway() == 1101) { robots[n].Mowe(0, -1); } else { robots[n].Mowe(-1, 0); }
                        break;
                    case 4: //  влево или прямо
                        if (robots[n].Roadway() == 1110) { robots[n].Mowe(0, 1); } else { robots[n].Mowe(1, 0); }
                        break;
                }*/


                
                // робот гдето и ищет перекресток с максимальным количеством квестов
                 k = CrossTask.IndexOf(3);
                 if (k == -1) { k = CrossTask.IndexOf(2);}
                 if (k == -1) { k = CrossTask.IndexOf(1); }
                 if (k != -1) // если квесты на карте есть
                 {
                   // int[] finich =Cross.ElementAt(k);
                     switch (Whatway(new int[] { CrossX.ElementAt(k), CrossY.ElementAt(k) }, robots[n].Locasion())) // значение куда повернуть из перекрестка
                     {
                        case 1: //вниз
                        robots[n].Mowe(1,0);

                        break;
                       case 2://вверх
                        robots[n].Mowe(-1, 0);

                        break;
                        case 3://вправо
                        robots[n].Mowe(0, 1);

                        break;
                       case 4: // влево
                        robots[n].Mowe(0, -1);

                        break;
                       default:
                        Console.Write("Error WereIm 2");
                        break;
                     }

                 }// тут если трек будет равен пути (вторая функция) надо уменьшать трек при ппростое
                 
            }
        }

        void NewCross(int n)
        {
            if (!CrossX.Contains(robots[n].Locasion()[0]) || !CrossY.Contains(robots[n].Locasion()[1]))
            {
                CrossX.Add(robots[n].Locasion()[0]);
                CrossY.Add(robots[n].Locasion()[1]);
                switch (robots[n].LastStep())
                {
                    case 1: // верх 11 10 9 8
                        switch (robots[n].Roadway())
                        {
                            case 1111: // 4 дороги
                                CrossTask.Add(3);
                                CrossWayUnk.Add(11);
                                break;
                            case 1110: // 3 дороги не низ
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
                            case 1101: // 3 дороги не верх
                                CrossTask.Add(2);
                                CrossWayUnk.Add(10);
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
                            case 1101: // 3 дороги не верх
                                CrossTask.Add(2);
                                CrossWayUnk.Add(7);
                                break;
                            case 1110: // 3 дороги не низ
                                CrossTask.Add(2);
                                CrossWayUnk.Add(6);
                                break;
                            case 0111: // 3 дороги не лево
                                CrossTask.Add(2);
                                CrossWayUnk.Add(5);
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
                            case 1101: // 3 дороги не верх
                                CrossTask.Add(2);
                                CrossWayUnk.Add(9);
                                break;
                            case 1110: // 3 дороги не низ
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
                int k = 0;
                for (; true; k++) { if (CrossX[k] == robots[n].Locasion()[0] && CrossY[k] == robots[n].Locasion()[1]) { break; } }
                switch (robots[n].LastStep())
                {
                    case 2: // верх 10 9 8 4 3 2 ( уточняем 1 5 6 7 12 13 14)
                        switch (CrossWayUnk[k])
                        {
                            case 2:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 0;
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
                                CrossWayUnk[k] = 9;
                                break;
                            case 14:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 8;
                                break;
                            default:
                                break;
                        }
                        break;
                    case 1: // низ 10 7 6 4 3 1 ( уточняем 2 5 8 9 11 13 14)
                        switch (CrossWayUnk[k])
                        {
                            case 1:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 0;
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
                                CrossWayUnk[k] = 7;
                                break;
                            case 14:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 6;
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
                                CrossWayUnk[k] = 0;
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
                                CrossWayUnk[k] = 8;
                                break;
                            case 12:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 6;
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
                                CrossWayUnk[k] = 0;
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
                                CrossWayUnk[k] = 9;
                                break;
                            case 12:
                                CrossTask[k]--;
                                CrossWayUnk[k] = 7;
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
            }
        }

        public void Loop(RealMap realMap)
        {
            takts++;
            for (int n = 0; n < robots.Length; n++)
            {

                if (robots[n].Explove(realMap) != 0)
                {
                    NewCross(n);
                    WereIm(n);
                }
                
                UpdMap(n);

            }
        }

        void UpdMap(int n)
        {
            localMap[robots[n].Locasion()[1], robots[n].Locasion()[0]]++;
            if (CrossTask.Count == 0) { localMap[robots[n].Locasion()[1], robots[n].Locasion()[0]]=1; }
        } 

        public int[,] MAP()
        {
            return localMap;
        } 

        public bool stopmark()
        {
            int k = CrossTask.IndexOf(3);
            if (k == -1) { k = CrossTask.IndexOf(2); }
            if (k == -1) { k = CrossTask.IndexOf(1); }
            if (k == -1)
            {
                for (k = 0; k < robots.Length; k++)
                {
                    if (!robots[k].Status()) { return true; }
                }
                return false;
            }
            return true;

        } 

        int Whatway(int[] cross, int[] robot) {
            int[] road = new int[4];

            for(int i=0, j=0; i < localMap.GetLength(0);) {
                WayMap[i, j] = localMap[i, j];
                j++;
                if (j == localMap.GetLength(1)){ i++;j = 0; }
            }
            if (WayMap[robot[1]+1, robot[0]] != 0) { WayMap[robot[1], robot[0]] = 0; robot[1] = robot[1] + 1; road[0] = WhatwayREC(cross, robot); robot[1] = robot[1] - 1; }
            if (WayMap[robot[1]-1, robot[0]] != 0) { WayMap[robot[1], robot[0]] = 0; robot[1] = robot[1] - 1; road[1] = WhatwayREC(cross, robot); robot[1] = robot[1] + 1; }
            if (WayMap[robot[1], robot[0]+1] != 0) { WayMap[robot[1], robot[0]] = 0; robot[0] = robot[0] + 1; road[2] = WhatwayREC(cross, robot); robot[0] = robot[0] - 1; }
            if (WayMap[robot[1], robot[0]-1] != 0) { WayMap[robot[1], robot[0]] = 0; robot[0] = robot[0] - 1; road[3] = WhatwayREC(cross, robot); robot[0] = robot[0] + 1; }
            int mem = 10000000;
            if (road[0] != 0) { mem = 3; }
            if (road[1] != 0) { if (road[1] < road[0]|| road[0] == 0) { mem = 4; road[0] = road[1]; } }
            if (road[2] != 0) { if (road[2] < road[0]|| road[0] == 0) { mem = 1; road[0] = road[2]; } }
            if (road[3] != 0) { if (road[3] < road[0]|| road[0] == 0) { mem = 2; road[0] = road[3]; } }

            return (mem);
            }
        int WhatwayREC(int[] cross, int[] robot)
        {
            if (robot[0] == cross[0] && robot[1] == cross[1]) { return (1); }
            int[] road = new int[4];
            if (WayMap[robot[1] + 1, robot[0]] != 0) { WayMap[robot[1], robot[0]] = 0; robot[1] = robot[1] + 1; road[0] = + WhatwayREC(cross, robot); robot[1] = robot[1] - 1; } 
            if (WayMap[robot[1] - 1, robot[0]] != 0) { WayMap[robot[1], robot[0]] = 0; robot[1] = robot[1] - 1; road[1] = + WhatwayREC(cross, robot); robot[1] = robot[1] + 1; }
            if (WayMap[robot[1], robot[0] + 1] != 0) { WayMap[robot[1], robot[0]] = 0; robot[0] = robot[0] + 1; road[2] = + WhatwayREC(cross, robot); robot[0] = robot[0] - 1; }
            if (WayMap[robot[1], robot[0] - 1] != 0) { WayMap[robot[1], robot[0]] = 0; robot[0] = robot[0] - 1; road[3] = + WhatwayREC(cross, robot); robot[0] = robot[0] + 1; }

            if (road[1] != 0) { if (road[1] < road[0] || road[0] == 0) road[0] = road[1]; }
            if (road[2] != 0) { if (road[2] < road[0] || road[0] == 0) road[0] = road[2]; }
            if (road[3] != 0) { if (road[3] < road[0] || road[0] == 0) road[0] = road[3]; }

            if (road[0] != 0) { return (road[0]+1); }
                return (0);
        }






    }





}
