using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UCM.IAV.Movimiento
{
    /// <summary>
    /// Clase para manejar el comportamieto general de los agentes 
    /// </summary>
    public class AgentesManager : MonoBehaviour
    {

        public Agente[] agentes;
        private void Start()
        {
            agentes = GetComponentsInChildren<Agente>();
        }

        private void Update()
        {
            if (Input.GetKeyUp("space"))
            {
                // Cambia el estado de los agentes al tocar la flauta
                foreach (Agente a in agentes)
                {
                    a.ToggleFlauta();
                }
            }
        }
    }
}