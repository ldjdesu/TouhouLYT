using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour {

    private float m_Time;   

    public GameObject m_Ice;

    // Use this for initialization
    void Start()
    {

        m_Time = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - m_Time > 0.0025f)
        {
            this.transform.Translate(new Vector2(1, 0) * Time.deltaTime*1.5f, Space.Self);
        }

        if (m_Ice.transform.position.x > 3.5 || m_Ice.transform.position.x < -3.5 || m_Ice.transform.position.y < -4 || m_Ice.transform.position.y > 4)
        {
            MyDestroy();
        }
    }

    public void MyDestroy()
    {
        Destroy(m_Ice);
    }
}
