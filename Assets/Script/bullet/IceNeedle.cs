using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceNeedle : MonoBehaviour {

    public GameObject m_IceNeedle;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        this.transform.Translate(new Vector2(1, 0) * Time.deltaTime , Space.Self);

        if (m_IceNeedle.transform.position.x > 3.5 || m_IceNeedle.transform.position.x < -3.5 || m_IceNeedle.transform.position.y < -4 || m_IceNeedle.transform.position.y > 4)
        {
            MyDestroy();
        }

    }

    public void MyDestroy()
    {
        Destroy(m_IceNeedle);
    }
}
