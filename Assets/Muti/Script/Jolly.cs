using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jolly : ClasseGeneral
{
   
    private Transform positionJollyRiferimento;
    //verra aggiunta quando il giocatore scegliera la pedina
    public GameObject pedinaRiferimento;
    private GlobalVariabili global;
    public bool jollyAssegnato=false;
    public bool jollyRiferiemento=false;
    
    // Start is called before the first frame update
    void Start()
    {
        jollyRiferiemento=true;
        global=GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>();
        pedinaRiferimento=global.pedina;
        positionJollyRiferimento=pedinaRiferimento.GetComponent<Pedine>().FindChildWithTag(pedinaRiferimento.transform,"PosizioneJolly");
        
    }

    // Update is called once per frame
    void Update()
    {
        //se il jolly è assegnato al giocatore allora muovilo
       if(jollyAssegnato){ 
            //lascialo senza padre
            if(transform.parent!=null)transform.parent=null;

                transform.position=positionJollyRiferimento.transform.position;
                float rotationY = positionJollyRiferimento.transform.rotation.eulerAngles.y;
                transform.rotation = Quaternion.Euler(90f, rotationY+90f , -270f);
            //e disabilita jolly riferimento. 
            if(jollyRiferiemento)jollyRiferiemento=false;
       }
        
    }


     
     
     
    
}

