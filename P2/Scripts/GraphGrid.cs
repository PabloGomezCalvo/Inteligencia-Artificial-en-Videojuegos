/*    
   Copyright (C) 2020 Federico Peinado
   http://www.federicopeinado.com

   Este fichero forma parte del material de la asignatura Inteligencia Artificial para Videojuegos.
   Esta asignatura se imparte en la Facultad de Informática de la Universidad Complutense de Madrid (España).

   Autor: Federico Peinado 
   Contacto: email@federicopeinado.com
*/
namespace UCM.IAV.Navegacion
{

    using UnityEngine;
    using System;
    using System.Collections.Generic;

    //namespace UnityEngine;

    public class GraphGrid : Graph {

        public GameObject obstaclePrefab;
        public string mapName = "arena.map";
        public bool get8Vicinity = false;
        public float cellSize = 1f;
        [Range(0, Mathf.Infinity)]
        public float defaultCost = 1f;
        [Range(0, Mathf.Infinity)]
        public float maximumCost = Mathf.Infinity;
        string mapsDir = "Maps";

        // Para la generacion del laberinto
        public int stept_end = 10;

        // Nos guardamos el ini y el fin
        Vector2 ini;
        Vector2 fin;

        //Cols y Rows
        public int numCols;
        public int numRows;

        //Vector de Objetos
        GameObject[] vertexObjs;

        // Boleanos para los obstaculos
        bool[,] mapVertices;

        private int GridToId(int x, int y) {
            return Math.Max(numRows, numCols) * y + x;
        }

        public override void Load()
        {
            base.Load();

            mapVertices = new bool[numRows, numCols];

            //Generacion del mapa
            GenerateMap();
        
            // Dibujado del tablero
            for (int i = 0; i < numCols; i++) {
                for (int j = 0; j < numRows; j++) {
                    if (mapVertices[i, j]) {
                        Instantiate(vertexPrefab, new Vector3(i, 0, j), Quaternion.identity, transform);
                    }
                    else
                    {
                        Instantiate(obstaclePrefab, new Vector3(i, 0, j), Quaternion.identity, transform);
                    }
                }
            }
        }

        public void GenerateMap()
        {
            int nC = numCols - 1;
            int nR = numRows - 1;

            //Eleccion de casilla inicial y final
            // x -> row
            // y -> col
            int x = UnityEngine.Random.Range(0, 4); //U-D
            int y = -1; //L-R
            int xf = 0, yf = 0;

            // La final estara en la opuesta de la inicial
            switch (x)
            {
                case 0: // Up ini
                    x = 0;
                    y = UnityEngine.Random.Range(0, nC);

                    xf = nR;
                    yf = nC - y;
                    break;
                case 1: // Down ini
                    x = nR;
                    y = UnityEngine.Random.Range(0, nC);

                    xf = 0;
                    yf = nC - y;
                    break;
                case 2: // Left ini
                    x = UnityEngine.Random.Range(0, nR);
                    y = 0;

                    xf = nR - x;
                    yf = nC;
                    break;
                case 3: // Right ini
                    x = UnityEngine.Random.Range(0, nR);
                    y = nC;

                    xf = nR - x;
                    yf = 0;
                    break;
                default:
                    break;
            }

            ini = new Vector2(x, y);
            fin = new Vector2(xf, yf);

            //Ini
            mapVertices[x, y] = true;
            //Fin
            mapVertices[xf, yf] = true;

            if (xf == 0) xf++;
            else if (xf == nR) xf--;
            if (yf == 0) yf++;
            else if (yf == nC) yf--;

            int tempx, tempy;
            tempx = xf;
            tempy = yf;

            xf = UnityEngine.Random.Range(1, nR);
            yf = UnityEngine.Random.Range(1, nC);

            /*
            Debug.Log("ini: " + x + ", " + y);
            Debug.Log("mid: " + tempx + ", " + tempy);
            Debug.Log("fin: " + xf + ", " + yf);
            */

            // Generacion del camino a la salida
            bool done = false;
            int stepts = 0;
            bool step1 = false;
            int toDo;
            while (!done)
            {
                if (x == xf)
                { // Ya estan en la misma Row
                    toDo = UnityEngine.Random.Range(0, 3);
                    if (toDo == 2) toDo += 2;
                }
                // Ya estan en la misma col
                else if (y == yf) toDo = UnityEngine.Random.Range(2, 5);
                else toDo = UnityEngine.Random.Range(0, 5);

                if (toDo != 0) toDo--;

                // Movimientos hacia la salida en funcion del random para generar el camino inicial
                switch (toDo)
                {
                    case 0: //Hacia la salida en horizontal
                        if (y < yf)
                        {
                            y++;
                        }
                        else if (y > 1)
                        {
                            y--;
                        }
                        break;
                    case 1: //Hacia la salida en horizontal
                        if (y < yf)
                        {
                            y++;
                        }
                        else if (y > 1)
                        {
                            y--;
                        }
                        break;
                    case 2: //Hacia la salida en vertical
                        if (x < xf)
                        {
                            x++;
                        }
                        else if (x > 1)
                        {
                            x--;
                        }
                        break;
                    case 3: //Hacia la salida en vertical
                        if (x < xf)
                        {
                            x++;
                        }
                        else if (x > 1)
                        {
                            x--;
                        }
                        break;
                    case 4: //Full Random
                        int rand;
                        switch (UnityEngine.Random.Range(0, 2))
                        {
                            case 0:
                                rand = UnityEngine.Random.Range(-1, 2);
                                if (x < nR || x > 1)
                                    x += rand;
                                break;
                            case 1:
                                rand = UnityEngine.Random.Range(-1, 2);
                                if (y < nC || y > 1)
                                    y += rand;
                                break;
                            default:
                                break;
                        }

                        break;
                    default:
                        break;
                }

                // Vamos poniendo a true las casillas por las que pasas para generar el camino
                mapVertices[x, y] = true;

                //Debug.Log("fin: " + xf + ", " + yf);

                if (x == xf && y == yf)
                {
                    if (step1) done = true;

                    if (stepts == stept_end)
                    {
                        step1 = true;
                        xf = tempx;
                        yf = tempy;
                    }
                    else
                    {
                        // Eleccion de casillas aleatorias para generar el laberinto
                        stepts++;
                        //int r = UnityEngine.Random.Range(0, 4);
                        int r = UnityEngine.Random.Range(0, 4);
                        switch (r)
                        {
                            case 0: //U
                                xf = 1;
                                yf = UnityEngine.Random.Range(1, nC);
                                break;
                            case 1: //D
                                xf = nR - 1;
                                yf = UnityEngine.Random.Range(1, nC);
                                break;
                            case 2: //R
                                xf = UnityEngine.Random.Range(1, nC);
                                yf = 1;
                                break;
                            case 3: //L
                                xf = UnityEngine.Random.Range(1, nC);
                                yf = nC - 1;
                                break;
                            default:
                                xf = UnityEngine.Random.Range(1, nR);
                                yf = UnityEngine.Random.Range(1, nC);
                                break;
                        }
                    }
                }
            }
        }

