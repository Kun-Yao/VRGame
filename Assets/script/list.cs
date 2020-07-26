using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class list : MonoBehaviour
{
    RawImage ri;
    GameObject g;
    Vector3 PosOfCar;
    Quaternion Rot;
    TextAsset ta;
    string[] vs;
    GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        PosOfCar = new Vector3(-250, -135, 190);
        Rot = Quaternion.Euler(0, 1, 0);
        ri = (RawImage)FindObjectOfType(typeof(RawImage));
        ta = Resources.Load<TextAsset>("carList/list");
        vs = ta.text.Split('\n');
        // for(int i=0; i<vs.Length-1; i++)
        // {
        //     vs[i] = vs[i].Substring(0, vs[i].Length - 1);
        // }

        camera = GameObject.Find("CarCamera");

        for (int i = 0; i < vs.Length-1; i++)
        {
            RawImage tmp = Instantiate(ri, transform);
            tmp.name = (i).ToString();
            //tmp.texture = null;
            tmp.color = new Color(255, 255, 255, 0);

            g = (GameObject)Instantiate(Resources.Load(vs[i]), tmp.transform.position, Rot, tmp.transform);
            g.transform.localPosition = PosOfCar;
            g.transform.localScale = new Vector3(10, 10, 10);
            Debug.Log(g.transform.lossyScale + " " + g.name);
            
            tmp.gameObject.AddComponent<Button>();
            tmp.gameObject.AddComponent<chooseCar>();
            if (g == null)
            {
                Debug.Log("null");
            }
            else
            {
                Debug.Log(g.name);
            }

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