using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarcaMovement : MonoBehaviour
{
    [SerializeField]
    private float Position1;
    [SerializeField]
    private float Position2;

    [SerializeField]
    private GameObject Spawn1;
    [SerializeField]
    private GameObject Spawn2;

    private IEnumerator coroutine;
    private float waitTime = 0.1f;

    public void MovementActive(GameObject pj)
    {
        //Hago tp al pj encima de la barca
        pj.transform.position = this.transform.position;
        //Corrutina encargada del movimiento, parametro derecho para saber hacia donde tengo que ir
        coroutine = Cerrar(waitTime, pj, Position1 == transform.position.x);
        StartCoroutine(coroutine);
    }

    private IEnumerator Cerrar(float waitTime, GameObject pj, bool plus)
    {
        bool done = false;
        float vel;
        //Seteo la velocidad a la que voy con el sentido correcto
        if (plus)
            vel = 0.1f;
        else
            vel = -0.1f;
        while (!done) {
            yield return new WaitForSeconds(waitTime);
            //Translado barca y pj a la siguiente posicion
            transform.Translate(new Vector3(vel,0,0));
            pj.transform.position = new Vector3(transform.position.x,2, transform.position.z);
            //Miro si he llegado ya y si es asi, termino el while
            if (plus && transform.position.x >= Position2)
            {
                transform.position = new Vector3(Position2, transform.position.y, transform.position.z);
                done = true;
            }
            else if (!plus && transform.position.x <= Position1)
            {
                transform.position = new Vector3(Position1, transform.position.y, transform.position.z);
                done = true;
            }
        }
        //Por ultimo suelto al pj en el spawn correcto
        if(plus)
            pj.transform.position = Spawn2.transform.position;
        else
            pj.transform.position = Spawn1.transform.position;
    }
}
