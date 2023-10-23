using System.Collections;
using System.Collections.Generic;

public class Question
{
    public string question;
    public string[] options;
    public int correctIndex;
    public int difficulty;
    
    public Question(string question, string[] options, int correctIndex, int difficulty)
    {
        this.question = question;
        this.options = options;
        this.correctIndex = correctIndex;
        this.difficulty = difficulty;
    }
}
