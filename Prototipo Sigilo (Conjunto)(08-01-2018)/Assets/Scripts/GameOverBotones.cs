using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverBotones : MonoBehaviour {

    public void ReinicarEljuego()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void VolverAlmenu()
    {
        SceneManager.LoadScene ("MenuPrincipal");
    }
}

