using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;
public class Piano : MonoBehaviour
{
    [SerializeField]
    private Fantasma fantasma;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Vizconde")
        {
            GameManager.instance.Breaking = true;
            if (GameManager.instance.Captured)
            {
                // Le damos colision
                fantasma.Dancer.GetComponent<Rigidbody>().useGravity = true;
                fantasma.Dancer.GetComponent<BehaviorTree>().enabled = true;
                fantasma.Dancer.GetComponent<NavMeshAgent>().enabled = true;
                // La volvemos a soltar en la escena
                fantasma.Dancer.transform.parent = collision.gameObject.transform.parent;
                fantasma.Dancer.transform.position = new Vector3(fantasma.Dancer.transform.position.x, collision.gameObject.transform.position.y, fantasma.Dancer.transform.position.z);
                //Quitamos la variable global
                GameManager.instance.Captured = false;
            }
        }
        else if (collision.gameObject.tag == "Fantasma")
        {
            GameManager.instance.Breaking = false;
        }
    }
}
