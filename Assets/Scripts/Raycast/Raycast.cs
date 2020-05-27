using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private float maxDistance = 10;
    public LayerMask mask;
    public Material materialHighlight;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        #region Raycast
        //RaycastHit hitInfo;
        //if (Physics.Raycast(ray, out hitInfo,maxDistance,mask,QueryTriggerInteraction.Ignore))
        //{
        //    Debug.Log(hitInfo.collider.gameObject.name);
        //    Debug.DrawLine(transform.position, hitInfo.point, Color.red);
        //}
        //else
        //{
        //    //Debug.DrawLine(ray.origin, ray.origin+ray.direction*100, Color.green);
        //    Debug.DrawRay(transform.position, transform.position + transform.forward*100, Color.yellow);
        //}
        #endregion

        #region RaycastAll
        RaycastHit[] hitInfos;
        hitInfos= Physics.RaycastAll(ray, maxDistance, mask);

        foreach (RaycastHit hit in hitInfos)
        {
            hit.collider.gameObject.GetComponent<Renderer>().material = materialHighlight;
        }
        #endregion
    }
}
