using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public UIController ui;
    public Camera mainCam;      //attach main camera here

    [Tooltip("Speed multiplier for Horizontal and Vertical movement.")]
    [Range(5,50)]
    public float speed = 10, jumpForce = 5, dashForce = 10;

    public Vector3 dir; //this is the direction we want to add force
    public Vector3 startPosition;  //assign this in start()

    public bool isGrounded = true;      //these don't need to be public
    public bool canJump = false;
    public bool canDash = true;

    // get a reference to the rigidbody
    Rigidbody rb;
    int coins = 0;

    [Header("Audio")]
    
    public AudioSource aud;
    public AudioClip coinClip;
    [Range(0f, 1f)]
    public float coinVolume = .5f;

    
    void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
        if(mainCam == null)
        {
            mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        }
    }
        
    void Start()
    {
      rb = this.GetComponent<Rigidbody>(); 

      startPosition = GameObject.Find("Start Here").transform.position;
      ResetPlayer();

      coins = 0;
      //scoreText.text = "Coins: " + score;

      if(ui == null)
      {
        ui = GameObject.Find("Canvas Stuff").GetComponent<UIController>();
      }

      if(PlayerPrefs.GetInt("canJump") == 1)
      {
        canJump = true;
      }

      if(mainCam == null)
      {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
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

    public void Dash()
    {
        if(canDash)
        {
            //optionally, cancel out velocity to move in new direction
            rb.velocity = Vector3.zero;
            rb.AddForce(dir * dashForce, ForceMode.Impulse);
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait(float waitTime = 1f)
    {
        canDash = false;       // if true, not it is not true
        yield return new WaitForSeconds(waitTime);
        canDash = true;       // if false, now it is not false

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
        else if(other.gameObject.CompareTag("Coin"))
        {
            Debug.Log("You got a coin!");
            Destroy(other.gameObject);
            coins ++;
            ui.AddScore();
            aud.PlayOneShot(coinClip);
        }
        else if(other.gameObject.CompareTag("JumpPowerUp"))
        {
            canJump = true;
            PlayerPrefs.SetInt("canJump", 1);        // 1 is true, 0 is false
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("AltCam"))
        {
            mainCam.gameObject.SetActive(false);
            other.transform.GetChild(0).gameObject.SetActive(true);
        }
        /*
        else if(other.gameObject.CompareTag("Sand"))
        {
            isGrounded = true;
            rb.mass *= 2;
        }
        */
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
        
        if(other.gameObject.CompareTag("AltCam"))
        {
            mainCam.gameObject.SetActive(true);
            other.transform.GetChild(0).gameObject.SetActive(false);
        }
        /*
        if(other.gameObject.CompareTag("Sand"))
        {
            isGrounded = false;
            rb.mass /= 2;
        }
        */
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
