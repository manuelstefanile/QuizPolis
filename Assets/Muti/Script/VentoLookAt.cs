using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentoLookAt : MonoBehaviour
{
    private GameObject oggettolook;
    // Start is called before the first frame update
    public void OggettoDaSeguire(GameObject oggetto){
        oggettolook=oggetto;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(oggettolook!=null)
            transform.LookAt(oggettolook.transform);
    }
}
