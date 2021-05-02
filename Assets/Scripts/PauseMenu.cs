﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool mGameIsPaused = false;
    public GameObject mPauseMenuUI;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (mGameIsPaused)
            {
                Resume();
            } else
            {
                Paused(); 
            }
        }
    }

    public void Resume()
    {
        PlayerMovements.instance.enabled = true;
        mPauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        mGameIsPaused = false;
    }

    void Paused()
    {
        PlayerMovements.instance.enabled = false;
        mPauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        mGameIsPaused = true;
    }

    public void LoadMainMenu()
    {
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
}