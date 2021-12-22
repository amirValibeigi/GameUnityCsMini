using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerGame : MonoBehaviour
{
    [SerializeField] private Text timerText;
    private float defaultSecondsTime = GlobalState.getDefaultSecondsTime();


    void Start()
    {

    }

    void Update()
    {
        counterDown();

        if (defaultSecondsTime <= 1)
        {
            GlobalState.restartGame();
        }
    }



    private void counterDown()
    {
        defaultSecondsTime -= Time.deltaTime;

        float minutes = Mathf.FloorToInt(defaultSecondsTime / 60),
        seconds = Mathf.FloorToInt(defaultSecondsTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
