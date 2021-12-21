using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalState
{
    private static int countBot = 5;
    private static float defaultSecondsTime = 540;



    public static int getCountBot()
    {
        return countBot;
    }

    public static void setCountBot(int count)
    {
        countBot = count;
    }


    public static float getDefaultSecondsTime()
    {
        return defaultSecondsTime;
    }


    public static void pauseGame()
    {
        Time.timeScale = 0;
    }
    public static void resumeGame()
    {
        Time.timeScale = 1;
    }

    public static bool isRunGame()
    {
        return Time.timeScale == 1;
    }

}
