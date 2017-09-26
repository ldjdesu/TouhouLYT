using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedRedBullet : MonoBehaviour {
    public GameObject m_RedRedBullet;

    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        this.transform.Translate(new Vector2(1, 0) * Time.deltaTime * 2.5f, Space.Self);

        if (m_RedRedBullet.transform.position.x > 3.5 || m_RedRedBullet.transform.position.x < -3.5 || m_RedRedBullet.transform.position.y < -4 || m_RedRedBullet.transform.position.y > 4)
        {
            MyDestroy();
        }

    }

    public void MyDestroy()
    {
        Destroy(m_RedRedBullet);
    }

}
