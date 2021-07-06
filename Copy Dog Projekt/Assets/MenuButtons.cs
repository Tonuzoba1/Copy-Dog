﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject pauseMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void StartLVL1EXP()
    {
        SceneManager.LoadScene(3);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void Flee()
    {
        SceneManager.LoadScene(1);
    }

    public void Shopping()
    {
        SceneManager.LoadScene(2);
    }
}