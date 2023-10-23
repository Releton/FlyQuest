using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] doors;
    public static int spawnNumber = 0;
    int spawnNumberLocal = 0;
    public static int points = 0;
    public static int life = 3;
    private QuestionSelector qs;
    public TMP_Text QuestionText;
    public TMP_Text Points;
    public TMP_Text Mode;
    public static int firstIndexAnswer = -1;
    public GameObject questionPanel;
    public TMP_Text questionZoomed;
    public static bool isQuestionZoomed = false;
    private Question quest;
    private int index;
    // Update is called once per frame
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        spawnNumber = 0;
        spawnNumberLocal = 0;
        points = 0;
        life = 3;
        qs = new QuestionSelector();
        Mode.text = QuestionSelector.mode;
    }
    void Update()
    {
        if (life <= 0)
        {
            GameManager.isAlive = false;
        }
        Points.text = points.ToString();
        if ((QuestionDetector.canSpawn || DoorMovement.canSpawn) && GameManager.isAlive && !PauseMenu.isPaused)
        {
            spawnNumberLocal++;
            spawnNumber++;

            DisplayQuestion();
            QuestionDetector.canSpawn = false;
            DoorMovement.canSpawn = false;
        }

    }

    private void DisplayQuestion()
    {
        if (spawnNumberLocal >= 1 && spawnNumberLocal <= 5)
        {
            quest = qs.getEzQuestion();
            index = 0;
        }
        else if (spawnNumberLocal > 5 && spawnNumberLocal <= 8)
        {
            quest = qs.getMdQuestion();
            index = 1;
        }
        else if (spawnNumberLocal > 8 && spawnNumberLocal <= 10)
        {
            quest = qs.getHdQuestion();
            index = 2;
        }
        if (spawnNumberLocal == 10)
        {
            spawnNumberLocal = 0;
        }
        Debug.Log("First "+quest.question);
        questionZoomed.text = quest.question;
        questionPanel.gameObject.SetActive(true);
        isQuestionZoomed = true;
        float computed = quest.question.Length * 0.1f;
        Invoke("IntstantiateDoor", (index == 0) ? computed : (index == 1 ? (computed + 1) : computed + 2));
    }
    private void IntstantiateDoor()
    {
        Instantiate(doors[index]);
        Question q = quest;
        QuestionText.text = q.question;
        DoorMovement.question = q;
        Debug.Log("Second "+q.question);
        questionPanel.gameObject.SetActive(false);
        isQuestionZoomed = false;
    }
}
