using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isAlive = true;
    private void Start()
    {
        isAlive = true;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FindObjectOfType<AudioManager>().Play("MouseClick");
        }
    }

}
