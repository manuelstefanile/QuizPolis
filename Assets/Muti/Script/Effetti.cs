using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effetti : MonoBehaviour
{
    public GameObject tornado;
    public GameObject esplosione;
    public GameObject rispostaCorretta;
    public GameObject firePunti;
    public GameObject pioggiaImprevisti;
    public GameObject imprevistoJolly;

    
    [SerializeField]
    private GameObject winLuce;
    



    public Transform transformLeftHand;
    public Transform transformRighttHand;
    private bool bonusDisponibile=false;
    private GameObject effettoBonusDispL;
    private GameObject effettoBonusDispR;

    private AudioSource bonusSuonoContinuo;



    public void SetBonusDisponibile(bool valore){
        bonusDisponibile=valore;
        if(valore){
            //attivo il suono
            	bonusSuonoContinuo=GameObject.Find("SoundGeneral").GetComponent<SoundGeneralScript>().AttivaBonusContinuo();
            //creo l effetto sulle mani
            BonusDisponibileEffetto();
        }else{
            
            if(effettoBonusDispL!=null||effettoBonusDispR!=null)
            {
                GameObject.Find("SoundGeneral").GetComponent<SoundGeneralScript>().DisableAudioSourceGame(bonusSuonoContinuo);
                Destroy(effettoBonusDispL);
                Destroy(effettoBonusDispR);
            }
        }
    }
    public bool GetBonusDisponibile(){
        return bonusDisponibile;
    }
    // Start is called before the first frame update
    public void Tornado(Vector3 position,Quaternion rotazione){
        GameObject tornatoobj=Instantiate(tornado,position,rotazione);
        tornatoobj.transform.localScale=new Vector3(0.5f,0.5f,0.5f);
        StartCoroutine(WaitAndDestroy(tornatoobj));

    }
    public void RispostaCorretta(Vector3 position,Quaternion rotazione){
        
        GameObject corretta=Instantiate(rispostaCorretta,position,rotazione);
        
        //??
        ParticleSystem sistemaParticelle = corretta.GetComponent<ParticleSystem>();
        ParticleSystem.MainModule mainModule = sistemaParticelle.main;
        mainModule.startColor = new ParticleSystem.MinMaxGradient(Color.green);

        //corretta.transform.localScale=new Vector3(0.03f,0.03f,0.03f);
        StartCoroutine(WaitAndDestroy(corretta));
    }
    public void ApplicaBonus(Vector3 position,Quaternion rotazione){
        //attiva audio bonus esplosione
        GameObject.Find("SoundGeneral").GetComponent<SoundGeneralScript>().AttivaBonusUse();

        SetBonusDisponibile(false);

        GameObject expl=Instantiate(esplosione,position,rotazione);
        expl.transform.localScale=new Vector3(0.20f,0.20f,0.20f);
        StartCoroutine(WaitAndDestroy(expl));
    }

    public void ApplicaFireBonus(CasellaScript casella){
        //il penultimo figlio
        casella.gameObject.transform.GetChild(casella.gameObject.transform.childCount-2).gameObject.SetActive(true);
        //fire.transform.localScale=new Vector3(0.20f,0.20f,0.20f);
        
    }
    public void SpegniFireBonus(CasellaScript casella){
        //il penultimo figlio
        casella.gameObject.transform.GetChild(casella.gameObject.transform.childCount-2).gameObject.SetActive(false);
    }
     IEnumerator WaitAndDestroy(GameObject oggdestr)
    {
        // Attendi 3 secondi
        yield return new WaitForSeconds(3);

        // Esegui l'evento dopo l'attesa di 3 secondi
        Destroy(oggdestr);
    }

    void Start()
    {
        
    }
    //creo l effetto sulle mani
    private void BonusDisponibileEffetto(){
            effettoBonusDispL = Instantiate(rispostaCorretta);
            ParticleSystem sistemaParticelle = effettoBonusDispL.GetComponent<ParticleSystem>();
            ParticleSystem.MainModule mainModule = sistemaParticelle.main;

            // Ferma completamente il sistema di particelle
            sistemaParticelle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

            // Imposta i nuovi valori
            mainModule.startSize = 0.22f;
            mainModule.loop = true;
            mainModule.duration = 1.55f;
            mainModule.startLifetime = 2.55f;
            mainModule.startColor = new ParticleSystem.MinMaxGradient(Color.red);

        // Riavvia il sistema di particelle
            sistemaParticelle.Play();
    

        effettoBonusDispR=Instantiate(rispostaCorretta);
         ParticleSystem sistemaParticelle2 = effettoBonusDispR.GetComponent<ParticleSystem>();
        ParticleSystem.MainModule mainModule2 = sistemaParticelle2.main;

        sistemaParticelle2.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        mainModule2.startSize=0.22f;
        mainModule2.loop=true;
        mainModule2.duration=1.55f;
        mainModule2.startLifetime=2.55f;
        mainModule2.startColor = new ParticleSystem.MinMaxGradient(Color.red);

        sistemaParticelle2.Play();

        
    }
    public void Pioggia(Vector3 position){
        
        GameObject pioggiaObj=Instantiate(pioggiaImprevisti,position,Quaternion.Euler(90,0,0));
    }

    public void ApplicaVelenoPoliziotto(CasellaScript casella){
        //l ultimo figlio
        casella.gameObject.transform.GetChild(casella.gameObject.transform.childCount-1).gameObject.SetActive(true);
        //fire.transform.localScale=new Vector3(0.20f,0.20f,0.20f);
        
    }
    public void SpegniVelenoPoliziotto(CasellaScript casella){
        //l ultimo figlio
        casella.gameObject.transform.GetChild(casella.gameObject.transform.childCount-1).gameObject.SetActive(false);
    }

    public void ApplicaStarUp(CasellaScript casella){
        casella.gameObject.transform.GetChild(casella.gameObject.transform.childCount-3).gameObject.SetActive(true);
    }
    public void SpegniStarUp(CasellaScript casella){
        casella.gameObject.transform.GetChild(casella.gameObject.transform.childCount-3).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(bonusDisponibile){
            //creo l instanza se non esiste
            if(effettoBonusDispL==null&&effettoBonusDispR==null){
                //
            }else{
                //li posiziono sulle mani
                effettoBonusDispL.transform.position=transformLeftHand.transform.position;
                effettoBonusDispR.transform.position=transformRighttHand.transform.position;
            }
        }
        
    }
    public void JollyEffetto(Vector3 posizioneJollyEffetto){
        GameObject jollyEff=Instantiate(imprevistoJolly,posizioneJollyEffetto,
            Quaternion.Euler(imprevistoJolly.transform.eulerAngles));
        //attiva l effetto che segue le carta metre si deposita
        jollyEff.GetComponent<VentoLookAt>().OggettoDaSeguire(GameObject.FindWithTag("GlobalVar")
            .GetComponent<GlobalVariabili>().GetDomandaAttualmenteAttiva());
        StartCoroutine(WaitAndDestroy(jollyEff));
    }

    public void WinEffect(GameObject pedinaRiferimento){

        Instantiate(winLuce,pedinaRiferimento.transform);
    }
   
}
