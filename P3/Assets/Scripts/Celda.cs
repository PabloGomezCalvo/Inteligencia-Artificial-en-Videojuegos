using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celda : MonoBehaviour
{
    private GameObject preso;

    [SerializeField]
    private GameObject CeldaPos;
    [SerializeField]
    private GameObject FueraCelda;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Fantasma")
        {
            if (GameManager.instance.Captured)
            {
                // Coger del fantasma la bailarina y quitarla de hija
                
                // Guardarla como presa
                //preso = bailarina;

                // Moverla dentro de la celda
                collision.gameObject.transform.position = CeldaPos.transform.position;

                GameManager.instance.Locked = true;
                GameManager.instance.Captured = false;
            }
        } 
        else if (collision.gameObject.tag == "Vizconde") 
        {
            if (GameManager.instance.Locked) 
            {
                // Sacar a la bailarina de la celda y quitarla de presa
                preso.transform.position = FueraCelda.transform.position;
                preso = null;

                GameManager.instance.Locked = false;
            }
        }
    }

}
