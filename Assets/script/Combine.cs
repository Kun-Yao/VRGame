using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.IO;


[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class Combine : MonoBehaviour {

    public GameObject engine;
    public GameObject panel;
    public GameObject dup;
    private string name;
    private string path, ass;
    private List<string> carList = new List<string>();
    private string test;


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
        
        if (save()) {

            Mesh msh = engine.GetComponent<MeshFilter>().sharedMesh;
            AssetDatabase.CreateAsset(msh, ass);
            AssetDatabase.SaveAssets();
            PrefabUtility.SaveAsPrefabAsset(engine, path);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            panel.SetActive(false);
        }

    }

    //確認名稱是否重複
    private bool save() {

        StreamReader sr = new StreamReader("Assets/Resources/carList/list.txt");
        test = sr.ReadLine();
        while(test != null) {
            Debug.Log(test);
            carList.Add(test);
            test = sr.ReadLine();
        }
        sr.Close();

        name = GameObject.Find("InputField").GetComponent<InputField>().text;

        bool isActive = true;
        foreach (string car in carList) {
            if (car.Equals(name)) {
                GameObject.Find("InputField").GetComponent<InputField>().text = "";
                isActive = false;
                if (dup != null)
                    dup.SetActive(true);
                break;
            }
        }

        if (isActive) {
            
            path = "Assets/Resources/" + name + ".Prefab";
            ass = "Assets/Resources/Model/" + name + ".asset";
            StreamWriter sw = new StreamWriter("Assets/Resources/carList/list.txt", true);
            sw.WriteLine(name);
            sw.Close();
            return true;
        }
        return false;
    }
}
