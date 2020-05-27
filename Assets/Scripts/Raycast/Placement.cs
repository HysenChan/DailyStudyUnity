using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    #region OnlyOneTree
    //public LayerMask planeMask;
    //public GameObject cube;

    //public GameObject selectedPrefab;

    //private void Update()
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //    if (Physics.Raycast(ray, out RaycastHit hitInfo,Mathf.Infinity,planeMask))
    //    {
    //        cube.transform.position = hitInfo.point;
    //        cube.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
    //    }

    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Instantiate(cube, hitInfo.point, Quaternion.FromToRotation(Vector3.up, hitInfo.normal));
    //    }
    //}
    #endregion

    #region ThreeTrees
    public LayerMask planeMask;
    public GameObject selectedPrefab;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, planeMask))
        {
            selectedPrefab.transform.position = hitInfo.point;
            selectedPrefab.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(selectedPrefab, hitInfo.point, Quaternion.FromToRotation(Vector3.up, hitInfo.normal));
        }
    }
    #endregion
}
