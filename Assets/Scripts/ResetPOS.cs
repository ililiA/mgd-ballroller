using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPOS : MonoBehaviour
{
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
        this.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.CompareTag("Hole"))  
      {
          Debug.Log("Resetting");
          UnityEngine.SceneManagement.SceneManager.LoadScene(2);
      }

      if(other.gameObject.CompareTag("Hole1"))  
      {
          Debug.Log("Resetting");
          UnityEngine.SceneManagement.SceneManager.LoadScene(4);
      }
    }
}
