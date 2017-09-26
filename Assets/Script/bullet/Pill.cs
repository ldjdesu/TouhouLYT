using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : MonoBehaviour {

    public GameObject m_Pill;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.Translate(new Vector2(1, 0) * Time.deltaTime *1.5f, Space.Self);

        if (m_Pill.transform.position.x > 3.5 || m_Pill.transform.position.x < -3.5 || m_Pill.transform.position.y < -4 || m_Pill.transform.position.y > 4)
        {
            MyDestroy();
        }

    }

    public void MyDestroy()
    {
        Destroy(m_Pill);
    }
}
