namespace ATao.Model
{
    public class Map
    {
        public Vector2 vector = new Vector2();

        //0:通道，1障碍物
        public int type;
        //todo 有车，冻结

        public Map(int x,int y,int type)
        {
            this.vector.x = x;
            this.vector.y = y;
            this.type = type;
        }
    }
}