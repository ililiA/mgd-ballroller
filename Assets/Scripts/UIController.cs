using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 0;
    
    void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
        scoreText.text = "Coins: " + score;
    }
    
    
    
    void Start()
    {
        score = PlayerPrefs.GetInt("Score");
        scoreText.text = "Coins: " + score.ToString();
    }
    

    public void AddScore(int amount = 1)
    {
        Debug.Log("Adding score");
        score += amount;
        scoreText.text = "Coins: " + score.ToString();
        PlayerPrefs.SetInt("Score", score);
    }
}
