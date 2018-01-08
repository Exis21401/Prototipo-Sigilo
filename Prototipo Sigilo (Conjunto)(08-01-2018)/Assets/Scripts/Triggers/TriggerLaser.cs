using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLaser : MonoBehaviour
{
    public Animator animacionPalanca;
    public GameObject Lazer;
    public bool Activada;

    // Use this for initialization
    void Start()
    {
        Activada = false;
        animacionPalanca.enabled = false;
        //Lazer.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {

            if (!Activada)
            {
                
                GetComponent<AudioSource>().Play();
                Activada = true;
                Lazer.SetActive(true);
            }


            animacionPalanca.enabled = true;
        }

    }
}

