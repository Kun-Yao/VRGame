using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public GameObject panel;
     
    public void pop() {

        if (panel != null)
            panel.SetActive(!panel.activeSelf);
    }
}
