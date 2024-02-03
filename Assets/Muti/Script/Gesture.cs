using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

//struttura che memorizza i dati delle ossa
[System.Serializable]
public struct GestureStruct{
    public string name;
    public List<Vector3> fingersData;

    //per chiamare un certo evento quando la gesture è effettuata
    public UnityEvent onRecognized;
}
public class Gesture : MonoBehaviour
{
    //riferimento alle dita
    public OVRSkeleton skeleton;
    public List<GestureStruct> gestures;
    public List<OVRBone> fingerBones;
    public bool debugMode;
    private bool firstAssign=false;
    //soglia ammissibile. se supera allora scarto la gesture
    public float threshold=0.1f;

    //per evitare di chiamare sempre la stessa gesture quando è immobile.
    private GestureStruct previusGesture;

    public bool manoLeftbool;
    
    public bool LPugno=false;
    public bool RPugno=false;


    public bool LOk=false;
    public bool ROk=false;



    // Start is called before the first frame update
    void Start()
    {
        //assegno tutte le ossa della mano
        fingerBones = new List<OVRBone>(skeleton.Bones);
        if(fingerBones.Count>0){
            firstAssign=true;
        }
        previusGesture=new GestureStruct();
    }

    // Update is called once per frame
    void Update()
    {

        
         if(!firstAssign){
            
            fingerBones = new List<OVRBone>(skeleton.Bones);
            if(fingerBones.Count>0)firstAssign=true;
         }
        if(firstAssign && debugMode && Input.GetKeyDown(KeyCode.Space)){
            Save();
        }
        GestureStruct currentGesture = Recognize();

        //se il gesto corrente è il pugno. se è la mano sx allora setta la var a true analogo per dx
        //altrimenti setta la var dei rispettivi pugni a false
        
        //se è stata riconosciuta una forma è true else currentGesture è null e quindi 
        //hasrecognized è false
        bool hasRecognized=!currentGesture.Equals(new GestureStruct());

        //serve per i pugni e per segnalare che una mano è chiusa alla GestureFunction cosi da attivare
        //la funz se necessario
        /*if(hasRecognized&&currentGesture.name.Equals("Pugno")){
            //Debug.Log("Pugno " + manoLeftbool);
            if(manoLeftbool)
                LPugno=true;
            else RPugno=true;
        }else{
            if(manoLeftbool)
                LPugno=false;
            else RPugno=false;
        }*/
        SetVarDoubleHand(hasRecognized,currentGesture,"Pugno",manoLeftbool,ref LPugno,ref RPugno);
        SetVarDoubleHand(hasRecognized,currentGesture,"ok",manoLeftbool,ref LOk,ref ROk);
        

        //serve per dare la possibilita di ripetere consecutivamente la stessa gesture
        //senza pero riconoscerla se sta in loop
        if(!hasRecognized){
            previusGesture=new GestureStruct();
        }

        //check la nuova gesture che non deve essere uguale alla vechcia gesture
        //altrimenti si va in loop quando si è fermi su una posa
        if(firstAssign && hasRecognized && !currentGesture.Equals(previusGesture)){            
            previusGesture=currentGesture;
            try{currentGesture.onRecognized.Invoke();}catch(Exception){}
        }
    }
    //passo per riferimento e non per copia
    private void SetVarDoubleHand(bool hasrecognized, GestureStruct currendgesture,string gestoDaRiconoscere,bool manoLbool,ref bool LGest, ref bool Rgest){
        if(hasrecognized&&currendgesture.name.Equals(gestoDaRiconoscere)){
            //Debug.Log("Pugno " + manoLeftbool);
            if(manoLbool)
                LGest=true;
            else Rgest=true;
        }else{
            if(manoLbool)
                LGest=false;
            else Rgest=false;
        }
    }
    void Save(){
        //creo la struttura per salvare i dati delle ossa
        GestureStruct g= new GestureStruct();
        g.name="new Gesture";
        List<Vector3> data=new List<Vector3>();
        Debug.Log("------------------------------------------s");
        foreach (var bone in fingerBones)
        {
            Debug.Log("********************s");
            //salva in data le posizioni delle ossa. Tutte
            data.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
        }

        //salvo nella struttura 
        g.fingersData=data;
        gestures.Add(g);
    }
    //riconosci il gesto piu o meno simile. Quindi scarta o ritorna la gesture piu simile.
    GestureStruct Recognize(){
        GestureStruct currentgesture=new GestureStruct();
        float currentMin= Mathf.Infinity;

        foreach (var gesture in gestures)
        {
            float sumDistance=0;
            bool isDiscared=false;
            for(int i=0;i<fingerBones.Count;i++){
                
                Vector3 currentData= skeleton.transform.InverseTransformPoint(fingerBones[i].Transform.position);
                float distance = Vector3.Distance(currentData,gesture.fingersData[i]);

                if(distance>threshold){
                    isDiscared=true;
                    break;
                }
                sumDistance+=distance;
            }
            if(!isDiscared && sumDistance<currentMin){
                currentMin=sumDistance;
                currentgesture=gesture;
            }

        }
        return currentgesture;
    }
}
