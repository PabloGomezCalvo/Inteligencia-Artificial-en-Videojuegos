using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Componente para generar el pueblo aleatoriamente
/// </summary>
public class GeneraTerreno : MonoBehaviour {

    
    public GameObject suelo;
    public GameObject casa;
    public GameObject pared;

    uint lenght;
    uint height;

    List<int> pos = new List<int> {-25, -15, -5, 5, 15, 25 };

    /// <summary>
    /// Limpia el pueblo
    /// </summary>
    private void ClearPueblo()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    /// <summary>
    /// Genera el pueblo aleatoriamente
    /// </summary>
    private void CreatePueblo()
    {
        lenght = (uint)suelo.transform.localScale.x;
        height = (uint)suelo.transform.localScale.z;

        //Matriz con las posiciones donde podemos construir
        bool[,] construccion = new bool[lenght, height];

        uint nObj = 10;

        //Elegimos las posiciones donde se construira
        for (int i = 0; i < nObj; i++)
        {
            bool assign = false;
            while (!assign)
            {
                uint x = (uint)Random.Range(0, lenght);
                uint z = (uint)Random.Range(0, height);
                if (!construccion[x, z])
                {
                    construccion[x, z] = true;
                    assign = true;
                }
            }
        }

        //Construimos
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < lenght; j++)
            {
                //Construir
                if (construccion[i, j])
                {
                    //Random para elegir la construccion
                    if (Random.Range(0, 2) == 0)
                    {
                        Instantiate(casa, new Vector3(pos[i], 0, pos[j]), Quaternion.identity,transform);
                    }
                    else
                    {
                        if (Random.Range(0, 2) == 0)
                            Instantiate(pared, new Vector3(pos[i], 0, pos[j]), Quaternion.identity, transform);
                        else
                            Instantiate(pared, new Vector3(pos[i], 0, pos[j]), Quaternion.Euler(0, 90, 0), transform);
                    }
                }
            }
        }
    }

    // Start is called before the first frame update
    private void Start() {
        CreatePueblo();

    }

    /// <summary>
    /// Crea un nuevo pueblo
    /// </summary>
    public void ResetPueblo()
    {
        ClearPueblo();
        CreatePueblo();
    }

   
}
