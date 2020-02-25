using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UCM.IAV.Movimiento
{
    public class EvitarObstaculos : ComportamientoAgente
    {
        public float rayDistance;
        public override Direccion GetDireccion()
        {
            Direccion direccion = new Direccion();
            if (agente.velocidad.magnitude > 0.1f)
            {
                RaycastHit FronthitInfo;
                if (Physics.Raycast(transform.position, (Quaternion.AngleAxis(0, Vector3.up) * agente.velocidad.normalized), out FronthitInfo, rayDistance))
                {
                    if (FronthitInfo.collider.tag == "obstaculos")
                    {
                        direccion.lineal = (Quaternion.AngleAxis(180, Vector3.up) * agente.velocidad.normalized);
                        Debug.Log(direccion.lineal);
                    }
                }
            }
            return direccion;

        }
    }
}
