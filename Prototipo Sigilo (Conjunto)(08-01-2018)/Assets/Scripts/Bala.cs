using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

    public int daño;
    
    public Rigidbody2D rb;
    public float velocidadBala;
    public GameObject Enemigo;

    public float tiempoDestrucción;

    //para comprobar si el enemigo mira a la izquierda o derecha
    //public GameObject enemigo;
    //private Transform enemigoPosicion;

    int puntoActual;

  
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        //enemigo = GameObject.FindGameObjectWithTag("Enemy");
        //enemigoPosicion = enemigo.transform;
    }

    void Start()
    {
  

        /*if (enemigoPosicion.localScale.x > 27.83f)
        {
            rb.velocity = new Vector2(velocidadBala, rb.velocity.y);
        }
        else if (enemigoPosicion.localScale.x < 27.83f)
        {
            rb.velocity = new Vector2(-velocidadBala, rb.velocity.y);
        } */



    }

    

    void Update()
    {
        Destroy(gameObject, tiempoDestrucción);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
            Destroy(this);
        Debug.Log("Destruida");
    }
}
