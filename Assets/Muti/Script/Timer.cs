using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer 
{
    private float countdownTime; // Tempo iniziale del timer
    private bool timerRunning; // Controlla se il timer è in esecuzione
    private TextMeshPro testoRiferimento;



    public Timer(float startTime,TextMeshPro testo)
    {
        countdownTime = startTime;
        timerRunning = true;
        testoRiferimento=testo;
    }
    public void SetTimerRunning(bool valore){
        timerRunning=valore;
    }
    public void UpdateTimer()
    {
        if (timerRunning)
        {
            countdownTime -= Time.deltaTime; // Decrementa il tempo rimanente basandosi sul tempo trascorso da un frame all'altro
            //stampa il tempo a video
            
            testoRiferimento.text=countdownTime.ToString().Substring(0,2);
            if (countdownTime <= 0)
            {
                countdownTime = 0; // Imposta il tempo a zero per evitare numeri negativi
                timerRunning = false; // Ferma il timer
                Debug.Log("Tempo scaduto!"); // Avviso quando il tempo raggiunge lo zero
            }
        }
    }

    public float GetTimeRemaining()
    {
        return countdownTime;
    }

    public bool IsTimerRunning()
    {
        return timerRunning;
    }
}

