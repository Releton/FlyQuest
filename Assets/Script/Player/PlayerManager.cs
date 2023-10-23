using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
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
            GameManager.isAlive = false;
        }
    }
    private void renderHearts()
    {
        for(int i = 0; i < 3; i++)
        {
            if(Spawner.life <= i || !GameManager.isAlive)
            {
                hearts[i].enabled= false;
            }
        }
    }
}
