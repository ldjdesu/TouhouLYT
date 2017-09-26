using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillAndNeedleN : MonoBehaviour {

    public GameObject m_PillAndNeedleN;

    private float m_Time;

    // Use this for initialization
    void Start()
    {
        m_Time = Time.time;


    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time-m_Time>1.25f)
        {
            this.transform.Translate(new Vector2(1, 0) * Time.deltaTime*1f, Space.Self);
        }

        if (m_PillAndNeedleN.transform.position.x > 3.5 || m_PillAndNeedleN.transform.position.x < -3.5 || m_PillAndNeedleN.transform.position.y < -4 || m_PillAndNeedleN.transform.position.y > 4)
        {
            MyDestroy();
        }

    }

    public void MyDestroy()
    {
        Destroy(m_PillAndNeedleN);
    }
}
