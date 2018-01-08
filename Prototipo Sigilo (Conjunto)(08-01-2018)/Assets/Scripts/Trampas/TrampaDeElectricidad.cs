using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaDeElectricidad : MonoBehaviour {
    public Animator animacionPalanca;
    public GameObject RayoElectricidad;
    public bool Activada;
    public float timer;
    public const float TiempoDeEspera = 3.0f;

    // Use this for initialization
    void Start()
    {
        Activada = false;
        animacionPalanca.enabled = false;
        RayoElectricidad.GetComponent<GameObject>();
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Activada)
        {
           timer += Time.deltaTime;
           if (timer >= TiempoDeEspera)
           RayoElectricidad.SetActive(false);
           //Activada = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
                timer = 0;
                GetComponent<AudioSource>().Play();
                Activada = true;
                RayoElectricidad.SetActive(true);
                animacionPalanca.enabled = true;
        }

    }
}
