using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject gameUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (GlobalState.isRunGame())
                GlobalState.pauseGame();
            else
                GlobalState.resumeGame();
        }

        if (GlobalState.isRunGame())
        {
            gameUI.SetActive(true);
            pauseMenuUI.SetActive(false);
        }
        else
        {
            gameUI.SetActive(false);
            pauseMenuUI.SetActive(true);
        }
    }

    public void onClickPauseGame()
    {
        GlobalState.pauseGame();
    }

    public void onClickResumeGame()
    {
        GlobalState.resumeGame();
    }

    public void onClickQuitGame()
    {
        Application.Quit();
    }
}
