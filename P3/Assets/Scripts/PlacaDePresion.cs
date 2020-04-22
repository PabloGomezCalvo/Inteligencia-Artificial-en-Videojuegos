using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaDePresion : MonoBehaviour
{
    [SerializeField]
    private GameObject Puerta;

    private IEnumerator coroutine;

    [SerializeField]
    private float TimeToReopen = 2.0f;
    private void OnCollisionEnter(Collision collision)
    {
        //Desactivo la puerta para poder pasar
        Puerta.transform.Rotate(new Vector3(0,1,0),90);
        //empiezo corutine para volver a cerrar
        coroutine = Cerrar(TimeToReopen);
        StartCoroutine(coroutine);
    }


    private IEnumerator Cerrar(float waitTime)
    {
        //espero el tiempo dado antes de volver a activar la puerta
        yield return new WaitForSeconds(waitTime);
        Puerta.transform.Rotate(new Vector3(0, 1, 0), -90);
    }

}
