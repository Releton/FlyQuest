using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public static Question question = null;
    public static bool hasAnswered = false;
    public static int index = -1;
    public static bool canSpawn = false;
    private AudioManager audioManager;
    // Start is called before the first frame update
    private Rigidbody rb;
    private float speedAdd = 1f;
    private GameObject greenVignette;
    private GameObject redVignette;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        audioManager = FindObjectOfType<AudioManager>();
        greenVignette = GameObject.FindWithTag("GreenVig");
        redVignette = GameObject.FindWithTag("RedVig");
        print(redVignette); 
        print(greenVignette);
    }

    // Update is called once per frame
    void Update()
    {
        float computedSpeed = (GameManager.spawnNumber / 5f);
        speedAdd = computedSpeed >= 6f ? 6f : computedSpeed;
        if (!GameManager.isQuestionZoomed && HealthManager.isAlive)
        {
            rb.transform.Translate(new Vector3(0, 0, -speedAdd - 2) * Time.deltaTime);
        }

        if (hasAnswered)
        {
            if (question.correctIndex == index)
            {
                if (question.difficulty == 0) GameManager.points += 1;
                else if (question.difficulty == 1) GameManager.points += 2;
                else if (question.difficulty == 2) GameManager.points += 4;

                audioManager.Play("Success");
                greenVignette.GetComponent<VignetteAdjuster>()?.doVignette();
            }
            else
            {
                GameManager.life--;
                audioManager.Play("Failure");
                redVignette.GetComponent<VignetteAdjuster>()?.doVignette();

            }
            hasAnswered = false;
            canSpawn = true;
            Destroy(this.gameObject);
        }
    }
}
