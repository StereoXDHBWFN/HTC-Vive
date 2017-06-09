using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK.SecondaryControllerGrabActions;
using VRTK.GrabAttachMechanics;
using VRTK;

public class SpawnObject : MonoBehaviour
{

    public Transform SpawnPoint;
    public Material newMaterialRef;
    [Tooltip("bla")]
    public bool cube = false;
    [Tooltip("bla")]
    public bool dalek = false;

    private string dalekpath = "../Dateiconverter/OBJFiles/DalekFull/DalekFull.obj";

    private string cubepath = "../Dateiconverter/OBJFiles/Cube/cube.obj";
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
        obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        obj.transform.position = SpawnPoint.position;
        obj.transform.rotation = SpawnPoint.rotation;
        obj.AddComponent<Rigidbody>();
        obj.GetComponent<Rigidbody>().detectCollisions = true;
        obj.AddComponent<BoxCollider>();
        obj.AddComponent<VRTK_InteractableObject>();
        obj.AddComponent<VRTK_FixedJointGrabAttach>();
        obj.AddComponent<VRTK_AxisScaleGrabAction>();
        obj.GetComponent<VRTK_AxisScaleGrabAction>().uniformScaling = true;
        obj.GetComponent<VRTK_InteractableObject>().isGrabbable = true;
        obj.GetComponent<VRTK_InteractableObject>().grabAttachMechanicScript = obj.GetComponent<VRTK_FixedJointGrabAttach>();
        obj.GetComponent<VRTK_InteractableObject>().secondaryGrabActionScript = obj.GetComponent<VRTK_AxisScaleGrabAction>();

    }

    public void toggleCube()
    {
        cube = !cube;
        if (cube)
        {
            GameObject.Find("CubeToggle").GetComponent<Image>().color = Color.red;
            dalek = false;
            GameObject.Find("DalekToggle").GetComponent<Image>().color = Color.white;
        }
        else
        {
            GameObject.Find("CubeToggle").GetComponent<Image>().color = Color.white;
            dalek = true;
            GameObject.Find("DalekToggle").GetComponent<Image>().color = Color.red;
        }
    }
    public void toggleDalek()
    {
        dalek = !dalek;
        if (dalek)
        {
            GameObject.Find("DalekToggle").GetComponent<Image>().color = Color.red;
            cube = false;
            GameObject.Find("CubeToggle").GetComponent<Image>().color = Color.white;
        }
        else
        {
            GameObject.Find("DalekToggle").GetComponent<Image>().color = Color.white;
            cube = true;
            GameObject.Find("CubeToggle").GetComponent<Image>().color = Color.red;
        }
    }

}
