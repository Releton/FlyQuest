using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionDetector : MonoBehaviour
{
    public static bool canSpawn = true;
    private void Start()
    {
        canSpawn = true;
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag.Contains("Door"))
        {
            Spawner.life--;
            canSpawn = true;
            Destroy(collision.gameObject);
        }
    }
}
