using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class camera_switch : MonoBehaviour
{
    Camera firstpers;
    Camera thirdpers;
    GameObject first;
    GameObject third;
    GameObject engine;
    //GameObject MainCam;
    // Start is called before the first frame update
    void Start()
    {
        //MainCam = GameObject.Find("Main Camera");
        engine = this.gameObject;
        Debug.Log(engine.name);
        first = GameObject.Find("first");
        first.transform.localPosition = new Vector3(0, engine.transform.localScale.y/10, engine.transform.localScale.z/30);
        Debug.Log(first.transform.position);
        firstpers = first.GetComponent<Camera>();

        third = GameObject.Find("third");
        third.transform.localPosition = new Vector3(0, engine.transform.localScale.y, -engine.transform.localScale.z-3);
        thirdpers = third.GetComponent<Camera>();

        firstpers.enabled = false;
        //MainCam.GetComponent<Camera>().enabled = false;
        thirdpers.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            if (firstpers.enabled)
            {
                firstpers.enabled = false;
                Thread.Sleep(100);
                thirdpers.enabled = true;
                Debug.Log("third");
            }
            else if(thirdpers.enabled)
            {
                thirdpers.enabled = false;
                Thread.Sleep(100);
                firstpers.enabled = true;
                Debug.Log("first");
            }
            else
            {
                Debug.Log("已經沒有了");
            }
        }
    }
}
