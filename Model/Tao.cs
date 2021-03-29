using System;
using System.Collections.Generic;
using System.Linq;
using ATao.Test;

namespace ATao.Model
{
    public class Tao
    {
        public int x;
        public int y;
        public Tao previous;
        public int f;
        public int g;
        public int h;

        public Tao(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Refresh(Tao end)
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

        public void CalculateH(Tao end)
        {
            this.h = Math.Abs(this.x - end.x) + Math.Abs(this.y - end.y);
        }

        public List<Tao> getNextList()
        {
            List<Tao> nextList = new List<Tao>();

            Tao west = new Tao(this.x - 1, this.y);
            west.previous = this;
            if (canBeUse(west)) nextList.Add(west);

            Tao east = new Tao(this.x + 1, this.y);
            east.previous = this;
            if (canBeUse(east)) nextList.Add(east);

            Tao north = new Tao(this.x, this.y + 1);
            north.previous = this;
            if (canBeUse(north)) nextList.Add(north);

            Tao south = new Tao(this.x, this.y - 1);
            south.previous = this;
            if (canBeUse(south)) nextList.Add(south);

            return nextList;
        }

        public bool canBeUse(Tao next)
        {
            if (Block.blockList.Where(q => q.x == next.x && q.y == next.y).Count() > 0) return false;

            return next.x < 20 && next.x > 0 && next.y < 20 && next.x > 0;
        }
    }
}