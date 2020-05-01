using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManagerCheats : MonoBehaviour
{
    [SerializeField]
    private Camera[] cameraArray;
    [SerializeField]
    private UCM.IAV.Movimiento.JugadorAgente player;
    [SerializeField]
    private Palanca[] palancas;
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private Fantasma fantasma;
    [SerializeField]
    private Text[] textos;

    private Vector3 respawnCelda;
    private Vector3 respawnFantasma;
    private Vector3 respawnPlayer;
    private Vector3 respawnBackStage;
    private int currentCamera;

    // Start is called before the first frame update
    void Start()
    {
        textos[0].text = "Piano roto: NO";
        textos[1].text = "LamparaIzq rota: NO";
        textos[2].text = "LamparaDer rota: NO";
        textos[3].text = "Secuestrada: NO";
        textos[4].text = "Cantando: SI";

        respawnBackStage = new Vector3(-1.6f, 1.7f, 9.3f);
        respawnCelda = new Vector3(7.3f,1.27f,16.5f);
        respawnFantasma = new Vector3(-6.7f,1.7f,16.1f);
        respawnPlayer = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        currentCamera = 0;
        cameraArray[0].gameObject.SetActive(true);
        for(int i = 1; i < cameraArray.Length; i++)
            cameraArray[i].gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cameraArray[currentCamera].gameObject.SetActive(false);
            currentCamera = ++currentCamera % cameraArray.Length;
            cameraArray[currentCamera].gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            player.transform.position = respawnPlayer;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (Palanca p in palancas)
            {
                p.Toggle();
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            player.transform.position = respawnFantasma;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            player.transform.position = respawnCelda;
        }
        string piano;
        if (gameManager.Breaking)
            piano = "SI";
        else
            piano = "NO";
        textos[0].text = "Piano roto: " + piano;

        string lampIzq;
        if (gameManager.GetLampIZQ)
            lampIzq = "SI";
        else
            lampIzq = "NO";
        textos[1].text = "LamparaIzq rota: " + lampIzq;

        string lampDer;
        if (gameManager.GetLampDER)
            lampDer = "SI";
        else
            lampDer = "NO";
        textos[2].text = "LamparaDer rota: " + lampDer;

        string secuestrada;
        if (gameManager.Captured || gameManager.Locked)
            secuestrada = "SI";
        else
            secuestrada = "NO";
        textos[3].text = "Secuestrada: " + secuestrada;

        string cantando;
        if (!gameManager.Singing && !gameManager.Captured)
            cantando = "SI";
        else
            cantando = "NO";
        textos[4].text = "Cantando: " + cantando;
    }
}
