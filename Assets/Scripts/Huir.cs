using UnityEngine;
namespace UCM.IAV.Movimiento
{

    /// <summary>
    /// Clase para modelar el comportamiento de Huir de otro agente
    /// </summary>
    public class Huir : ComportamientoAgente
    {
        /// <summary>
        /// Comienzo de la distancia de frenado
        /// </summary>
        public float maxDistance;
        /// <summary>
        /// Obtiene la dirección
        /// </summary>
        /// <returns>Direccion</returns>
        public override Direccion GetDireccion()
        {
            Direccion direccion = new Direccion();
            if ((objetivo.transform.position - transform.position).magnitude < maxDistance)
            {
                direccion.lineal = (objetivo.transform.position - transform.position)*-1;
                direccion.lineal.Normalize();
            }

            return direccion;
        }
    }
}

