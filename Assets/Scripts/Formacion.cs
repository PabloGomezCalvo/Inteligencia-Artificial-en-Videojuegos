namespace UCM.IAV.Movimiento
{
    using UnityEngine;

    /// <summary>
    /// Clase para modelar el comportamiento de SEGUIR a otro agente
    /// </summary>
    public class Formacion : ComportamientoAgente
    {
        public float raydistance;
        protected Seguir seguir;

        private void Start()
        {
            seguir = GetComponent<Seguir>();
        }
        /// <summary>
        /// Obtiene la dirección
        /// </summary>
        /// <returns></returns>
        public override Direccion GetDireccion()
        {
            Direccion direccion = new Direccion();
            RaycastHit hitInfo;
            direccion.lineal = Vector3.zero;
            float angle = 0.0f;
            for(int i = 0; i < 8; i++)
            {
                if (Physics.Raycast(transform.position, (Quaternion.AngleAxis(angle, Vector3.up) * transform.forward), out hitInfo, raydistance))
                {
                    Debug.Log(hitInfo.collider.tag);

                    if (hitInfo.collider.tag == "rata")
                    {
                        direccion.lineal += (Quaternion.AngleAxis(angle, Vector3.up) * transform.forward) * -1;
                    }
                }
                angle += 45;
            }

            if(direccion.lineal != Vector3.zero)
            {
                print(1);
            }

            return direccion;
        }
    }
}
