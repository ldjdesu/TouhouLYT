using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillAndNeedleP : MonoBehaviour {

    public GameObject m_PillAndNeedleP;

    private GameObject m_PillAndNeedleN;
    private GameObject BulletBox;

    public int n; 

    private float m_Time;

    private GameObject bullet;

    // Use this for initialization
    void Start()
    {
        m_PillAndNeedleN =  Resources.Load("PillAndNeedleN") as GameObject;

        BulletBox = GameObject.Find("BulletBox");

        m_Time = Time.time;

    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time-m_Time<(0.9f-n*0.07f))
        {
            this.transform.Translate(new Vector2(1, 0) * Time.deltaTime * 2f, Space.Self);
        }
        else
        {
            if (Time.time - m_Time > (0.9f - n * 0.07f)+1)
            {
                bullet = GameObject.Instantiate(m_PillAndNeedleN, m_PillAndNeedleP.transform.position, m_PillAndNeedleP.transform.rotation);
                bullet.transform.SetParent(BulletBox.transform);
                MyDestroy();
            }
        }

        if (m_PillAndNeedleP.transform.position.x > 3.5 || m_PillAndNeedleP.transform.position.x < -3.5 || m_PillAndNeedleP.transform.position.y < -4 || m_PillAndNeedleP.transform.position.y > 4)
        {
            MyDestroy();
        }

    }

    public void MyDestroy()
    {
        Destroy(m_PillAndNeedleP);
    }
}
