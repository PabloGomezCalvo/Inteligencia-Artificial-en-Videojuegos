namespace UCM.IAV.Movimiento
{
    using UnityEngine;

    /// <summary>
    /// Clase para gestionar la formacion de las ratas
    /// </summary>
    public class Formacion : ComportamientoAgente
    {
        /// <summary>
        /// La distnacia que tiene que estar separadas las unas de las otras
        /// </summary>
        [Range(1.0f, 5.0f)]
        public float raydistance;


        protected Seguir seguir;

        private void Start()
        {
            seguir = GetComponent<Seguir>();
        }
        /// <summary>
        /// Obtiene la direccion para poder estar a distancia de otros agentes
        /// </summary>
        /// <returns>Direccion</returns>
        public override Direccion GetDireccion()
        {
            Direccion direccion = new Direccion();
            RaycastHit hitInfo;
            direccion.lineal = Vector3.zero;
            float angle = 0.0f;
            // Dispara 8 rayos con una separacion de 360 para detectar los otros agentes
            for(int i = 0; i < 8; i++)
            {
                if (Physics.Raycast(transform.position, (Quaternion.AngleAxis(angle, Vector3.up) * transform.forward), out hitInfo, raydistance))
                {

                    if (hitInfo.collider.tag == "rata" || hitInfo.collider.tag == "Player")
                    {
                        // suma la direccion opuesta del rayo
                        direccion.lineal += (Quaternion.AngleAxis(angle, Vector3.up) * transform.forward) * -1;
                    }
                }
                angle += 45;
            }

            

            return direccion;
        }
    }
}
