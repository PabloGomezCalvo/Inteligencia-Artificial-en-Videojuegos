using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LamparaMovement : MonoBehaviour
{
    private IEnumerator corutine;
    [SerializeField]
    private float MaxH;
    [SerializeField]
    private float MinH;
    [SerializeField]
    private float WaitTime;
    [SerializeField]
    private Palanca palanca;
    [SerializeField]
    private BehaviorDesigner.Runtime.BehaviorTree [] pj;

    private bool _down;


    public void Move(bool down)
    {
        _down = down;
        //le digo al publico que se vaya o vuelva al escenario
        if (transform.position.y != MinH)
        {
            foreach (BehaviorDesigner.Runtime.BehaviorTree a in pj)
                a.SetVariableValue("Lampara", true);
        }
        else
        {
            foreach (BehaviorDesigner.Runtime.BehaviorTree a in pj)
                a.SetVariableValue("Lampara", false);
        }
        //Empiezo corrutina de movimiento
        corutine = MoveCorutine(down);
        StartCoroutine(corutine);
        
    }

    private IEnumerator MoveCorutine(bool upper)
    {
        bool done = false;
        float vel;
        //Seteo la velocidad a la que voy con el sentido correcto
        if (upper)
            vel = -0.1f;
        else
            vel = 0.1f;
        while (!done) {
            yield return new WaitForSeconds(WaitTime);
            transform.Translate(new Vector3(0, vel, 0));
            //muevo la lampara y compruebo si he terminado de moverlas
            if(upper && transform.position.y <= MinH)
            {
                transform.position = new Vector3(transform.position.x,MinH,transform.position.z);
                done = true;
            }
            else if(!upper && transform.position.y >= MaxH)
            {
                transform.position = new Vector3(transform.position.x, MaxH, transform.position.z);
                done = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(_down && collision.gameObject.tag == "Vizconde")
        {
            palanca.Toggle(); //subo lampara
        }
    }

}
