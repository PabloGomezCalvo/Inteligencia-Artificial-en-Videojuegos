using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private bool _luzIZQ;
    private bool _luzDER;

    public LamparaMovement LamparIZQ;
    public LamparaMovement LamparDER;


    public ObstaculoControlador[] obstaculos;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLamparaDerecha(bool enabled)
    {
        _luzDER = enabled;
        LamparDER.Move(enabled);
        if (!GetPublicAvailable)
        {
            Obstaculos = false;
        }
        else
        {
            Obstaculos = true;

        }
    }

    public void SetLamparaIzquierda(bool enabled)
    { 
        _luzIZQ = enabled;
        LamparIZQ.Move(enabled);

        if (!GetPublicAvailable)
        {
            Obstaculos = false;
        }
        else
        {
            Obstaculos = true;

        }

    }

    private bool Obstaculos
    {
        get
        {
            return GetPublicAvailable;
        }

        set
        {
            print(value);
            foreach (var obs in obstaculos)
            {
                obs.Obstaculo = value;
            }
        }
    }

    public bool GetLampIZQ
    {
        get
        {
            return _luzIZQ;
        }
    }

    public bool GetLampDER
    {
        get
        {
            return _luzDER;
        }
    }

    public bool GetPublicAvailable
    {
        get
        {
            return _luzDER || _luzIZQ;
        }
    }

    private bool _singing;

    public bool Singing
    {
        get
        {
            return _singing;
        }
        set
        {
            _singing = value;
        }
    }
}
