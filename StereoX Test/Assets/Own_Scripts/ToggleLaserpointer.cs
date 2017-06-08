using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wacki;
using Valve.VR;

public class ToggleLaserpointer : MonoBehaviour {

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_Grip;
	private ViveUILaserPointer myLaserPointer;
	private SteamVR_Controller.Device device;
    private SteamVR_TrackedObject trackedObject;
	// Use this for initialization
	void Start () {
		myLaserPointer = GetComponent<ViveUILaserPointer> ();
        trackedObject = GetComponent<SteamVR_TrackedObject>();
	}

    // Update is called once per frame
    void Update() {
        device = SteamVR_Controller.Input((int)trackedObject.index);
        if(device.GetPressDown(triggerButton))
        {
            myLaserPointer.enabled = !myLaserPointer.enabled;
        }
    }
}
