using UnityEngine;
public class QuestionSelector
{
    public static string mode;

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
        Debug.Log(mode);
        int r = Random.Range(0, range);
        for(; r == Spawner.firstIndexAnswer;)
        {
            r = Random.Range(0, range);
        }
        Spawner.firstIndexAnswer = r;
        return r;
    }
}
