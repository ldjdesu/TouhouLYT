using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish2_Left : Fish2Move {

    private Fish2Move m_Fish2Move;

    private GameObject m_RedNeedle;
    private GameObject m_IceBullet;

    private GameObject m_Reimu;

    private GameObject BulletBox;

    private AudioSource fishATK;

    private int flg=0;

    void Start()
    {

        m_Fish2Move = Fish2.transform.GetComponent<Fish2Move>();

        m_RedNeedle= Resources.Load("RedNeedle") as GameObject;
        m_IceBullet = Resources.Load("IceBullet") as GameObject;

        BulletBox = GameObject.Find("BulletBox");

        fishATK = GameObject.Find("AudioBox").GetComponent<Audio>().m_FishATK;


    }


    void Update()
    {
        if (Fish2.transform.position.y < 1.25)
        {
            if (flg == 0)
            {
                StartCoroutine("Fire");
                flg = 1;
            }
            Invoke("RightMove", 1.5f);
            
        }
        else
        {
            Fish2.transform.position = Vector2.Lerp(Fish2.transform.position, new Vector2(Fish2.transform.position.x, 0.3f), Time.deltaTime);
        }

    }

    void RightMove()
    {
        m_Fish2Move.Right();
        Fish2.transform.Translate(new Vector2(2.18f, -0.4f) * Time.deltaTime*0.5f ,Space.Self);
    }

    private IEnumerator Fire()
    {
        GameObject bullet;
        Vector3 bulletPos = new Vector2(1,0);

        for (int i = 0; i < 8; i++)
        {
            fishATK.Play();
            for (int j = 0; j < 8; j++)
            {

                if (j==0)
                {
                    bullet = GameObject.Instantiate(m_IceBullet, Fish2.transform.position, Quaternion.identity) as GameObject;
                    bullet.transform.SetParent(BulletBox.transform);
                    Bullet.ChangeDirection(bullet, bullet.transform.position + new Vector3(-1, 0, 0));

                    bullet = GameObject.Instantiate(m_IceBullet, Fish2.transform.position, Quaternion.identity) as GameObject;
                    bullet.transform.SetParent(BulletBox.transform);
                    Bullet.ChangeDirection(bullet, bullet.transform.position + new Vector3(1, 0, 0));
                }
                else
                {
                    if (j<5)
                    {
                        bullet = GameObject.Instantiate(m_IceBullet, Fish2.transform.position, Quaternion.identity) as GameObject;
                        bullet.transform.SetParent(BulletBox.transform);
                        Bullet.ChangeDirection(bullet, bullet.transform.position + new Vector3((j - 4) * 0.25f, j * 0.25f, 0));

                        bullet = GameObject.Instantiate(m_IceBullet, Fish2.transform.position, Quaternion.identity) as GameObject;
                        bullet.transform.SetParent(BulletBox.transform);
                        Bullet.ChangeDirection(bullet, bullet.transform.position + new Vector3((j - 4) * 0.25f, -j * 0.25f, 0));
                    }
                    else
                    {
                        bullet = GameObject.Instantiate(m_IceBullet, Fish2.transform.position, Quaternion.identity) as GameObject;
                        bullet.transform.SetParent(BulletBox.transform);
                        Bullet.ChangeDirection(bullet, bullet.transform.position + new Vector3((j - 4) * 0.25f, (8-j) * 0.25f, 0));

                        bullet = GameObject.Instantiate(m_IceBullet, Fish2.transform.position, Quaternion.identity) as GameObject;
                        bullet.transform.SetParent(BulletBox.transform);
                        Bullet.ChangeDirection(bullet, bullet.transform.position + new Vector3((j - 4) * 0.25f, -(8-j) * 0.25f, 0));
                    }
                }
            }
            yield return new WaitForSeconds(0.06f);
        }
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < 2; i++)
        {
            //实时获取
            m_Reimu = GameObject.FindGameObjectWithTag("Reimu");
            Vector3 ReimuPos = new Vector3(0, -2, 0);
            if (m_Reimu!=null)
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
                    Bullet.ChangeDirection(bullet, ReimuPos + new Vector3((k - 2) * 0.2f, (k - 2) * 0.05f));
                    yield return new WaitForSeconds(0.01f);
                }
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(1.2f);
        }

        StopCoroutine("Fire");
    }
}
