using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    public float throwForce = 40f;
    public GameObject grenade;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            ThrowGrenade();
        }
    }

    void ThrowGrenade(){
        GameObject grenadette = Instantiate(grenade, transform.position, transform.rotation);
        Rigidbody rb = grenadette.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
