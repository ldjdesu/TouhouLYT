using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReimuBullet : MonoBehaviour {

    public GameObject m_ReimuBullet;


	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {

        m_ReimuBullet.transform.Translate(new Vector2(1, 0) * Time.deltaTime * 10f, Space.Self);

        if (m_ReimuBullet.transform.position.x > 3.5 || m_ReimuBullet.transform.position.x < -3.5 || m_ReimuBullet.transform.position.y < -4 || m_ReimuBullet.transform.position.y > 4)
        {
            MyDestroy();
        }

    }

    public void MyDestroy()
    {
        Destroy(m_ReimuBullet);
    }

    //击中敌人
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fish"||other.tag=="Qruno")
        {
            MyDestroy();
        }
    }



}
