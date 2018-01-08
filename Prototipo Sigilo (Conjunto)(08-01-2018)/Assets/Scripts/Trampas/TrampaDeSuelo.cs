using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaDeSuelo : MonoBehaviour {

    Rigidbody2D rb;
    public GameObject S1;
    public Vector3 dir = new Vector3(2,0,0);
    //sonido trampa
    public AudioClip trampasuelo;
    //animacion palanca
    public Animator animacionPalanca;
    public bool Activada;
	
	void Start ()
    {
        rb = S1.GetComponent<Rigidbody2D>();
        Activada = false;
        animacionPalanca.enabled = false;   
    }
    // Update is called once per frame
    void Update () {
		
       
	}
  private void OnTriggerStay2D(Collider2D other)
    {
      
        if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E) && !Activada)
        {
            print("triggered");
            GetComponent<AudioSource>().Play();
            Activada = true;   
            animacionPalanca.enabled = true;
            rb.velocity = dir;
        }

    }

   

}
