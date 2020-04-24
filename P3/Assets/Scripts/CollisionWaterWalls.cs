using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWaterWalls : MonoBehaviour
{
    public BarcaMovement Barca;
    [SerializeField]
    private float AreaProximidad;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Cantante") {
            //Compruebo si la barca esta cerca
            float x1, x2, z1, z2;
            x1 = this.transform.position.x + AreaProximidad;
            x2 = this.transform.position.x - AreaProximidad;
            z1 = this.transform.position.z + AreaProximidad;
            z2 = this.transform.position.z - AreaProximidad;

            //Si es asi le digo q empiece a moverse con el pj
            if (x1 > Barca.transform.position.x && x2 < Barca.transform.position.x
                && z1 > Barca.transform.position.z && z2 < Barca.transform.position.z)
            {
                Barca.MovementActive(collision.gameObject);
            }
        }
    }
}
