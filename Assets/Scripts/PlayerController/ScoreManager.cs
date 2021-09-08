using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public bool gameOver = false;
    public TMP_Text scoreText;
   
    public int score;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        if(instance!= this)
        {
            Destroy(gameObject);
        }
    }
    public void ScoreCollecting()
    {
        if(gameOver)
        {      
            return;
        }
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
}
