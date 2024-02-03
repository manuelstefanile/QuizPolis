using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClasseGeneral : MonoBehaviour
{
    public bool muoviGradualmentebool;
    public bool scalaGradualmentebool=false;
      public IEnumerator MuoviGradualmente(GameObject oggettoDaMuovere,Vector3 destinazione, float durata)
    {
        muoviGradualmentebool=true;
        Vector3 posizioneIniziale = oggettoDaMuovere.transform.position;
        float tempoPassato = 0f;

        while (tempoPassato < durata)
        {
            
            oggettoDaMuovere.transform.position = Vector3.Lerp(posizioneIniziale, destinazione, tempoPassato / durata);
            tempoPassato += Time.deltaTime;
            yield return null;
        }

        oggettoDaMuovere.transform.position = destinazione; // Assicura che l'oggetto sia esattamente nella destinazione finale
        muoviGradualmentebool=false;
    }
      public IEnumerator RuotaGradualmente(GameObject oggettoDaRuotare,float rotazioneX,float rotazioneY,float rotazioneZ,float durata)
{
    Quaternion rotazioneIniziale = oggettoDaRuotare.transform.rotation;
    Quaternion rotazioneDesiderata = Quaternion.Euler(rotazioneX, rotazioneY, rotazioneZ);
    float tempoPassato = 0f;

    while (tempoPassato < durata)
    {
        oggettoDaRuotare.transform.rotation = Quaternion.Lerp(rotazioneIniziale, rotazioneDesiderata, tempoPassato / durata);
        tempoPassato += Time.deltaTime;
        yield return null;
    }

    oggettoDaRuotare.transform.rotation = rotazioneDesiderata; // Assicura che l'oggetto sia ruotato nella direzione finale
}
    //cerca figli e nipoti
    public Transform FindInChildren(Transform parent, string nome)
    {
        foreach (Transform child in parent)
        {
            if (child.gameObject.name.Equals(nome))
            {
                return child;
            }

            Transform foundInChildren = FindInChildren(child, nome);
            if (foundInChildren != null)
            {
                return foundInChildren;
            }
        }
        return null;
    }

       public IEnumerator ScalaGradualmente(GameObject oggettoScalare,Vector3 scalaFinale, float durata)
    {
        scalaGradualmentebool=true;
        Vector3 scalaIniziale = oggettoScalare.transform.localScale;
        float tempoPassato = 0f;

        while (tempoPassato < durata)
        {
            oggettoScalare.transform.localScale = Vector3.Lerp(scalaIniziale, scalaFinale, tempoPassato / durata);
            tempoPassato += Time.deltaTime;
            yield return null;
        }

        oggettoScalare.transform.localScale = scalaFinale; // Assicura che l'oggetto sia alla scala finale
        scalaGradualmentebool=false;
    }

      public Transform FindChildWithTag(Transform parent, string tag)
    {
        foreach (Transform child in parent)
        {
            if (child.CompareTag(tag))
            {
                return child; // Restituisce l'oggetto se ha il tag cercato
            }
            // Se l'oggetto corrente non ha il tag, controlla i suoi figli ricorsivamente
            Transform found = FindChildWithTag(child, tag);
            if (found != null)
            {
                return found; // Se l'oggetto è stato trovato nei figli, restituiscilo
            }
        }
        return null; // Nessun oggetto con il tag trovato
    }

        //attendo wqualche secondo poi chiamo la funzione
        public IEnumerator WaitSecond(float seconds, Delegate actionToExecute, params object[] parameters){
        yield return new WaitForSeconds(seconds);
        // Dopo aver atteso i secondi necessari, esegui la funzione passata come parametro con gli argomenti specificati
        actionToExecute.DynamicInvoke(parameters);
    }
}
