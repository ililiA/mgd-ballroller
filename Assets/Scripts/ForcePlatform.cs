using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePlatform : MonoBehaviour
{
    public float force = 10f;
    public bool zeroOtVelocity = true;
    public bool singleUse = false;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //get the rigidbody component of player
            Rigidbody rb = other.GetComponent<Rigidbody>();
            // stop the player's movement
            rb.velocity = Vector3.zero;
            // push the player UP relative to the direction of this platform
            rb.AddForce(this.transform.up * force, ForceMode.Impulse);
            // destroy this after use
            if(singleUse)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
