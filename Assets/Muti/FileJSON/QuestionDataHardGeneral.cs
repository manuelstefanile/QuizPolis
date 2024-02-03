using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionDataHardGeneral : InterfaceQuestionJson
{
    public string question;
    public string answer;
    public string difficulty;

    
    public string GetQuestion(){
        return question;

    }
  public string GetAnswere(){
    return answer;
  }
}

