using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathScreen;
    bool hasTriggeredOnce = false;
    public TMP_Text mode;
    public TMP_Text highScore;
    public GameObject pauseMenu;
    private AudioManager audioManager;
    public ParticleSystem explosion;
    public Camera mainCam;
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        deathScreen.SetActive(false);
        mainCam = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        if(!GameManager.isAlive)
        {
            pauseMenu.SetActive(false);
            deathScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            setHighScore();
            highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
            mode.text = $"{QuestionSelector.mode}:  {Spawner.points}";
            if (!hasTriggeredOnce)
            {
                audioManager.Play("Death");
                audioManager.Pause("Theme");
                explosion.gameObject.transform.position = mainCam.transform.position;
                explosion.Play();
                Destroy(GameObject.FindGameObjectWithTag("PlayerObject"));
            }

            hasTriggeredOnce = true;
        }
    }

    public void homeButtonClick()
    {
        PauseMenu.isPaused = false;
        pauseMenu.SetActive(false);
        GameManager.isAlive = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void setHighScore()
    {
        if(Spawner.points > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Spawner.points);
        }
    }

    public void restart()
    {
        PauseMenu.isPaused = false;
        pauseMenu.SetActive(false);
        GameManager.isAlive = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
