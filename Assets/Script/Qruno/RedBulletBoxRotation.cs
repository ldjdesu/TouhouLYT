using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBulletBoxRotation : MonoBehaviour {

    public GameObject m_RedBulletBoxRotation;

    private float m_time;

    private AudioSource allATK;

    int flg = 0;

    // Use this for initialization
    void Start () {

        m_time = Time.time;

        allATK = GameObject.Find("AudioBox").GetComponent<Audio>().m_AllATK;

    }
	
	// Update is called once per frame
	void Update () {

        if ((Time.time - m_time) % 50 > 4 && (Time.time - m_time) % 50 < 18)
        {
            if (flg==0)
            {
                allATK.Play();
                flg = 1;
            }
            m_RedBulletBoxRotation.transform.Rotate(new Vector3(0, 0, -1), Time.deltaTime * 15f);
        }

        if ((Time.time - m_time) % 50 > 22 && (Time.time - m_time) % 50 < 36)
        {
            if (flg == 1)
            {
                allATK.Play();
                flg = 2;
            }
            m_RedBulletBoxRotation.transform.Rotate(new Vector3(0, 0, 1), Time.deltaTime * 15f);
        }
        if ((Time.time - m_time) % 50 > 38 && (Time.time - m_time) % 50 < 41.5)
        {
            if (flg == 2)
            {
                allATK.Play();
                flg = 3;
            }
            m_RedBulletBoxRotation.transform.Rotate(new Vector3(0, 0, 1), Time.deltaTime * 25f);
        }

        if ((Time.time - m_time) % 50 > 42.5 && (Time.time - m_time) % 50 < 46) 
        {
            if (flg == 3)
            {
                allATK.Play();
                flg = 4;
            }
            m_RedBulletBoxRotation.transform.Rotate(new Vector3(0, 0, -1), Time.deltaTime * 25f);
        }


    }

    public void MyDestroy()
    {
        Destroy(m_RedBulletBoxRotation);
    }
}
