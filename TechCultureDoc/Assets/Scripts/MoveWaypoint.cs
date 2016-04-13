using UnityEngine;
using System.Collections;

public class MoveWaypoint : MonoBehaviour {

    public GameObject Player;
    public GameObject Controls;
    public GameObject MiniMap;
    public GameObject ForwardArrow;
    public GameObject BackwardsArrow;
    public GameObject LeftArrow;
    public GameObject RightArrow;
    public GameObject CArrow;
    public GameObject CCArrow;


    public Material defaultMaterial;
    public Material glowMaterial;

    bool toggleCtrls = true;
    bool toggleMap = false;

    void OnTriggerStay(Collider other) {
        
        if (other.gameObject.tag == "MoveForwards") {
            MovePlayerForwards();
        }

        if (other.gameObject.tag == "MoveBackwards") {
            MovePlayerBackwards();
        }

        if (other.gameObject.tag == "MoveLeft") {
            MovePlayerLeft();
        }

        if (other.gameObject.tag == "MoveRight") {
            MovePlayerRight();
        }

        if (other.gameObject.tag == "RotateClockwise") {
            RotateClockwise();
        }

        if (other.gameObject.tag == "RotateCounterClockwise") {
            RotateCounterClockwise();
        }

        
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Toggle") {
            ToggleControls();
        }

        if (other.gameObject.tag == "ToggleMap") {
            ToggleMap();
        }
    }
    
    void OnTriggerExit(Collider other) {

        ForwardArrow.GetComponent<Renderer>().material = defaultMaterial;
        LeftArrow.GetComponent<Renderer>().material = defaultMaterial;
        RightArrow.GetComponent<Renderer>().material = defaultMaterial;
        BackwardsArrow.GetComponent<Renderer>().material = defaultMaterial;
        CArrow.GetComponent<Renderer>().material = defaultMaterial;
        CCArrow.GetComponent<Renderer>().material = defaultMaterial;
    }

    public void MovePlayerForwards() {

        ForwardArrow.GetComponent<Renderer>().material = glowMaterial;

        Player.transform.Translate(Vector3.forward * Time.deltaTime * 3);
    }

    void MovePlayerBackwards() {

        BackwardsArrow.GetComponent<Renderer>().material = glowMaterial;

        Player.transform.Translate(Vector3.back * Time.deltaTime * 3);
    }

    void MovePlayerLeft() {

        LeftArrow.GetComponent<Renderer>().material = glowMaterial;

        Player.transform.Translate(Vector3.left * Time.deltaTime * 3);
    }

    void MovePlayerRight() {

        RightArrow.GetComponent<Renderer>().material = glowMaterial;

        Player.transform.Translate(Vector3.right * Time.deltaTime * 3);
    }

    void RotateClockwise() {

        CArrow.GetComponent<Renderer>().material = glowMaterial;

        Player.transform.Rotate(0, 1.0f, 0);
    }

    void RotateCounterClockwise() {

        CCArrow.GetComponent<Renderer>().material = glowMaterial;

        Player.transform.Rotate(0, -1.0f, 0);
    }

    void ToggleControls() {

        if (toggleCtrls) {

            Controls.SetActive(false);

            toggleCtrls = false;

        } else {

            Controls.SetActive(true);

            toggleCtrls = true;

        }    
    }

    void ToggleMap() {

        if (toggleMap) {

            MiniMap.SetActive(false);

            toggleMap = false;

        }
        else {

            MiniMap.SetActive(true);

            toggleMap = true;

        }

    }

}
