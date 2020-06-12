using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class carcontrol4 : MonoBehaviour
{
    GameObject car;
    //new BoxCollider collider;
    new Rigidbody rigidbody;
    MeshRenderer[] tires;
    GameObject dashBoard;
    Camera third;

    int direction = 0;
    float maxspeed = 300;
    Vector3 checkPoint;
    float maxForce = 0;
    //float delayTime = 0;

    private void Start()
    {
        car = this.gameObject;
        rigidbody = transform.GetComponent<Rigidbody>();
        //rigidbody = car.AddComponent<Rigidbody>();
        //rigidbody.mass = 150;
        //rigidbody.centerOfMass = new Vector3(0, -1, 0);
        
        //collider = car.AddComponent<BoxCollider>();
        //collider.center = new Vector3(0, transform.lossyScale.y / 2, 0);
        //collider.size = transform.localScale;

        tires = transform.GetChild(0).GetComponentsInChildren<MeshRenderer>();
        dashBoard = GameObject.Find("Text");

        checkPoint = transform.position;
    }

    void Update()
    {
        //showSpeed();
        if (Mathf.Cos(car.transform.rotation.x) < 0.8 || Mathf.Cos(car.transform.rotation.z) < 0.8 || Input.GetKey(KeyCode.R))
        {
            Debug.Log("break");
            carevent.ResetCar(this.gameObject, checkPoint);
            Debug.Log(gameObject.name);

        }
        if (rigidbody.velocity.magnitude >= 0 || rigidbody.velocity.magnitude <= maxspeed)
        {
            dashBoard.GetComponent<Text>().text = (rigidbody.velocity.magnitude).ToString("0");
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("punch");
        if (other.gameObject.tag == "flag")
        {
            checkPoint = other.transform.position;
            Debug.Log(checkPoint);
        }
        else if (other.gameObject.CompareTag("ground"))
        {
            if (Mathf.Cos(transform.rotation.x) < 0.707 || Mathf.Cos(transform.rotation.z) < 0.707)
            {
                Debug.Log("轉起來啦");
                transform.position = checkPoint;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                rigidbody.velocity = new Vector3(0, 0, 0);
            }
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("ground") && (Mathf.Cos(transform.rotation.x) < 0.707 || Mathf.Cos(transform.rotation.z) < 0.707))
        {
            Debug.Log("轉起來啦");
            
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            rigidbody.velocity = new Vector3(0, 0, 0);
            transform.position = checkPoint;
        }
        if (collision.gameObject.CompareTag("ground"))
        {
            Move();
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            Debug.Log("123");
            direction = 0;

            rigidbody.velocity *= 0.93f;
            rigidbody.mass = Mathf.Infinity;
            maxForce = 0;
        }
    }

    private void Move()
    {
        rigidbody.mass = 300;
        rigidbody.AddForce(transform.forward * maxForce);
        //移動
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = 1;
            if (rigidbody.velocity.magnitude < maxspeed)
            {
                maxForce = 15000;
                for (int i = 0; i < 4; i++)
                {
                    tires[i].transform.Rotate(25 * rigidbody.velocity.magnitude, 0, 0);
                }
            }
            else
            {
                rigidbody.velocity = transform.forward * direction * maxspeed;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = -1;
            if (rigidbody.velocity.magnitude < maxspeed)
            {
                maxForce = -15000;
                for (int i = 0; i < 4; i++)
                {
                    tires[i].transform.Rotate(-25 * rigidbody.velocity.magnitude, 0, 0);
                }
            }
            else
            {
                rigidbody.velocity = transform.forward * direction * maxspeed;
            }
        }
        else
        {
            direction = 0;
            rigidbody.velocity *= 0.93f;
            maxForce = 0;
        }

        //轉彎
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Debug.Log("右轉");
            transform.Rotate(0, 0.75f * direction, 0);

            //Debug.Log(transform.rotation.y);
            for (int i = 0; i < 2; i++)
            {
                tires[i].transform.localRotation = Quaternion.Euler(0, 25, 0);
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Debug.Log("左轉");
            transform.Rotate(0, -0.75f * direction, 0);

            //Debug.Log(transform.rotation.y);
            //transform.Rotate(0, -1.5f * direction, 0);
            for (int i = 0; i < 2; i++)
            {
                tires[i].transform.localRotation = Quaternion.Euler(0, -25, 0);
            }
        }
        else
        {
            for (int i = 0; i < 2; i++)
            {
                tires[i].transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

    //private void showSpeed()
    //{
    //    delayTime += Time.time;
    //    Debug.Log(delayTime % 10);
    //    if (delayTime % 10 >= 5f)
    //    {
    //        dashBoard.GetComponent<Text>().text = (rigidbody.velocity.magnitude).ToString("0.0");
    //        delayTime = 0;
    //    }
    //}
}


