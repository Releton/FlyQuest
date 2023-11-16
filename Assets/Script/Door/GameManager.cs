using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ThirdPersonMovement player;
    // Start is called before the first frame update
    public GameObject[] doors;
    public static int spawnNumber = 0;
    int spawnNumberLocal = 0;
    public static int points = 0;
    public static int life = 3;
    private QuestionSelector qs;
    public TMP_Text QuestionText;
    public TMP_Text Points;
    public static int firstIndexAnswer = -1;
    public GameObject questionPanel;
    public TMP_Text questionZoomed;
    public static bool isQuestionZoomed = false;
    private Question quest;
    private int index;
    private float spawnTimer = 0;
    bool counting = false;
    private float timeReq;
    // Update is called once per frame
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        spawnNumber = 0;
        spawnNumberLocal = 0;
        points = 0;
        life = 3;
        qs = new QuestionSelector();
    }
    void Update()
    {

        if(counting)
        {
            spawnTimer += Time.deltaTime;
        }
        if(spawnTimer >=  timeReq && counting)
        {
            counting = false;   
            IntstantiateDoor();
            spawnTimer = 0;
        }

        if (life <= 0)
        {
            HealthManager.isAlive = false;
        }
        Points.text = points.ToString();
        if ((EndDoorCollision.canSpawn || DoorManager.canSpawn) && HealthManager.isAlive && !PauseMenu.isPaused)
        {
            spawnNumberLocal++;
            spawnNumber++;

            DisplayQuestion();
            EndDoorCollision.canSpawn = false;
            DoorManager.canSpawn = false;
        }
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            questionPanel.gameObject.SetActive(false);
            DoorManager.canSpawn = false;
            EndDoorCollision.canSpawn = false;
            player.TeleportToStart();
            isQuestionZoomed = false;
            print("Herer");
            spawnTimer = timeReq;
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
            questionZoomed.text = quest.question;
            questionPanel.gameObject.SetActive(true);
            player.TeleportToStart();
            isQuestionZoomed = true;
            print("Herer SHH");
        counting = true;
        timeReq = (index == 0) ? 5 : (index == 1 ? (10) : 15);
    } 
    private void IntstantiateDoor()
    {
        Instantiate(doors[index]);
        Question q = quest;
        QuestionText.text = q.question;
        DoorManager.question = q;
        Debug.Log("Second "+q.question);
        questionPanel.gameObject.SetActive(false);
        isQuestionZoomed = false;
    }
}
