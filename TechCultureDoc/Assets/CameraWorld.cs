using UnityEngine;
using System.Collections;

public class CameraWorld : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(1, 1, this.GetComponent<Camera>().nearClipPlane));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
