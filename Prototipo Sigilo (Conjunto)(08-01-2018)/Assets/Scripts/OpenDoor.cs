using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    public Rigidbody2D rb;
    public GameObject Door;
    public Vector3 dir = new Vector3(0, 0, 0);
    public GameObject KeyIcon;
    public AudioClip puerta;

    // Use this for initialization
    void Start()
    {
        rb = Door.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player") && (GameObject.Find("Jugador").GetComponent<CogerObjeto>().TieneLlave))
        {
            rb.velocity = dir;
            print("Abrete sésamo");
            GameObject.Find("Jugador").GetComponent<CogerObjeto>().TieneLlave = false;
            KeyIcon.gameObject.SetActive(false);
            GetComponent<AudioSource>().Play();
        }
    }
}
