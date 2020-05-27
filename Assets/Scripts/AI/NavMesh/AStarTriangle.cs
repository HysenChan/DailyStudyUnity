namespace AStar
{
    /// <summary>
    /// 三角形
    /// </summary>
    public struct AStarTriangle
    {
        //三角形的三个点坐标
        public AStarPoint a;
        public AStarPoint b;
        public AStarPoint c;

        //三角形中心
        public AStarPoint centroid;

        public AStarTriangle(AStarPoint a,AStarPoint b,AStarPoint c)
        {
            this.a = a;
            this.b = b;
            this.c = c;

            //计算重心
            centroid.x = (a.x + b.x + c.x) / 3;
            centroid.y = (a.x + b.x + c.x) / 3;
            centroid.z = (a.x + b.x + c.x) / 3;
        }
    }
}
