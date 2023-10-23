using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public void OnMathsClick()
    {
        QuestionSelector.mode = "maths";
        ChangeScene();
    }
    public void OnChemistryClick()
    {
        QuestionSelector.mode = "chemistry";
        ChangeScene();
    }
    public void OnPhyscisClick()
    {
        QuestionSelector.mode = "physics";
        ChangeScene();
    }
    public void OnBiologyClick()
    {
        QuestionSelector.mode = "biology";
        ChangeScene();
    }
    public void OnComputerClick()
    {
        QuestionSelector.mode = "computer";
        ChangeScene();
    }
    public void OnMixedClick()
    {
        QuestionSelector.mode = "mixed";
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
