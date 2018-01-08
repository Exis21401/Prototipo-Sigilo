using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAtaque : MonoBehaviour {

    public int dmg = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.CompareTag("Enemy"))
        {
            col.SendMessageUpwards("Damage", dmg);
        }
    }
}
