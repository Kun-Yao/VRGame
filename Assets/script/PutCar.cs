using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutCar : MonoBehaviour {

    GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start() {
        
        Instantiate(Resources.Load(gameManager.carName), new Vector3(10, 10, 10), transform.rotation);
    }

}
