using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerGame : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private float defaultSecondsTime = 9;


    void Start()
    {

    }

    void Update()
    {
        defaultSecondsTime -= Time.deltaTime;

        float minutes = Mathf.FloorToInt(defaultSecondsTime / 60),
        seconds = Mathf.FloorToInt(defaultSecondsTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
