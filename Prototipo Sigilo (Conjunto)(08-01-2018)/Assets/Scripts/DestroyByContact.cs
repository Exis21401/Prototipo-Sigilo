using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public AudioClip muerte;
    public bool muerto;
    public GameObject Cuchillo;
    public Transform CuchilloPos;
    Animator anim;
    public ParticleSystem sangre;
    public float Vida;
    public bool ConCuchillo;
    public GameObject Colisionconsuelo;
    public Rigidbody2D rb;
    public bool Kinematico;
    

    // Use this for initialization
    void Start () {
	anim = GetComponent<Animator>();
        muerto = false;
        Vida = 1;
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void FixedUpdate()
    {
    }

    void EjecutarParticulas()
    {
        sangre.Play();
    }

    void EjecutarSonido ()
    {
        GetComponent<AudioSource>().Play();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            sangre.Play();
			print("Triggered");
            anim.SetBool("EnemigoAbatido", true);
            //Destroy(gameObject);           
            EjecutarSonido();
            muerto = true;
            Destroy(this.GetComponent<BoxCollider2D>());
            Destroy(this.GetComponent<RangeAttack>());
            Destroy(this.GetComponent<PatrolPoints>());
            Destroy(this.GetComponent<AudioSource>());
            if (Kinematico)
            {
                Destroy(Colisionconsuelo.GetComponent<BoxCollider2D>());
                rb.isKinematic = true;
            }
            if (ConCuchillo)
            {
                Instantiate(Cuchillo,CuchilloPos.position,transform.rotation); 
            }

        }
        else if (other.gameObject.CompareTag("Knife"))
        {
            sangre.Play();
            print("Triggered");
            anim.SetBool("EnemigoAbatido", true);
            //Destroy(gameObject);
            EjecutarSonido();
            muerto = true;
            Destroy(this.GetComponent<BoxCollider2D>());        
            Destroy(this.GetComponent<PatrolPoints>());
            Destroy(this.GetComponent<AudioSource>());
            //Destroy(this.GetComponent<RangeAttack>().detectadoInstanciado);
            Destroy(this.GetComponent<RangeAttack>());
            if (Kinematico)
            {
                Destroy(Colisionconsuelo.GetComponent<BoxCollider2D>());
                rb.isKinematic = true;
            }
            if (ConCuchillo)
            {
                Instantiate(Cuchillo, CuchilloPos.position, transform.rotation);
            }

        }
        else if (other.gameObject.CompareTag("DeathTrap"))
        {
            sangre.Play();
            print("Triggered");
            anim.SetBool("AbatidoFuerte", true);      
            //Destroy(gameObject);
            EjecutarSonido();
            muerto = true;
            Destroy(this.GetComponent<BoxCollider2D>());
            Destroy(this.GetComponent<RangeAttack>());
            Destroy(this.GetComponent<PatrolPoints>());
            Destroy(this.GetComponent<AudioSource>());
            if (Kinematico)
            {
                Destroy(Colisionconsuelo.GetComponent<BoxCollider2D>());
                rb.isKinematic = true;
            }
            if (ConCuchillo)
            {
                Instantiate(Cuchillo, CuchilloPos.position, transform.rotation);
            }
        }
    }
    public void Damage (int damage)
    {
        Vida -= damage;

    }
       
}
