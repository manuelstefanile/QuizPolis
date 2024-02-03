using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDadi : MonoBehaviour
{
    public Camera cameraStanzaA;
    public Material displayMaterial;
    //pedina
    public GameObject follow;
    public Vector3 offsetCamera;
    

    void Start(){
        
        //oculus=GameObject.FindWithTag("Oculus");
    }

    void Update()
    {
        if(follow!=null){
            Vector3 positionTag=Vector3.zero;
            
            if(tag.Equals("SchermoDado1")){
                //position camera 1 in pedina
                positionTag=follow.transform.GetChild(1).transform.position;
                
            }else{
                ////position camera 2 in pedina
                positionTag=follow.transform.GetChild(2).transform.position;
                
            }
                
            //segui positionCamera della pedina
             Vector3 posizioneObiettivo =positionTag+offsetCamera;
            //Vector3 nuovaPosizione = Vector3.Lerp(transform.position, posizioneObiettivo, 1f * Time.deltaTime);
            transform.position = posizioneObiettivo;
            //transform.Rotate(follow.transform.eulerAngles+new Vector3(0,-90,0));
            float rotationY = follow.transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, rotationY - 90f, 0f);

            //transform.position=follow.transform.GetChild(0).transform.position+offsetCamera;
            
        }
        // Assicurati che la camera e il materiale siano assegnati
        if (cameraStanzaA != null && displayMaterial != null)
        {
            // Aggiorna la texture del materiale con l'output della camera
            displayMaterial.mainTexture = cameraStanzaA.targetTexture;
        }
    }
}
