using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchosPared : MonoBehaviour {
    Rigidbody2D rb;
    public Vector3 dir = new Vector3(-10, 0, 0);

    public AudioClip trampaPinchos;
    public Animator animacionPalanca;

    public bool Activada;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
        Activada = false;
        animacionPalanca.enabled = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            rb.velocity = dir;

            if (!Activada)
            {
                GetComponent<AudioSource>().Play();
                Activada = true;
            }
            
        
            animacionPalanca.enabled = true;
        }

    }
}
