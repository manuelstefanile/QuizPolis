using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CasellaScript : ClasseGeneral
{
  //mi dice il numero della casella
    public int numCasella;
    //mi da la direzione della pedina(dove deve andare) forse non serve
    public Vector3 direzionePedina;
    public int dififcoltaDomanda;
    public int puntiDomanda;
    public tipoDomanda domandaType;
    public Material[] colori;
    
    public GameObject star;
    private int puntiRealiNonModificati=0;
    private int difficoltaDomandaNonModificata=0;



    public bool casellaImprevisto=false;
    public ImprevistiGlobalVar.tipoDomandaImprevisti domandaImprevistoType;
    public Material materialeImprevisti;
    
    

    public enum tipoDomanda
    {
      verbi,grammatica,geografia,oggetti,animali  
    }





    
    // Start is called before the first frame update
    void Start()
    {
      //testoPuntiCasella=FindChildWithTag(this.gameObject.transform,"TestoPuntiCasella").GetComponent<TextMeshPro>();
      //Debug.Log("test " + testoPuntiCasella.text);
       
    }




    public void ColoroSup(Material colore){

       Renderer rendererFiglio = transform.GetChild(0).GetComponent<Renderer>();

      if (rendererFiglio != null) {
        rendererFiglio.material = colore;
    }
    }
    
     


    
    public void SetStar(){
      for(int i=4;i>dififcoltaDomanda;i--){
        GameObject figlio=transform.GetChild(i+2).gameObject;
        Destroy(figlio);

      }

    }




//prendi la stringa e verifica se fa parte delle categorie di domanda o di imprevisto
//e gestisci con il catch, dato che la mancata assegnazione rilancia un ArgumentException
//e assegna la string
    public void SetNameP1Sup(string nomeSup){
      GameObject text=transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject;

      string nomeSupAggiornato=NomeTitoloCasella(nomeSup);

      text.GetComponent<TextMeshPro>().text=nomeSupAggiornato;
    }





    //gli do la stringa che è uguale all enum del tipo. mi ritorna la stringa del tipo, ma in inglese
    public string NomeTitoloCasella(string nomeSup){
      string nomeSupAggiornato=String.Empty;
      try{
        tipoDomanda parsedEnum = (tipoDomanda)Enum.Parse(typeof(tipoDomanda), nomeSup);
        switch(parsedEnum){
          case tipoDomanda.verbi: nomeSupAggiornato="VERBS";
            break;
          case tipoDomanda.grammatica: nomeSupAggiornato="GRAMMAR";
            break;
          case tipoDomanda.animali: nomeSupAggiornato="ANIMALS";
            break;
          case tipoDomanda.oggetti: nomeSupAggiornato="OBJECTS";
            break;
          case tipoDomanda.geografia: nomeSupAggiornato="GEOGRAPHY";
            break;
          default:break;
        }
      }catch(ArgumentException){
        ImprevistiGlobalVar.tipoDomandaImprevisti parsedEnum = (ImprevistiGlobalVar.tipoDomandaImprevisti)Enum.Parse(typeof(ImprevistiGlobalVar.tipoDomandaImprevisti), nomeSup);
        switch(parsedEnum){
          case ImprevistiGlobalVar.tipoDomandaImprevisti.jolly: nomeSupAggiornato="JOLLY";
            break;
          case ImprevistiGlobalVar.tipoDomandaImprevisti.Add_Star: nomeSupAggiornato="STAR";
            break;
          case ImprevistiGlobalVar.tipoDomandaImprevisti.time: nomeSupAggiornato="TIME";
            break;
          default:break;
        }
      }
      return nomeSupAggiornato;
    }




    //per conoscere esattamente il nome della categoria
    public string GetNameP1Sup(){
      return transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text;
    }




    public Material ColorePerTipo(tipoDomanda tipo){
      switch(tipo){
        case tipoDomanda.verbi: return colori[0];
        case tipoDomanda.animali: return colori[1];
        case tipoDomanda.grammatica: return colori[2];
        case tipoDomanda.geografia: return colori[3];
        case tipoDomanda.oggetti: return colori[4];
        default:break;
      }
      return null;
    }
    

    // Update is called once per frame
    void Update()
    {
         
    }
    public void MoltiplicatorePunti(){
      puntiRealiNonModificati=puntiDomanda;
      puntiDomanda=puntiDomanda*2;
      SetTestoPuntiCasella(puntiDomanda.ToString());
      
    }
    public void PuntiDimezzati(){
      puntiRealiNonModificati=puntiDomanda;
      puntiDomanda=puntiDomanda/2;
      SetTestoPuntiCasella(puntiDomanda.ToString());
      
    }
    public void RipristinaPunti(){
      puntiDomanda=puntiRealiNonModificati;
      SetTestoPuntiCasella(puntiDomanda.ToString());
    }
    public void SetTestoPuntiCasella(string punti){
      FindChildWithTag(transform,"TestoPuntiCasella").GetComponent<TextMeshPro>().text=punti;
    }
    public TextMeshPro GetTextMeshPuntiCasella(){
        return FindChildWithTag(transform,"TestoPuntiCasella").GetComponent<TextMeshPro>();
    }

    public void StarUpAttiva(){
      difficoltaDomandaNonModificata=dififcoltaDomanda;
      dififcoltaDomanda++;
    }
    public void StarUpDisattiva(){
      dififcoltaDomanda=difficoltaDomandaNonModificata;
      
    }

    public GameObject CreaImprevisto(ImprevistiGlobalVar.tipoDomandaImprevisti imprevistoDaEscludere){
      casellaImprevisto=true;
      //assegno un imprevisto random, escludendo imprevistoDaEscludere e l imprevisto null
      do {
        this.domandaImprevistoType = (ImprevistiGlobalVar.tipoDomandaImprevisti)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(ImprevistiGlobalVar.tipoDomandaImprevisti)).Length);
      } while (this.domandaImprevistoType == imprevistoDaEscludere|| this.domandaImprevistoType==ImprevistiGlobalVar.tipoDomandaImprevisti.Null);
      
      //metti l efftto nuvola sopra
      GameObject.FindWithTag("Effetti").GetComponent<Effetti>().Pioggia(transform.position);

      //cambio il materiale della casella
      this.GetComponent<Renderer>().material=materialeImprevisti;
      //cambio il materialedel testo della casella
      GetTextMeshPuntiCasella().color=Color.white;

      //setto il nome dell imprevisto in p1sup e cambio il materiale di p1sup
      SetNameP1Sup(domandaImprevistoType.ToString());
      GameObject p1sup=transform.GetChild(0).gameObject;
      p1sup.GetComponent<Renderer>().material=materialeImprevisti;
      

      
      return this.gameObject;
    }
    
}
