using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    float seconds = 0;
    int minutes = 0;
    int hours = 0;
    public float myTime = 0;


    private void Start()
    {
        Time.timeScale = 1;
        TimerText.text = hours.ToString() + ":" + minutes.ToString() + ":" + seconds.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        myTime = Mathf.RoundToInt(Time.time);
       seconds = Mathf.RoundToInt(Time.time);
        //Debug.Log(seconds);
        if (seconds > 59) 
        {
            seconds = 0;
            minutes++;
        }
        if (minutes > 59) 
        {
            seconds = 0;
            minutes = 0;
            hours++;
        }
        TimerText.text = hours.ToString() + ":" + minutes.ToString() + ":" + seconds.ToString();

    }

    public int GetTime() 
    {
        return Mathf.RoundToInt(myTime);
    }

}
