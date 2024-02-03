using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingoloDado : MonoBehaviour
{
    //var che serve per indicare se è stata calcolata la faccia del cubo.
    //serve in un altro script
    public bool facciaCalcolata=false;
    //i numeri sono gli oggetti del cubo che mi permettono di capire la faccia
    //fanno parte del dado 
    private GameObject[] numeriCubo;
    // Start is called before the first frame update
    void Start()
    {

        //assegno le facce del dado
        numeriCubo=new GameObject[6];
        for(int i=0;i<6;i++){
            numeriCubo[i]=transform.GetChild(i).gameObject;

        }
    }

    //trovo la faccia del dado a seconda se il gameObject(facca del dado) passato corrisponde ad una
    // delle facce del dado. se uguale setta la variabile globale dei numeri usciti sulle facce
     public void CalcoloFacciaDado(GameObject facciaPavimento){

        Debug.Log(facciaPavimento.gameObject.name);

       
        if(facciaPavimento.Equals(numeriCubo[0])){
            if(this.tag.Equals("Dado1"))
                GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>().numDado1=6;
            else
                GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>().numDado2=6;
            Debug.Log("******************6");
        }else if(facciaPavimento.Equals(numeriCubo[1])){
            if(this.tag.Equals("Dado1"))
                GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>().numDado1=5;
            else
                GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>().numDado2=5;
            Debug.Log("******************5");
        }else if(facciaPavimento.Equals(numeriCubo[2])){
            if(this.tag.Equals("Dado1"))
                GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>().numDado1=4;
            else
                GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>().numDado2=4;
            Debug.Log("******************4");
        }else if(facciaPavimento.Equals(numeriCubo[3])){
            if(this.tag.Equals("Dado1"))
                GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>().numDado1=3;
            else
                GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>().numDado2=3;
            Debug.Log("******************3");
        }else if(facciaPavimento.Equals(numeriCubo[4])){
            if(this.tag.Equals("Dado1"))
                GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>().numDado1=2;
            else
                GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>().numDado2=2;
            Debug.Log("******************2");
        }else if(facciaPavimento.Equals(numeriCubo[5])){
            if(this.tag.Equals("Dado1"))
                GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>().numDado1=1;
            else
                GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>().numDado2=1;
            Debug.Log("******************1");
        }
         facciaCalcolata=true;

    }

}
