using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMouth : MonoBehaviour {

    public GameObject m_IceMouth;

    private float m_Time;

    private GameObject m_IceNeedle;

    private GameObject bulletBox;

    private AudioSource fishATK;

    // Use this for initialization
    void Start () {

        m_Time = Time.time;

        m_IceNeedle = Resources.Load("IceNeedle") as GameObject;

        bulletBox = GameObject.Find("BulletBox");


        fishATK = GameObject.Find("AudioBox").GetComponent<Audio>().m_FishATK;

        StartCoroutine("IceMouthATK");

    }
	
	// Update is called once per frame
	void Update () {

        if (Time.time-m_Time>2.5)
        {
            MyDestroy();
        }
		
	}

    public void MyDestroy()
    {
        Destroy(m_IceMouth);
    }

    private IEnumerator IceMouthATK()
    {
        GameObject bullet;
        Vector3 bulletPos = new Vector3(0, 0, 0);
        Vector3 pos = new Vector3(m_IceMouth.transform.position.x, m_IceMouth.transform.position.y, 0);
        for (int i = 0; i < 25; i++)
        {
            fishATK.Play();
            bulletPos.x = m_IceMouth.transform.position.x + Mathf.Cos(Random.Range(1, 360)*3.14f/180f);
            bulletPos.y = m_IceMouth.transform.position.y + Mathf.Sin(Random.Range(1, 360)*3.14f/180f);

            bullet = GameObject.Instantiate(m_IceNeedle, pos, Quaternion.identity) as GameObject;
            bullet.transform.SetParent(bulletBox.transform);

            Bullet.ChangeDirection(bullet, bulletPos);
            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(0.1f);
    }
}
