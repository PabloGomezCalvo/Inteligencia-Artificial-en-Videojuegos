using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UCM.IAV.Movimiento
{
    public class AgentePerro : Agente
    {
        protected Seguir seguir;

        protected Huir huir;

        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start()
        {
            seguir = GetComponent<Seguir>();
            huir = GetComponent<Huir>();
            seguir.enabled = true;
            huir.enabled = false;
            cuerpoRigido = GetComponent<Rigidbody>();
             velocidad = Vector3.zero;
            direccion = new Direccion();
            grupos = new Dictionary<int, List<Direccion>>();

            
        }
        public override void ToggleFlauta()
        {
            seguir.enabled = !seguir.enabled;            
                    
            huir.enabled = !huir.enabled;            
        }
    }
}

