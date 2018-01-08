using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDvidajugador : MonoBehaviour {

    public Sprite[] Vidas;
    public Image VidasUI;

    private PlayerHealth player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    void Update()
    {
        VidasUI.sprite = Vidas[player.vidaJugador];
    }
}

