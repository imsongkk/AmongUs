using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public GameObject target;
    public void OnButtonClick()
    {
        if (target.activeSelf)
            target.SetActive(false);
        else
            target.SetActive(true);
    }
}
