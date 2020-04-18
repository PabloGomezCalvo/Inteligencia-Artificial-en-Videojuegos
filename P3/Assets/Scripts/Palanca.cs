using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour
{

    public Material MatEnabled;
    public Material MatDisabled;

    [System.Serializable]
    public class OnPalancaToggle : UnityEngine.Events.UnityEvent<bool> {};

    [SerializeField]
    public OnPalancaToggle OnInteract;


    private MeshRenderer _mesh;

    private bool _enabled;

    public void Toggle()
    {
        _enabled = !_enabled;

        OnInteract.Invoke(_enabled);
        

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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            Toggle();
    }


}
