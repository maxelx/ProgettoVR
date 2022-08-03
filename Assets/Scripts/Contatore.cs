using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Classe View che rappresenta lo schermo
public class Contatore : MonoBehaviour
{
    public TextMesh text;

    //private String textToShow = "";
    public static int counter = 0;
    public static int totale = 0;
    public static String testo = "";
    
    // Update is called once per frame
    void Update()
    {
        float percentuale = ((float)counter / totale)*100;
        switch (VRbutton.counter)
        {
            case 0: testo = "Ciao, benvenuto! \n premi per \n continuare";
                break;
            case 1: testo = "In questo esercizio \n dovrai premere i \n bersagli con i piedi";
                break;
            case 2: testo = "Pronto per la demo? \n colpisci i 4 \n bersagli in arrivo";
                break;
            case 3: testo = "Ora sei pronto \n per iniziare \n premi il bottone e \n inizia la partita";
                counter = 0;
                totale = 0;
                break;
            case 4: testo = "Score : \n"+(int)percentuale+"%";
                break;
            default:
                if ((int)percentuale > 85)
                {
                    testo = "Complimenti, risultato \n soddisfacente";
                }
                else
                {
                    testo = "Peccato, riprova e \n sarai più fortunato";
                }
                break;
        }
        
        text.text = testo;
    }
}
