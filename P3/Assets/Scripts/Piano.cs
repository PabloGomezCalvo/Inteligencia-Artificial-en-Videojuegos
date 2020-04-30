using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Vizconde")
        {
            GameManager.instance.Breaking = true;
        }
        else if (collision.gameObject.tag == "Fantasma")
        {
            GameManager.instance.Breaking = false;
        }
    }
}
