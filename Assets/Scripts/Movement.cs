using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//classe che definisce il comportamento del movimento degli oggetti e delle collisioni
public class Movement : MonoBehaviour
{
    private float position;
    // Update is called once per frame
    private void Start()
    {
        position = transform.position.x;
    }

    void Update()
    {
        //sposto in avanti il colpo
        transform.position += Time.deltaTime * transform.forward * 2;
        
        //check degli sbandi, nel caso succeda riposiziono alla posizione precedente
        float actual = transform.position.x;
        float differenza = Math.Abs( actual - position);
        //position += 2; actual != position
        //if (differenza == 0.0)
        if (differenza != 0f)
        {
            transform.position = new Vector3(position, transform.position.y, transform.position.z);
            //Destroy(gameObject);
            
        }
        position = actual;


    }
    
    //funzione di distruzione dei colpi quando collidono con i piedi giusti, e di conseguenza aumento/diminuizione dei punti
    private void OnCollisionEnter(Collision collision)
    {
        String nome = transform.GetComponent<Renderer>().material.mainTexture.name;
        //Se premo con il piede corretto guadagno un punto
        if ((collision.transform.name == "PiedeSX" && nome == "odh_icon" ) || (collision.transform.name == "PiedeDX" && nome != "odh_icon") || collision.transform.name.Contains("cubo"))
        {
            Contatore.counter++; 
            Destroy(gameObject);
        }
        //Se premo con il piede sbagliato perdo punti
        if ((collision.transform.name == "PiedeSX" && nome != "odh_icon" ) || (collision.transform.name == "PiedeDX" && nome == "odh_icon") || collision.transform.name.Contains("cubo"))
        {
            Contatore.counter--;
            Destroy(gameObject);
        }
    }
}
