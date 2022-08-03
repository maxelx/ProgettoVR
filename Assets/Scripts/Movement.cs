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
        transform.position += Time.deltaTime * transform.forward * 2;
        
        
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
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "PiedeSX" || collision.transform.name == "PiedeDX" || collision.transform.name.Contains("cubo"))
        {
            Contatore.counter++; 
            Destroy(gameObject);
        }
    }
}
