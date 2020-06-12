using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToDrive : MonoBehaviour
{
    
    public string goToTheScene;

    [SerializeField]
    Transform engine;

    public void Play() {

        //engine.GetComponent<carcontrol4>().enabled = true;
        engine.GetComponent<BuildBlock>().enabled = false;
        SceneManager.LoadScene(goToTheScene);
    }
}
