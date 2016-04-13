using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckCollision : MonoBehaviour {

    public float maxPickupRange = 5.0f;
    GameObject Player;

    //public Camera mainCam;

    public GameObject carriedObject;

    public bool isCarrying = false;

    //Distance a held object should be from the camera
    public float dis = 3;

    //Smoothing value applied to held object movement (Higher = sharper movement)
    public float smooth = 3;

    // Use this for initialization
    void Start() {
        Player = GameObject.FindGameObjectWithTag("Player");
        carriedObject = GameObject.Find("Placeholder");
        //mainCam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update() {
        //print("Closest Object is " + GetClosestObject("Interact").name);
        if (isCarrying) {
            CarryObject(carriedObject);
            //CheckDrop();
        }
    }

    void OnTriggerStay(Collider other) {

        if (other.gameObject.tag == "Finger" && !isCarrying) {
            Debug.Log("PINCH");
            print("Closest Object is " + GetClosestObject("Interact").name);

            carriedObject = GetClosestObject("Interact");
            isCarrying = true;
        }

    }

    void OnTriggerExit(Collider other) {

        isCarrying = false;
        carriedObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        carriedObject = GameObject.Find("Placeholder");

    }

   

    public void CarryObject(GameObject obj) {

        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.transform.position = Vector3.Lerp(obj.transform.position, this.transform.position, Time.deltaTime * smooth);
        obj.transform.rotation = Quaternion.Lerp(obj.transform.rotation, Quaternion.EulerAngles(0, 0, 0), Time.deltaTime * smooth);
        //obj.transform.LookAt(this.gameObject.transform);
    }

    GameObject GetClosestObject(string tag) {
        //List<GameObject> objectsWithTag = new List<GameObject>(GameObject.FindGameObjectsWithTag(tag));
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(tag);
        GameObject closest = GameObject.Find("Placeholder"); ;
        float distance = maxPickupRange;
        Vector3 position = transform.position;
        foreach (GameObject go in gos) {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance) {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}


