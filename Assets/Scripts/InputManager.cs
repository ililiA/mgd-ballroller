using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // get a reference to the playerMovement script
    public PlayerMovement player;
    //public PlayerMovement powerup;


    // Start is called before the first frame update
    void Start()
    {
        if(player == null)
        {
            player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        }

        //powerup = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // call movement every frame and send its axis data
        player.dir.x = Input.GetAxis("Horizontal");
        player.dir.z = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Space))
        {
            player.Jump();
            /*
            if(powerup > 0)
            {
                player.Jump();
            }
            else
            {
                Debug.Log("You need a PowerUp to jump!");
            }
            */
        }

    }
}
