using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;

public class Fantasma : MonoBehaviour {

    private GameObject bailarina;

    public GameObject Dancer {
        get
        {
            return bailarina;
        }
        set
        {
            bailarina = value;
        }
    }

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
        if (collision.gameObject.tag == "Cantante")
        {
            // Guardamos la bailarina
            bailarina = collision.gameObject;
            //La ponemos como hija del fantasma
            bailarina.transform.parent = this.transform;
            //Le quitamos la colision para evitar problemas de estancamiento
            bailarina.GetComponent<Rigidbody>().useGravity = false;
            bailarina.GetComponent<BehaviorTree>().enabled = false;
            bailarina.GetComponent<NavMeshAgent>().enabled = false;
            //Activamos la variable global de captura
            GameManager.instance.Captured = true;
        }
        else if (collision.gameObject.tag == "Vizconde" && GameManager.instance.Captured == true)
        {
            // Le damos colision
            bailarina.GetComponent<Rigidbody>().useGravity = true;
            bailarina.GetComponent<BehaviorTree>().enabled = false;
            bailarina.GetComponent<NavMeshAgent>().enabled = false;
            // La volvemos a soltar en la escena
            bailarina.transform.parent = collision.gameObject.transform.parent;
            //Quitamos la variable global
            GameManager.instance.Captured = false;
        }
    }
}
