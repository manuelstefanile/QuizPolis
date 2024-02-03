using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomandeScript : ClasseGeneral
{
    public String domanda;
    public String risposta;
    public int dififcoltaDomanda;
    public int puntiDomanda;
    public String domandaType;
    public GameObject puntoDepositoDomandeRiposste;
    public GameObject puntoDepositoImprevistiRiposte;
    private string rispostaData;

    //mi dice se è attualmente attiva e mostrata all utente
    public bool attiva=false;
    public bool imprevistoDomanda=false;
    //Boolean per l eventualita del null, ossia quando scarti la carta con il jolly
    private Boolean esitoRisposta;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void SetRispostaData(string risposta){
    rispostaData=risposta;
   }
   public string GetRispostaData(){
    return rispostaData;
   }

//verifica se la risposta è corretta e porta la carta nel deposito
    public bool VerificaRisposta(String rispostaData){
        Debug.Log("verificarisposta");
        GameObject puntoDepositoGeneral;
        //se non è un imprevisto allora
        if(!imprevistoDomanda){
            puntoDepositoGeneral=puntoDepositoDomandeRiposste;
            FindChildWithTag(transform.GetChild(1),"Bus").gameObject.SetActive(false);
            FindChildWithTag(transform.GetChild(1),"Gomma").gameObject.SetActive(false);

        //se è un imprevisto
        }else {
            puntoDepositoGeneral=puntoDepositoImprevistiRiposte;
            GetComponent<Imprevisti>().DisabilitaAnimImprevisto();
        }




        if(rispostaData.Equals(risposta)){

            StartCoroutine(MuoviGradualmente(this.gameObject,puntoDepositoGeneral.transform.position,2f));
            StartCoroutine(RuotaGradualmente(this.gameObject,0,0,0,2f));

            attiva=false;
            esitoRisposta=true;
            return true;
        }else {
            StartCoroutine(MuoviGradualmente(this.gameObject,puntoDepositoGeneral.transform.position,2f));
            StartCoroutine(RuotaGradualmente(this.gameObject,0,0,0,2f));

            attiva=false;
            esitoRisposta=false;

            return false;
        }
        //disabilita le mesh
        
        
    }

    public void DisabilitaMesh(){
        for(int i=0;i<this.transform.childCount;i++){
            GameObject filgio=this.transform.GetChild(i).gameObject;
            filgio.SetActive(false);
        }
        
    }
    public Boolean GetEsitoRisposta(){
        return esitoRisposta;
    }
}
