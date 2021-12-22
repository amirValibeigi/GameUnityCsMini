using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    [SerializeField] public InputField txtNamePlayer;

    public void Start()
    {
        initVarables();
    }


    public void onClickPlayEasyMode()
    {
        PlayerPrefs.SetString("namePlayer", txtNamePlayer.text);
        PlayerPrefs.Save();

        SceneManager.LoadScene("DustIIScenes");
    }

    public void onClickQuitGame()
    {
        Application.Quit();
    }


    private void initVarables()
    {
        txtNamePlayer.text = PlayerPrefs.GetString("namePlayer", "AmIr");
    }
}
