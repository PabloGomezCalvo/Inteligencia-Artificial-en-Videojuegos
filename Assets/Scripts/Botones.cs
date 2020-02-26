using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botones : MonoBehaviour
{
  
    public void Salir()
    {
        Application.Quit();
    }
    
    public void GenerarMapa()
    {
        Debug.Log("MAPA NUEVO");
    }

}
