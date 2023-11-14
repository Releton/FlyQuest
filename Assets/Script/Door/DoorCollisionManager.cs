using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorCollisionManager : MonoBehaviour
{
    public TMP_Text option;
    private int index;
    private void Start()
    {
        index = int.Parse(gameObject.tag);
    }
    private void Update()
    {
        if(DoorManager.question!=null)
        {
            option.text = DoorManager.question.options[index];
        }
    }
    private void OnTriggerExit(Collider collide)
    {
        if (collide.tag.Contains("Player"))
        {
            DoorManager.index = index;
            DoorManager.hasAnswered = true;
        }
    }
}
