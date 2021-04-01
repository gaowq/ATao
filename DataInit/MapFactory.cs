using System;
using System.Collections.Generic;
using ATao.Model;
using ATao.Util;

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

                    if (i < 10 && j >= 3 && j <= 4) b = 1;//添加障碍物

                    if (i > 3 && j == 7) b = 1;//添加障碍物

                    Map map1 = new Map(i, j, b);

                    newMap.Add(map1);
                    mapDic.Add(CommonUtil.CombineKeyByVector2(i, j), map1);
                }
            }

            map = newMap;
        }

        public static Map FindByVector(int x, int y, bool isUseful = false)
        {
            string key = CommonUtil.CombineKeyByVector2(x, y);

            if (mapDic.ContainsKey(key))
            {
                if (!isUseful || (mapDic[key].type == 0 && mapDic[key].dynamicType == 0)) return mapDic[key];
            }
            return null;
        }

        public static Map FindByVector(Vector2 vector)
        {
            return FindByVector(vector.x, vector.y);
        }

        /**
            isUseful 为true表示只查询可以用的地图。false表示任意类型都可以
        */
        public static List<Map> GetNearByVector(Vector2 vector, bool isUseful = false)
        {
            var result = new List<Map>();

            var eastMap = MapFactory.FindByVector(vector.x + 1, vector.y, isUseful);
            var westMap = MapFactory.FindByVector(vector.x - 1, vector.y, isUseful);
            var northMap = MapFactory.FindByVector(vector.x, vector.y + 1, isUseful);
            var southMap = MapFactory.FindByVector(vector.x, vector.y - 1, isUseful);

            if (eastMap != null) result.Add(eastMap);
            if (westMap != null) result.Add(westMap);
            if (northMap != null) result.Add(northMap);
            if (southMap != null) result.Add(southMap);

            return result;
        }
    }
}