using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //lista di oggetti da spawnare
    public List<GameObject> oggSpawn;
    // Start is called before the first frame update
    void Start(){
        float x=0.1f;
        for(int i=0;i<oggSpawn.Count;i++){
            GameObject ogg= Instantiate(oggSpawn[i],transform.position,transform.rotation);
            x=x+0.2f;
            ogg.transform.position=ogg.transform.position+new Vector3(x,1f,0);
            ogg.SetActive(true);
        }
    }

}
