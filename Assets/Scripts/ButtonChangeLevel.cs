using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // don't forget this
                                    // scenes must be added to the build index

public class ButtonChangeLevel : MonoBehaviour
{
    public void ChangeScene(int index)
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            PlayerPrefs.SetInt("Score", 0);
            PlayerPrefs.SetInt("canJump", 0);
            //canDash
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }

}
