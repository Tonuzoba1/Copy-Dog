using UnityEngine;
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
        EnemyStats.EnemyPowerUp();
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

    public void Units()
    {
        SceneManager.LoadScene(4);
    }

    public void RestartAfterWin()
    {
        PlayerStats.reachedLevel--;
        SceneManager.LoadScene(3);

    }
}
