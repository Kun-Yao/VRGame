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
    TextAsset ta;
    string s;
    GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        Pos = new Vector3(-131, -69, 0);
        Rot = Quaternion.Euler(0, 0, 0);
        ri = (RawImage)FindObjectOfType(typeof(RawImage));
        ta = Resources.Load<TextAsset>("carList/list");
        s = ta.text;
        string[] vs = s.Split('\n');
        for(int i = 0; i<2; i++)
        {
            Debug.Log(vs[i]);
        }
        camera = GameObject.Find("CarCamera");
        for (int i = 0; i < vs.Length; i++)
        {
            RawImage tmp = Instantiate(ri, transform);
            tmp.name = (i).ToString();
            tmp.texture = null;
            tmp.color = new Color(255, 255, 255, 0);
            g =GameObject.Find(vs[i]);
            //g = GameObject.Find("green");
            if(g == null)
            {
                Debug.Log("null");
            }
            else
            {
                Debug.Log(g.name);
            }
            //g = (GameObject)Instantiate(Resources.Load(vs[i]), tmp.transform.position, Rot, tmp.transform);
            //g.transform.localScale = new Vector3(10, 10, 10);
            //Debug.Log(g.transform.lossyScale + " " + g.name);
            //Pos += new Vector3(50, 0, 0);
            //tmp.gameObject.AddComponent<Button>();
            //tmp.gameObject.AddComponent<chooseCar>();
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