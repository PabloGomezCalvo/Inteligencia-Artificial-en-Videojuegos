using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ObstaculoControlador : MonoBehaviour
{
    NavMeshObstacle obstacle;
    private void Awake()
    {
        obstacle = GetComponent<NavMeshObstacle>();

    }

    // Start is called before the first frame update
    void Start()
    {
        //obstacle.enabled = false;

    }

    public bool Obstaculo
    {
        set
        {
            obstacle.enabled = value;
        }
    }
}
