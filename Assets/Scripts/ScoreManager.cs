using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [Header("Score")]
    public Text scoreText;
    private int score;

    [Header("Coins")]
    public Text coinText;
    private int coins;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void addPoints(int points)
    {
        score = score + points;
        scoreText.text = score.ToString("000000");
    }

    public void GetCoin()
    {
        coins = coins + 1;
        coinText.text = "X" + coins.ToString("00");
    }
}
