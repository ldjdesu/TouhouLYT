using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour {

    private float m_Time;

    public GameObject m_Needle;

    // Use this for initialization
    void Start () {

        m_Time = Time.time;

    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time-m_Time>3)
        {
            this.transform.Translate(new Vector2(1, 0) * Time.deltaTime , Space.Self);
        }

        if (m_Needle.transform.position.x > 3.5 || m_Needle.transform.position.x < -3.5 || m_Needle.transform.position.y < -4 || m_Needle.transform.position.y > 4)
        {
            MyDestroy();
        }
    }

    public void MyDestroy()
    {
        Destroy(m_Needle);
    }
}
