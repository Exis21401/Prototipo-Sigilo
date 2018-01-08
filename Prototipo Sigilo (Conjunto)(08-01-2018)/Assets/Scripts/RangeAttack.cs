using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{


    public Transform objetivo;
    public float rangoSeguir;

    public float rangoAtaque;
    public int daño;
    private float tiempoUltimoAataque;
    public float ataqueCD;

    public GameObject bala;

    public float fuerzaBala;
    //disparo
    public Transform salidaDisparo;


    public Transform raycastPoint;

    //indicador has sido detectado
    public Transform salidaSeñalDetectado;
    public GameObject detectado;

    public GameObject detectadoInstanciado;
    //public bool estasDetectado;

    //public PatrolPoints patrolppoints;

    public AudioClip SonidoDetectado;

    // Use this for initialization
    void Start()
    {

    }


    public LayerMask attackLayers;
    // Update is called once per frame

    void Update()
    {

        //distancia de ataque

        float distanciaJugador = Vector3.Distance(transform.position, objetivo.position);
        bool lookingRight = transform.localScale.x < 0;
        bool isPlayerRight = (objetivo.position - transform.position).x > 0;

        if ((distanciaJugador < rangoAtaque) && detectadoInstanciado == null && ((lookingRight && isPlayerRight) || (!lookingRight && !isPlayerRight)))
        {
            Vector3 direccionTarget = objetivo.position - transform.position;

            detectadoInstanciado = Instantiate(detectado, salidaSeñalDetectado.position, salidaSeñalDetectado.rotation, this.transform);
            print("DETECTADO!");
            GetComponent<AudioSource>().Play();

        }
        else if ((distanciaJugador > rangoAtaque) && detectadoInstanciado != null)
        {
            Destroy(detectadoInstanciado);
            GetComponent<AudioSource>().Stop();
        }



        //chequear si es momento de atacar

        if (Time.time > tiempoUltimoAataque + ataqueCD && detectadoInstanciado != null)
        {
            Vector3 direccionTarget = objetivo.position - transform.position;
            //raycast para ver si tenemos linea hacia el target
            RaycastHit2D hit = Physics2D.Raycast(raycastPoint.position, direccionTarget.normalized, rangoAtaque, attackLayers);


            Debug.Log(hit.transform);
            //

            if (hit.transform == objetivo)
            {
                //dar al jugador - disparar proyectil

                print("Disparado");
                GameObject balaNueva = Instantiate(bala, salidaDisparo.position, Quaternion.identity);
                if (lookingRight)
                {
                    balaNueva.GetComponent<Rigidbody2D>().velocity = -transform.right * fuerzaBala;
                }

                else
                {
                    balaNueva.GetComponent<Rigidbody2D>().velocity = transform.right * fuerzaBala;
                    balaNueva.GetComponent<SpriteRenderer>().flipX = true;
                }

                //balaNueva.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(fuerzaBala, 0f));
                tiempoUltimoAataque = Time.time;

                /* if (transform.localScale.x < 0 && objetivo.transform.position.x > transform.position.x && objetivo.transform.position.x < transform.position.x + rangoAtaque) {

                    GameObject balaNueva = Instantiate(bala, salidaDisparo.position, salidaDisparo.rotation);

                balaNueva.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(fuerzaBala, 0f));


                tiempoUltimoAataque = Time.time; 
                }
                if (transform.localScale.x > 0 && objetivo.transform.position.x < transform.position.x && objetivo.transform.position.x > transform.position.x - rangoAtaque)
                {

                    GameObject balaNueva = Instantiate(bala, salidaDisparo.position, salidaDisparo.rotation);

                balaNueva.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-fuerzaBala, 0f));
                tiempoUltimoAataque = Time.time; 
                } */
                //balaNueva.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(fuerzaBala, 0f));

            }
        }
    }

}























