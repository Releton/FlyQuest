    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenu;
    public GameObject deathScreen;
    private void Start()
    {
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if(isPaused)
            {
                pauseGame();
            }
            else
            {
                resumeGame();
            }
        }
    }

    public void pauseGame()
    {
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(true);
        Time.timeScale= 0f;
        Debug.Log("Click Pause");
    }

    public void resumeGame()
    {
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("Click Resume");
    }

    public void forfiet()
    {
        HealthManager.isAlive = false;
    }


}
