using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish1_Right : Fish1Move {

    private Fish1Move m_Fish1Move;

    private GameObject m_RedNeedle;
    private GameObject m_Pill;

    private GameObject m_Reimu;

    private GameObject BulletBox;

    private float m_Time;


    private int flg;

    private AudioSource fishATK;


    void Start () {

        m_Fish1Move = Fish1.transform.GetComponent<Fish1Move>();
        m_RedNeedle = Resources.Load("RedNeedle") as GameObject;
        m_Pill = Resources.Load("Pill") as GameObject;

        BulletBox = GameObject.Find("BulletBox");

        fishATK = GameObject.Find("AudioBox").GetComponent<Audio>().m_FishATK;


        m_Time = Time.time;

        flg = 0;
    }
    private void Update()
    {
        //下移动
        if (Fish1.transform.position.y>1.5)
        {
            Fish1.transform.position = Vector2.Lerp(Fish1.transform.position, new Vector2(Fish1.transform.position.x, -0.6f), Time.deltaTime*0.5f);
        }

        //左移动
        else
        {
            Invoke("LeftMove", 0.2f);
            m_Fish1Move.Left();
            if (flg==0)
            {
                StartCoroutine("Fire");
                flg = 1;
            }
        }

    }

    private IEnumerator Fire()
    {
        GameObject bullet;
        Vector3 bulletPos1 = new Vector2(0.4f, -1f);
        Vector3 bulletPos2 = new Vector2(0.3f, -1f);

        for (int i = 0; i < 10; i++)
        {
            fishATK.Play();
            //实时获取位置
            m_Reimu = GameObject.FindGameObjectWithTag("Reimu");
            Vector3 ReimuPos = new Vector3(0, -2, 0);
            if (m_Reimu != null)
            {
                ReimuPos = m_Reimu.transform.position;
            }
            if (i > 0 && i < 6)
            {
                bullet = GameObject.Instantiate(m_RedNeedle, Fish1.transform.position, Quaternion.identity) as GameObject;
                bullet.transform.SetParent(BulletBox.transform);
                Bullet.ChangeDirection(bullet, ReimuPos + new Vector3((i - 3) * 0.1f, 0));
                yield return new WaitForSeconds(0.01f);
            }
            else
            {
                bullet = GameObject.Instantiate(m_Pill, Fish1.transform.position, Quaternion.identity) as GameObject;
                bullet.transform.SetParent(BulletBox.transform);
                Bullet.ChangeDirection(bullet, bullet.transform.position + bulletPos1);

                bullet = GameObject.Instantiate(m_Pill, Fish1.transform.position, Quaternion.identity) as GameObject;
                bullet.transform.SetParent(BulletBox.transform);
                Bullet.ChangeDirection(bullet, bullet.transform.position + bulletPos2);
                yield return new WaitForSeconds(0.4f);
            }
        }
        StopCoroutine("Fire");
    }

    /// <summary>
    /// Fish1_Right的左移动
    /// </summary>
    void LeftMove()
    {
        Fish1.transform.Translate(new Vector2(-2.18f, -1.5f) * Time.deltaTime * 0.75f);
    }

}
