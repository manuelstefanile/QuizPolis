using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureDetFunction : MonoBehaviour
{
    //script che serve per forbici 
    public Kaybord scriptKeyboard;
    public Kaybord scriptTouchPad;
    //var che si setta in global. Quando arriva la domanda, puoi usare la keyboard
    public bool EnableKeyboard=false;
    //var che si setta in global. Quando arriva la domanda, puoi dare la risposta
    public bool EnableResponse=false;
    public bool EnablePugno=false;
    public bool EnableJolly=false;

    public GameObject gestureObj;
    //test pugni
    private  Gesture gestureR;
    private Gesture gestureL;
    
    
    // Start is called before the first frame update

//setto le var dello script della tastiera cosi da sapere se è sulla mano
//sx o dx

    
    void Start(){
        gestureL=gestureObj.GetComponents<Gesture>()[0];
        gestureR=gestureObj.GetComponents<Gesture>()[1];
    }




    void Update(){

        
        //se posso attivare il jolly, allora per ogni osso, controlla l osso Palmo. Se i palmi sono ad una certa distanza,
            //allora asttiva il jolly
        if(EnableJolly){
            //Debug.Log("Jolly true");
            foreach (OVRBone item in gestureR.fingerBones)
            {
            
            if(item.Id.ToString().Equals("Body_LeftHandPalm")){
                //vettore 3 dell indice
                Vector3 palmo1=gestureR.skeleton.transform.InverseTransformPoint(item.Transform.position);
                // Debug.Log(indice1 + "palmo1R");
                //prendi l indice anche nella mano L
                foreach (OVRBone item2 in gestureL.fingerBones)
                    {
                        if(item2.Id.ToString().Equals("Body_LeftHandPalm")){
                            Vector3 palmo2=gestureL.skeleton.transform.InverseTransformPoint(item.Transform.position);
                        //vettore 3 dell indice
                        //Debug.Log(indice2 + " palmo2L");
                        //Debug.Log("+ distanza palmi " +Vector3.Distance(indice1,indice2));
                        if(0.18f>Vector3.Distance(palmo1,palmo2)){
                            Jolly();
                        }
                
                        };
                    }
                };
            }
        }
                
        /*****************************************/
       
    }




public void Forbici(){
    
    if(EnableKeyboard){
            int difficoltaDomanda=GameObject.FindGameObjectWithTag("GlobalVar").GetComponent<GlobalVariabili>()
        .GetDomandaAttualmenteAttiva().GetComponent<DomandeScript>().dififcoltaDomanda;    
        //se la difficolta è 1 allora usa le scelte opzioni
        if(difficoltaDomanda==1){
            if(!scriptTouchPad.aperta){
                GameObject.Find("SoundGeneral").GetComponent<SoundGeneralScript>().AttivaTastieraApri();
                scriptTouchPad.aperta=true;
                scriptTouchPad.gameObject.SetActive(true);
            
            }else{
                GameObject.Find("SoundGeneral").GetComponent<SoundGeneralScript>().AttivaTastieraChiudi();
                scriptTouchPad.aperta=false;
                scriptTouchPad.gameObject.SetActive(false);
            
            }
        }else{
            if(!scriptKeyboard.aperta){
                GameObject.Find("SoundGeneral").GetComponent<SoundGeneralScript>().AttivaTastieraApri();
                scriptKeyboard.aperta=true;
                StartCoroutine(scriptKeyboard.ScalaGradualmente(scriptKeyboard.gameObject,new Vector3(0.4f,0.4f,0.4f),1f));
            }else{
                GameObject.Find("SoundGeneral").GetComponent<SoundGeneralScript>().AttivaTastieraChiudi();
                scriptKeyboard.aperta=false;
                StartCoroutine(scriptKeyboard.ScalaGradualmente(scriptKeyboard.gameObject,new Vector3(0f,0f,0f),1f));
            }
            
        }
        //attiva = true abilita il movimento verso la mano della tastiera. per evitare di chiamare sempre update
        //scriptKeyboard.attiva=true;
        //se la tastiera è chiusa allora aprila
   
    }
    
}



//se il gesto è ok allora conferma l input
    public void Ok(){
        if(EnableResponse)
            if(gestureL.LOk&&gestureR.ROk){
                GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>().ConfermaInputText();
            }
        
    }



    //quando chiudi entrambi i pugni applica il bonus
    public void Pugno(){
        if(EnablePugno){
            if(gestureL.LPugno&&gestureR.RPugno){
                GameObject.FindWithTag("Bonus").GetComponent<Bonus>().ApplicaBonus();
                //applica bonus
                

            }
        }
        
    }



    public void Jolly(){
        //chiama jolly solo se i palmi sono ad una certa distanza e la gesture è avvenuta
        if(EnableJolly&&gestureL.LPugno&&gestureR.RPugno){
            //attiva suono usoJolly
            GameObject.Find("SoundGeneral").GetComponent<SoundGeneralScript>().AttivaJollyUsa();
            GlobalVariabili global= GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>();

             Jolly[] oggettiConScriptA = FindObjectsOfType<Jolly>();
            
                        foreach (Jolly oggetto in oggettiConScriptA)
                        {
                            
                            if(oggetto.jollyAssegnato){
                                
                                //effetto. prendi un jolly tra quelli presenti e attivalo   
                                GameObject.FindWithTag("Effetti").GetComponent<Effetti>().JollyEffetto(oggetto.gameObject.transform.position);                           
                                Destroy(oggetto.gameObject);

                                break;
                            }                        
                    }
            //global jolly-1
            global.SubJolly();
            global.PosaCartaJollyAttivo();
            EnableJolly=false;

            //skippa domanda
        }
            
        

    }
}
