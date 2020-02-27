using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UCM.IAV.Movimiento
{
    /// <summary>
    /// Clase para gestionar esquive de obstaculos
    /// </summary>
    public class EvitarObstaculos : ComportamientoAgente
    {
        /// <summary>
        /// La distancia de comprobación del rayo
        /// </summary>
        /// 
        [Range(1.0f, 10.0f)]
        public float rayDistance;
        public override Direccion GetDireccion()
        {
            Direccion direccion = new Direccion();
            // Se comprueba que el agente se está moviendo
            if (agente.velocidad.magnitude > 0.1f)
            {
                RaycastHit FronthitInfo;
                // Se lanza un RayCast en la dirección en la que el agente está yendo
                if (Physics.Raycast(transform.position, (Quaternion.AngleAxis(0, Vector3.up) * agente.velocidad.normalized), out FronthitInfo, rayDistance))
                {
                    // Se comprueba si el RayCast aha colisionado en un objeto con el tag de obstaculos
                    if (FronthitInfo.collider.tag == "obstaculos")
                    {
                         Debug.DrawRay(transform.position, agente.velocidad.normalized * rayDistance, Color.white);
                         RaycastHit LhitInfo;
                         RaycastHit RhitInfo;
                        bool hitL = Physics.Raycast(transform.position, (Quaternion.AngleAxis(15, Vector3.up) * agente.velocidad.normalized), out LhitInfo, rayDistance,8);
                        bool hitR =Physics.Raycast(transform.position, (Quaternion.AngleAxis(-15, Vector3.up) * agente.velocidad.normalized), out RhitInfo, rayDistance,8);
                        // Si ambos rayos laterales chocan comprueba cual de los dos se encuentra mas cerca y va en direccion opuesta a el.
                        if(hitL && hitR){
                            if(LhitInfo.distance > RhitInfo.distance){
                             direccion.lineal = (Quaternion.AngleAxis(90, Vector3.up) * agente.velocidad.normalized);
                            }
                            else{
                             direccion.lineal = (Quaternion.AngleAxis(-90, Vector3.up) * agente.velocidad.normalized);

                            }
                        }
                        // Si choca el izq va hacia la der
                        else if (hitL){
                             direccion.lineal = (Quaternion.AngleAxis(90, Vector3.up) * agente.velocidad.normalized);
                        }
                        // Si choca el der va hacia la izq
                        else{
                             direccion.lineal = (Quaternion.AngleAxis(-90, Vector3.up) * agente.velocidad.normalized);

                        }
                        
                    }
                    
                }
            }
            return direccion;

        }
    }
}
