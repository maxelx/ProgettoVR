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
        if (!isPressed && premuto)
        {
            button.transform.localPosition = new Vector3(0.3920001f, -1.24f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            isPressed = true;
            counter++;
            if (counter == 4)
            {
                audio.Play();
            }
            premuto = false;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(0.3920001f, -2.11f, 0);
            onRelease.Invoke();
            isPressed = false;
            premuto = true;
        }
    }
    
    
}
