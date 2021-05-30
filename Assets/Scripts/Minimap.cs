using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        print(target.activeSelf);
        if (target.activeSelf)
            target.SetActive(false);
        else
            target.SetActive(true);
    }
}
