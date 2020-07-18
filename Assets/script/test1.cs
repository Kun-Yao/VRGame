using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class test1 : MonoBehaviour
{
    
    private List<string> carList = new List<string>();
    private string test;
    private GameObject g;

    void Start()
    {
        StreamReader sr = new StreamReader("Assets/Resources/carList/list.txt");
        test = sr.ReadLine();
        while(test != null) {
        
            carList.Add(test);
            test = sr.ReadLine();
        }
        sr.Close();

        foreach (var car in carList) {
            
            g = GameObject.Find(car);
            if (g == null)
                Debug.Log("null");
            else
                Debug.Log(g.name);
        }
    }

}
