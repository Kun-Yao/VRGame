using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;


[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class Combine : MonoBehaviour {

    public GameObject engine;
    private string name;
    private string path, ass;
    GameManager gameManager;

    void Awake() {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void combine() {

        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];


        int i = 0;
        while (i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);

            i++;
        }
        transform.GetComponent<MeshFilter>().mesh = new Mesh();
        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        transform.gameObject.SetActive(true);

        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }

        name = GameObject.Find("InputField").GetComponent<InputField>().text;
        path = "Assets/Resources/" + name + ".Prefab";
        ass = "Assets/Resources/" + name + ".asset";

        gameManager.carList.Add(name);
        foreach (var car in gameManager.carList) {
            Debug.Log (car);
        }


        Mesh msh = engine.GetComponent<MeshFilter>().sharedMesh;
        AssetDatabase.CreateAsset(msh, ass);
        AssetDatabase.SaveAssets();
        PrefabUtility.SaveAsPrefabAsset(engine, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

    }
}
