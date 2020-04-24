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

    public void Move()
    {
        if (transform.position.y != MinH)
        {
            corutine = MoveCorutine(true);
            StartCoroutine(corutine);
        }
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
        if(transform.position.y == MinH && collision.gameObject.tag == "Vizconde")
        {
            palanca.Toggle();
            corutine = MoveCorutine(false);
            StartCoroutine(corutine);        
        }
    }

}
