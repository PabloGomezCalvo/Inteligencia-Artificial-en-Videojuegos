using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour
{

    [SerializeField]
    private Material MatEnabled;
    [SerializeField]
    private Material MatDisabled;
    [SerializeField]
    private LamparaMovement Lampara;



    private MeshRenderer _mesh;
    
    private bool _enabled;

    public void Toggle()
    {
        _enabled = !_enabled;

        if (_enabled)
            _mesh.material = MatEnabled;
        else
            _mesh.material = MatDisabled;
    }

    // Start is called before the first frame update
    void Start()
    {
        _enabled = false;
        _mesh = GetComponent<MeshRenderer>();
        if(_mesh != null)
        { 
            _mesh.material = MatDisabled;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Fantasma" && !_enabled)
        { 
            Lampara.Move();
            Toggle();
        }
    }
}
