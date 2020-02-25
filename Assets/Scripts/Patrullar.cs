namespace UCM.IAV.Movimiento
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Patrullar : ComportamientoAgente
    {
        public float rayDistance;

        // Update is called once per frame
        public override Direccion GetDireccion()
        {
            Direccion direccion = new Direccion();
            //direccion.lineal = Vector3.zero;
            RaycastHit FronthitInfo;
            RaycastHit LhitInfo;
            RaycastHit RhitInfo;

            //Si colisiona el rayo delantero
            if (Physics.Raycast(transform.position, (Quaternion.AngleAxis(0, Vector3.up) * transform.forward), out FronthitInfo, rayDistance))
            {
                // Si colisiona con un muro
                if (FronthitInfo.collider.tag == "Player")
                {
                    // Si colisionan los rayos frontal-lateral
                    // Si dan ambos
                    if (Physics.Raycast(transform.position, (Quaternion.AngleAxis(315, Vector3.up) * transform.forward), out LhitInfo, rayDistance) &&
                    Physics.Raycast(transform.position, (Quaternion.AngleAxis(45, Vector3.up) * transform.forward), out RhitInfo, rayDistance))
                    {
                        // La izq esta mas lejos -> vamos a la der
                        if (LhitInfo.distance > RhitInfo.distance)
                        {
                            direccion.lineal = direccion.lineal + new Vector3(15, 0, 0);
                        }
                        // La der esta mas lejos -> vamos a la izq
                        else
                        {
                            direccion.lineal = direccion.lineal + new Vector3(-15, 0, 0);
                        }
                    }
                    // Si da solo el derecho
                    else if (Physics.Raycast(transform.position, (Quaternion.AngleAxis(45, Vector3.up) * transform.forward), out RhitInfo, rayDistance))
                    {

                        direccion.lineal = direccion.lineal + new Vector3(-15, 0, 0);
                    }
                    //Si da solo el izq
                    else
                    {
                        Debug.Log("L");

                        direccion.lineal = direccion.lineal + new Vector3(15, 0, 0);
                    }
                }
            }
            return direccion;
        }
    }
}