using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Power : MonoBehaviour {

    public GameObject m_Power;

    private DataManager m_DataManager;

    private Text PowerText;

    private AudioSource Eat;

    public float speed = 2;


	// Use this for initialization
	void Start () {

        PowerText = GameObject.Find("PowerText").GetComponent<Text>();

        Eat = GameObject.Find("AudioBox").GetComponent<Audio>().m_Eat;
    }
	
	// Update is called once per frame
	void Update () {

        m_Power.transform.Translate(Vector2.down * Time.deltaTime * speed, Space.Self);
        if (m_Power.transform.position.x > 3.5 || m_Power.transform.position.x < -3.5 || m_Power.transform.position.y < -4 || m_Power.transform.position.y > 4)
        {
            MyDestroy();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Reimu")
        {
            Eat.Play();
            m_DataManager = GameObject.Find("BG").GetComponent<DataManager>();
            Vector3 ReimuPos = new Vector3(other.transform.position.x, other.transform.position.y, -0.1f);
            if (m_DataManager.Power<128)
            {
                m_DataManager.Power += 2;
                PowerText.text = m_DataManager.Power.ToString();
            }
            Bullet.ChangeDirectionDown(m_Power, ReimuPos);
            Invoke("MyDestroy", 0.08f);
        }

    }

    public void MyDestroy()
    {
        Destroy(m_Power);
    }


}
