using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish2_Fixation : Fish2Move
{

    private Fish2Move m_Fish2Move;

    private GameObject m_Needle;
    private GameObject m_RedNeedle;

    private GameObject BulletBox;

    private GameObject m_Reimu;

    private float m_Time;

    private int flg;

    private AudioSource fishATK;
    private AudioSource allATK;

    // Use this for initialization
    void Start()
    {
        m_Fish2Move = Fish2.transform.GetComponent<Fish2Move>();

        m_Needle = Resources.Load("Needle") as GameObject;
        m_RedNeedle = Resources.Load("RedNeedle") as GameObject;

        BulletBox = GameObject.Find("BulletBox");

        fishATK = GameObject.Find("AudioBox").GetComponent<Audio>().m_FishATK;
        allATK = GameObject.Find("AudioBox").GetComponent<Audio>().m_AllATK;

        m_Time = Time.time;

        flg = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //下移动
        if (Time.time - m_Time < 1.5f)
        {
            Fish2.transform.Translate(Vector2.down * Time.deltaTime * 1.5f);
        }
        else
        {
            if (flg==0)
            {
                StartCoroutine("Fire");
                flg = 1;
            }
            Invoke("UpMove", 7);
        }
    }

    void UpMove()
    {
        Fish2.transform.Translate(Vector2.up * Time.deltaTime * 0.75f);
    }

    private IEnumerator FireRed()
    {
        GameObject bullet;
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < 2; i++)
        {
            //实时获取
            m_Reimu = GameObject.FindGameObjectWithTag("Reimu");
            Vector3 ReimuPos = new Vector3(0, -2, 0);
            if (m_Reimu != null)
            {
                ReimuPos = m_Reimu.transform.position;
            }
            for (int j = 0; j < 3; j++)
            {
                fishATK.Play();
                for (int k = 0; k < 5; k++)
                {
                    bullet = GameObject.Instantiate(m_RedNeedle, Fish2.transform.position, Quaternion.identity) as GameObject;
                    bullet.transform.SetParent(BulletBox.transform);
                    Bullet.ChangeDirection(bullet, ReimuPos + new Vector3((k - 2) * 0.2f, (2 - k) * 0.05f));
                    yield return new WaitForSeconds(0.01f);
                }
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(0.3f);
        }
        StopCoroutine("FireRed");
    }

    private IEnumerator Fire()
    {
        GameObject bullet;
        Vector3 bulletPos = new Vector2(0, 0);
        for (int i = 0; i < 2500; i+=13)
        {
            fishATK.Play();
            bulletPos.x = Fish2.transform.position.x + (0.1f+i*0.0003f) * Mathf.Cos(i * 3.14159f / 180f);
            bulletPos.y = Fish2.transform.position.y + (0.1f+i*0.0003f) * Mathf.Sin(i * 3.14159f / 180f);

            bullet = GameObject.Instantiate(m_Needle, bulletPos, Quaternion.identity) as GameObject;
            bullet.transform.SetParent(BulletBox.transform);
            Bullet.ChangeDirection(bullet, bulletPos+bulletPos-Fish2.transform.position);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.3f);
        allATK.Play();
        StartCoroutine("FireRed");
        yield return new WaitForSeconds(1f);

        for (int i = 2400; i > 0; i -= 13)
        {
            fishATK.Play();
            bulletPos.x = Fish2.transform.position.x + (0.1f + i * 0.0003f) * Mathf.Cos(i * 3.14159f / 180f);
            bulletPos.y = Fish2.transform.position.y + (0.1f + i * 0.0003f) * Mathf.Sin(i * 3.14159f / 180f);

            bullet = GameObject.Instantiate(m_Needle, bulletPos, Quaternion.identity) as GameObject;
            bullet.transform.SetParent(BulletBox.transform);
            Bullet.ChangeDirection(bullet, bulletPos + bulletPos - Fish2.transform.position);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.3f);
        allATK.Play();
        StartCoroutine("FireRed");
        StopCoroutine("Fire");
    }

}
