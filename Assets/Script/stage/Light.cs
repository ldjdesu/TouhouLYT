using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour {

    private SpriteRenderer m_Light;

    private Color speed =new Color(0,0,0,26/255f);

    private bool ifUp = true;

	// Use this for initialization
	void Start () {

        m_Light = this.transform.GetComponent<SpriteRenderer>();


    }
	
	// Update is called once per frame
	void Update () {

        if (m_Light.color.a<100/255f)
        {
            ifUp = true;
        }
        if (m_Light.color.a>150/255f)
        {
            ifUp = false;
        }
        if (ifUp)
        {
            m_Light.color += speed;
        }
        else
        {
            m_Light.color -= speed;
        }
		
	}
}
