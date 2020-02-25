/*    
   Copyright (C) 2020 Federico Peinado
   http://www.federicopeinado.com

   Este fichero forma parte del material de la asignatura Inteligencia Artificial para Videojuegos.
   Esta asignatura se imparte en la Facultad de Informática de la Universidad Complutense de Madrid (España).

   Autor: Federico Peinado 
   Contacto: email@federicopeinado.com
*/
using UnityEngine;
namespace UCM.IAV.Movimiento
{

    /// <summary>
    /// Clase para modelar el comportamiento de SEGUIR a otro agente
    /// </summary>
    public class Seguir : ComportamientoAgente
    {
        public float closeDistance;
        public float maxDistance;
        /// <summary>
        /// Obtiene la dirección
        /// </summary>
        /// <returns></returns>
        public override Direccion GetDireccion()
        {
            Direccion direccion = new Direccion();
            direccion.lineal = objetivo.transform.position - transform.position;
            direccion.lineal.Normalize();

            direccion.lineal = direccion.lineal * agente.aceleracionMax;
            if (maxDistance > (objetivo.transform.position - transform.position).magnitude)
            {
                float percentaje = 0.25f * maxDistance/ ((objetivo.transform.position - transform.position).magnitude);
                direccion.lineal *= percentaje;        
                if (closeDistance > (objetivo.transform.position - transform.position).magnitude)
                {
                    direccion.lineal *= 0;
                }
            }
            
            return direccion;
        }
    }
}
