using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuDejuego : MonoBehaviour {

    public GameObject menuPrincipal;
    public GameObject menuOpciones;

    public void Jugar ()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void Salir ()
    {
        Application.Quit();
    }

    public void OpcionesMenu ()
    {
        menuPrincipal.SetActive(false);
        menuOpciones.SetActive(true);
    }

    public void VolverAlMenu ()
    {
        menuPrincipal.SetActive(true);
        menuOpciones.SetActive(false);
    }

    }

   
    

