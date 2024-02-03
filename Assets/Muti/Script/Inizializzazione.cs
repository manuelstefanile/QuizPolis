using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Inizializzazione : MonoBehaviour
{
    //pavimento per le caselle del "monopoly"
    public GameObject pavimento;
    public GameObject poliziotto;
    private int numeroDiImprevisti=0;
    
    public void InizializzaGame(int difficolta){
        //conterrà difficolta,numero di Caselle randomicho
        Queue<int> indiciCaselleDefinitive=DifficoltaRandom(difficolta);
        GameObject lastPavimento=pavimento;
        GlobalVariabili global=GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>();
        
        int difficoltaCasella=0;

        CaricaFilePerDifficolta(difficolta,global);
        
        ForCreaCaselle(difficoltaCasella,lastPavimento,global,indiciCaselleDefinitive);
        //crea le caselle imprevisto
        InizializzaImprevisto(global,numeroDiImprevisti);

        InizializzaP1(indiciCaselleDefinitive.Dequeue());
        


        
        
    }
    private void CaricaFilePerDifficolta(int difficolta,GlobalVariabili global){
        QuestionLoader loader=GameObject.FindObjectOfType<QuestionLoader>();
        switch(difficolta){
            //carica solo il file domande difficolta 1
            case 1:
                loader.GetQuestionListHard1();
                global.SetScorePerFineGioco(500);
                break;
            case 2:
            //per via della stella che aumenta la difficolta, devo caricare anche la 3Hard
                loader.GetQuestionListHard1();
                loader.GetQuestionListHardGeneral(2);
                loader.GetQuestionListHardGeneral(3);
                global.SetScorePerFineGioco(700);
                break;
            case 3:
                loader.GetQuestionListHard1();
                loader.GetQuestionListHardGeneral(2);
                loader.GetQuestionListHardGeneral(3);
                loader.GetQuestionListHardGeneral(4);
                global.SetScorePerFineGioco(800);
                break;
            case 4:
                loader.GetQuestionListHard1();
                loader.GetQuestionListHardGeneral(2);
                loader.GetQuestionListHardGeneral(3);
                loader.GetQuestionListHardGeneral(4);
                loader.GetQuestionListHardGeneral(5);
                global.SetScorePerFineGioco(1000);
                break;
            default: break;
        }
    }
    private void ForCreaCaselle(int difficoltaCasella,GameObject lastPavimento,GlobalVariabili global,Queue<int> indiciCaselleDefinitive){
        //creo le caselle in tondo.assegno il numero di casella alla var della casella.
        //mi prendo il centro della casella con bounds.center.Assegno un range di difficolta,
        //punti e tipo. Assegno alla var globale caselle il pavimento che si trova in quella posizione dell array
        //verra utilizzata poi per spostare la pedina facendo riferimento alla casella
        for(int i=2;i<12;i++){
            difficoltaCasella=indiciCaselleDefinitive.Dequeue();
            lastPavimento=CaselleIniz(new Vector3(0f,0,5f),i,lastPavimento,global,difficoltaCasella);
           
        }
        //x e -z
         for(int i=12;i<22;i++){
            difficoltaCasella=indiciCaselleDefinitive.Dequeue();
            lastPavimento=CaselleIniz(new Vector3(5f,0,0),i,lastPavimento,global,difficoltaCasella);
            //do la rotazione solo a partire dal 11 altrimenti ruoterebbe sempre le caselle
            if(i==12){
                lastPavimento.transform.Rotate(new Vector3(0,90,0));
            }
            
           
        }
         for(int i=22;i<32;i++){
            difficoltaCasella=indiciCaselleDefinitive.Dequeue();
            lastPavimento=CaselleIniz(new Vector3(0f,0,-5f),i,lastPavimento,global,difficoltaCasella);
            //polizia. distruggi il tipo della domanda
            if(i==31){
                //51.3x
                Destroy(lastPavimento.transform.GetChild(0).gameObject);
                //crea il poliziotto
                GameObject poliz=Instantiate(poliziotto,lastPavimento.transform.position,Quaternion.identity);
                Vector3 polizpos=poliz.transform.position;
                poliz.transform.position=new Vector3(51.3f,-0.32f,polizpos.z);
                //-90 90 0
                poliz.transform.Rotate(new Vector3(-90,90,0));
                global.poliziotto=poliz;
            }
            if(i==22){
                lastPavimento.transform.Rotate(new Vector3(0,90,0));
            }
           
        }
        for(int i=32;i<41;i++){
            difficoltaCasella=indiciCaselleDefinitive.Dequeue();
            lastPavimento=CaselleIniz(new Vector3(-5f,0,0),i,lastPavimento,global,difficoltaCasella);
            if(i==32){
                lastPavimento.transform.Rotate(new Vector3(0,90,0));
            }
           
        }
    }
    private Queue<int> DifficoltaRandom(int difficolta){
                Dictionary<int,float> domandePercentuali=new Dictionary<int, float>();
           //crea testo start e lo metto come primo figlio
           switch(difficolta){
            case 1:
                domandePercentuali.Add(1,40*1);
                numeroDiImprevisti=1;
            //ci saranno solo domante con 1 star e 1(no star) imprevisto
                break;
            case 2:
                domandePercentuali.Add(1,40f*0.5f);
                domandePercentuali.Add(2,40f*0.5f);
                numeroDiImprevisti=2;
            //ci saranno domande 2(50%) star e 1(50%), e 2 imprevisti
                break;
            case 3:
                domandePercentuali.Add(1,40f*0.2f);
                domandePercentuali.Add(2,40f*0.2f);
                domandePercentuali.Add(3,40f*0.6f);
                numeroDiImprevisti=6;
            //ci saranno domande 1(20%),2(20%),3(60%) star e 6 imprevisti
                break;
            case 4:
                domandePercentuali.Add(1,40f*0.1f);
                domandePercentuali.Add(2,40f*0.2f);
                domandePercentuali.Add(3,40f*0.3f);
                domandePercentuali.Add(4,40f*0.4f);
                numeroDiImprevisti=10;
            //ci saranno 1(10%),2(20%),3(30%),4(40%) star e 10 imprevisti
                break;
                
           }
        List<int> indiciCaselle = new List<int>();
        //difficolta delle caselle in modo randomico
        Queue<int> indiciCaselleDefinitive=new Queue<int>();

        //popolo la lista di interi in maniera ordinata 1,1,1,1,1,2,2,2,2,3,3,3, che mi indica la difficolta della casella in cui si trova
        foreach (KeyValuePair<int, float> coppia in domandePercentuali)
        {
            int chiave = coppia.Key;
            float valore = coppia.Value;

            for(int i=0;i<valore;i++){
                indiciCaselle.Add(chiave);
            } 
        }
        // Mescola gli indici in modo randomico cosi da avere 1,3,2,1,1,2,1,2,3,3,2,1,1,1
        indiciCaselle = indiciCaselle.OrderBy(x => UnityEngine.Random.value).ToList();
        // Aggiungi gli indici mescolati alla coda 
        foreach (int indice in indiciCaselle)
        {
            indiciCaselleDefinitive.Enqueue(indice);
        }
        return indiciCaselleDefinitive;
    }
    private void InizializzaP1(int difficolta){
        CasellaScript casella=pavimento.GetComponent<CasellaScript>();
        casella.dififcoltaDomanda=difficolta;
        casella.SetStar();
        /*******************************************/
        casella.SetNameP1Sup("verbi");
        casella.puntiDomanda=UnityEngine.Random.Range(1,11);
        /*******************************************/

        //metti il testo go sullo start
        GameObject go=new GameObject();
        go.name="P1Start";
        go.AddComponent<TextMeshPro>();
        go.transform.parent=pavimento.transform;
        go.transform.SetAsFirstSibling();

        go.transform.position=new Vector3(1.44f,0.11f,11f);
        go.transform.rotation=Quaternion.Euler(90,-90,0);
        TextMeshPro tmpgo=go.GetComponent<TextMeshPro>();
        tmpgo.text="START";
        tmpgo.fontSize=12;
        tmpgo.fontStyle=FontStyles.Bold;

        //togli tutte le stelle e lascia solo la prima
        pavimento.transform.GetChild(5).gameObject.SetActive(false);
        pavimento.transform.GetChild(6).gameObject.SetActive(false);
        pavimento.transform.GetChild(7).gameObject.SetActive(false);

    }
    //passa 1,20   2,20
    private  GameObject CaselleIniz(Vector3 posizione,int numeroCasella,GameObject lastPavimento,GlobalVariabili global,int difficoltaCasella){
        
            
            lastPavimento=Instantiate(lastPavimento,lastPavimento.transform.position+posizione,lastPavimento.transform.rotation);
            lastPavimento.name="P"+numeroCasella;
            CasellaScript casella=lastPavimento.GetComponent<CasellaScript>();
            
            casella.numCasella=numeroCasella;
            casella.direzionePedina=lastPavimento.GetComponent<Renderer>().bounds.center;
            
             casella.dififcoltaDomanda=difficoltaCasella;
            casella.puntiDomanda=UnityEngine.Random.Range(1,11);
            casella.domandaType=(CasellaScript.tipoDomanda)UnityEngine.Random.Range(0,System.Enum.GetValues(typeof(CasellaScript.tipoDomanda)).Length);

            

            Material coloreCasella=casella.ColorePerTipo(casella.domandaType);
            casella.ColoroSup(coloreCasella);

            casella.SetNameP1Sup(casella.domandaType.ToString());
            casella.SetStar();
            
            //setta il testo casella punti della casella.
            casella.FindChildWithTag(casella.transform,"TestoPuntiCasella").GetComponent<TextMeshPro>().text=casella.puntiDomanda.ToString();
            
            
            

            global.caselle[numeroCasella-1]=lastPavimento;
            return lastPavimento;
    }

    private void InizializzaImprevisto(GlobalVariabili global,int numImprevisto){
       GameObject[] caselleCreate=global.caselle;

         /*
        GameObject casellaScelta=caselleCreate[1];
                casellaScelta.GetComponent<CasellaScript>().CreaImprevisto(ImprevistiGlobalVar.tipoDomandaImprevisti.Null);
                casellaScelta.GetComponent<CasellaScript>().domandaImprevistoType=ImprevistiGlobalVar.tipoDomandaImprevisti.Add_Star;
                global.caselle[1]=casellaScelta;
                
        GameObject casellaScelta2=caselleCreate[2];
                casellaScelta2.GetComponent<CasellaScript>().CreaImprevisto(ImprevistiGlobalVar.tipoDomandaImprevisti.Null);
                casellaScelta2.GetComponent<CasellaScript>().domandaImprevistoType=ImprevistiGlobalVar.tipoDomandaImprevisti.Add_Star;
                global.caselle[2]=casellaScelta2;
        */
            

        //conterrà le caselle già diventate imprevisto
        List<int> caselleImprevisto=new List<int>();
        
        for(int i=0;i<numImprevisto;){
            int casellaRandom=UnityEngine.Random.Range(0,40);
            //escludi le caselle estreme
            if(casellaRandom==0||casellaRandom==10||casellaRandom==20||casellaRandom==30){
            }else{
                bool casellaOccupata=false;
                foreach(int caselleSelezionate in caselleImprevisto){
                    if(caselleSelezionate==casellaRandom){
                        //casellaRandom scelta è una casella già imprevisto
                        casellaOccupata=true;
                        }
                    }
                //altrimenti crea la casella imprevisto
                if(!casellaOccupata)   {
                    GameObject casellaScelta=caselleCreate[casellaRandom];
                    if(numeroDiImprevisti==1)
                    //l imprevisto che non deve capitare è star
                        casellaScelta.GetComponent<CasellaScript>().CreaImprevisto(ImprevistiGlobalVar.tipoDomandaImprevisti.Add_Star);
                    else
                        casellaScelta.GetComponent<CasellaScript>().CreaImprevisto(ImprevistiGlobalVar.tipoDomandaImprevisti.Null);
                    global.caselle[casellaRandom]=casellaScelta;
                    caselleImprevisto.Add(casellaRandom);
                    i++;
                }
            }
            
        }
        


    }
}
