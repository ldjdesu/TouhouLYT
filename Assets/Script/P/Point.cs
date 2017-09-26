using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Point : MonoBehaviour {

    public GameObject m_Point;

    private DataManager m_DataManager;

    private Text ScoreText;

    private AudioSource Eat;

    public float speed = 2;

    // Use this for initialization
    void Start()
    {

        m_DataManager = GameObject.Find("BG").GetComponent<DataManager>();
        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();

        Eat = GameObject.Find("AudioBox").GetComponent<Audio>().m_Eat;
    }

    // Update is called once per frame
    void Update()
    {

        m_Point.transform.Translate(Vector2.down * Time.deltaTime * speed, Space.Self);
        if (m_Point.transform.position.x > 3.5 || m_Point.transform.position.x < -3.5 || m_Point.transform.position.y < -4 || m_Point.transform.position.y > 4)
        {
            MyDestroy();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Reimu")
        {
            Eat.Play();
            Vector3 ReimuPos = new Vector3(other.transform.position.x, other.transform.position.y, -0.1f);
            if (m_DataManager.Score < 999999999)
            {
                m_DataManager.Score += 2333;
                ScoreText.text = m_DataManager.Score.ToString();
            }
            Bullet.ChangeDirectionDown(m_Point, ReimuPos);
            Invoke("MyDestroy", 0.08f);
        }

    }

    public void MyDestroy()
    {
        Destroy(m_Point);
    }
}
