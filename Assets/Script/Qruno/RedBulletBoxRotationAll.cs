using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBulletBoxRotationAll : MonoBehaviour {

    public GameObject m_RedBulletBoxRotationAll;

    private float m_time;

    private AudioSource allATK;

    private int flg = 0;

    // Use this for initialization
    void Start()
    {

        m_time = Time.time;

        allATK = GameObject.Find("AudioBox").GetComponent<Audio>().m_AllATK;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time-m_time>4&&flg==0)
        {
            flg = 1;
            m_time = Time.time;
        }

        if (flg==1)
        {
            if ((Time.time - m_time) % 18 >  5&& (Time.time - m_time) % 18 < 13)
            {
                m_RedBulletBoxRotationAll.transform.Rotate(new Vector3(0, 0, 1), Time.deltaTime * 8f);
            }

            if ((Time.time - m_time) % 18 < 4 || (Time.time - m_time) % 18 > 14)
            {
                m_RedBulletBoxRotationAll.transform.Rotate(new Vector3(0, 0, -1), Time.deltaTime * 8f);
            }
        }

    }



    public void MyDestroy()
    {
        Destroy(m_RedBulletBoxRotationAll);
    }
}
