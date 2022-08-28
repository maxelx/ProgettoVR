using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

//Classe che definisce lo spawn di nuovi proiettili analizzando la traccia audio in esecuzione
public class Spawner : MonoBehaviour
{
	public GameObject[]cubes;
	public Transform[] points;
	public AudioSource audio;
	//public TextMesh text;
	//ogni quanto
	public float beat = (60 /161)*3;
	//variabile d'appoggio
	private float timer;
	//spectrum array
	private float[] spectrum = new float[4096];
	//Audio variables
	private float prev = 0;
	private bool stato = true;
	private bool statoP = false;
	private bool send = true;

	
	// Update is called once per frame
    void Update()
    {
	    Texture newMat2 = Resources.Load<Texture2D>("odh_icon");
	    
	    //se sono arrivato allo stato "demo"

	    if (VRbutton.counter==2 && send)
	    {
		    //Lancio 4 proiettili demo
		    GameObject cube = Instantiate(cubes[0], points[Random.Range(0, 5)]);
		    cube.transform.localPosition = new Vector3(-1,0, 0); //Random.Range(0, 28)
		    cube.GetComponent<Renderer>().material.mainTexture = newMat2;
		    
		    GameObject cube2 = Instantiate(cubes[0], points[Random.Range(0, 5)]);
		    cube2.transform.localPosition = new Vector3(0,0, 5); //Random.Range(0, 28)

		    GameObject cube3 = Instantiate(cubes[0], points[Random.Range(0, 5)]);
		    cube3.transform.localPosition = new Vector3(-1,0, 9); //Random.Range(0, 28)
		    cube3.GetComponent<Renderer>().material.mainTexture = newMat2;
		    
		    GameObject cube4 = Instantiate(cubes[0], points[Random.Range(0, 5)]);
		    cube4.transform.localPosition = new Vector3(0,0, 13); //Random.Range(0, 28)

		    send = false;
	    }

	    if (VRbutton.counter >= 3)
	    {
		    audio.GetSpectrumData(spectrum, 0, FFTWindow.Hamming);
		    //audio.GetOutputData(spectrum, 0);
		    float now = spectrum[0]*400;
	    
		    if (now >=1 && timer > beat)
		    {
			    prev = now;
			    stato = true;
		    }
		    else
		    {
			    stato = false;
		    }
	    
		    if (stato && !statoP)
		    {
			    GameObject cube = Instantiate(cubes[Random.Range(0, 4)], points[Random.Range(0, 4)]);
			    float pos = Random.Range(-0.5f, 0.5f);
			    cube.transform.localPosition = new Vector3(pos,0, 0); //Random.Range(0, 28)
			    if (pos < 0)
			    {
				    // Assigns a texture named "Podium_AlbedoTransparency" to the object.
				    cube.GetComponent<Renderer>().material.mainTexture = newMat2;
			    }
			    
			    timer -= beat;
			    Contatore.totale++;
		    }
		    statoP = stato;
	    
		    timer += Time.deltaTime;
	    }
    }
    IEnumerator ExampleCoroutine()
    {
	    //yield on a new YieldInstruction that waits for 1 seconds.
	    yield return new WaitForSeconds(2);
    }
}
