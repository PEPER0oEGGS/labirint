﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labirint
{
    public class MapRob
    {// карта построеная роботами = граф - перекресток/связь(длинна)/

        public List <Cross> Crosstreat = new List<Cross>(); // известные перекрестки

        public void Mapadd(Cross cross)
        {
            if (Crosstreat.Contains(cross)) { Crosstreat.Add(cross); }
            else
        }
        
        public void UpdCross()
        {
            if(Crosstreat.An)
        }
        public Cross UpdCross()
        {
            return Crosstreat(1);
        }

    }
   public class Cross //Перекресток
    {
        int crosnumber; // номер перекрестка. 
        int activeQvest; //количество задач в этом перекрестке (неииследованные тонели) нужно чтоб роботы бежали в тунель брать квесты (если они там есть)
        int Cnowroad; // исследованные пути перекрестка. для навигации чтоб пути искать не знаем - забиваем на перекресток. можно знать куда ведут пока хз*
        // выходы в 4 стороны либо не направленно, либо Cnowroad указывает вход и выход относительно ХУ (верх низ право лево и их комбинации. тупик может ссылатся сам на себя*)

        /* первый перекресток (П) допустим имеет вход и две дороги
         * 111110111
         * 00000П000
         * 111111111
         * 
         * тк дорога из начала (вход в лабиринт) не нужна мы говорим что она ведет в этот же перекресток, при поиске пути мы мищем дорогу и если попадаем туда где были - удаляем путь
         * 
         * это НЕ поможет убрать циклы типа вообщем хз
         * 
         * 111111111111111111
         * 00000000П0000П1111
         * 111111110111101111
         * 11111111П0000П1111
         * 
         */
        Cross outcross0; // направление 0 вход в перекресток (у нулевого не должно быть или в маршруте учту хз пока)
        Cross outcross1; // направление 1 (если есть (не тупик и исследованна))
        Cross outcross2; // направление 2 (если есть (не тупик и исследованна))
        Cross outcross3; // направление 3 (если есть (не тупик и исследованна))

        Road Road0; // Дорога 0 (у нулевого не должно быть или в маршруте учту хз пока)
        Road Road1; // Дорога 1 (дорога к первому направлению если есть)
        Road Road2; // Дорога 2 --\\--
        Road Road3; // Дорога 3 --\\--
    }
   public class Road //Связь
    {
        int RoadNomber; // для различия дорог. мб вообще не нужно
        int Longway; //Длинна
       
    }

   public class Navi //навигация
    {  
        /* Идея такая. 
         * 1) робот кидает сюда запрос куда ему надо и где он находится.
         * 
         * Идея - пеллинг от противного (торговая марка)
         * 
         * берем точку куда нам надо и из всех ее известных дорог (1-3(иначе задания не будет))
         * 
         * получаем 3 пути (смежных перекрестка)
         * 
         * из них по 1-3 пути
         * 
         * как итог 3^n путей  максимум можно браковать пути ведущие в одну точку итд.
         * 
         * один 100% ведет туда где робот его и берем (инвертируем и кидаем роботу запросившему)
         * 
         * минус - может быть самым длиным по дорогам. - проверить потестив.
         * 
         */
    }


    // поражен что ты дошел до сюдя ибо я сошел с ума и хз как это реализовывать пока сделаю роботов
}
