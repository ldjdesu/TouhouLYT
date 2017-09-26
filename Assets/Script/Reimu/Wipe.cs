using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Wipe : MonoBehaviour {

    private GameObject m_Reimu;
    private DataManager m_DataManager;

    private Text ScoreText;


    // Use this for initialization
    void Start () {
        m_Reimu = GameObject.FindGameObjectWithTag("Reimu");
        m_DataManager = GameObject.Find("BG").GetComponent<DataManager>();

        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //触发
    private void OnTriggerStay(Collider other)
    {
        if (m_Reimu.GetComponent<ReimuATK>().ReimuLife && other.tag != "ReimuBullet" && other.tag != "ReimuBulletTracking" && other.tag != "Power" &&
            other.tag != "Point" && other.tag != "EnchantmentTigger" && other.tag != "FireLightTigger" && other.tag != "FireTigger"&&other.tag!="Reimu")
        {
            m_DataManager.Score += 3;
            ScoreText.text = m_DataManager.Score.ToString();
        }

    }
}
