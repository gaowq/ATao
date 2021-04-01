using System;
using System.Collections.Generic;
using ATao.Model;

namespace ATao.DataInit
{
    //初始化时保存地图点信息
    //同时用dictionary和list保存，一个索引一个遍历
    public class MapFactory
    {
        public static List<Map> map;

        public static Dictionary<string, Map> mapDic;
        public static int xl = 20;//横坐标数量
        public static int yl = 10;//纵坐标数量

        public static void Create()
        {
            var newMap = new List<Map>();
            mapDic = new Dictionary<string, Map>();
            for (int i = 1; i <= xl; i++)
            {
                for (int j = 1; j <= yl; j++)
                {
                    int b = 0;//可通行

                    if (i < 5 && j == 3) b = 1;//添加障碍物

                    Map map1 = new Map(i, j, b);

                    newMap.Add(map1);
                    mapDic.Add(String.Format("{0}_{1}", i, j), map1);
                }
            }

            map = newMap;
        }

        public static Map FindByVector(int x, int y)
        {
            string key = string.Format("{0}_{1}", x, y);

            if (mapDic.ContainsKey(key))
            {
                return mapDic[key];
            }
            else
            {
                return null;
            }
        }

        public static Map FindByVector(Vector2 vector)
        {
            return FindByVector(vector.x, vector.y);
        }
    }
}