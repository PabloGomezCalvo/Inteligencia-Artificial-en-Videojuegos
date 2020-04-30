using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botones : MonoBehaviour
{

    /// <summary>
    /// Para salir del juego
    /// </summary>
    public void Salir()
    {
        Application.Quit();
    }
    public void Reset()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

}