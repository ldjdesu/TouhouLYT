using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicRotation : MonoBehaviour {

    public GameObject m_MagicRotation;

    private Vector3 RotateSpeed = new Vector3(0, 0, 360);

    private Vector3 min= new Vector3(1.2f, 1.2f);
    private Vector3 max = new Vector3(2.0f, 2.0f);

    private float speed = 1;



    private bool ifUp = false;

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {

        m_MagicRotation.transform.Rotate(RotateSpeed * Time.deltaTime);

        if (m_MagicRotation.transform.localScale.x<1.4)
        {
            ifUp = true;
        }
        if (m_MagicRotation.transform.localScale.x >1.8)
        {
            ifUp = false;
        }

        if (ifUp)
        {
            m_MagicRotation.transform.localScale = Vector3.Lerp(m_MagicRotation.transform.localScale, max, Time.deltaTime*speed);
        }
        else
        {
            m_MagicRotation.transform.localScale = Vector3.Lerp(m_MagicRotation.transform.localScale, min, Time.deltaTime*speed); 
        }
		
	}
}
