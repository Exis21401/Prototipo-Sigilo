using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPalanca : MonoBehaviour {

    private bool Activada;
    public Animator animacionPalanca;
    public AudioClip palanca;

	// Use this for initialization
	void Start () {
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
            Activada = true;
            animacionPalanca.enabled = true;
            GetComponent<AudioSource>().Play();
        }
    }
}
