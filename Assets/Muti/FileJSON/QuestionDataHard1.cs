using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionDataHard1 : InterfaceQuestionJson
{
    public string question;
    public string answer;
    public string A;
    public string B;
    public string C;
    public string D;
    public int difficulty;

    public string GetAnswere()
    {
        throw new System.NotImplementedException();
    }

    public string GetQuestion()
    {
        throw new System.NotImplementedException();
    }
}
