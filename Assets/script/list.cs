using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class list : MonoBehaviour
{
    RawImage ri;
    GameObject g;
    Vector3 Pos;
    Quaternion Rot;
    List<string> vs;
    GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        Pos = new Vector3(-131, -69, 0);
        Rot = Quaternion.Euler(0, 45, 0);
        ri = (RawImage)FindObjectOfType(typeof(RawImage));
        vs = carevent.GetList();
        camera = GameObject.Find("carCamera");
        for (int i = 0; i < vs.Count; i++)
        {

            RawImage tmp = Instantiate(ri, transform);
            tmp.name = (i).ToString();
            g = (GameObject)Instantiate(Resources.Load(vs[i]), tmp.transform.position, Rot, tmp.transform);
            g.transform.localScale = new Vector3(10, 10, 10);
            Debug.Log(g.transform.lossyScale + " " + g.name);
            Pos += new Vector3(50, 0, 0);
            tmp.gameObject.AddComponent<Button>();
            tmp.gameObject.AddComponent<chooseCar>();
        }


        //for(int i=0; i<carevent.GetList().Count; i++)
        //{
        //    //生成list內的東西
        //    Instantiate()
        //}

    }

    // Update is called once per frame
    void Update()
    {

    }

}