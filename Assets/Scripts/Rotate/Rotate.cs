using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private void Update()
    {
        //this.transform.Rotate(new Vector3(1, 0, 0));
        //this.GetComponent<Transform>().Rotate(0, 0, 1);
        //this.GetComponent<Transform>().Rotate(0, 0, 1, Space.World);
        //this.transform.Translate(0, 0, 1);
        //this.transform.Translate(0, 0, 1,Space.Self);
        this.transform.Translate(0, 0, 1, Space.World);
    }
}
