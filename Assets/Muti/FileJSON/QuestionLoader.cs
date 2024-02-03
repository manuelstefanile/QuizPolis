using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
//tutto cio che implementa interfaceQuestion
public class QuestionDataList<T> where T : InterfaceQuestionJson
{
    public List<T> Verbs=new List<T>();
    public List<T> Grammar=new List<T>();
    public List<T> Geography=new List<T>();
    public List<T> Objects=new List<T>();
    public List<T> Animals=new List<T>();


    public T GetQuestionForType(CasellaScript.tipoDomanda tipodomanda){
        System.Random  randomGenerator = new System.Random(System.DateTime.Now.Millisecond);
        
        switch(tipodomanda){
            case CasellaScript.tipoDomanda.verbi:
                return Verbs[randomGenerator.Next(0,Verbs.Count)];
            case CasellaScript.tipoDomanda.grammatica:
                return Grammar[randomGenerator.Next(0,Grammar.Count)];
            case CasellaScript.tipoDomanda.geografia:
                return Geography[randomGenerator.Next(0,Geography.Count)];
            case CasellaScript.tipoDomanda.oggetti:
                return Objects[randomGenerator.Next(0,Objects.Count)];
            case CasellaScript.tipoDomanda.animali:
                return Animals[randomGenerator.Next(0,Animals.Count)];
        }
        /****************************************************************************AGGIUSTARE**********/
         return Animals[UnityEngine.Random.Range(0,Verbs.Count)];
    }


    
}

public class QuestionLoader : MonoBehaviour
{
    public TextAsset questionsHard1JSON; // Riferimento al file JSON
    public TextAsset questionsHard2JSON; // Riferimento al file JSON
    public TextAsset questionsHard3JSON; // Riferimento al file JSON
    public TextAsset questionsHard4JSON; // Riferimento al file JSON
    public TextAsset questionsHard5JSON; // Riferimento al file JSON
    //contiene una Lista di domande
    //per ogni difficolta una lista di domande
    private QuestionDataList<QuestionDataHard1> questionListHard1;
    private QuestionDataList<QuestionDataHardGeneral> questionListHard2;
    private QuestionDataList<QuestionDataHardGeneral> questionListHard3;
    private QuestionDataList<QuestionDataHardGeneral> questionListHard4;
    private QuestionDataList<QuestionDataHardGeneral> questionListHard5;



    public QuestionDataList<QuestionDataHard1> GetQuestionListHard1(){
        if(questionListHard1==null){
            Debug.Log("ok instanzio");
            questionListHard1=new QuestionDataList<QuestionDataHard1>();
            string jsonString = questionsHard1JSON.text;
            questionListHard1 = JsonUtility.FromJson<QuestionDataList<QuestionDataHard1>>(jsonString);
            Debug.Log(questionListHard1.Verbs.Count);
            Debug.Log(questionListHard1.Geography.Count);
            return questionListHard1;
        }else return questionListHard1;
    }
    public QuestionDataList<QuestionDataHardGeneral> GetQuestionListHardGeneral(int difficolta){
        switch(difficolta){    
            case 2:
                if(questionListHard2==null){
                    questionListHard2=new QuestionDataList<QuestionDataHardGeneral>();
                    string jsonString = questionsHard2JSON.text;
                    questionListHard2 = JsonUtility.FromJson<QuestionDataList<QuestionDataHardGeneral>>(jsonString);
                    return questionListHard2;
                }else return questionListHard2;
            case 3:
                if(questionListHard3==null){
                    questionListHard3=new QuestionDataList<QuestionDataHardGeneral>();
                    string jsonString = questionsHard3JSON.text;
                    questionListHard3 = JsonUtility.FromJson<QuestionDataList<QuestionDataHardGeneral>>(jsonString);
                    return questionListHard3;
                }else return questionListHard3;
            case 4:
                if(questionListHard4==null){
                    questionListHard4=new QuestionDataList<QuestionDataHardGeneral>();
                    string jsonString = questionsHard4JSON.text;
                    questionListHard4 = JsonUtility.FromJson<QuestionDataList<QuestionDataHardGeneral>>(jsonString);
                    return questionListHard4;
                }else return questionListHard4;
            case 5:
                if(questionListHard5==null){
                    questionListHard5=new QuestionDataList<QuestionDataHardGeneral>();
                    string jsonString = questionsHard5JSON.text;
                    questionListHard5 = JsonUtility.FromJson<QuestionDataList<QuestionDataHardGeneral>>(jsonString);
                    return questionListHard5;
                }else return questionListHard5;
            
        }
        return null;
    }


    void Start()
    {
        
    }

    void Update(){
        
    }
    
}
