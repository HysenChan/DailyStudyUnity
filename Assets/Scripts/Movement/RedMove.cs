using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMove : MonoBehaviour
{
    public int moveSpeed = 3;
    public float debugTime = 0f;

    private void FixedUpdate()
    {
        //沿Z轴移动：
        //第一种表示方式
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
        //第二种表示方式
        //transform.Translate(0, 0, Time.deltaTime*moveSpeed);
        //第三种表示方式，基于世界坐标
        //transform.Translate(0, 0, Time.deltaTime * moveSpeed, Space.World);
        //第四种表达方式，基于自身坐标
        //transform.Translate(0, 0, Time.deltaTime * moveSpeed, Space.Self);

        //相对于摄像机每秒1单位向右移动物体
        //transform.Translate(Vector3.right * Time.deltaTime*moveSpeed, Camera.main.transform);
    }
}
