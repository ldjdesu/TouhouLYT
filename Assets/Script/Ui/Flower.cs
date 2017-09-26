using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Flower : MonoBehaviour {

    public Image m_Loading;

    private ParticleSystem Flower1;
    private ParticleSystem Flower2;


    // Use this for initialization
    void Start () {

        Flower1 = GameObject.Find("Flower1").GetComponent<ParticleSystem>();
        Flower2 = GameObject.Find("Flower2").GetComponent<ParticleSystem>();

    }
	
	// Update is called once per frame
	void Update () {

        if (m_Loading.enabled==true)
        {
            Flower1.Play();
            Flower2.Play();
        }
		
	}
}
