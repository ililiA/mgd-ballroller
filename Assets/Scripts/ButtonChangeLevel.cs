using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // don't forget this
                                    // scenes must be added to the build index

public class ButtonChangeLevel : MonoBehaviour
{
    public int levelWithJump = 7;
    
    void Awake()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            PlayerPrefs.SetInt("Score", 0);
            PlayerPrefs.SetInt("canJump", 0);
            //canDash
        }
        else if(SceneManager.GetActiveScene().buildIndex >= levelWithJump)
        {
            PlayerPrefs.SetInt("canJump", 1);
        }
    }

    public void ChangeScene(int index)
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            PlayerPrefs.SetInt("Score", 0);
            PlayerPrefs.SetInt("canJump", 0);
            //canDash
        }
        else if(SceneManager.GetActiveScene().buildIndex >= levelWithJump)
        {
            PlayerPrefs.SetInt("canJump", 1);
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }

}
