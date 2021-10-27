using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public UIController ui;

    [Tooltip("Speed multiplier for Horizontal and Vertical movement.")]
    [Range(5,50)]
    public float speed = 10, jumpForce = 5;

    public Vector3 dir; //this is the direction we want to add force
    public Vector3 startPosition;  //assign this in start()

    public bool isGrounded = true;      //these don't need to be public
    public bool canJump = false;

    // get a reference to the rigidbody
    Rigidbody rb;
    int coins = 0;

    /*
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    */
    
    void Start()
    {
      rb = this.GetComponent<Rigidbody>(); 

      startPosition = GameObject.Find("Start Here").transform.position;
      ResetPlayer();

      coins = 0;
      //scoreText.text = "Coins: " + score;

      if(ui == null)
      {
        ui = GameObject.Find("Score").GetComponent<UIController>();
      }

      if(PlayerPrefs.GetInt("canJump") == 1)
      {
        canJump = true;
      }
    }

    void FixedUpdate()
    {
        rb.AddForce(dir * speed);

        //if the player falls below the level, reset the player
        if(this.transform.position.y < -5)
        {
            ResetPlayer();
        }
    }
    
    public void ResetPlayer()
    {
        //canJump = false;

        startPosition = GameObject.Find("Start Here").transform.position;
        rb.velocity = Vector3.zero;                 //set speed to zero
        rb.angularVelocity = Vector3.zero;          //set rotation to zero
        this.transform.rotation = Quaternion.identity;  //set rotaion to 0,0,0
        this.transform.position = startPosition;     //move player
    }

    public void Jump()
    {
        if(isGrounded && canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("Jumping!");
        }
        else
        {
            Debug.Log("You need a PowerUp to jump!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }

        else if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins ++;
            ui.AddScore();
        }
        else if(other.gameObject.CompareTag("JumpPowerUp"))
        {
            canJump = true;
            PlayerPrefs.SetInt("canJump", 1);        // 1 is true, 0 is false
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }

    

    // create a function to move
   // public void MoveHorizontal(float force)
    //{
       // rb.AddForce(force * speed, 0, 0);
    //}

    // create a function to move
    //public void MoveVertical(float force)
    //{
      //  rb.AddForce(0, 0, force * speed);
    //}
}
