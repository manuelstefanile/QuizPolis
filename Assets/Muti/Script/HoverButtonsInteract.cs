using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HoverButtonsInteract : ClasseGeneral
{
     public InputField testoRisposta;
    // Start is called before the first frame update    
    public virtual void ScripviRispostaInputField(){
        GlobalVariabili global=GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>();
        //scrivo la risposta del bottone che ho premuto sul inputfield
        if(testoRisposta!=null)
            testoRisposta.text=FindChildWithTag(this.transform,"TestoBottoniRisposta").GetComponent<TextMeshPro>().text;
        SettaButtonsWhiteNoOne();
        
        
        //rbp.norm=new Color(0f, 1f, 0f, 0.4f);
        //altrimenti non si aggiorna
        
        
        
    }
    public void SettaButtonsWhiteNoOne(){
        //colora il bottone di verde quando selezionato
        GameObject bottone=transform.GetChild(1).GetChild(0).GetChild(0).gameObject;
        InteractableColorVisual rbp=bottone.GetComponent<InteractableColorVisual>();
        


        InteractableColorVisual.ColorState vv=new InteractableColorVisual.ColorState();
        vv.Color=new Color(0f, 1f, 0f, 0.2f);
        rbp.InjectOptionalNormalColorState(vv);

        //e metti tutti gli altri bottoni a bianco
        GameObject[] gameob=GameObject.FindGameObjectsWithTag("TestoBottoniRisposta");
        
        foreach(GameObject obj in gameob){
            
            GameObject padre=obj.transform.parent.gameObject;
            
            if(padre.transform.GetChild(0).gameObject!=bottone){
                InteractableColorVisual rbp2=padre.transform.GetChild(0).gameObject.GetComponent<InteractableColorVisual>();
                InteractableColorVisual.ColorState vv2=new InteractableColorVisual.ColorState();
                vv2.Color=new Color(1f, 1f, 1f, 0.2f);
                rbp2.InjectOptionalNormalColorState(vv2);
                rbp2.enabled=false;
                rbp2.enabled=true;
            }
            
            
        }

    }

    public void ResettaColorStartAll(bool chiudere){
        GameObject[] gameob=GameObject.FindGameObjectsWithTag("TestoBottoniRisposta");
        
        foreach(GameObject obj in gameob){
            GameObject padre=obj.transform.parent.gameObject;
            
            
                InteractableColorVisual rbp2=padre.transform.GetChild(0).gameObject.GetComponent<InteractableColorVisual>();
                InteractableColorVisual.ColorState vv2=new InteractableColorVisual.ColorState();
                vv2.Color=new Color(1f, 1f, 1f, 0.2f);
                rbp2.InjectOptionalNormalColorState(vv2);
                rbp2.enabled=false;
                rbp2.enabled=true;
            }
            if(chiudere){
                gameObject.transform.parent.gameObject.SetActive(false);
            }
    }

    public void SettaRispostePulsanti(string risposta){
        FindChildWithTag(transform,"TestoBottoniRisposta").gameObject.GetComponent<TextMeshPro>().text=risposta;
    }
}
