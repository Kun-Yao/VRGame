﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Control : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean grabAction;
    public SteamVR_Action_Boolean side;
    public SteamVR_Action_Boolean menu;
    public SteamVR_Action_Pose pose;

    public Ray ray;
    public RaycastHit hit;
    public bool bHit;

    public bool GetGrab()
    {
        ray = new Ray(transform.position, transform.forward);
        bHit = Physics.Raycast(ray, out hit);
        return grabAction.stateUp;
    }

    public bool Acceler()
    {
        //return grabAction.GetState(handType);
        return grabAction.stateUp;
    }

    //public bool GoBack()
    //{
    //    return side.state;
    //}

    public bool getmenu()
    {
        return menu.stateUp;
    }

    
}
