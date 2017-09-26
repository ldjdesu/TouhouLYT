using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Loading : MonoBehaviour {

    public Image m_Loading;

    //true=up
    private bool UproDown = false;

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (m_Loading.color.a < 10 / 255f)
        {
            UproDown = true;
        }
        if (m_Loading.color.a > 250 / 255f)
        {
            UproDown = false;
        }

        if (UproDown)
        {
            m_Loading.color = new Color(m_Loading.color.r, m_Loading.color.g, m_Loading.color.b, m_Loading.color.a + 8 / 255f);
        }
        else
        {
            m_Loading.color = new Color(m_Loading.color.r, m_Loading.color.g, m_Loading.color.b, m_Loading.color.a - 8 / 255f);
        }
    }
}
