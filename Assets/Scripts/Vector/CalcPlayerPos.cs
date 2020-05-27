using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcPlayerPos : MonoBehaviour
{
    [SerializeField]
    private Transform playerPos;

    // Update is called once per frame
    void Update()
    {
        Vector3 destination = playerPos.position - transform.position;
        destination.Normalize();
        Debug.DrawRay(transform.position,destination, Color.green);
        transform.Translate(destination*Time.deltaTime);
    }
}
