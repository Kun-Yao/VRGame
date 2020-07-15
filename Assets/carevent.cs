using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class carevent
{
    public static void ResetCar(GameObject gameObject, Vector3 Position)
    {
        GameObject.Destroy(gameObject);
        Debug.Log("1");
        GameObject newG = GameObject.Instantiate(gameObject, Position, Quaternion.Euler(0, 0, 0));
        Debug.Log("2");
        newG.GetComponent<test>().enabled = true;
        newG.transform.GetChild(1).GetComponentInChildren<Camera>().enabled = true;
    }

    //建立list
    public static List<string> vehicle = new List<string> { "Chev666", "111", "222", "333", "444"};

    public static void addlist(string name)
    {
        vehicle.Add(name);
    }

    public static List<string> GetList()
    {
        return vehicle;
    }

    //選賽車
    static GameObject target;
    public static void setTarget(GameObject car)
    {
        target = car;
    }
    public  static GameObject getTarget()
    {
        //target.transform.GetChild(1).transform.GetComponent<Camera>().enabled = true;
        return target;
    }
    
    
}
