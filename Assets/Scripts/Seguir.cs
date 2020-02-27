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
        /// <summary>
        /// Minimo de distancia que tiene que estar del objetivo
        /// </summary>
        /// 
        [Range(1.0f, 5.0f)]
        public float closeDistance;
        /// <summary>
        /// Comienzo de la distancia de frenado
        /// </summary>
        /// 
        [Range(5.0f, 20.0f)]
        public float maxDistance;
        /// <summary>
        /// Obtiene la dirección para ir hacia su objetivo, y se frena progresivamente hasta llegar
        /// </summary>
        /// <returns>Direccion</returns>
        public override Direccion GetDireccion()
        {
            Direccion direccion = new Direccion();
            direccion.lineal = objetivo.transform.position - transform.position;
            direccion.lineal.Normalize();

            Vector3 auxVec = direccion.lineal * agente.aceleracionMax;
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
