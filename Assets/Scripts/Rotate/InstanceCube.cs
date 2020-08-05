using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceCube : MonoBehaviour
{
    public GameObject myPrefab;
    public int totalNum = 5;
    public Transform desTransform;

    private void Start()
    {
        for (int i = 0; i < totalNum; i++)
        {
            float x = desTransform.position.x;
            float y = desTransform.position.y;
            float z = desTransform.position.z;
            GameObject obj = Instantiate(myPrefab, new Vector3(x + i * 1, y, z), desTransform.rotation) as GameObject;
        }
    }
}
