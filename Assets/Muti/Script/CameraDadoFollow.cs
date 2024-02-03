using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDadoFollow : MonoBehaviour
{
    public GameObject dado;
    public Vector3 offset;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        transform.position = dado.transform.position + offset;
        transform.LookAt(dado.transform.position);
        //transform.position=dado.transform.position;    
    }
}
