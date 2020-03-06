using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UCM.IAV.Movimiento
{
    /// <summary>
    ///  Clase que hereda de Agente para controlar los diferentes comportamientos del Perro
    /// </summary>
    public class AgentePerro : Agente
    {
        protected Seguir seguir;

        protected Huir huir;

        protected Patrullar patrullar;

        
        private void Start()
        {
            seguir = GetComponent<Seguir>();
            huir = GetComponent<Huir>();
            patrullar = GetComponent<Patrullar>();

            seguir.enabled = true;
            huir.enabled = false;
            patrullar.enabled = false;
            cuerpoRigido = GetComponent<Rigidbody>();
             velocidad = Vector3.zero;
            direccion = new Direccion();
            grupos = new Dictionary<int, List<Direccion>>();

            
        }
        public override void ToggleFlauta()
        {
            seguir.enabled = !seguir.enabled;            
            patrullar.enabled = !patrullar.enabled;

            huir.enabled = !huir.enabled;            
        }
    }
}

