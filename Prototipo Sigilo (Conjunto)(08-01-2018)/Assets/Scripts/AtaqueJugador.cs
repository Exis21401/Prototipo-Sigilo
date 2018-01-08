using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueJugador : MonoBehaviour {

    private bool atacando = false;
    private float TiempoAtaque = 0;
    private float CdAtaque = 0.3f;

    public Collider2D TriggerAtaque;

    private Animator anim;
	// Use this for initialization
	void Start ()
    {
        anim = gameObject.GetComponent<Animator>();
        TriggerAtaque.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("j") && !atacando)
        {
            atacando = true;
            TiempoAtaque = CdAtaque;

            TriggerAtaque.enabled = true;
        }

        if (atacando)
        {
            if (TiempoAtaque > 0)
            {
                TiempoAtaque -= Time.deltaTime;
            }
            else
            {
                atacando = false;
                TriggerAtaque.enabled = false;
            }
        }

        anim.SetBool("Atacando", atacando);
	}
}
