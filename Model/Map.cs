namespace ATao.Model
{
    public class Map
    {
        public Vector2 vector = new Vector2();

        //0:通道，1障碍物，2有车，3冻结
        public int type;

        public Map(int x,int y,int type)
        {
            this.vector.x = x;
            this.vector.y = y;
            this.type = type;
        }
    }
}