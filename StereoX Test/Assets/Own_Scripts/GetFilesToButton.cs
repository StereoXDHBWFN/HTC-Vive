using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GetFilesToButton : MonoBehaviour {

    [Tooltip("Pfad zum Ordner, welcher die Subordner mit den Objekten enthält.")]
    private string objectsPath = ".\\OBJFiles";

    [SerializeField] Transform Parent;
    [SerializeField] GameObject buttonPrefab;
    static string[] objectFolders;
	// Use this for initialization
	void Start () {

        objectFolders = Directory.GetDirectories(objectsPath);
        for ( int i = 0; i < objectFolders.Length; i++)
        {
            DirectoryInfo dir = new DirectoryInfo(objectFolders[i]);
            GameObject button = (GameObject)Instantiate(buttonPrefab);
            button.name = "Button " + i;
            int a = i;
            button.GetComponentInChildren<Text>().text = dir.Name;
            button.GetComponent<Button>().onClick.AddListener(() => { toggleButton(a); });
            button.transform.SetParent(Parent.transform, false);
        }
	}
	
    public static string[] getPaths()
    {
        return objectFolders;
    }

    void toggleButton(int ind)
    {
        print("toggle " + ind);
        GameObject.Find("WorldSpaceMenu").GetComponent<SpawnObject>().toggle(ind);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
