using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedNeedle : MonoBehaviour {

    public GameObject m_RedNeedle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        m_RedNeedle.transform.Translate(new Vector2(1, 0) * Time.deltaTime*1.5f, Space.Self);

        if (m_RedNeedle.transform.position.x > 3.5 || m_RedNeedle.transform.position.x < -3.5 || m_RedNeedle.transform.position.y < -4 || m_RedNeedle.transform.position.y > 4)
        {
            MyDestroy();
        }
    }


    public void MyDestroy()
    {
        Destroy(m_RedNeedle);
    }

}
