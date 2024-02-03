using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class DadiScript : ClasseGeneral
{
    //oggetto dado generale che ha i due dadi.
    public GameObject d1;
    public GameObject d2;
    // Start is called before the first frame update
    public void AddRigidbody(){
        Rigidbody rigidd1=d1.AddComponent<Rigidbody>();
        Rigidbody rigidd2=d2.AddComponent<Rigidbody>();
        rigidd1.isKinematic=false;
        rigidd2.isKinematic=false;
        rigidd1.useGravity=true;
        rigidd2.useGravity=true;
        rigidd1.mass = 1.0f; // Imposta la massa del Rigidbody
        rigidd2.mass = 1.0f; // Imposta la massa del Rigidbody
        rigidd1.angularDrag=0;
        rigidd2.angularDrag=0;

        /**********************/
        StartCoroutine(RuotaGradualmente(d1,0,0,UnityEngine.Random.Range(-360,361),0.2f));
        StartCoroutine(RuotaGradualmente(d2,0,0,UnityEngine.Random.Range(-360,361),0.2f));
        /*********************/

        /*Vector3 forza = new Vector3(UnityEngine.Random.Range(-2,2), UnityEngine.Random.Range(-2,2), UnityEngine.Random.Range(-2,2)); // Definisce la forza da applicare (in questo caso, lungo l'asse x e z)
        Vector3 forza1 = new Vector3(UnityEngine.Random.Range(-2,2), UnityEngine.Random.Range(-2,2), UnityEngine.Random.Range(-2,2)); // Definisce la forza da applicare (in questo caso, lungo l'asse x e z)

        rigidd1.AddForce(forza, ForceMode.Impulse); // Applica una forza iniziale all'oggetto
        rigidd2.AddForce(forza1, ForceMode.Impulse); // Applica una forza iniziale all'oggetto*/
        //Destroy(GetComponent<Rigidbody>());
    }
    public void tornaVicinoMani(){
        //riabilita cioè che è stato disattivato quando si ha lanciato i dadi e spostali nella posizione
        GlobalVariabili global=GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>();
        GameObject pedina=global.pedina;
        GameObject dadiPosition=pedina.GetComponent<Pedine>().FindChildWithTag(pedina.transform,"PosizioneDadi").gameObject;
            
        //togli il rigid ai dadi
        Destroy(GameObject.FindWithTag("Dado1").GetComponent<Rigidbody>());
        Destroy(GameObject.FindWithTag("Dado2").GetComponent<Rigidbody>());
        
        //posiziono accanto alla pedina e ruoto. setto calcolofaccia a false
        StartCoroutine(MuoviGradualmente(this.gameObject,dadiPosition.transform.position,2f));
        StartCoroutine(RuotaGradualmente(d1,0,0,-90,2));
        StartCoroutine(RuotaGradualmente(d2,0,0,90,2));
        StartCoroutine(MuoviGradualmente(d1,dadiPosition.transform.position,2f));
        StartCoroutine(MuoviGradualmente(d2,dadiPosition.transform.position+new Vector3(0,0.04f,0),2f));
        d1.GetComponent<SingoloDado>().facciaCalcolata=false;
        d2.GetComponent<SingoloDado>().facciaCalcolata=false;
        //StartCoroutine(MuoviGradualmente(d2,Vector3.zero,2f));
        //StartCoroutine(MuoviGradualmente(d1,new Vector3(1,0,0),2f));
    }
   
}
