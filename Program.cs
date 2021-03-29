using System;
using System.Collections.Generic;
using System.Linq;
using ATao.Model;
using ATao.DataInit;
using ATao.Util;

namespace ATao
{
    class Program
    {
        static void Main(string[] args)
        {
            //0.生成地图
            //1.初始化小车
            //2.开始走动，更新位置。
            //3.增加障碍后，实时更新路径。
            MapFactory.Create();
            CarFactory.InitCar();
            UpdateView.UpdateMain();
        }
    }
}
