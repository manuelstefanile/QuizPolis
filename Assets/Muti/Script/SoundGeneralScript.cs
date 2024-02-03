using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundGeneralScript : ClasseGeneral
{

    private AudioSource AttivaAudio(string OggettoAudio,int numeroAudioSource,float volume){
        AudioSource audioSource=FindInChildren(transform,OggettoAudio).gameObject.GetComponents<AudioSource>()[numeroAudioSource];
        audioSource.volume=volume;
        if(!audioSource.isPlaying)audioSource.Play();
        return audioSource;
    }
    public void DisableAudioSourceGame(AudioSource audio){
        audio.Stop();

    }

    //durante la scelta della difficolta e delle pedine
    /********************************* è un loop, quindi da disattivare*/
    public AudioSource AttivaDifficoltaPedine(){
            return AttivaAudio("GameGeneral",0,0.01f);       
    }

    //durante tutto il gioco, dopo la scelta della pedina
    public AudioSource AttivaAllGame(){
        //disabilito l audio delle pedine e difficolta
        FindInChildren(transform,"GameGeneral").gameObject.GetComponents<AudioSource>()[0].Stop();
        //attivo audio game
        return AttivaAudio("GameGeneral",1,0.01f);     
    }

    //quando va  a finire sull'imprevisto
    public AudioSource AttivaImprevisto(){
        return AttivaAudio("Imprevisto",0,0.05f);     
    }

    //quando prendi il jolly
    public AudioSource AttivaJollyPreso(){
        return AttivaAudio("Jolly",0,0.05f);     
    }
    
    //quando usi il jolly
    public AudioSource AttivaJollyUsa(){
        return AttivaAudio("Jolly",1,0.05f);     
    }

    
    //quando vai sopra il poliziotto 
    public AudioSource AttivaPoliziotto(){
        return AttivaAudio("Poliziotto",0,0.05f);     
    }

    
    //quando perdi sul poliziotto e attivi il veleno
    public AudioSource AttivaPoliziottoVeleno(){
        return AttivaAudio("Poliziotto",1,0.05f);     
    }

    //quando prendi sulla starUp
    /********************************* è un loop, quindi da disattivare*/
    public AudioSource AttivaStarLose(){
        return AttivaAudio("Star",0,0.02f);     
    }
    
    

    
    //quando prendi i dadi(void perchè richiamato nell evento)
    public void AttivaDadiPresi(){
         AttivaAudio("Dadi",0,0.05f);     
    }
    //quando lanci i dadi
    public AudioSource AttivaDadiLancio(){
        return AttivaAudio("Dadi",1,0.05f);     
    }

    //quando muovi la pedina
    public AudioSource AttivaMovePedina(){
        return AttivaAudio("MovePedina",0,0.05f);     
    }
    //quando apri la tastiera
    public AudioSource AttivaTastieraApri(){
        return AttivaAudio("Tastiera",0,0.05f);     
    }
    //quando chiudi la tastiera
    public AudioSource AttivaTastieraChiudi(){
        return  AttivaAudio("Tastiera",1,0.05f);     
    }
    //quando la risposta + corretta
    public AudioSource AttivaRispostaCorretta(){
        return  AttivaAudio("Risposta",0,0.05f);     
    }
        //quando la risposta è sbagliata
    public AudioSource AttivaRispostaSbagliata(){
        return  AttivaAudio("Risposta",1,0.05f);     
    }
        //quando hai il bonus in mano
    public AudioSource AttivaBonusContinuo(){
        return  AttivaAudio("Bonus",0,0.05f);     
    }
        //quando usi il bonus
    public AudioSource AttivaBonusUse(){
        return  AttivaAudio("Bonus",1,0.05f);     
    }
        //quando estrai la domanda
    public AudioSource AttivaDomandaEstratta(){
        return  AttivaAudio("Domanda",0,0.05f);     
    }
        //quando superi lo start , +50pt
    public AudioSource AttivaStart50(){
        return  AttivaAudio("Start",0,0.05f);     
    }
        //quando vinci
    public AudioSource AttivaWin(){
        return AttivaAudio("Win",0,0.05f);     
    }
}
