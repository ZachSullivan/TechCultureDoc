using UnityEngine;
using System.Collections;

public class LoS : MonoBehaviour {

    public Camera MiniMap;

    void Update() {

        RaycastHit hit;
        Ray ray = this.GetComponent<Camera>().ScreenPointToRay(transform.position);

        if (Physics.Raycast(ray, out hit, 1000)) {

            if (hit.collider.CompareTag("hideObject")) {

                Debug.Log("hit");
                GameObject o = hit.collider.gameObject;

                Color color = o.GetComponent<Renderer>().material.color;
                color.a = 0.2f;
                o.GetComponent<Renderer>().material.color = color;


            }
            else {
                GameObject[] hides;
                hides = GameObject.FindGameObjectsWithTag("hideObject");

                // Iterate through them and turn each one off
                foreach (GameObject hide in hides) {
                    Color color = hide.GetComponent<Renderer>().material.color;
                    color.a = 1.0f;
                    hide.GetComponent<Renderer>().material.color = color;
                }
            }

        }

    }
}