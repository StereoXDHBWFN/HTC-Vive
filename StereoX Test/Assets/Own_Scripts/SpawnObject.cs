using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK.SecondaryControllerGrabActions;
using VRTK.GrabAttachMechanics;
using VRTK;


public class SpawnObject : MonoBehaviour
{

    static void FitToChildren(GameObject rootGameObject)
    {
        bool hasBounds = false;
        Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);

        for (int i = 0; i < rootGameObject.transform.childCount; ++i)
        {
            Renderer childRenderer = rootGameObject.transform.GetChild(i).GetComponent<Renderer>();
            if (childRenderer != null)
            {
                if (hasBounds)
                {
                    bounds.Encapsulate(childRenderer.bounds);
                }
                else
                {
                    bounds = childRenderer.bounds;
                    hasBounds = true;
                }
            }
        }

        BoxCollider collider = (BoxCollider)rootGameObject.GetComponent<Collider>();
        collider.center = bounds.center - rootGameObject.transform.position;
        collider.size = bounds.size;
    }

    public Transform SpawnPoint;
    public Material newMaterialRef;
    [Tooltip("bla")]
    public bool cube = false;
    [Tooltip("bla")]
    public bool dalek = false;
    [Tooltip("bla")]
    public bool torus = false;

    private GameObject obj;
    private string dalekpath = "../Dateiconverter/OBJFiles/DalekFull/DalekFull.obj";
    private string large_torus_path = "../Dateiconverter/OBJFiles/large/large.obj";
    private string cubepath = "../Dateiconverter/OBJFiles/Cube/cube.obj";
    public void SpawnObj()
    {
        if (cube)
        {
            obj = OBJLoader.LoadOBJFile(cubepath);
        }
        else if (dalek)
        {
            obj = OBJLoader.LoadOBJFile(dalekpath);
        }
        else if (torus)
        {
            obj = OBJLoader.LoadOBJFile(large_torus_path);
        }
        else
        {
            obj = new GameObject();
        }
        

        obj.transform.position = SpawnPoint.position;
        obj.transform.rotation = SpawnPoint.rotation;
        obj.AddComponent<Rigidbody>();
        obj.AddComponent<BoxCollider>();
        FitToChildren(obj);
        obj.AddComponent<VRTK_InteractableObject>();
        obj.AddComponent<VRTK_AxisScaleGrabAction>();
        obj.AddComponent<VRTK_FixedJointGrabAttach>();
        obj.GetComponent<Rigidbody>().detectCollisions = true;
        obj.GetComponent<VRTK_InteractableObject>().isGrabbable = true;
        obj.GetComponent<VRTK_AxisScaleGrabAction>().uniformScaling = true;
        obj.GetComponent<VRTK_InteractableObject>().grabAttachMechanicScript = obj.GetComponent<VRTK_FixedJointGrabAttach>();
        obj.GetComponent<VRTK_InteractableObject>().secondaryGrabActionScript = obj.GetComponent<VRTK_AxisScaleGrabAction>();
        obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

    }

    public void toggleCube()
    {
        cube = !cube;
        if (cube)
        {
            GameObject.Find("CubeToggle").GetComponent<Image>().color = Color.red;
            dalek = false;
            GameObject.Find("DalekToggle").GetComponent<Image>().color = Color.white;
            GameObject.Find("TorusToggle").GetComponent<Image>().color = Color.white;
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
            cube = false;
            GameObject.Find("CubeToggle").GetComponent<Image>().color = Color.white;
            GameObject.Find("TorusToggle").GetComponent<Image>().color = Color.white;
        }
        else
        {
            GameObject.Find("DalekToggle").GetComponent<Image>().color = Color.white;
                    }
    }
    public void toggleTorus()
    {
        torus = !torus;
        if (torus)
        {
            GameObject.Find("TorusToggle").GetComponent<Image>().color = Color.red;
            cube = false;
            GameObject.Find("CubeToggle").GetComponent<Image>().color = Color.white;
            GameObject.Find("DalekToggle").GetComponent<Image>().color = Color.white;
        }
        else
        {
            GameObject.Find("TorusToggle").GetComponent<Image>().color = Color.white;
        }
    }

}
