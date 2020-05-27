using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMove : MonoBehaviour
{
    public GameObject RedBall;
    public int MoveSpeed = 10;

    private void FixedUpdate()
    {
        //蓝球沿着红球坐标系的z轴正向以和红球同样的速度匀速运动。
        transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime, RedBall.transform);
    }
}
