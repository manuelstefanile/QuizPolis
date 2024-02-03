using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TabletScore : ClasseGeneral
{
    private Transform positionTabletRiferimento;
    //verra aggiunta quando il giocatore scegliera la pedina
    public GameObject pedinaRiferimento;
    private GlobalVariabili global;
    private TextMeshPro testo;
    public TextMeshPro testoDadi;
    // Start is called before the first frame update
    void Start()
    {
        global=GameObject.FindWithTag("GlobalVar").GetComponent<GlobalVariabili>();
        testo=FindChildWithTag(this.transform,"TestoScore").gameObject.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if(positionTabletRiferimento==null){
            if(pedinaRiferimento!=null){
                positionTabletRiferimento=pedinaRiferimento.GetComponent<Pedine>().FindChildWithTag(pedinaRiferimento.transform,"PositionScore");
            }
        }else{
            testo.text="Score:\n"+global.puntiGiocatore;
            transform.position=positionTabletRiferimento.transform.position;
            float rotationY = positionTabletRiferimento.transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(90f, rotationY+180f , 0f);
        }
        
    }
    public void AggiornaTestoDadi(string valoreDadi){
        testoDadi.text="Dadi: "+valoreDadi;
    }
}
