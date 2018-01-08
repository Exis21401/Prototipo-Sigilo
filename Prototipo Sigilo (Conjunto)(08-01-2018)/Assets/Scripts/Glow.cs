using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Interactuable"))
        {
            print("Estas cerca de un objeto");
            other.gameObject.GetComponent<Light>().enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Interactuable"))
        {
            other.gameObject.GetComponent<Light>().enabled = false;
        }
    }
}
