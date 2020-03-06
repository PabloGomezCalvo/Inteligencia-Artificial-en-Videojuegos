    namespace UCM.IAV.Movimiento
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Clase para gestionar el patrullaje
    /// </summary>
    public class Patrullar : ComportamientoAgente
    {
        public bool changePatron;

        /// <summary>
        /// El tiempo que cambia la dirección del patrullaje
        /// </summary>
        [Range(0.5f, 10.0f)]
        public float timePatroling;

        /// <summary>
        /// El intervalo para desviar el paso
        /// </summary>
        [Range(0.0f, 180.0f)]
        public float desviacion;

        /// <summary>
        /// Devuelve la dirrección del patrullaje
        /// </summary>
        /// <returns></returns>
        public override Direccion GetDireccion()
        {
            Direccion direccion = new Direccion();
            
            //direccion.lineal = Vector3.zero;
            if (agente.velocidad.magnitude < 0.1f || changePatron)
            {
                changePatron = false;
                direccion.lineal = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
                StartCoroutine(WaitChangePatron());
            }
            else
            {
                
                direccion.lineal = Quaternion.AngleAxis( Random.Range(-desviacion, desviacion), Vector3.up) * agente.velocidad.normalized*3;
            }
            
            return direccion;
        }

        /// <summary>
        /// Corutina para esperar el siguiente cambio de direccion del patrullaje
        /// </summary>
        /// <returns></returns>
        private IEnumerator WaitChangePatron()
        {
            
            yield return new WaitForSeconds(timePatroling);
            changePatron = true;
        }
    }
}