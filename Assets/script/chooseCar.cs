using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chooseCar : MonoBehaviour
{
    Button btn;
    GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("CarCamera");
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(click);
    }

    private void click()
    {
        camera.transform.position = transform.GetChild(0).position;
        carevent.setTarget(transform.GetChild(0).gameObject);
        //Debug.Log(carevent.getTarget().name);
    }
}