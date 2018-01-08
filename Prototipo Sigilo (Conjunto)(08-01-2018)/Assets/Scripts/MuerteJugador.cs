using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteJugador : MonoBehaviour
{

    public AudioClip muerte;

    Animator anim;

    public ParticleSystem sangre;

    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

    }

    void Muerte()
    {
        sangre.Play();
        anim.Play("Dead");
    }

    void EjecutarSonido()
    {
        GetComponent<AudioSource>().Play();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            anim.SetBool("Muerto", true);
            Muerte();
            print("Triggered");
            //Destroy(gameObject);

            EjecutarSonido();

        }
    }
}
