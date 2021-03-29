using System.Collections.Generic;
using ATao.Model;

namespace ATao.Test
{
    public class Block
    {
        public static  List<Point> blockList;

        public static void createBlock()
        {
            blockList = new List<Point>();
            blockList.Add(new Point(1,8));
            blockList.Add(new Point(2,8));
            blockList.Add(new Point(3,8));
            blockList.Add(new Point(4,8));
            blockList.Add(new Point(5,8));
            blockList.Add(new Point(4,10));
            blockList.Add(new Point(5,10));
            blockList.Add(new Point(6,10));
             blockList.Add(new Point(7,10));
             blockList.Add(new Point(8,10));
             blockList.Add(new Point(9,10));
            blockList.Add(new Point(1,12));
            blockList.Add(new Point(2,12));
            blockList.Add(new Point(3,12));
            blockList.Add(new Point(4,12));
            blockList.Add(new Point(5,12));
        }
    }
}