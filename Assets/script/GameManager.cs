using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    static GameManager car; 
    public string carName;
    
    void Awake () {

        if (car == null) {
            car = this;
            DontDestroyOnLoad(this);
        }
        else if (this != car) {
            Destroy(gameObject);
        } 
    }     
}
