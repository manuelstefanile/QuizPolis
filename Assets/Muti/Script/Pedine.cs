using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class Pedine : MonoBehaviour
{
    //piano 
    public GameObject P1;
    //
    public GameObject OISR;
    private bool moveOISR=true;
    public bool pedinaGiocatore=false;
    public int casellaPosizionePedina=1;
    // Start is called before the first frame update

    
    //setto questa pedina a true cosi da identificare quella che gioca e la assegno alla var globale
    public void setPedinaGiocatoreTrue(){
        pedinaGiocatore=true;
        GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>().pedina=this.gameObject;
        //disabilita i collider dei dadi con questa pedina
        GameObject.FindWithTag("Dado1").GetComponent<IgnoreCollider>().SettaCollisionDisable();
        GameObject.FindWithTag("Dado2").GetComponent<IgnoreCollider>().SettaCollisionDisable();
        //assegna le 2 camere dadi
        GameObject.FindWithTag("SchermoDado1").GetComponent<CameraDadi>().follow=this.gameObject;
        GameObject.FindWithTag("SchermoDado2").GetComponent<CameraDadi>().follow=this.gameObject;
        //assegna il tablet alla pedina
        GameObject.FindWithTag("TabletScore").GetComponent<TabletScore>().pedinaRiferimento=this.gameObject;
        //assegna alla posizione joll
        GameObject.FindWithTag("TabletScore").GetComponent<TabletScore>().pedinaRiferimento=this.gameObject;
        DestroyAllPedineGiocatore();

        //attiva l audio iniziale
        GameObject.Find("SoundGeneral").GetComponent<SoundGeneralScript>().AttivaAllGame();

    }
    public void DestroyAllPedineGiocatore(){
        GameObject[] pedinegioc=GameObject.FindGameObjectsWithTag("Pedine");
        foreach(GameObject ped in pedinegioc){
            if(ped!=this.gameObject)
                Destroy(ped);

        }
    }
    public void PosizionaStart(){
        //apri la porta
        GameObject.Find("PortaStartGame").GetComponent<Animator>().enabled=true;
        //posiziono la pedina allo start del gioco. la ruoto e aumento lo scale.
        //rimuovo la possibilita di grabbare la pedina
        Vector3 centroP1=P1.GetComponent<Renderer>().bounds.center;
         StartCoroutine(MuoviGradualmente(this.gameObject,centroP1+new Vector3(0,1.3f,0), 3f));
         StartCoroutine(RuotaGradualmente(transform,new Quaternion(0,0,0,1), 1f));
         //ruota la mesh se non è il birillo. Perchè il birillo ha l origine sfasata :C
         StartCoroutine(RuotaGradualmente(FindChildWithTag(transform,"PedinaObj"),
            Quaternion.Euler(name.StartsWith("Birillo")?-90f:0f,name.StartsWith("Birillo")?0f:90f,0), 1f));

        StartCoroutine(ScalaGradualmente(new Vector3(10f,10f,10f),1));
        GetComponent<Grabbable>().enabled=false;
        FindFiglioPerNome(this.gameObject,"HandGrabInteractable_mirror").SetActive(false);
        FindFiglioPerNome(this.gameObject,"HandGrabInteractable").SetActive(false);
        

    }
    //trova il figlio di un oggetto per nome
    private GameObject FindFiglioPerNome(GameObject padre,String nome){        
        Transform handGrabObject = null;
        foreach (Transform child in padre.transform)
        {
            if (child.gameObject.name.Equals(nome))
            {
                handGrabObject = child;
                break;
            }
        }
        return handGrabObject.gameObject;
    }

    //muove gradualmente l oggetto fino al punto destinazione
     public IEnumerator MuoviNonGradualmente(GameObject oggSpostare,Vector3 destinazione, float durata)
    {
        //aspetta 1 secondo poi muovi
        yield return new WaitForSeconds(1);
        oggSpostare.transform.position = destinazione; // Assicura che l'oggetto sia esattamente nella destinazione finale
        GameObject.Find("SoundGeneral").GetComponent<SoundGeneralScript>().AttivaMovePedina();
        
    }

     public IEnumerator MuoviGradualmente(GameObject oggSpostare,Vector3 destinazione, float durata)
    {
        //aspetta 1 secondo poi muovi
        //yield return new WaitForSeconds(1);
        Vector3 posizioneIniziale = oggSpostare.transform.position;
        float tempoPassato = 0f;
        while (tempoPassato < durata)
        {
            oggSpostare.transform.position = Vector3.Lerp(posizioneIniziale, destinazione, tempoPassato / durata);
            tempoPassato += Time.deltaTime;
            yield return null;
        }

        oggSpostare.transform.position = destinazione; // Assicura che l'oggetto sia esattamente nella destinazione finale
        //sposto le componenti oisr nella pedina. cosi si muoveranno assieme
        if(!moveOISR&&OISR.transform.parent==null){
            OISR.transform.SetParent(this.transform);
            
        }
        if(moveOISR){
            //quando finisce di muoversi la pedina, sposta la camera sull oggetto pedina.
            StartCoroutine(MuoviGradualmente(OISR,transform.GetChild(0).transform.position, 2f));
            moveOISR=false;
        }
    }
    //ruoto l oggetto gradualmente
      public IEnumerator RuotaGradualmente(Transform riferimento,Quaternion rotazioneFinale, float durata)
    {
        Quaternion rotazioneIniziale = riferimento.transform.rotation;
        float tempoPassato = 0f;

        while (tempoPassato < durata)
        {
            riferimento.transform.rotation = Quaternion.Lerp(rotazioneIniziale, rotazioneFinale, tempoPassato / durata);
            tempoPassato += Time.deltaTime;
            yield return null;
        }

        riferimento.transform.rotation = rotazioneFinale; // Assicura che l'oggetto sia ruotato nella direzione finale
    }
    //scala la pedina
        IEnumerator ScalaGradualmente(Vector3 scalaFinale, float durata)
    {
        Vector3 scalaIniziale = transform.localScale;
        float tempoPassato = 0f;

        while (tempoPassato < durata)
        {
            transform.localScale = Vector3.Lerp(scalaIniziale, scalaFinale, tempoPassato / durata);
            tempoPassato += Time.deltaTime;
            yield return null;
        }

        transform.localScale = scalaFinale; // Assicura che l'oggetto sia alla scala finale
    }

     public Transform FindChildWithTag(Transform parent, string tag)
    {
        foreach (Transform child in parent)
        {
            if (child.CompareTag(tag))
            {
                return child; // Restituisce l'oggetto se ha il tag cercato
            }
            // Se l'oggetto corrente non ha il tag, controlla i suoi figli ricorsivamente
            Transform found = FindChildWithTag(child, tag);
            if (found != null)
            {
                return found; // Se l'oggetto è stato trovato nei figli, restituiscilo
            }
        }
        return null; // Nessun oggetto con il tag trovato
    }

    //quando prendo una pedina, le altre non devono essere prese.quindi disabilita il grab
    public void DisabilitaGrab(){
        GameObject[] oggettiPedina=GameObject.FindGameObjectsWithTag("Pedina");
        foreach(GameObject pedina in oggettiPedina){
            if(pedina.name!=this.name){
                pedina.GetComponent<Grabbable>().enabled=false;
                pedina.GetComponent<Pedine>().FindFiglioPerNome(this.gameObject,"HandGrabInteractable_mirror").SetActive(false);
                pedina.GetComponent<Pedine>().FindFiglioPerNome(this.gameObject,"HandGrabInteractable").SetActive(false);
            }

        }
    }

}
