using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UCM.IAV.Movimiento
{
    public class AgentesManager : MonoBehaviour
    {

        public Agente[] agentes;
        private void Start()
        {
            agentes = GetComponentsInChildren<Agente>();
        }
        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        void Update()
        {
            if(Input.GetKeyUp("space")){
                foreach (Agente a in agentes)
                {
                    a.ToggleFlauta();
                }   
            }
        }
    }
}