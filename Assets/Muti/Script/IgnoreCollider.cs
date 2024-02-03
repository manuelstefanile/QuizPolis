using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollider : MonoBehaviour
{
    private Collider collDaIgnorare;

    // Ignora le facce del collider della pedina. cosi i dadi non ci sbattono sopra
    public void SettaCollisionDisable()
    {
        Pedine pedinaScript=GameObject.FindGameObjectWithTag("GlobalVar").GetComponent<GlobalVariabili>().pedina.GetComponent<Pedine>();
        collDaIgnorare=pedinaScript.FindChildWithTag(pedinaScript.transform,"PedinaObj").GetComponent<Collider>();
        
        for(int i=0;i<6;i++){
            Collider collFaccia=transform.GetChild(i).gameObject.GetComponent<Collider>();
            Physics.IgnoreCollision(collDaIgnorare, collFaccia);
        }    
        Physics.IgnoreCollision(collDaIgnorare, GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
