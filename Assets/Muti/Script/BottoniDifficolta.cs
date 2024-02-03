using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BottoniDifficolta :HoverButtonsInteract
{
    public string testoDifficolta;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void ScripviRispostaInputField()
    {
        base.ScripviRispostaInputField();
        int difficolta;
        GlobalVariabili globalvar=GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>();
        //testo difficolta
        TextMeshPro testo=transform.parent.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        TextMeshPro testoBottone=FindChildWithTag(this.transform,"TestoBottoniRisposta").GetComponent<TextMeshPro>();

        if(testoBottone.text.Equals("Next")){
            if(globalvar.GetDifficolta()==0){
                testo.text="Select a difficulty";
            }else{
                Debug.Log("bottone nex ok, deve muovere");
                GameObject oculus=GameObject.FindWithTag("Oculus");
                StartCoroutine(MuoviGradualmente(oculus,GameObject.Find("Spawn").transform.position+new Vector3(0.5f,-0.5f,-0.5f),2f));


                //inizializza il gioco con la difficolta
                GameObject.FindObjectOfType<Inizializzazione>().InizializzaGame(globalvar.GetDifficolta());

                       // creo un delegate con action<bool> da passare come parametro alla funzione puovipedinadadi(false)
            //Action<bool, int, float> metodoMuoviPedinaDadi = new Action<bool, int, float>(MuoviPedinaDadi); un esempio
                Delegate destroyP = new Action(DestroyButtonDifficolta);
                StartCoroutine(WaitSecond(2.2f, destroyP));
                
                
                //vai avanti nel gioco. la difficolta è stata scelta
            }
        }else{
            //converti il testo in int e mettilo in difficolta
            int.TryParse(testoBottone.text, out difficolta);
            globalvar
                .SetDifficolta(difficolta);
            //prendo il testo
            
            testo.text=testoDifficolta;
            switch(difficolta){
                case 1: testo.color=Color.white;
                    break;
                case 2: testo.color=Color.green;
                    break;
                case 3: testo.color=Color.yellow;
                    break;
                case 4: testo.color=Color.red;
                    break;
                default: break;
            }
        }
        
        
    }

    private void DestroyButtonDifficolta(){
        Destroy(transform.parent.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
