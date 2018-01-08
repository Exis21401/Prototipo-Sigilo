using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    Rigidbody rb;
    public GameObject Enemy;
    //public Vector3 dir = new Vector3(0,0,0);
	// Use this for initialization
	void Start () {
       rb = Enemy.GetComponent<Rigidbody>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void FixedUpdate()
    {
        //rb.velocity = dir;
    }
}
