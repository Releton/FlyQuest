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
        Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Cursor.lockState = CursorLockMode.None; //Added by Divyadyuti Roy
        //Cursor.visible = false;
        if (Input.GetKeyUp(KeyCode.Escape))
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
        //Added by Divyadyuti Roy:
        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl))
        {
            Cursor.visible = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0) && !deathScreen.activeSelf && !isPaused)
        {
            Cursor.visible = false;
        }
    }

    public void pauseGame()
    {
        isPaused = true;
        //Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; // Added by Divyadyuti Roy
        pauseMenu.SetActive(true);
        Time.timeScale= 0f;
        Debug.Log("Click Pause");
    }

    public void resumeGame()
    {
        isPaused = false;
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; // Added by Divyadyuti Roy
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("Click Resume");
    }

    public void forfiet()
    {
        HealthManager.isAlive = false;
    }


}
