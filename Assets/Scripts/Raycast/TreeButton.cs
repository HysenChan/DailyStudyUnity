using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeButton : MonoBehaviour
{
    public GameObject treePrefab;

    public void PressButton()
    {
        FindObjectOfType<Placement>().selectedPrefab = treePrefab;
    }
}
