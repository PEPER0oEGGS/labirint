using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labirint
{
    class RealMap
    {
        int[,] map; // карта и ее размер.
        int[] start = new int[2];
        public void load(int[,] newMap,int x, int y) //загрузка карты 
        {
            map = newMap;
            start[0] = x;
            start[1] = y;
        }

        public int GetXSize() //получить размер по х
        {
         return map.GetLength(0);
        }

        public int GetYSize() //получить размер по y
        {
            return map.GetLength(1);
        }

        public int Look(int x, int y)//получить размер по x
        {
            return map[x, y];
        }
        public int[] GetStart() //получить размер по х
        {
            return start;
        }

    }
}
