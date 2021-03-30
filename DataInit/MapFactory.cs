using System.Collections.Generic;
using ATao.Model;

namespace ATao.DataInit
{
    public class MapFactory
    {
        public static List<Map> map;
        public static int xl = 5;//横坐标数量
        public static int yl = 5;//纵坐标数量

        public static void Create()
        {
            var newMap = new List<Map>();
            newMap.Add(new Map(1, 1, 0));
            newMap.Add(new Map(1, 2, 0));
            newMap.Add(new Map(1, 3, 1));
            newMap.Add(new Map(1, 4, 0));
            newMap.Add(new Map(1, 5, 0));

            newMap.Add(new Map(2, 1, 0));
            newMap.Add(new Map(2, 2, 0));
            newMap.Add(new Map(2, 3, 1));
            newMap.Add(new Map(2, 4, 0));
            newMap.Add(new Map(2, 5, 0));

            newMap.Add(new Map(3, 1, 0));
            newMap.Add(new Map(3, 2, 0));
            newMap.Add(new Map(3, 3, 1));
            newMap.Add(new Map(3, 4, 0));
            newMap.Add(new Map(3, 5, 0));

            newMap.Add(new Map(4, 1, 0));
            newMap.Add(new Map(4, 2, 0));
            newMap.Add(new Map(4, 3, 0));
            newMap.Add(new Map(4, 4, 0));
            newMap.Add(new Map(4, 5, 0));

            newMap.Add(new Map(5, 1, 0));
            newMap.Add(new Map(5, 2, 0));
            newMap.Add(new Map(5, 3, 0));
            newMap.Add(new Map(5, 4, 0));
            newMap.Add(new Map(5, 5, 0));

            map = newMap;
        }

    }
}