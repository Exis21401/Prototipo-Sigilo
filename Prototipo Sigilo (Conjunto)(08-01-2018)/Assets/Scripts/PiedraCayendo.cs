using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiedraCayendo : MonoBehaviour {

    public GameObject Piedra;
    public Rigidbody2D rb;
    
    
    // Use this for initialization
    void Start () {

        rb = Piedra.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            
        }
    }
}

