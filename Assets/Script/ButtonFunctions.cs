using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public void OnMathsClick()
    {
        ChangeScene();
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
