using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Kaybord : ClasseGeneral
{
   public Transform PositionKeyb; // Riferimento all'oggetto B che si desidera seguire
    public float velocitaSeguimento = 5f; // Velocità di movimento per il seguimento
    

    public bool aperta=true;
    

    void Start(){
     
    }
    void Update()
    {
            
            Vector3 posizioneObiettivo = PositionKeyb.position;
            Vector3 nuovaPosizione = Vector3.Lerp(transform.position, posizioneObiettivo, velocitaSeguimento * Time.deltaTime);
            transform.position = nuovaPosizione;
            transform.rotation=PositionKeyb.transform.rotation;


        
    }
}