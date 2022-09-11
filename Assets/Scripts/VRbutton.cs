using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//Classe controller che gestisce la pressione del bottone nella gui 
public class VRbutton : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    public AudioSource audio;
    private GameObject presser;
    private bool isPressed;
    private bool premuto = true;
    public static int counter; //contatore della macchina a stati

    private void OnTriggerEnter(Collider other)
    {
        //se premo il bottone
        if (!isPressed && premuto)
        {
            //faccio scendere l'oggetto "bottone"
            button.transform.localPosition = new Vector3(0.3920001f, -1.24f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            isPressed = true;
            counter++;
            //se sono arrivato allo stato 4 (quello del gioco)
            if (counter == 4)
            {
                //faccio partire la musica
                audio.Play();
            }
            premuto = false;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            //se rilascio il bottone faccio risalire l'oggetto bottone
            button.transform.localPosition = new Vector3(0.3920001f, -2.11f, 0);
            onRelease.Invoke();
            isPressed = false;
            premuto = true;
        }
    }
    
    
}
