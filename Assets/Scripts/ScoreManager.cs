using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void addPoints(int points)
    {
        score = score + points;
        scoreText.text = score.ToString("000000");
    }
}
