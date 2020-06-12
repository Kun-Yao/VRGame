using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    private Transform targetPos; //跟隨的目標
    private Vector3 offsetPos; //固定位置
    private Vector3 tempPos; //臨時變量
    // Start is called before the first frame update
    void Start()
    {
        offsetPos = new Vector3(0, 8, -20);
        targetPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        tempPos = targetPos.position + targetPos.TransformDirection(offsetPos);
        transform.position = Vector3.Lerp(transform.position, tempPos, Time.fixedDeltaTime * 3);
        transform.LookAt(targetPos);
    }
}
