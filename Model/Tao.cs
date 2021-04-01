using System;
using System.Collections.Generic;
using System.Linq;
using ATao.DataInit;
using ATao.Util;

namespace ATao.Model
{
    public class Tao
    {
        public Vector2 vector2 = new Vector2();
        public Tao previous;

        public int f;
        public int g;
        public int h;

        public Tao(int x, int y)
        {
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

            Tao west = new Tao(this.vector2.x - 1, this.vector2.y);
            west.previous = this;
            if (canBeUse(west)) nextList.Add(west);

            Tao east = new Tao(this.vector2.x + 1, this.vector2.y);
            east.previous = this;
            if (canBeUse(east)) nextList.Add(east);

            Tao north = new Tao(this.vector2.x, this.vector2.y + 1);
            north.previous = this;
            if (canBeUse(north)) nextList.Add(north);

            Tao south = new Tao(this.vector2.x, this.vector2.y - 1);
            south.previous = this;
            if (canBeUse(south)) nextList.Add(south);

            return nextList;
        }

        public bool canBeUse(Tao next)
        {
            //var nextV2 = next.vector2;
            var map = MapFactory.FindByVector(next.vector2);

            return (map != null && map.type == 0 && map.dynamicType == 0);//MapFactory.map.Where(q => q.vector.x == nextV2.x && q.vector.y == nextV2.y && q.type == 0 && q.dynamicType == 0).Count() > 0;
            //return CommonUtil.CanRun(next.vector2);
        }
    }
}