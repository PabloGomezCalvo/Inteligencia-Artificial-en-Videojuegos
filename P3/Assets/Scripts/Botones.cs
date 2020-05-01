using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botones : MonoBehaviour
{

    // Para salir del juego
    public void Salir()
    {
        Application.Quit();
    }
    //resetear escena
    public void Reset()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

}