using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    public Collider[] collIgnorePlane;
    //ignoro la collisione con plane fisico
    void Start(){
        foreach(Collider col in collIgnorePlane){
            Physics.IgnoreCollision(GetComponent<Collider>(), col);
        }
        
    }
    // se un dado collide con il collider del piano ed è fermo allora calcoloa la faccia del dado.
    //con scriptdado.facciacalocolata, la calcolo solo una volta, poi viene settata a false
  private void OnTriggerStay(Collider collision)
    {

        //se i taga dei padri delle facce sono: dado1 o dado2 allora calcola la faccia
        GameObject padreCubo=collision.transform.parent.gameObject;
        String padreCubotag=collision.transform.parent.tag;
        
        if(padreCubotag.Equals("Dado1")||padreCubotag.Equals("Dado2")){
            
            

            SingoloDado scriptdado=padreCubo.GetComponent<SingoloDado>();
            if(!scriptdado.facciaCalcolata&&padreCubo.GetComponent<Rigidbody>()!=null){
                if(padreCubo.GetComponent<Rigidbody>().velocity.Equals(Vector3.zero)){
                    GameObject.Find("SoundGeneral").GetComponent<SoundGeneralScript>().AttivaDadiLancio();
                    scriptdado.CalcoloFacciaDado(collision.gameObject);
                }
                
                
                
            }
        }
    
    }

}