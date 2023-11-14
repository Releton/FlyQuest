using UnityEngine;
using UnityEngine.UI;

public class PlayerHeartRenderer : MonoBehaviour
{
    public Image[] hearts;
    private void Update()
    {
        renderHearts();
        isPlayerAlive();
    }

    private void isPlayerAlive()
    {
        if(gameObject.transform.position.y < 0)
        {
            HealthManager.isAlive = false;
        }
    }
    private void renderHearts()
    {
        for(int i = 0; i < 3; i++)
        {
            if(GameManager.life <= i || !HealthManager.isAlive)
            {
                hearts[i].enabled= false;
            }
        }
    }
}
