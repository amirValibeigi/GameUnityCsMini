using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalState
{
    private static int countBot = 5;
    private static float defaultSecondsTime = 540;
    private static string[] nameBots = {
        "James","Mary","Robert","Patricia","John","Jennifer",
        "Michael","Linda","William","Elizabeth","David","Barbara",
        "Richard","Susan","Joseph","Jessica","Thomas","Sarah","Charles",
        "Karen","Christopher","Nancy","Daniel","Lisa","Matthew","Betty",
        "Anthony","Margaret","Mark","Sandra"
};


    public static int getCountBot()
    {
        return countBot;
    }

    public static void setCountBot(int count)
    {
        countBot = count;
    }

    public static string[] getNamesBot()
    {
        return nameBots;
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

    public static void restartGame()
    {
        SceneManager.LoadScene("DustIIScenes");
    }
}
