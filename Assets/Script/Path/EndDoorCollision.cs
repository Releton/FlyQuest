using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDoorCollision : MonoBehaviour
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
            GameManager.life--;
            canSpawn = true;
            Destroy(collision.gameObject);
        }
    }
}
