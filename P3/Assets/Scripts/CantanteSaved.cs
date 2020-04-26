using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CantanteSaved : MonoBehaviour
{
    [SerializeField]
    private BehaviorDesigner.Runtime.BehaviorTree cantante;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Vizconde")
        {
            cantante.SetVariableValue("Asustada",false);
        }
    }
}
