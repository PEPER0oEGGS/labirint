using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labirint
{
    public class Robot //(работает верно) КРОМЕ ТРЕКА
    {
        
        bool stat=true; // статус тру свободен фолс занят
        int[] locasion = new int[2]; // положение в 3д зависит от карты
        int[] lastlocasion = new int[2]; // прошлое положение (только при движении)
        int[] STOPlocasion = new int[2]; // положение такт назад
        int Crosstupe; // 1 - тупик 2 - дорога 3 - перекресток.
        public int Taskcounter = 0;
        int roadway = 0;// направления дорог
        int[,] Track; // локальная карта робота места где он ходил. надо слиять с глобальной картой что бы остальных орентировать.
        
       public void SetPoz(RealMap realMap, int i) // Инициализация робота 
        {
            locasion[0] = realMap.GetStart()[0];
            locasion[1] = realMap.GetStart()[1];
            lastlocasion[0] = realMap.GetStart()[0];
            lastlocasion[1] = realMap.GetStart()[1];
            Crosstupe = 1;
            Track = new int[realMap.GetXSize(), realMap.GetYSize()];
            if (realMap.Look(locasion[0] + 1, locasion[1]) == 0) { lastlocasion[0] = locasion[0] + 1; }
            if (realMap.Look(locasion[0] - 1, locasion[1]) == 0) { lastlocasion[0] = locasion[0] - 1; }
            if (realMap.Look(locasion[0], locasion[1] + 1) == 0) { lastlocasion[1] = locasion[1] + 1; }
            if (realMap.Look(locasion[0], locasion[1] - 1) == 0) { lastlocasion[1] = locasion[1] - 1; }
            
            TrackUpd();
        } //(работает верно)
       
        public void Mowe (int x, int y)  //  1 такт 1 ход принимает только +-1
        {
            lastlocasion[0] = locasion[0];
            lastlocasion[1] = locasion[1];
            locasion[0] = locasion[0] + x;
            locasion[1] = locasion[1] + y; 
            STOPlocasion[0] = locasion[0];
            STOPlocasion[1] = locasion[1];
            TrackUpd();
        } //(работает верно)

        public int Explove(RealMap realMap)  // исследование смотрит на карту определяет квадраты +-1 от себя и действует.
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
                if (!stat && Taskcounter!=0)
                {
                    stat = true; // исследование закончено 
                    Taskcounter++;
                }
                return 0;
            } //(работает верно)
            // дорога
            if (Crosstupe == 2) // если на дороге определить куда она идет.
            {
                switch (roadway)
                {
                    case 11: //верх низ
                        if (locasion[0] - 1 == lastlocasion[0]) { Mowe(1, 0); } //вниз
                        else{Mowe(-1, 0);}//вверх
                        break; 
                    case 110: //верх право
                        if (locasion[0] - 1 == lastlocasion[0]){Mowe(0, 1);}//право
                        else{ Mowe(-1, 0); } //вверх
                        break; 
                    case 1010: //верх лево
                        if (locasion[0] - 1 == lastlocasion[0]) {Mowe(0, -1); } //лево
                        else{Mowe(-1, 0); } //вверх
                        break; //низ право
                    case 101:
                        if (locasion[0] + 1 == lastlocasion[0]){ Mowe(0, 1); } //право
                        else { Mowe(1, 0); } //вниз
                        break; // низ лево
                    case 1001:
                        if (locasion[0] + 1 == lastlocasion[0]){ Mowe(0, -1); } //лево
                        else{ Mowe(1, 0); } //низ
                        break; //право лево
                    case 1100:

                        if (locasion[1] - 1 == lastlocasion[1]) { Mowe(0, 1); }// право
                        else{ Mowe(0, -1); } //лево
                            break;
                    default:
                        Console.Write("Error");
                        break;
                }

                return 0;
            } //(работает верно)
            //перекресток
            if (Crosstupe >= 3)
            {
                if (STOPlocasion[0] != locasion[0] && STOPlocasion[1] != locasion[1]) { TrackUpd(); }
                STOPlocasion[0] = locasion[0];
                STOPlocasion[1] = locasion[1];
                if (!stat)
                {
                    stat = true; // исследование закончено 
                    Taskcounter++;   
                }  
                return roadway;  
            }
            Console.WriteLine("Error Explove");
            return 0;
        } //(работает верно)

        public void lookaround(RealMap realMap) // определяет где он и куда может пойти 
        {
            Crosstupe = 0;
            roadway = 0;
            if (realMap.Look(locasion[0] + 1, locasion[1]) == 0) { Crosstupe++; roadway += 1; } //низ
            if (realMap.Look(locasion[0] - 1, locasion[1]) == 0) { Crosstupe++; roadway += 10; } //верх
            if (realMap.Look(locasion[0], locasion[1] + 1) == 0) { Crosstupe++; roadway += 100; } //вправо
            if (realMap.Look(locasion[0], locasion[1] - 1) == 0) { Crosstupe++; roadway += 1000; } //влево

        } //(работает верно)

        void TrackUpd() // запись трека для определения того где был робот (не учитывает повторный проход)
        {

        // Track[locasion[1], locasion[0]] = 1;
           Track[locasion[1], locasion[0]] += 1; //учитывает повторный проход
        } 

        public int[] Locasion() // Передает где он
        {
            return locasion;
        } //(работает верно)

        public int LastStep() // передает как туда пришел 
        {
            if (locasion[0] - 1 == lastlocasion[0]) { return (1); } //сверху
            if (locasion[0] + 1 == lastlocasion[0]) { return (2); } //снизу
            if (locasion[1] + 1 == lastlocasion[1]) { return (3); } //право
            if (locasion[1] - 1 == lastlocasion[1]) { return (4); } //лево
            return (-1);
        } //(работает верно)

        public int[,] GetTrack()
        {
            return Track;
        } // передает трек //(работает верно)

        public bool Status()
        {
            return stat;
        } // передает наличие задачи //(работает верно)

        public void SetActive()
        {
            stat = false;
        } // получает задачу  //(работает верно)

        public int Roadway() // направления дорог в пространстве //(работает верно)
        {
            return roadway;
        }

        public int Way()  //(работает верно)
        {
            int way = 0;

                for (int i=0, j = 0; j < Track.GetLength(1);)
                {
                    way += Track[i, j];
                    i++;
                    if(i == Track.GetLength(0)) { i = 0; j++; }
                }
            return way;
        }
            
        }
    }


