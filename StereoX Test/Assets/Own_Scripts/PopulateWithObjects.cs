using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateWithObjects : MonoBehaviour {

    public Transform cubeSpawn;
    
    // Use this for initialization
	void Start () {
        GameObject item = Instantiate(Resources.Load(".../Dateiconverter/OBJFiles/DalekFull/DalekFull.obj", typeof(GameObject))) as GameObject;
        item.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        item.transform.position = cubeSpawn.position;
        item.transform.rotation = cubeSpawn.rotation;
        item.AddComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
