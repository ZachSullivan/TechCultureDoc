using UnityEngine;
using System.Collections;

public class CameraToggle : MonoBehaviour {

    //Obtain reference to both camera setups
    public Camera OVRCam;
    public Camera StandardCam;

	// Use this for initialization
	void Start () {

        //By default, OVR camera should be toggled on
        OVRCam.enabled = true;
        StandardCam.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {

        //Check if the cameraToggle key ('V') has been pressed, if yes then enable/disable VR & Standard Camera
        if (Input.GetButtonDown("cameraToggle")) {
         OVRCam.enabled = !OVRCam.enabled;
         StandardCam.enabled = !StandardCam.enabled;
        }

    }
}

