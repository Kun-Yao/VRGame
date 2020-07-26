using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chooseCar : MonoBehaviour
{
    Button btn;
    GameObject camera;
    GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("CarCamera");
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(click);
    }

    private void click()
    {
        GameObject game = transform.GetChild(0).gameObject;
        camera.transform.position = new Vector3(game.transform.position.x, 150, 225);
        game.transform.rotation = Quaternion.Euler(0, 2, 0);
        //物件旋轉(未完成)
        carevent.setTarget(transform.GetChild(0).gameObject);
        //Debug.Log(carevent.getTarget().name);

        //儲存輸入車子名
        int pos = game.name.IndexOf("(");
        game.name = game.name.Substring(0, pos);
        gameManager.carName = game.name;
        Debug.Log("aaaaa");
        Debug.Log(gameManager.carName);
    }

}