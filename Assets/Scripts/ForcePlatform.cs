//bounce that boi
// have a bunch that connect like a warp/boost (single use)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePlatform : MonoBehaviour
{
    public float force = 10f;
    public bool zeroOtVelocity = true;
    public bool singleUse = false;

    [Header("Audio")]
    
    public AudioSource aud;
    public AudioClip forceClip;
    [Range(0f, 1f)]
    public float forceVolume = .5f;

    void OnDrawGizmosSelected()
    {
        // Draws a 1/2 unit long cyan line in the direction of the force
        Gizmos.color = Color.cyan;
        Vector3 direction = transform.TransformDirection(Vector3.up) * force * .5f;
        Gizmos.DrawRay(transform.position, direction);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            aud.PlayOneShot(forceClip);
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
