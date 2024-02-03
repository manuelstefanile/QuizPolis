using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Poliziotto : ClasseGeneral
{
    public Transform PositionPoliziottoAlzato; // Riferimento all'oggetto B che si desidera seguire
    private Vector3 PositionPoliziottoSdraiato; // Riferimento all'oggetto B che si desidera seguire
    public float velocitaSeguimento = 5f; 
    private bool invoca=false;
    private bool coroutineStart=false;
    //è il canvas
    private GameObject nuvolaDialogo;
    private DialogoPoliziotto scriptNuvolaDialogo;
    
    // Start is called before the first frame update
    void Start()
    {
        PositionPoliziottoSdraiato=transform.position;
        PositionPoliziottoAlzato=GameObject.FindWithTag("PosizionePoliziotto").transform;
        nuvolaDialogo=Instantiate(GameObject.FindWithTag("NuvolaFumetto"),this.transform.position,Quaternion.identity);//,Quaternion.Euler(90,90,-180));
        nuvolaDialogo.transform.rotation=Quaternion.Euler(90,90,-180);
        nuvolaDialogo.transform.SetParent(this.transform);
        nuvolaDialogo.transform.localPosition=new Vector3(-2f,1.5f,0.45f);
        nuvolaDialogo.transform.localScale=Vector3.zero;
        
        scriptNuvolaDialogo=nuvolaDialogo.transform.GetChild(0).gameObject.GetComponent<DialogoPoliziotto>();

        nuvolaDialogo.SetActive(false);
        Destroy(GameObject.FindGameObjectsWithTag("NuvolaFumetto")[0]);
    }
    public void SetInvoca(bool valore){
        invoca=valore;
    }
    public bool GetInvoca(){
        return invoca;
    }

    public void InvocaPoliziotto(){
        //attiva usono poliziotto invocato
        GameObject.Find("SoundGeneral").GetComponent<SoundGeneralScript>().AttivaPoliziotto();
            SetInvoca(true);
            StartCoroutine(MuoviGradualmente(this.gameObject,new Vector3(45.5f,1f,1.34f),2));
            StartCoroutine(RuotaGradualmente(this.gameObject,0,90,0,2));
            //attiva la nuvola dialogo
            nuvolaDialogo.SetActive(true);

            
            scriptNuvolaDialogo.StartDialogue();

            StartCoroutine(ScalaGradualmente(nuvolaDialogo,new Vector3(0.005f,0.005f,0.005f),2));
      
    }
        public void PosaPoliziotto(){
            SetInvoca(false);
            StartCoroutine(MuoviGradualmente(this.gameObject,PositionPoliziottoSdraiato,2));
            StartCoroutine(RuotaGradualmente(this.gameObject,-90,0,90,2));
            //attiva la nuvola dialogo
            
            scriptNuvolaDialogo.SetTestoEmpty();

            
            StartCoroutine(ScalaGradualmente(nuvolaDialogo,new Vector3(0f,0f,0f),2));
            nuvolaDialogo.SetActive(false);
      
    }


    // Update is called once per frame
    void Update()
    {
        
        
    }
}
