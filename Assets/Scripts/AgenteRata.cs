﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UCM.IAV.Movimiento
{

    /// <summary>
    /// Clase que hereda de Agente para controlar los diferentes comportamientos de la rata
    /// </summary>
    public class AgenteRata : Agente
    {
        protected Seguir seguir;
        protected Formacion formacion;

        protected Patrullar patrullar;

        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start()
        {
            seguir = GetComponent<Seguir>();
            formacion = GetComponent<Formacion>();
            patrullar = GetComponent<Patrullar>();
            seguir.enabled = false;
            formacion.enabled = true;
            patrullar.enabled = true;
            cuerpoRigido = GetComponent<Rigidbody>();
             velocidad = Vector3.zero;
            direccion = new Direccion();
            grupos = new Dictionary<int, List<Direccion>>();

            
        }
        public override void ToggleFlauta()
        {
            seguir.enabled = !seguir.enabled;
            patrullar.enabled = !patrullar.enabled;            
        }
    }
}
