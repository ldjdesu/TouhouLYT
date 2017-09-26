using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish1_Fixation_Left : Fish1Move {

    private Fish1Move m_Fish1Move;

    private float m_Time;

	// Use this for initialization
	void Start () {

        m_Fish1Move = Fish1.transform.GetComponent<Fish1Move>();

        m_Time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

        if (Time.time-m_Time<1.5f)
        {
            Fish1.transform.Translate(Vector2.down * Time.deltaTime * 1.5f);
        }
        else
        {
            Invoke("RightMove", 0.75f);
        }
	}
    void RightMove()
    {
        m_Fish1Move.Right();
        Fish1.transform.Translate(new Vector2(2.18f, -1) * Time.deltaTime * 0.75f);
    }
}
