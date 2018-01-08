using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    public Rigidbody2D rb;
    public GameObject Lazer;
    public float velocidad;
	// Use this for initialization
	void Start () {
        rb = Lazer.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(velocidad,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
            Destroy(gameObject);

    }
}
