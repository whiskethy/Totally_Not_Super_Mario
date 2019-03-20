using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timeText;
    float timeLeft = 400;

    // Start is called before the first frame update
    void Start()
    {
        timeText.text = Mathf.RoundToInt(timeLeft).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        timeText.text = Mathf.RoundToInt(timeLeft).ToString();
    }
}
