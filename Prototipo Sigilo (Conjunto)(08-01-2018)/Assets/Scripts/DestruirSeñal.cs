using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirSeñal : MonoBehaviour {

    public float Tiempo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, Tiempo);
	}
}
