using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerDetector : MonoBehaviour
{
    public TMP_Text option;
    private int index;
    private void Start()
    {
        index = int.Parse(gameObject.tag);
    }
    private void Update()
    {
        if(DoorMovement.question!=null)
        {
            option.text = DoorMovement.question.options[index];
        }
    }
    private void OnTriggerExit(Collider collide)
    {
        if (collide.tag.Contains("Player"))
        {
            DoorMovement.index = index;
            DoorMovement.hasAnswered = true;
        }
    }
}
