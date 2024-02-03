using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private bool bonus=false;
    private bool debuff=false;
    private bool starUp=false;
    private AudioSource starSound;
    public void SetBonusTrue(){
        bonus=true;
        //applica il bonus alle caselle
        GlobalVariabili global=GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>();
        Effetti effetti=GameObject.FindWithTag("Effetti").GetComponent<Effetti>();
        GameObject[] caselle=global.caselle;
            foreach(GameObject casobj in caselle){
                CasellaScript casellaScript= casobj.GetComponent<CasellaScript>();
                //applica il fuoco sui numeri punteggio delle caselle
                effetti.ApplicaFireBonus(casellaScript);
                //moltiplica il punteggio
                casellaScript.MoltiplicatorePunti();
            }
    }
    public void SetBonusFalse(){
        bonus=false;
        //applica il bonus alle caselle
        //applica il bonus alle caselle
        GlobalVariabili global=GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>();
        GameObject[] caselle=global.caselle;
        Effetti effetti=GameObject.FindWithTag("Effetti").GetComponent<Effetti>();
            foreach(GameObject casobj in caselle){
                CasellaScript casellaScript= casobj.GetComponent<CasellaScript>();
                casellaScript.RipristinaPunti();
                effetti.SpegniFireBonus(casellaScript);
            }
    }
    public bool GetBonus(){
        return bonus;
    }
    // Start is called before the first frame update
    public void ApplicaBonus(){
        GlobalVariabili global=GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>();
        int rispostecons=global.risposteConsecutive;
        if(rispostecons>=2&&!bonus){
            global.risposteConsecutive=0;

            SetBonusTrue();

            //fai qualcosa con gli effetti e moltiplicatore X2;
            Effetti effetti=GameObject.FindWithTag("Effetti").GetComponent<Effetti>();
            Transform posizioneExplL=GameObject.FindWithTag("LeftHand").transform;
            Transform posizioneExplR=GameObject.FindWithTag("RightHand").transform;
            effetti.ApplicaBonus(posizioneExplL.position,posizioneExplL.rotation);
            effetti.ApplicaBonus(posizioneExplR.position,posizioneExplR.rotation);
            
            
        }
    }


    //debuff
    public void SetDebuffTrue(){
        Debug.Log("setdebuf true");
        //audio poliziottodebuff
        GameObject.Find("SoundGeneral").GetComponent<SoundGeneralScript>().AttivaPoliziottoVeleno();
        debuff=true;
        //applica il bonus alle caselle
        GlobalVariabili global=GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>();
        Effetti effetti=GameObject.FindWithTag("Effetti").GetComponent<Effetti>();
        GameObject[] caselle=global.caselle;
            foreach(GameObject casobj in caselle){
                CasellaScript casellaScript= casobj.GetComponent<CasellaScript>();
                //applica il fuoco sui numeri punteggio delle caselle
                effetti.ApplicaVelenoPoliziotto(casellaScript);
                //moltiplica il punteggio
                casellaScript.PuntiDimezzati();
            }
    }
    public void SetDebuffFalse(){
        debuff=false;
        //applica il bonus alle caselle
        //applica il bonus alle caselle
        GlobalVariabili global=GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>();
        GameObject[] caselle=global.caselle;
        Effetti effetti=GameObject.FindWithTag("Effetti").GetComponent<Effetti>();
            foreach(GameObject casobj in caselle){
                CasellaScript casellaScript= casobj.GetComponent<CasellaScript>();
                casellaScript.RipristinaPunti();
                effetti.SpegniVelenoPoliziotto(casellaScript);
            }
    }
    public bool GetDebuff(){
        return debuff;
    }

     public void SetStarUpTrue(){
        //attiva suono star
        starSound=GameObject.Find("SoundGeneral").GetComponent<SoundGeneralScript>().AttivaStarLose();
        starUp=true;
        //applica il bonus alle caselle
        GlobalVariabili global=GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>();
        Effetti effetti=GameObject.FindWithTag("Effetti").GetComponent<Effetti>();
        GameObject[] caselle=global.caselle;
            foreach(GameObject casobj in caselle){
                CasellaScript casellaScript= casobj.GetComponent<CasellaScript>();
                //applica il fuoco sui numeri punteggio delle caselle
                effetti.ApplicaStarUp(casellaScript);
                //moltiplica il punteggio
                casellaScript.StarUpAttiva();
            }
    }
        public void SetStarUpFalse(){
        GameObject.Find("SoundGeneral").GetComponent<SoundGeneralScript>().DisableAudioSourceGame(starSound);
        starUp=false;
        //applica il bonus alle caselle
        //applica il bonus alle caselle
        GlobalVariabili global=GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>();
        GameObject[] caselle=global.caselle;
        Effetti effetti=GameObject.FindWithTag("Effetti").GetComponent<Effetti>();
            foreach(GameObject casobj in caselle){
                CasellaScript casellaScript= casobj.GetComponent<CasellaScript>();
                 //applica il fuoco sui numeri punteggio delle caselle
                effetti.SpegniStarUp(casellaScript);
                //moltiplica il punteggio
                casellaScript.StarUpDisattiva();
            }
    }
    public bool GetStarUp(){
        return starUp;
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
