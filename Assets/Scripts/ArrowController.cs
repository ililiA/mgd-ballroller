using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public PlayerMovement player;
    Vector3 arrowScale; // reference "size" for arrow

    // Start is called before the first frame update
    void Start()
    {
        arrowScale = Vector3.one;   //set the reference size to 1,1,1
    }

    void Awake() 
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.rotation = Quaternion.LookRotation(player.dir, Vector3.up);
        arrowScale.z = player.dir.magnitude;    //update the depth scale based on the strength of the
        this.transform.localScale = arrowScale; // assign the scale to the arrow

    }
}