        private Vector2 IdToGrid(int id)
        {
            Vector2 location = Vector2.zero;
            location.y = Mathf.Floor(id / numCols);
            location.x = Mathf.Floor(id % numCols);
            return location;
        }

        protected void SetNeighbours(int x, int y, bool get8 = false)
        {
            int col = x;
            int row = y;
            int i, j;
            int vertexId = GridToId(x, y);
            neighbors[vertexId] = new List<Vertex>();
            costs[vertexId] = new List<float>();
            Vector2[] pos = new Vector2[0];
            if (get8)
            {
                pos = new Vector2[8];
                int c = 0;
                for (i = row - 1; i <= row + 1; i++)
                {
                    for (j = col - 1; j <= col; j++)
                    {
                        pos[c] = new Vector2(j, i);
                        c++;
                    }
                }
            }
            else
            {
                pos = new Vector2[4];
                pos[0] = new Vector2(col, row - 1);
                pos[1] = new Vector2(col - 1, row);
                pos[2] = new Vector2(col + 1, row);
                pos[3] = new Vector2(col, row + 1);
            }
            foreach (Vector2 p in pos)
            {
                i = (int)p.y;
                j = (int)p.x;
                if (i < 0 || j < 0)
                    continue;
                if (i >= numRows || j >= numCols)
                    continue;
                if (i == row && j == col)
                    continue;
                if (!mapVertices[i, j])
                    continue;
                int id = GridToId(j, i);
                neighbors[vertexId].Add(vertices[id]);
                costs[vertexId].Add(defaultCost);
            }
        }

        public override Vertex GetNearestVertex(Vector3 position)
        {
            int col = (int)(position.x / cellSize);
            int row = (int)(position.z / cellSize);
            Vector2 p = new Vector2(col, row);
            List<Vector2> explored = new List<Vector2>();
            Queue<Vector2> queue = new Queue<Vector2>();
            queue.Enqueue(p);
            do
            {
                p = queue.Dequeue();
                col = (int)p.x;
                row = (int)p.y;
                int id = GridToId(col, row);
                if (mapVertices[row, col])
                    return vertices[id];

                if (!explored.Contains(p))
                {
                    explored.Add(p);
                    int i, j;
                    for (i = row - 1; i <= row + 1; i++)
                    {
                        for (j = col - 1; j <= col + 1; j++)
                        {
                            if (i < 0 || j < 0)
                                continue;
                            if (j >= numCols || i >= numRows)
                                continue;
                            if (i == row && j == col)
                                continue;
                            queue.Enqueue(new Vector2(j, i));
                        }
                    }
                }
            } while (queue.Count != 0);
            return null;
        }

    }
}
