using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{

    public GameObject toggleRiferimento;
    void Start(){
            

    }
    // Start is called before the first frame update
    public void Vittoria(Queue<GameObject> DomandeUscite,GameObject pedinaRiferimento,int scoreGiocatore){

        GameObject scroll=GameObject.Find("ScrollDomande");

        //setto il testo score
        scroll.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text="Score " + scoreGiocatore;
        //portalo vicino al giocatore
        scroll.GetComponent<Kaybord>().enabled=true;
        
        
        //setto il primo manualmente
        GameObject primaDomanda=DomandeUscite.Dequeue();
        DomandeScript domanda1=primaDomanda.GetComponent<DomandeScript>();

        toggleRiferimento.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text=domanda1.domanda;

        toggleRiferimento.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text=
            domanda1.domandaType + " "+ domanda1.dififcoltaDomanda +" \n"+ domanda1.puntiDomanda.ToString() + " Point";

        toggleRiferimento.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text=
            "Correct answere\n" +domanda1.risposta;

        toggleRiferimento.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text=
            "Answere given\n"+domanda1.GetRispostaData();
   
        SettaColoreToggle(toggleRiferimento,domanda1.GetEsitoRisposta());

        while(DomandeUscite.Count>0){
            GameObject oggettoDomanda=DomandeUscite.Dequeue();
            DomandeScript domandescript=oggettoDomanda.GetComponent<DomandeScript>();
            GameObject toggle=Instantiate(toggleRiferimento,toggleRiferimento.transform.position+new Vector3(0,0,40f),toggleRiferimento.transform.rotation);
            
            toggle.transform.SetParent(toggleRiferimento.transform.parent,false);

            toggle.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text=domandescript.domanda;
            toggle.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text=
                 domandescript.domandaType + " "+ domandescript.dififcoltaDomanda +" \n"+ domandescript.puntiDomanda.ToString() + " Point";

            toggle.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text=
                "Correct answere\n" +domandescript.risposta;

            toggle.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text=
                "Answere given\n"+domandescript.GetRispostaData();

                SettaColoreToggle(toggle,domandescript.GetEsitoRisposta());

            }

        GameObject.FindWithTag("Effetti").GetComponent<Effetti>().WinEffect(pedinaRiferimento);

    }
    
    private void SettaColoreToggle(GameObject toggle,bool esito){

        if(esito)
            toggle.GetComponent<Image>().color=Color.green;
        else if(!esito){
            toggle.GetComponent<Image>().color=Color.red;
        }else
            toggle.GetComponent<Image>().color=Color.grey;

    }
}
