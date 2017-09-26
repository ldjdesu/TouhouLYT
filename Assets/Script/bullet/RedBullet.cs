using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : MonoBehaviour {

    public GameObject m_RedBullet;

	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {

        this.transform.Translate(new Vector2(1, 0) * Time.deltaTime *3f, Space.Self);

        if (m_RedBullet.transform.position.x > 3.5 || m_RedBullet.transform.position.x < -3.5 || m_RedBullet.transform.position.y < -4 || m_RedBullet.transform.position.y > 4)
        {
            MyDestroy();
        }

    }

    public void MyDestroy()
    {
        Destroy(m_RedBullet);
    }
}
