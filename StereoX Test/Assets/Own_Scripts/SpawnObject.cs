using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK.SecondaryControllerGrabActions;
using VRTK.GrabAttachMechanics;
using VRTK;
using System;
using System.IO;

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

    private GameObject obj;
    private string[] paths;
    private bool[] activeButton;

    void Start ()
    {
        paths = GetFilesToButton.getPaths();
        activeButton = new bool[paths.Length];
    }

    public void SpawnObj()
    {
        int index_of_selected = Array.IndexOf(activeButton, true);
        string[] files = Directory.GetFiles(paths[index_of_selected], "*.obj");
        Debug.Log(files[0]);
        obj = OBJLoader.LoadOBJFile(files[0]);

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

    public void toggle(int index)
    {
        print("func "+ index);
        bool state = activeButton[index];
        for (int i = 0; i < activeButton.Length; i++)
        {
            activeButton[i] = false;
        }
        if (!state)
        {
            activeButton[index] = true;
        }
        for (int i = 0; i < activeButton.Length; i++)
        {
            if(activeButton[i])
            {
                GameObject.Find("Button "+i).GetComponent<Image>().color = Color.red;
            }
            else
            {
                GameObject.Find("Button "+i).GetComponent<Image>().color = Color.white;
            }
        }

    }
   
}
