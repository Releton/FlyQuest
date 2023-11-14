using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSetter : MonoBehaviour
{
    private TMP_Text scoreTxt;
    private void Start()
    {
        scoreTxt = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        scoreTxt.text = GameManager.points.ToString();
    }

}
