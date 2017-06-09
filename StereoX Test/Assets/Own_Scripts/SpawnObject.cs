using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObject : MonoBehaviour
{

    public Transform SpawnPoint;
    public Material newMaterialRef;
    [Tooltip("bla")]
    public bool cube = false;
    [Tooltip("bla")]
    public bool dalek = false;

    private string dalekpath = "C:/Users/Patrick/Desktop/dalekFull.obj";

    private string cubepath = "C:/Users/Patrick/Desktop/cube.obj";
    public void SpawnObj()
    {
        Mesh holderMesh = new Mesh();
        ObjImporter newMesh = new ObjImporter();
        if(cube)
        {
            holderMesh = newMesh.ImportFile(cubepath);
        }
        if(dalek)
        {
            holderMesh = newMesh.ImportFile(dalekpath);
        }

        //MeshRenderer renderer = gameObject.AddComponent<MeshRenderer>();
        //MeshFilter filter = gameObject.AddComponent<MeshFilter>();
        //filter.mesh = holderMesh;
        //renderer.material = newMaterialRef;

        GameObject obj = new GameObject();
        obj.AddComponent<MeshRenderer>();
        obj.AddComponent<MeshFilter>();
        obj.GetComponent<MeshFilter>().mesh = holderMesh;
        obj.GetComponent<MeshRenderer>().material = newMaterialRef;
        obj.transform.position = SpawnPoint.position;
        obj.transform.rotation = SpawnPoint.rotation;
        obj.AddComponent<Rigidbody>();
        obj.GetComponent<Rigidbody>().detectCollisions = true;


    }

    public void toggleCube()
    {
        cube = !cube;
        if (cube)
        {
            GameObject.Find("CubeToggle").GetComponent<Image>().color = Color.red;
        }
        else
        {
            GameObject.Find("CubeToggle").GetComponent<Image>().color = Color.white;
        }
    }
    public void toggleDalek()
    {
        dalek = !dalek;
        if (dalek)
        {
            GameObject.Find("DalekToggle").GetComponent<Image>().color = Color.red;
        }
        else
        {
            GameObject.Find("DalekToggle").GetComponent<Image>().color = Color.white;
        }
    }

}
