using UnityEngine;
public class QuestionSelector
{
    public static string mode;



    public Question getEzQuestion()
    {
        switch (mode)
        {
            case "maths":
                return Questions.maEzQ[generateRandomNumber(Questions.maEzQ.Length)];
            case "computer":
                return Questions.coEzQ[generateRandomNumber(Questions.coEzQ.Length)];
            case "biology":
                return Questions.biEzQ[generateRandomNumber(Questions.biEzQ.Length)];
            case "physics":
                return Questions.phEzQ[generateRandomNumber(Questions.phEzQ.Length)];
            case "chemistry":
                return Questions.chEzQ[generateRandomNumber(Questions.chEzQ.Length)];
            default:
                int x = generateRandomNumber(Questions.mixed[0].Length);
                int y = generateRandomNumber(Questions.mixed[0][x].Length);
                return Questions.mixed[0][x][y];
        }

    }
    public Question getMdQuestion()
    {
        switch (mode)
        {
            case "maths":
                return Questions.maMdQ[generateRandomNumber(Questions.maMdQ.Length)];
            case "computer":
                return Questions.coMdQ[generateRandomNumber(Questions.coMdQ.Length)];
            case "biology":
                return Questions.biMdQ[generateRandomNumber(Questions.biMdQ.Length)];
            case "physics":
                return Questions.phMdQ[generateRandomNumber(Questions.phMdQ.Length)];
            case "chemistry":
                return Questions.chMdQ[generateRandomNumber(Questions.chMdQ.Length)];
            default:
                int x = generateRandomNumber(Questions.mixed[1].Length);
                int y = generateRandomNumber(Questions.mixed[1][x].Length);
                return Questions.mixed[1][x][y];
        }
    }
    public Question getHdQuestion()
    {
        switch (mode)
        {
            case "maths":
                return Questions.maHdQ[generateRandomNumber(Questions.maHdQ.Length)];
            case "computer":
                return Questions.coHdQ[generateRandomNumber(Questions.coHdQ.Length)];
            case "biology":
                return Questions.biHdQ[generateRandomNumber(Questions.biHdQ.Length)];
            case "physics":
                return Questions.phHdQ[generateRandomNumber(Questions.phHdQ.Length)];
            case "chemistry":
                return Questions.chHdQ[generateRandomNumber(Questions.chHdQ.Length)];
            default:
                int x = generateRandomNumber(Questions.mixed[2].Length);
                int y = generateRandomNumber(Questions.mixed[2][x].Length);
                return Questions.mixed[2][x][y];
        }
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
