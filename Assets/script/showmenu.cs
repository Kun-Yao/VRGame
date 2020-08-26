using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showmenu : MonoBehaviour
{
    public GameObject right;
    public GameObject left;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (right.GetComponent<Control>().getmenu() || left.GetComponent<Control>().getmenu())
        {
            enabled = enabled ^ true;
        }
    }
}
