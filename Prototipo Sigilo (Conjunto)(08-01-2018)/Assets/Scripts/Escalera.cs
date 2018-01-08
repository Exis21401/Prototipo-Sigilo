using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalera : MonoBehaviour
{

    public float velocidadSubida;
    public GameObject Jugador;
    // Use this for initialization
    void Start()
    {

    }


    //para que al entrar en contacto con una escalera el jugador pueda bajar o subir,
    //
    void OnTriggerStay2D (Collider2D Jugador)
    {
        Jugador.GetComponent<Rigidbody2D>().gravityScale = 0;        
        //arriba
        if (Input.GetKey(KeyCode.W) && !GameObject.Find("Jugador").GetComponent<PlayerHealth>().JugadorMuerto)
        {
            Jugador.GetComponent<Rigidbody2D>().velocity = new Vector2(0, velocidadSubida);
            Jugador.transform.position = new Vector3(Mathf.Lerp(Jugador.transform.position.x, transform.position.x, Time.deltaTime * 10), Jugador.transform.position.y, Jugador.transform.position.z);
        }
        //abajo
        else if (Input.GetKey(KeyCode.S) && !GameObject.Find("Jugador").GetComponent<PlayerHealth>().JugadorMuerto)
        {
            Jugador.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -velocidadSubida);
            Jugador.transform.position = new Vector3(Mathf.Lerp( Jugador.transform.position.x,transform.position.x,Time.deltaTime * 10), Jugador.transform.position.y, Jugador.transform.position.z);
        }
        //para que el jugador no caiga directamente al soltarse de una escalera, baja poco a poco
        else
        {
            Jugador.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    void OnTriggerExit2D(Collider2D Jugador)
    {
        if (Jugador.GetComponent<Rigidbody2D>() != null) //Comprueba si el gameobject posee un Rigidbody2D
        {
            Jugador.GetComponent<Rigidbody2D>().gravityScale = 1.5f;
        }   
    }
  


}

