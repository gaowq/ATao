using System;
using System.Linq;
using ATao.DataInit;
using ATao.Model;

namespace ATao.Util
{
    public class CommonUtil
    {

        //获取坐标组合生成的字典键
        public static string CombineKeyByVector2(Vector2 vector2)
        {
            return CombineKeyByVector2(vector2.x, vector2.y);
        }

        public static string CombineKeyByVector2(int x, int y)
        {
            return String.Format("{0}_{1}", x, y);
        }
    }
}