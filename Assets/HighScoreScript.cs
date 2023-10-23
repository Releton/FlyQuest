using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreScript : MonoBehaviour
{
    public TMP_Text highScore;

    private void Start()
    {
        highScore.text =  PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}
