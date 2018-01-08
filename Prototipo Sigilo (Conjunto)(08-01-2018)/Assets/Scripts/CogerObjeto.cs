using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerObjeto : MonoBehaviour {

    public bool TieneCuchillo;
    public bool TieneLlave;
    public bool Recogido;
    public Sprite CuchilloEnMano;
    public GameObject hand;
    public GameObject KeyIcon;
    public GameObject EsferaIcon;
    public GameObject CuboIcon;
    public GameObject EnergiaIcon;
    // Use this for initialization
    void Start () {
        TieneCuchillo = false;
        TieneLlave = false;
        Recogido = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            TieneLlave = true;
            Recogido = true;
            print("Has cogido una llave");
            KeyIcon.gameObject.SetActive(true);
        }
        else if (other.gameObject.CompareTag("Knife"))
        {
            hand.GetComponent<SpriteRenderer>().sprite = CuchilloEnMano;
            other.gameObject.SetActive(false);
            TieneCuchillo = true;
            Recogido = true;
            print("Has cogido un Cuchillo");

        }
        else if (other.gameObject.CompareTag("Esfera"))
        {
            other.gameObject.SetActive(false);
            EsferaIcon.gameObject.SetActive(true);
        }
        else if (other.gameObject.CompareTag("Cubo"))
        {
            other.gameObject.SetActive(false);
            CuboIcon.gameObject.SetActive(true);
        }
        else if (other.gameObject.CompareTag("Energia"))
        {
            other.gameObject.SetActive(false);
            EnergiaIcon.gameObject.SetActive(true);
        }

    }
}
