using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AStar
{
    /// <summary>
    /// 点
    /// </summary>
    public struct AStarPoint
    {
        public int x;
        public int y;
        public int z;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="point"></param>
        public AStarPoint(Vector3 point)
        {
            x = (int)(point.x * AStarConfig.precision);
            y = (int)(point.y * AStarConfig.precision);
            z = (int)(point.z * AStarConfig.precision);
        }
    }
}
