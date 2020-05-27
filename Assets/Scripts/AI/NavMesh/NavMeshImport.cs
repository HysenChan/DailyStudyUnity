using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace AStar
{
    public class NavMeshImport
    {
        List<Vector3> allPoint = new List<Vector3>();

        public NavMeshInfo Load(string path)
        {
            List<string> fileInfo = LoadFile(path);
            NavMeshInfo navMeshInfo = ReadInfo(fileInfo);
            return navMeshInfo;
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        List<string> LoadFile(string path)
        {
            StreamReader sr = new StreamReader(path);

            string line;
            List<string> fileInfo = new List<string>();
            while ((line = sr.ReadLine()) != null)
            {
                //一行一行的读取
                //把每一行的内容存入数组链表容器
                fileInfo.Add(line);
            }
            //关闭流
            sr.Close();
            //销毁流
            sr.Dispose();
            //将数组链表容器返回
            return fileInfo;
        }

        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="fileInfo">文件信息</param>
        /// <returns></returns>
        NavMeshInfo ReadInfo(List<string> fileInfo)
        {
            NavMeshInfo navMeshInfo = new NavMeshInfo();

            for (int i = 0; i < fileInfo.Count; i++)
            {
                string str = fileInfo[i];

                string[] Split = str.Split(' ');

                if (Split[0] == "v")
                {
                    allPoint.Add(new Vector3(float.Parse(Split[1]), float.Parse(Split[2]), float.Parse(Split[3])));
                }
                else if (Split[0] == "f")
                {
                    int indicesA = int.Parse(Split[1]);
                    int indicesB = int.Parse(Split[2]);
                    int indicesC = int.Parse(Split[3]);

                    Vector3 a = allPoint[indicesA - 1];
                    Vector3 b = allPoint[indicesB - 1];
                    Vector3 c = allPoint[indicesC - 1];

                    AStarPoint aStarPointA = new AStarPoint(a);
                    AStarPoint aStarPointB = new AStarPoint(b);
                    AStarPoint aStarPointC = new AStarPoint(c);

                    AStarTriangle triangle = new AStarTriangle(aStarPointA, aStarPointB, aStarPointC);

                    navMeshInfo.allCentroid.Add(triangle.centroid);

                    AddPointIndices(navMeshInfo.pointIndexes, aStarPointA, triangle);
                    AddPointIndices(navMeshInfo.pointIndexes, aStarPointB, triangle);
                    AddPointIndices(navMeshInfo.pointIndexes, aStarPointC, triangle);
                }
            }
            return navMeshInfo;
        }

        /// <summary>
        /// 添加顶点索引
        /// </summary>
        /// <param name="navMeshInfo"></param>
        /// <param name="point"></param>
        /// <param name="triangle"></param>
        void AddPointIndices(Dictionary<AStarPoint, List<AStarTriangle>> navMeshInfo, AStarPoint point, AStarTriangle triangle)
        {
            if (navMeshInfo.ContainsKey(point))
            {
                navMeshInfo[point].Add(triangle);
            }
            else
            {
                List<AStarTriangle> list = new List<AStarTriangle>();
                list.Add(triangle);
                navMeshInfo.Add(point, list);
            }
        }
    }
}
