using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    static GameManager carName; 
    public List<string> carList;
    
    void Awake () {

        if (carName == null) {
            carName = this;
            DontDestroyOnLoad(this);
        }
        else if (this != carName) {
            Destroy(gameObject);
        } 
    }     
}
