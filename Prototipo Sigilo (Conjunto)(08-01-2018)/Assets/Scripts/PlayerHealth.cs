using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    Rigidbody2D rb;
    public GameObject PersonajeRoot;
    //public float saltoX;
    //public float saltoY;
	public AudioClip muerte;
    public AudioClip golepado;
    public ParticleSystem sangre;
    Animator anim;
    public int vidaJugador;
    public int dañoEnemigo;
    public bool JugadorMuerto;
    public float timer;
    public const float TiempoDeEspera = 3.0f;
    public int parpadeos = 7;
    public Sprite cara;
    public Sprite sonrisa;
    public GameObject boca;
    //public int dañoBala;
    //public AudioClip muerte;



    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
        JugadorMuerto = false;
        timer = 0.0f;
	}

    void Update()
    {
        if (vidaJugador <= 0)
        {
            anim.Play("Dead");
            sangre.Play();
            anim.SetBool("Muerto", true);
            JugadorMuerto = true;
            Destroy(this.GetComponent<BoxCollider2D>());
            rb.isKinematic = true;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
        if (JugadorMuerto)
        {
            timer += Time.deltaTime;
            if (timer >= TiempoDeEspera)
            SceneManager.LoadScene("Game Over");
        }
    }

    /*public IEnumerator Espera(float TiempoDeEspera)
    {
        print("Empieza la Corutina");
        yield return new WaitForSeconds(TiempoDeEspera);
    }

    public IEnumerator CorutinaEspera()
    {
        if (vidaJugador <= 0)
        {
            anim.Play("Dead");
            GetComponent<AudioSource>().Play();
            sangre.Play();
            anim.SetBool("Muerto", true);
            yield return StartCoroutine(Espera(5));
            SceneManager.LoadScene("Game Over");
        }
    }*/

    


        void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {

            //sangre.Play();
            //rgb.velocity = new Vector2 (saltoX, saltoY);

            //transform.localScale = new Vector3(0.6f, 1.2f, 0.6f);
            //vidaJugador = 0;
            //EjecutarSonido();

        }

        if (other.tag == "Trap")
        {
            vidaJugador = 0;
        }
           
        if (other.tag == "Bala")
        {
            //transform.localScale = new Vector3(0.6f, 1.2f, 0.6f);
            vidaJugador = vidaJugador - dañoEnemigo;           
            sangre.Play();
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(golepado);
            Destroy(other.gameObject);
            StartCoroutine(Blink());
            boca.GetComponent<SpriteRenderer>().sprite = cara;
            if (vidaJugador >= 3)
            {
                vidaJugador = vidaJugador - 1;      
            }
         }		
     }
    IEnumerator Blink ()
    {

        for(int i = 0; i < parpadeos; i++)
        {
            PersonajeRoot.gameObject.SetActive(false);

            yield return new WaitForSeconds(0.1f);

            PersonajeRoot.gameObject.SetActive(true);

            yield return new WaitForSeconds(0.1f);
        }
    }
}




    /*public void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    void EjecutarParticulas()
    {
        sangre.Play();
    }

    void EjecutarSonido()
    {
        GetComponent<AudioSource>().Play();
    } */

