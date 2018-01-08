using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Victoria : MonoBehaviour {

	
    public void VolveAJugar()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }

    
}