using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Imprevisti : ClasseGeneral
{
    public ImprevistiGlobalVar.tipoDomandaImprevisti imprevistoTipo;
    //tempo per l imprevisto time
    private Timer time;
    


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Aggiorna il timer ad ogni frame
        if(time!=null){
            time.UpdateTimer();
        // Esempio: se vuoi fare qualcosa quando il tempo è scaduto
        if (time!=null&&!time.IsTimerRunning())
        {
            time.SetTimerRunning(false);
            time=null;
            // Esegui azioni quando il tempo è scaduto
            //invio l input in global
            GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>().ConfermaInputText();
            
            
            Debug.Log("Fine del gioco!");
        }
        }
        
    }
    public Timer GetTime(){
        return time;
    }
    //mi ritorna se 
   
    public void SettaImprevisto(ImprevistiGlobalVar.tipoDomandaImprevisti tipoDomandaImprevisti){
        switch(tipoDomandaImprevisti){
            //cerca in ogni figlio se esiste imprevistostartup credo
            case ImprevistiGlobalVar.tipoDomandaImprevisti.Add_Star: 
                transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
                imprevistoTipo=ImprevistiGlobalVar.tipoDomandaImprevisti.Add_Star;
                break;
            case ImprevistiGlobalVar.tipoDomandaImprevisti.time: 
                transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
                imprevistoTipo=ImprevistiGlobalVar.tipoDomandaImprevisti.time;
                //attivo il tempo
                if(time==null){
                        Debug.Log("time instanzion tempo");
                        time = new Timer(45.0f,GetTextTimer());
                        
                    }
                break;
            case ImprevistiGlobalVar.tipoDomandaImprevisti.jolly: 
                transform.GetChild(1).GetChild(4).gameObject.SetActive(true);
                imprevistoTipo=ImprevistiGlobalVar.tipoDomandaImprevisti.jolly;
                //attivo il tempo
                
                break;
            default: break;
        }

    }
    public void DisabilitaAnimImprevisto(){
        switch(imprevistoTipo){
            //cerca in ogni figlio se esiste imprevistostartup credo
            case ImprevistiGlobalVar.tipoDomandaImprevisti.Add_Star: 
                transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
                break;
            case ImprevistiGlobalVar.tipoDomandaImprevisti.time: 
                transform.GetChild(1).GetChild(3).gameObject.SetActive(false);
                break;
            case ImprevistiGlobalVar.tipoDomandaImprevisti.jolly: 
                //transform.GetChild(1).GetChild(4).gameObject.SetActive(false);
                break;
            default: break;
        }

    }
  
      public bool ChiamaFunzioneImprevisto(bool esitodomanda){
        Debug.Log("jolly chiamo funzione imprev true");
        if(esitodomanda){
            switch(imprevistoTipo){
                case ImprevistiGlobalVar.tipoDomandaImprevisti.jolly: 
                //setta il suono che hai preso il jolly
                GameObject.Find("SoundGeneral").GetComponent<SoundGeneralScript>().AttivaJollyPreso();
                //aggiungi un jolly
                    GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>().AddJolly();
                    //prendi il jolly e portalo in posizione metti nello script jollyassegnato=true
                     Jolly[] oggettiConScriptA = GameObject.FindObjectsOfType<Jolly>();
                     //prendi tutti i jolly presenti e cerca quello di riferimento dell imprevisto 
                    foreach (Jolly oggetto in oggettiConScriptA)
                    {
                        //imposta assegnato a true per portarlo nella posizioneJolly
                        if(oggetto.jollyRiferiemento){
                            oggetto.jollyAssegnato=true;
                        }
                        
                        
                    }

                        return true;    
            //cerca in ogni figlio se esiste imprevistostartup credo
                default: break;
             }
        }else{
            switch(imprevistoTipo){
            //cerca in ogni figlio se esiste imprevistostartup credo
                case ImprevistiGlobalVar.tipoDomandaImprevisti.Add_Star: 
                    
                        GameObject.FindWithTag("Bonus").GetComponent<Bonus>().SetStarUpTrue();
                        return true;
                case ImprevistiGlobalVar.tipoDomandaImprevisti.jolly: 
                        Jolly[] oggettiConScriptA = GameObject.FindObjectsOfType<Jolly>();
                     //prendi tutti i jolly presenti e cerca quello di riferimento dell imprevisto 
                        foreach (Jolly oggetto in oggettiConScriptA)
                        {
                            //imposta assegnato a true per portarlo nella posizioneJolly
                            if(oggetto.jollyRiferiemento){
                                oggetto.jollyRiferiemento=false;
                            }                        
                    }
                        return false;
                
                    

                default: break;
             }

        }
        return false;

    
        
    }
     public void SpegniFunzioneImprevisto(){
        
            switch(imprevistoTipo){
                case ImprevistiGlobalVar.tipoDomandaImprevisti.Add_Star: 
                    GameObject.FindWithTag("Bonus").GetComponent<Bonus>().SetStarUpFalse();
                    break;
                case ImprevistiGlobalVar.tipoDomandaImprevisti.time: 
                    time.SetTimerRunning(false);
                    time=null;
                    break;
            //cerca in ogni figlio se esiste imprevistostartup credo
                default: break;
             }
        
        }
//ritorna se l imprevisto di quella casella è attualmente attivo
   
    private TextMeshPro GetTextTimer(){
        
        return transform.GetChild(1).GetChild(3).GetChild(1).gameObject.GetComponent<TextMeshPro>();
    }
}
