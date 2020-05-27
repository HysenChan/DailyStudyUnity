using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 2f;
    Vector3 target;
    private Rigidbody rb;

    void Start()
    {
        //指定速度，使用刚体移动
        //rb = gameObject.GetComponent<Rigidbody>();
        ////往Z轴滚动
        //rb.velocity = Vector3.forward * moveSpeed;

        //使用Vector3.MoveTowards
        target = new Vector3(20, transform.position.y, 20);
    }

    private void FixedUpdate()
    {
        //rb.MovePosition(transform.position + transform.forward * Time.deltaTime);

        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }
}
