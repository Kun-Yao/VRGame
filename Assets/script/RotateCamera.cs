using System.Collections;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    
    void Update()
    {
        
        if (Input.GetKey("left"))
            Camera.main.transform.RotateAround(Vector3.zero, Vector3.up, 200 * Time.deltaTime);
        else if (Input.GetKey("right"))
            Camera.main.transform.RotateAround(Vector3.zero, Vector3.up, -200 * Time.deltaTime);
    }
}
