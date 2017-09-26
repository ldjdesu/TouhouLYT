using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceRotation : MonoBehaviour {

    public GameObject m_IceRotation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        m_IceRotation.transform.Rotate(new Vector3(0, 0, -1));

	}
}
