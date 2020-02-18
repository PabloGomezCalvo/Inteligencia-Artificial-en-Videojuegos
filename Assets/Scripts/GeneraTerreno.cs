using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneraTerreno : MonoBehaviour {

    public GameObject suelo;
    public GameObject casa;
    public GameObject pared;

    uint lenght;
    uint height;

    List<int> pos = new List<int> {-25, -15, -5, 5, 15, 25 };

    // Start is called before the first frame update
    void Start() {
        lenght = (uint)suelo.transform.localScale.x;
        lenght--;
        height = (uint)suelo.transform.localScale.z;
        height--;

        /*
        int nVar = (int)Mathf.Max(lenght, height);
        nVar = nVar / 2;
        int minS = -5 * nVar;
       List<int> pos = new List<int>();
        for(int i = 0; i < nVar * 2; i++) {
            pos.Add(minS);
            minS += 10;
        }
        */


        //Matriz con las posiciones donde podemos construir
        bool [,] construccion = new bool[lenght, height];

        uint nObj = 10;

        //Elegimos las posiciones donde se construira
        for (int i = 0; i < nObj; i++) {
            bool assign = false;
            while (!assign)
            {
                uint x = (uint)Random.Range(0, lenght);
                uint z = (uint)Random.Range(0, height);
                if (!construccion[x, z]) {
                    construccion[x, z] = true;
                    assign = true;
                }
            }
        }

        //Construimos
        for(int i = 0; i < height; i++) {
            for (int j = 0; j < lenght; j++) {
                //Construir
                if(construccion[i, j]) {
                    //Random para elegir la construccion
                    if (Random.Range(0, 2) == 0) {
                        Instantiate(casa, new Vector3(pos[i], 0, pos[j]), Quaternion.identity);
                    }
                    else
                    {
                        if (Random.Range(0, 2) == 0)
                            Instantiate(pared, new Vector3(pos[i], 0, pos[j]), Quaternion.identity);
                        else
                            Instantiate(pared, new Vector3(pos[i], 0, pos[j]), Quaternion.Euler(0, 90, 0));
                    }
                }
            }
        }

    }

    // Update is called once per frame
    void Update() {
        
    }
}
