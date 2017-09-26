using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    private GameObject m_Camera;

    private Vector3 speed = new Vector3(0, 0, 1);
    private Vector3 rota = new Vector3(0, 1, 0);

    public float Speed = 2f;

    public bool ifRotate = false;

	// Use this for initialization
	void Start () {

        m_Camera = GameObject.Find("Cameranear");


    }
	
	// Update is called once per frame
	void Update () {

        m_Camera.transform.Translate(speed * Time.deltaTime * Speed, Space.World);

        if (ifRotate)
        {
            m_Camera.transform.Rotate(rota * Time.deltaTime*0.8f);
        }
		
	}
}
