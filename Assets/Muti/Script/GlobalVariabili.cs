using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class GlobalVariabili : ClasseGeneral
{
    public int numDado1=0;
    public int numDado2=0;
    public GameObject dadi;
    private int valoreTotaleDadi=0;
    public bool muoviPedina=false;
    //la pedina scelta
    public GameObject pedina;
    //le caselle del gioco
    public GameObject[] caselle=new GameObject[40];
    bool coroutineInEsecuzione = false;
    //se devi estrarre la domanda
    bool estraiDomanda=false;
    //dove si trovano le domande
    public GameObject Domande;
    public GameObject ImprevistoPrefab;
    //domanda mostrata all utente
    private GameObject domandaAttualmenteAttiva;
    //testo che verra poi confrontato con la risposta
    public InputField testoRisposta;
    //su quale casella si trova la pedina
    //public int casellaPedina=1;
    public GameObject keyboard;
    public GameObject touchPad;
    
    public int puntiGiocatore;
    
    public int risposteConsecutive=0;
    public GameObject poliziotto;
    private int jollyDisponibile=0;
    private int difficolta;
    private int scorePerFineGioco=0;
    //per il resoconto finale
    public Queue<GameObject> domandeUscite=new Queue<GameObject>();


    private SoundGeneralScript soundGeneral;




    
    //private int teststar=1;
    
    // Start is called before the first frame update
    void Start()
    {
        soundGeneral=GameObject.Find("SoundGeneral").GetComponent<SoundGeneralScript>();
        soundGeneral.AttivaDifficoltaPedine();
    }
        public int GetDifficolta(){
        return difficolta;
    }
    public void SetDifficolta(int diff){
        difficolta=diff;
    }
    public GameObject GetDomandaAttualmenteAttiva(){
        return domandaAttualmenteAttiva;
    }
    //chiama la coroutine per eseguire i passi uno per volta
    public void muoviPedinaDadi(bool muoviAvanti){
        //non è possibile attivare il bonus
        GameObject.FindWithTag("GestureFunction").GetComponent<GestureDetFunction>().EnablePugno=false;;
        muoviPedina = false;
        Pedine pedinaScript = pedina.GetComponent<Pedine>();
    
    // Verifica se una coroutine è già in esecuzione
        if (!coroutineInEsecuzione)
        {
            StartCoroutine(MuoviPedinaGradualmente(pedinaScript, valoreTotaleDadi,muoviAvanti));
        }
        
    }

//muove la pedina e se il numero di casella è 11,21,31,1 allora ruota la pedina
    IEnumerator MuoviPedinaGradualmente(Pedine pedinaScript, int valoreTotaleDadi,bool muoviAvanti)
    {
        coroutineInEsecuzione = true;
        if(muoviAvanti)valoreTotaleDadi++;
        for (int i = 0; i < valoreTotaleDadi; i++)
        {
            int doveAndare=0;
            int y1=0;
            int y11=0;
            int y21=0;
            int y31=0;

            //setto la rotazione della pedina in base alla direzione se avanti o indietro. e la casella dove andare
            if(muoviAvanti){
                //prendo la casella -1 dell array
                doveAndare=pedinaScript.casellaPosizionePedina-1;
                y1=360;
                y11=90;
                y21=180;
                y31=270;
            }else{
                //ddevo muovermi indietro
                doveAndare=pedinaScript.casellaPosizionePedina-2;
                y1=270;
                y11=360;
                y21=90;
                y31=180;
            }
            
            //non posso tornare piu indietro dello start. allora break
            if(doveAndare==-1){
                pedinaScript.casellaPosizionePedina=1;
                break;
            }
            Vector3 direzionePedina = caselle[doveAndare]
                .GetComponent<CasellaScript>().direzionePedina+new Vector3(0,pedina.transform.position.y,0);

                

                int numCasella=caselle[doveAndare].GetComponent<CasellaScript>().numCasella;

                //se è il primo lancio e la pedina si trova sui punti estremi allora  ruota quando vai indietro di -90 cosi da raddrizzare
                //la pedina
                bool caselleBackRuota=false;
                //se sto tornando indietro e capito nei punti estremi allora ruota
                if(!muoviAvanti&&(numCasella==10||numCasella==20||numCasella==30||numCasella==40)){
                    
                    y1-=90;
                    y11-=90;
                    y21-=90;
                    y31-=90;
                    caselleBackRuota=true;
                }
                //muovi la pedina
                yield return StartCoroutine(pedinaScript.MuoviNonGradualmente(pedina, direzionePedina, 0.8f));
                //ruota la pedina se mi trovo in queste situazioni.
                
                if(i==0&&caselleBackRuota){
                    Debug.Log("!BACKparto dagli spigoli ");
                    //metto il + 1 per far ruotare nella funzione , dato che tornando indietro prendo come 
                    //punto di riferimento la casella precedente
                    RuotaInBaseAllaCasella(pedinaScript,numCasella+1,y1,y11+90,y21+90,y31+90,muoviAvanti);
                }
                else if(i==(valoreTotaleDadi-1)&&(numCasella==11||numCasella==21||numCasella==31)&&!muoviAvanti){
                    Debug.Log("!BACKfinisco negli spigoli ");
                    //RuotaInBaseAllaCasella(pedinaScript,numCasella,y1,y11,y21,y31,muoviAvanti);
                }
                else{
                    
                    RuotaInBaseAllaCasella(pedinaScript,numCasella,y1,y11,y21,y31,muoviAvanti);
                }
                    
                caselleBackRuota=false;
                if(muoviAvanti){

                    //quando passi sullo start, per mezzo del lancio dei dadi
                    if(i!=0&&numCasella==1&&valoreTotaleDadi!=0){
                        //aggiungi 50 punti allo score
                        puntiGiocatore+=50;
                        soundGeneral.AttivaStart50();
                        Debug.Log("---+50pt");
                        
                    }

                    //aumenta di 1 modulo 
                    pedinaScript.casellaPosizionePedina++;
                    if(pedinaScript.casellaPosizionePedina==41){
                        pedinaScript.casellaPosizionePedina=1;
                        
                        
                    }
                    
                }else{
                     pedinaScript.casellaPosizionePedina--;
                }

                if(i==valoreTotaleDadi-1)pedinaScript.casellaPosizionePedina=numCasella;
                
            //suono pedina che si muove
            
        }
        //la pedina è ferma nella nuova posizione e se si trova nella pos 11,21,31,1 allora ruota
        
        
        coroutineInEsecuzione = false;
        
         
         //se vado avanti e capito nella casella poliziotto
        if(muoviAvanti&&pedinaScript.casellaPosizionePedina==31){
            
            estraiDomanda=false;
            //prendo la domanda e disabilito la mesh. poi sulla nuvoletta scrivo il la domanda
            estraiDomandaFunz();
            DomandeScript domandescript=domandaAttualmenteAttiva.GetComponent<DomandeScript>();
            
            
            FindChildWithTag(poliziotto.transform,"NuvolaFumetto").GetChild(0).GetComponent<DialogoPoliziotto>().domanda=domandescript.domanda;
            domandescript.DisabilitaMesh();
            poliziotto.GetComponent<Poliziotto>().InvocaPoliziotto();

            //se vado avanti e non vado nel poliziotto
        }else if(muoviAvanti&&pedinaScript.casellaPosizionePedina!=31){
            estraiDomanda=true;

        } 
        //se vado indietro
        if(!muoviAvanti){
            SettaStartDadi();
            estraiDomanda=false;

            //quando vai sopra il poliziotto
        }
        
            
        
        
    }
    private void RuotaInBaseAllaCasella(Pedine pedinaScript,int numCasella,int y1,int y11,int y21,int y31,bool muoviAvanti){
        
                if(numCasella==11){
                    pedinaScript.transform.rotation=Quaternion.Euler(0,y11,0);
                    
                }else if(numCasella==21){
                    pedinaScript.transform.rotation=Quaternion.Euler(0,y21,0);
                    
                }else if(numCasella==31){
                    pedinaScript.transform.rotation=Quaternion.Euler(0,y31,0);
                    
                    //questo per evitare di ruotare la pedina quando torna all indietro nella casella 1
                }else if(numCasella==1&&muoviAvanti){
                    pedinaScript.transform.rotation=Quaternion.Euler(0,y1,0);
                    //StartCoroutine(pedinaScript.RuotaGradualmente(Quaternion.Euler(0,y1,0),2f));
                }
    }

    // Update is called once per frame
    void Update()
    {
        //test
        
        //se sono stati assegnati i valori ai dadi allora muovi la pedina del valore
        if(numDado1!=0&&numDado2!=0){
            Pedine pedinescript= pedina.GetComponent<Pedine>();
            /*******************************************************************************************/
           valoreTotaleDadi=numDado1+numDado2;

            //aggiorna a schermo il valore dei dadi


            //test star , poi un altro imprev***********************************
            //valoreTotaleDadi=teststar;
            /********************************************************************/

            //test poliziotto
            //valoreTotaleDadi=30;

            //test rotazione
            //valoreTotaleDadi=10;

            //test 50 + start
            //valoreTotaleDadi=1;

            //test imprevisto
            //valoreTotaleDadi=teststar;
            GameObject.FindWithTag("TabletScore").GetComponent<TabletScore>().AggiornaTestoDadi(valoreTotaleDadi.ToString());
            muoviPedina=true;
            numDado1=0;
            numDado2=0;
        }
        if(muoviPedina){
            muoviPedinaDadi(true);
            /************************************************************/
            //teststar=22;
            /************************************************************/
        }
        //se è il momento di estrarre la domanda
        if(estraiDomanda){
        //se hai raggiunto i punti per superare il gioco allora non pescare la domanda e finisci il gioco
            if(!CheckFineGioco()){
                estraiDomandaFunz();
                estraiDomanda=false;
            }estraiDomanda=false;
            
        }
    }


    private void estraiDomandaFunz(){

        //attiva suono 
        soundGeneral.AttivaDomandaEstratta();
        //prendo la difficolta,tipo,punti dalla casella.
        Pedine pedineScript= pedina.GetComponent<Pedine>();
        CasellaScript casellaPosPedina=caselle[pedineScript.casellaPosizionePedina-1].GetComponent<CasellaScript>();

        GameObject domanda;
         DomandeScript domandaScript;

        //se la casella è un imprevisto allora crea un imprevisto
        if(casellaPosPedina.casellaImprevisto){

            //attiva suono
            soundGeneral.AttivaImprevisto();

            domanda=Instantiate(ImprevistoPrefab,ImprevistoPrefab.transform.position,transform.rotation);
            Imprevisti imprevistiScript=domanda.GetComponent<Imprevisti>();
            domandaScript=domanda.GetComponent<DomandeScript>();
            domandaScript.imprevistoDomanda=true;
            //cosi ottengo la striga esatta della categoria
            domandaScript.domandaType=casellaPosPedina.NomeTitoloCasella(casellaPosPedina.domandaType.ToString());
            //configuro la carta imprevisto
            imprevistiScript.SettaImprevisto(casellaPosPedina.domandaImprevistoType);
        }else{
                //creo la carta domanda fisica e assegno la domanda,risposta,difficolta,punti,tipo
            domanda=Instantiate(Domande,Domande.transform.position,transform.rotation);
            domandaScript=domanda.GetComponent<DomandeScript>();
            FindChildWithTag(domanda.transform,"Bus").gameObject.GetComponent<Animator>().enabled=true;
            FindChildWithTag(domanda.transform,"Gomma").gameObject.GetComponent<Animator>().enabled=true;
            domandaScript.domandaType=casellaPosPedina.NomeTitoloCasella(casellaPosPedina.domandaType.ToString());
        }

            //settaDomanda , risposte ed eventualmente suggerimenti per 1 star*******************************+++
            

            TextMeshPro domandatext=domanda.transform.GetChild(0).GetComponent<TextMeshPro>();
            domandaScript.attiva=true;
           // domandaScript.domanda="how many fingers do you have?";
            //domandaScript.risposta="a";
            domandaScript.dififcoltaDomanda=casellaPosPedina.dififcoltaDomanda;
            domandaScript.puntiDomanda=casellaPosPedina.puntiDomanda;
            /***********************************************************************************/

            SettaDomandaApparsa(domandaScript,casellaPosPedina);
            domandatext.text=domandaScript.domanda;

            domandaAttualmenteAttiva=domanda;

            

            

        

        
        //muovi la domanda dove sta il giocatore e ruota nella maniera adeguata
        Vector3 eule=pedina.GetComponent<Pedine>().transform.rotation.eulerAngles;
        
        int numCasella=caselle[pedineScript.casellaPosizionePedina-1].GetComponent<CasellaScript>().numCasella;
        GameObject oculus=pedineScript.FindChildWithTag(pedina.transform,"Oculus").gameObject;
        domandaScript.muoviGradualmentebool=true;
        if(numCasella>=11&&numCasella<21){
                    
                    StartCoroutine(domandaScript.RuotaGradualmente(domanda,eule.x-90,90,0,2f));
                    StartCoroutine(domandaScript.MuoviGradualmente(domanda,oculus.transform.position+new Vector3(4f,0,0),2f));
        }else if(numCasella>=21&&numCasella<31){
                    StartCoroutine(domandaScript.MuoviGradualmente(domanda,oculus.transform.position+new Vector3(0f,0,-4f),2f));
                    StartCoroutine(domandaScript.RuotaGradualmente(domanda,eule.x-90,180,0,2f));

        }else if(numCasella>=31&&numCasella<41){
                StartCoroutine(domandaScript.MuoviGradualmente(domanda,oculus.transform.position+new Vector3(-4f,0,0),2f));    
                StartCoroutine(domandaScript.RuotaGradualmente(domanda,eule.x-90,270,0,2f));
                
        }else if(numCasella>=1&&numCasella<11){
                StartCoroutine(domandaScript.MuoviGradualmente(domanda,oculus.transform.position+new Vector3(0,0,4f),2f));
                StartCoroutine(domandaScript.RuotaGradualmente(domanda,eule.x-90,0,0,2f));
        }
        GestureDetFunction funzioniGesture=GameObject.FindWithTag("GestureFunction").GetComponent<GestureDetFunction>();

        //quando la domanda è arriavata a destinazione allora abilita le tastiere e la risposta
        StartCoroutine(AttesaPosDomandeEAbilitaKeyb(funzioniGesture)) ;   
        //se ho il jolly, posso usarlo
        if(jollyDisponibile>0){
            
            funzioniGesture.EnableJolly=true;
        }else funzioniGesture.EnableJolly=false;

        

        

        
    }
    public void SettaDomandaApparsa(DomandeScript domandaScript,CasellaScript casellascript){
        QuestionLoader loader=GameObject.FindObjectOfType<QuestionLoader>();
        switch(casellascript.dififcoltaDomanda){
            case 1:
                QuestionDataHard1 qdh1=(QuestionDataHard1)loader.GetQuestionListHard1().GetQuestionForType(casellascript.domandaType);
                domandaScript.domanda=qdh1.question;
                domandaScript.risposta=qdh1.answer.ToLower();
                //modifica le lettere sui tastini. cerca i figli e modifica il testo dei figli
                touchPad.transform.GetChild(0).gameObject.GetComponent<HoverButtonsInteract>().SettaRispostePulsanti(qdh1.A);
                touchPad.transform.GetChild(1).gameObject.GetComponent<HoverButtonsInteract>().SettaRispostePulsanti(qdh1.B);
                touchPad.transform.GetChild(2).gameObject.GetComponent<HoverButtonsInteract>().SettaRispostePulsanti(qdh1.C);
                touchPad.transform.GetChild(3).gameObject.GetComponent<HoverButtonsInteract>().SettaRispostePulsanti(qdh1.D);
                break;
            case 2:
                QuestionDataHardGeneral general2=(QuestionDataHardGeneral)loader.GetQuestionListHardGeneral(2).GetQuestionForType(casellascript.domandaType);
                domandaScript.domanda=general2.question;
                domandaScript.risposta=general2.answer.ToLower(); 
                break;
            case 3:
                QuestionDataHardGeneral general3=(QuestionDataHardGeneral)loader.GetQuestionListHardGeneral(3).GetQuestionForType(casellascript.domandaType);
                domandaScript.domanda=general3.question;
                domandaScript.risposta=general3.answer.ToLower(); 
                break;
            case 4:
                QuestionDataHardGeneral general4=(QuestionDataHardGeneral)loader.GetQuestionListHardGeneral(4).GetQuestionForType(casellascript.domandaType);
                domandaScript.domanda=general4.question;
                domandaScript.risposta=general4.answer.ToLower(); 
                break;
            case 5:
                QuestionDataHardGeneral general5=(QuestionDataHardGeneral)loader.GetQuestionListHardGeneral(5).GetQuestionForType(casellascript.domandaType);
                domandaScript.domanda=general5.question;
                domandaScript.risposta=general5.answer.ToLower(); 
                break;
        }
    }
     public IEnumerator AttesaPosDomandeEAbilitaKeyb(GestureDetFunction funzionigesture)
    {
       
        
        yield return new WaitForSeconds(2f);
        funzionigesture.EnableKeyboard=true;
        funzionigesture.EnableResponse=true;
    }
    public void ConfermaInputText(){
        
        
        DomandeScript domandascript=domandaAttualmenteAttiva.GetComponent<DomandeScript>();

        ChiudiTastiere();
        
        //disabilita attiva dalla tastiera per evitare l update costante della posizione verso la mano
        
        //segnalo che la tastiera è chiusa
       


        Bonus bonusscript=GameObject.FindWithTag("Bonus").GetComponent<Bonus>();
        //se ho un bonus attivo, allora spegnilo. 
        //se sono nell imprevisto tempo allora spegnilo
        if(bonusscript.GetStarUp()){
            
           // domandaAttualmenteAttiva.GetComponent<Imprevisti>().SpegniFunzioneImprevisto();
           GameObject.FindWithTag("Bonus").GetComponent<Bonus>().SetStarUpFalse();
        }
        if(domandascript.imprevistoDomanda){
            if(domandaAttualmenteAttiva.GetComponent<Imprevisti>().GetTime()!=null){
                domandaAttualmenteAttiva.GetComponent<Imprevisti>().SpegniFunzioneImprevisto();
            }
        }
        //verifica la risposta senza spazi iniziali e finali e tutto in minuscolo
        bool esitoRisposta=domandascript.VerificaRisposta(testoRisposta.text.Trim().ToLower());
        //disattiva le animazioni
        if(!domandascript.imprevistoDomanda){
            FindChildWithTag(domandaAttualmenteAttiva.transform,"Bus").gameObject.GetComponent<Animator>().enabled=false;
            FindChildWithTag(domandaAttualmenteAttiva.transform,"Gomma").gameObject.GetComponent<Animator>().enabled=false;
        
        }
        
        Effetti effettiScript=GameObject.FindWithTag("Effetti").GetComponent<Effetti>();
        bool poliziottoVeleno=false;
        
        //perchè dura 1 turno , quindi quando dai l ok si chiude l effetto
        
        //se esatta allora guadagna i punti
        if(esitoRisposta){
            //attiva suono risposta corretta
            soundGeneral.AttivaRispostaCorretta();
            risposteConsecutive++;
            int puntiDomanda=domandascript.puntiDomanda;
            puntiGiocatore+=puntiDomanda;

            Transform posizioneHandL=GameObject.FindWithTag("LeftHand").transform;
            Transform posizioneHandR=GameObject.FindWithTag("RightHand").transform;
            effettiScript.RispostaCorretta(posizioneHandL.position,Quaternion.Euler(0,0,0));
            effettiScript.RispostaCorretta(posizioneHandR.position,Quaternion.Euler(0,0,0));
            //per l effetto del fuoco sulle mani se l effetto non è gia stato applicato
            if(risposteConsecutive>=2&&!effettiScript.GetBonusDisponibile()){
                effettiScript.SetBonusDisponibile(true);
            }


            //se hai risposto bene ad una domanda imprevisto allora attiva
            if(domandascript.imprevistoDomanda&&domandaAttualmenteAttiva.GetComponent<Imprevisti>().GetTime()==null){
                domandaAttualmenteAttiva.GetComponent<Imprevisti>().ChiamaFunzioneImprevisto(true);
            }

            //se ha risposto correttamente al poliziotto la var =false
            poliziottoVeleno=ControlloPoliziottoEPosa(esitoRisposta);

                    //setto la risposta
                domandascript.SetRispostaData(testoRisposta.text);
                //aggiungila alle domande uscite
                domandeUscite.Enqueue(domandaAttualmenteAttiva);

            //se non hai ancora vinto allora porta i dadi a te
            if(!CheckFineGioco()){
                SettaStartDadi();
            };
            
        }else{
            soundGeneral.AttivaRispostaSbagliata();
            //disabilita il fuoco sulle mani
            effettiScript.SetBonusDisponibile(false);
            poliziottoVeleno=ControlloPoliziottoEPosa(esitoRisposta);
            risposteConsecutive=0;
            effettiScript.Tornado(pedina.transform.position,Quaternion.Euler(-90,0,0));
            //torna indietro del # caselle sul cubo.

                    //setto la risposta
                domandascript.SetRispostaData(testoRisposta.text);
                //aggiungila alle domande uscite
                domandeUscite.Enqueue(domandaAttualmenteAttiva);
                 
            
           
            if(domandascript.imprevistoDomanda){
                //mi dice se ho attivato o meno l imprevisto
                domandaAttualmenteAttiva.GetComponent<Imprevisti>().ChiamaFunzioneImprevisto(false);
            }
            // creo un delegate con action<bool> da passare come parametro alla funzione puovipedinadadi(false)
            //Action<bool, int, float> metodoMuoviPedinaDadi = new Action<bool, int, float>(MuoviPedinaDadi); un esempio
             Delegate metodoMuoviPedinaDadi = new Action<bool>(muoviPedinaDadi);
            StartCoroutine(WaitSecond(1f, metodoMuoviPedinaDadi, false));

            //setto i dadi alla fine del movimento all indietro, quindi dentro la coroutine
            //muoviPedinaDadi(false);
        }

        //se c è il bonus attivo, allora disattivalo. Dimezzera anche i punti raddoppiati
        
        if(bonusscript.GetBonus()){
            
            bonusscript.SetBonusFalse();
        }

        if(bonusscript.GetDebuff()){
            
            bonusscript.SetDebuffFalse();
        }
        if(poliziottoVeleno){
            bonusscript.SetDebuffTrue();
        }
        

        
        //setta la risposta a nulla
        testoRisposta.text=String.Empty;

        
        
    
        
        
    }

    public void PosaCartaJollyAttivo(){
        //mi porta la domanda a posto
        
        domandaAttualmenteAttiva.GetComponent<DomandeScript>().VerificaRisposta("");
        SettaStartDadi();
        ChiudiTastiere();
        //chiudi anche le tastiere
    }
    public void ChiudiTastiere(){
        //suono chiusura tastiera
        soundGeneral.AttivaTastieraChiudi();
        Kaybord scriptTastiera=keyboard.GetComponent<Kaybord>();
        //togli la possibilita di invocare la tastiera e di inviare la risposta
        GestureDetFunction funzioniGesture=GameObject.FindWithTag("GestureFunction").GetComponent<GestureDetFunction>();
        funzioniGesture.EnableKeyboard=false;
        funzioniGesture.EnableResponse=false;

         if(scriptTastiera.aperta){
            scriptTastiera.aperta=false;
            //chiudi la tastiera
            StartCoroutine(scriptTastiera.ScalaGradualmente(keyboard,Vector3.zero,1.2f));
        }

        //se il touchpad è aperto
        Kaybord scriptTouchPad=touchPad.GetComponent<Kaybord>();
        if(scriptTouchPad.aperta){
            scriptTouchPad.aperta=false;
            //ripristina i colori del pad e chiudilo
            touchPad.transform.GetChild(0).GetComponent<HoverButtonsInteract>().ResettaColorStartAll(true);
            //chiudi la tastiera
            //scriptTouchPad.gameObject.SetActive(false);
            
        }
    }

    //porta i dadi vicino al giocatore
    private void SettaStartDadi(){
        dadi.GetComponent<DadiScript>().tornaVicinoMani();
        //abilita la possibilita di attivare il bonus prima del lancio del dado
        GameObject.FindWithTag("GestureFunction").GetComponent<GestureDetFunction>().EnablePugno=true;;
        //setta a schermo dadi=0;
        GameObject.FindWithTag("TabletScore").GetComponent<TabletScore>().AggiornaTestoDadi("0");

    }

    private bool ControlloPoliziottoEPosa(bool esitoRisposta){
            if(poliziotto.GetComponent<Poliziotto>().GetInvoca()){
                //non ho risposto bene al poliziotto
                if(!esitoRisposta){
                    poliziotto.GetComponent<Poliziotto>().PosaPoliziotto();
                    return true;
                }
                poliziotto.GetComponent<Poliziotto>().PosaPoliziotto();
            }
            return false;
    }

    public void AddJolly(){
        jollyDisponibile++;
    }
    public void SubJolly(){
        jollyDisponibile--;
    }
    public int GetJolly(){
        return jollyDisponibile;
    }
    private bool CheckFineGioco(){
        if(puntiGiocatore>=scorePerFineGioco){
            soundGeneral.AttivaWin();
            GetComponent<Victory>().Vittoria(domandeUscite,pedina,puntiGiocatore);
            return true;
        }else return false;
    }
    public void SetScorePerFineGioco(int scorefine){
        scorePerFineGioco=scorefine;
    }






}
