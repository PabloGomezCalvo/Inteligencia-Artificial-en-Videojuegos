using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour
{

    [SerializeField]
    private Material MatEnabled;
    [SerializeField]
    private Material MatDisabled;


    public enum PalancaEnum {IZQ, DER }

    public PalancaEnum typePalanca;
    private MeshRenderer _mesh;
    
    public bool EnabledP;

    //cambio de estado
    public void Toggle()
    {
        EnabledP = !EnabledP;

        if (EnabledP)
            _mesh.material = MatEnabled;
        else
            _mesh.material = MatDisabled;

        if(typePalanca == PalancaEnum.IZQ)
        {
            GameManager.instance.SetLamparaIzquierda(EnabledP);
        }
        else
        {
            GameManager.instance.SetLamparaDerecha(EnabledP);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        EnabledP = false;
        _mesh = GetComponent<MeshRenderer>();
        if(_mesh != null)
        { 
            _mesh.material = MatDisabled;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!EnabledP)
        { 
            Toggle();
        }
    }
}   
