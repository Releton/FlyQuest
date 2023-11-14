using UnityEngine;
public class QuestionSelector
{
    public Question getEzQuestion()
    {
        return Questions.maEzQ[generateRandomNumber(Questions.maEzQ.Length)];
    }
    public Question getMdQuestion()
    {
        return Questions.maMdQ[generateRandomNumber(Questions.maMdQ.Length)];
    }
    public Question getHdQuestion()
    {
        return Questions.maHdQ[generateRandomNumber(Questions.maHdQ.Length)];

    }

    private int generateRandomNumber(int range)
    {
        if (range <= 1) return 0;

        int r = Random.Range(0, (int) Mathf.Round((range * 100)/100f));
        for(; r == GameManager.firstIndexAnswer;)
        {
            r = Random.Range(0, (int)Mathf.Round((range * 100) / 100f));
        }
        GameManager.firstIndexAnswer = r;
        return r;
    }
}
