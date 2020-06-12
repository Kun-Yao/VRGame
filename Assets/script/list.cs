using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class list : MonoBehaviour
{
    
    GameObject[] item;
    GameObject buttonControl;
    int y = 130;
    
    // Start is called before the first frame update
    void Start()
    {
        
        //item = carevent.getll();
        Debug.Log(carevent.ll[0]);
        //resources.load

        //button.AddComponent<Text>().text = item[0];
        //button.GetComponent<Text>().text = item[0];
        //buttonControl = GameObject.Find("buttonControl");
        
        
        y = y - 40;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
