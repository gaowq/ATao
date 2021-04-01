using System;
using System.Collections.Generic;
using System.Linq;
using ATao.DataInit;
using ATao.Util;

namespace ATao.Model
{
    public class Tao
    {
        public Vector2 vector2;
        public Tao previous;

        public int f;
        public int g;
        public int h;

        public Tao(Vector2 vector2)
        {
            this.vector2 = vector2;
        }

        public Tao(int x, int y)
        {
            this.vector2 = new Vector2();
            this.vector2.x = x;
            this.vector2.y = y;
        }

        /**
        重新计算数据
        */
        public void Refresh(Vector2 end)
        {
            CalculateG();
            CalculateH(end);
            this.f = this.g + this.h;
        }

        public void CalculateG()
        {
            var now = this;
            var g = 1;

            while (now.previous != null)
            {
                now = now.previous;
                g++;
            }

            this.g = g;
        }

        public void CalculateH(Vector2 end)
        {
            this.h = Math.Abs(this.vector2.x - end.x) + Math.Abs(this.vector2.y - end.y);
        }

        public List<Tao> getNextList()
        {
            List<Tao> nextList = new List<Tao>();

            var nearUsefulMapList = MapFactory.GetNearByVector(this.vector2,true);

            foreach(var nearMap in nearUsefulMapList)
            {
                Tao newTao =new Tao(nearMap.vector);
                newTao.previous = this;

                nextList.Add(newTao);
            }

            return nextList;
        }
    }
}