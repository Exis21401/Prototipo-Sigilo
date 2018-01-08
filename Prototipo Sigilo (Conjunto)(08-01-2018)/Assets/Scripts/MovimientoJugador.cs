using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
	
    //public float velocidadInicial;
    //public float aumentoVelocidad;

    /*public float velocidadMaxima = 7f;
    public float tiempoDe0a100= 3f;
    private float aceleraciónPorSegundo;
    private float fuerzaVelocidad;

    private void Awake()
    {
        aceleraciónPorSegundo = velocidadMaxima / tiempoDe0a100;
        fuerzaVelocidad = 0f;
    }*/

    public float velocidadMovimiento;
    public float velocidadInicial = 0f;
    public float velocidadMaxima;

    //public float velocidadMovimientoMax;

    public float salto;

    //detecctión del suelo para el salto
    public Transform detectarSuelo;
    public float zonaDeteccionSuelo;
    public LayerMask EsNoesSuelo;
    private bool Suelo;
    public bool Ataca;
    //sonidos

    //public AudioClip andar;
    //public AudioClip correr;
    public AudioClip saltar;

    //particulaMovimiento
    public ParticleSystem polvoMovimiento;

    Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        velocidadMovimiento = velocidadInicial;
        Ataca = false;
    }

    void FixedUpdate()
    {
        Suelo = Physics2D.OverlapCircle(detectarSuelo.position, zonaDeteccionSuelo, EsNoesSuelo);

    }

    void Update()
    {

        /*float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * velocidadMovimiento * Time.deltaTime, 0, 0); */


        //salto jugador

        if (Input.GetKey(KeyCode.Space) && Suelo && !gameObject.GetComponent<PlayerHealth>().JugadorMuerto)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, salto);
            polvoMovimiento.Stop();
            anim.Play("Jump");
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(saltar);


        }
        else if (!Suelo)
        {
            velocidadMovimiento = 4f;
            polvoMovimiento.Stop();
            
        }

        //movimiento jugador izquierda

        if (Input.GetKey(KeyCode.A) && !gameObject.GetComponent<PlayerHealth>().JugadorMuerto)
        {
            transform.localScale = new Vector3(-0.6f, 0.62f, 0.6f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidadMovimiento, GetComponent<Rigidbody2D>().velocity.y);
	        anim.SetBool("Caminando",true);

            velocidadMovimiento = velocidadInicial++;
            if(!polvoMovimiento.isPlaying)
                polvoMovimiento.Play();
            //GetComponent<GameObject>();

            //GetComponent<AudioSource>().Play();

            //AudioSource audio = GetComponent<AudioSource>();
            //audio.PlayOneShot (andar);


            if (velocidadMovimiento >= velocidadMaxima)
            {
                velocidadMovimiento = velocidadMaxima;
                anim.SetBool("Corriendo", true);
            }
       
        }

       
        //movimiento jugador derecha

        else if (Input.GetKey(KeyCode.D) && !gameObject.GetComponent<PlayerHealth>().JugadorMuerto)
        {
            transform.localScale = new Vector3(0.6f, 0.62f, 0.6f);
            //transform.Translate(horizontal * velocidadMovimiento * Time.deltaTime, 0, 0);
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadMovimiento, GetComponent<Rigidbody2D>().velocity.y);
	        anim.SetBool("Caminando",true);
            velocidadMovimiento = velocidadInicial++;
            if (!polvoMovimiento.isPlaying)
                polvoMovimiento.Play();
            //GetComponent<GameObject>();

            //GetComponent<AudioSource>().Play();

            //AudioSource audio = GetComponent<AudioSource>();
            //audio.PlayOneShot(andar);

            if (velocidadMovimiento >= velocidadMaxima)
            {
                velocidadMovimiento = velocidadMaxima;
		        anim.SetBool("Corriendo",true);
            }

        }

        /*else if (Input.GetKey(KeyCode.E) && !Ataca && (GetComponent<CogerObjeto>().TieneCuchillo == true))
        {
            Ataca = true;
            //GameObject.Find("hand(1)").GetComponent<BoxCollider2D>().SetActive(true);
            anim.SetBool("Atacando", true);
        }

        else if (GetComponent<CogerObjeto>().TieneCuchillo == false)
        {
            anim.SetBool("Atacando", false);
        }*/


        if (Input.GetKeyUp(KeyCode.A) && !gameObject.GetComponent<PlayerHealth>().JugadorMuerto)
        {
            anim.SetBool("Caminando", false);
            anim.SetBool("Corriendo", false);
        }

        else if (Input.GetKeyUp(KeyCode.D) && !gameObject.GetComponent<PlayerHealth>().JugadorMuerto)
        {
            anim.SetBool("Caminando", false);
            anim.SetBool("Corriendo", false);
        }

        /*else if (Input.GetKeyUp(KeyCode.E))
        {
            Ataca = false;
            anim.SetBool("Atacando", false);
        }*/

        if (!Suelo)
        {
            polvoMovimiento.Stop();
        } 


         

    }

    void EjecutarParticulas()
    {
        polvoMovimiento.Play();
    }

    void PararPartículas ()
    {
        polvoMovimiento.Stop();
    }
}




