using System.Collections.Generic;

namespace AStar
{
    /// <summary>
    /// 导航网格信息
    /// </summary>
    public class NavMeshInfo
    {
        /// <summary>
        /// 所有三角形
        /// </summary>
        public List<AStarTriangle> allTriangle = new List<AStarTriangle>();

        /// <summary>
        /// 所有的重心
        /// </summary>
        public List<AStarPoint> allCentroid = new List<AStarPoint>();

        /// <summary>
        /// 三角形索引key点，value点构成的所有三角形，正常情况下有3个
        /// </summary>
        public Dictionary<AStarPoint, List<AStarTriangle>> pointIndexes = new Dictionary<AStarPoint, List<AStarTriangle>>();
    }
}
