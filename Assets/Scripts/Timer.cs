using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static TextMeshProUGUI timerText;
    public static float timeValue;
    bool timeStarted = false;

    private void Start()
    {
        timerText = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
    }


     private void FixedUpdate()
    {
        if (timeValue <= 0)
        {
            timeValue = 0;
        }

        timeValue -= Time.deltaTime;

        if (Menu.level == 1 && !timeStarted)
        {
            timeStarted = true;
            timeValue = 30;
            
        }
        timerText.text = "Time left: " + Mathf.Round(timeValue).ToString();

        if (timeValue<=0 && timeStarted)
        {
            SceneManager.LoadScene(1);
        }


    }





}
