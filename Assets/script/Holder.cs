using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

public class Holder : MonoBehaviour
{
    public SteamVR_LaserPointer laser;

    void Awake()
    {
        laser = GetComponent<SteamVR_LaserPointer>();
        laser.PointerIn -= PointerInside;
        laser.PointerIn += PointerInside;
        laser.PointerOut -= PointerOutside;
        laser.PointerOut += PointerOutside;
        laser.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == "car")
            Debug.Log("clicked");
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        Debug.Log("in");
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        Debug.Log("out");
    }
}
