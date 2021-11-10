using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenePicker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int progress = PlayerPrefs.GetInt("Progress", 3);
        Button[] buttons = new Button[transform.childCount];

        /*set all buttons to NOT interactable
        for(int i = 0; i < totalChildren; i++) 
        {
            this.transform.GetChild(i).GetComponent<Button>().interactable = false;
        }

        for(int i = 0; i < progress; i++) 
        {
            this.transform.GetChild(i).GetComponent<Button>().interactable = true;
        }
        */

        // here be dragons
        // add all buttons to an array of buttons
        // and set them to be NOT interactable
        for(int i = 0; i< buttons.Length; i++)
        {
            buttons[i] = transform.GetChild(i).GetComponent<Button>();
            buttons[i].interactable = false;
        }

        //for as many levels as the pplayer has gotton to
        // set them to interactable
        for(int i = 0; i< progress; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void ResetProgress()
    {
        PlayerPrefs.SetInt("Progress", 2);
        UnityEngine.SceneManagement.SceneManager.LoadScene("levelselect");
    }
}
