using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;

public class DialogoPoliziotto : MonoBehaviour
{
    public TextMeshProUGUI textcomponent;
    public string domanda;
    public float textSpeed;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        textcomponent.text=string.Empty;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTestoEmpty(){
        textcomponent.text=string.Empty;
    }
    public void StartDialogue(){
        index=0;
        
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine(){
         StringBuilder displayText = new StringBuilder();
        foreach(char c in domanda.ToCharArray()){
            displayText.Append(c);
            
            textcomponent.text=displayText.ToString();
            yield return new WaitForSeconds(textSpeed);

        }
    }

    //non utilizzata per ora
    void NextLine(){
        if(index<domanda.Length-1){
            index++;
            textcomponent.text=string.Empty;
            StartCoroutine(TypeLine());
        }else{
            gameObject.SetActive(false);
        }
    }
}
