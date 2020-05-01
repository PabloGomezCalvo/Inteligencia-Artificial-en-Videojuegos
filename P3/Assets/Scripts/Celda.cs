using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;

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
                // Guardarla como presa
                preso = collision.gameObject.GetComponent<Fantasma>().Dancer;
                // Quitarla de hija
                preso.transform.parent = this.transform.parent;

                // Moverla dentro de la celda
                preso.transform.position = CeldaPos.transform.position;
                // Fix para el fantasma
                collision.gameObject.transform.position = FueraCelda.transform.position;

                GameManager.instance.Locked = true;
                GameManager.instance.Captured = false;
            }
        } 
        else if (collision.gameObject.tag == "Vizconde") 
        {
            if (GameManager.instance.Locked) 
            {
                preso.GetComponent<BehaviorTree>().enabled = true;
                preso.GetComponent<NavMeshAgent>().enabled = true;
                // Sacar a la bailarina de la celda y quitarla de presa
                preso.transform.position = FueraCelda.transform.position;
                preso.transform.parent = collision.transform.parent;
                preso = null;

                GameManager.instance.Locked = false;
            }
        }
    }

}
