using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBulletBoxAll : MonoBehaviour {

    public GameObject m_RedBulletBox;

    private GameObject m_RedBullet;

    private AudioSource fishATK;

    private GameObject BulletBox;

    public GameObject Mouth91;
    public GameObject Mouth92;


    //用于区分发射角度
    public int n;



    // Use this for initialization
    void Start()
    {


        fishATK = GameObject.Find("AudioBox").GetComponent<Audio>().m_FishATK;

        m_RedBullet = Resources.Load("RedBullet") as GameObject;

        BulletBox = GameObject.Find("BulletBox");

        StartCoroutine("RedBulletBoxATK");

    }

    // Update is called once per frame
    void Update()
    {



    }

    public void MyDestroy()
    {
        Destroy(m_RedBulletBox);
    }

    private IEnumerator RedBulletBoxATK()
    {

        yield return new WaitForSeconds(1f);
        GameObject bullet;
        int Npos1;
        int Npos2;

        if (n-2<0)
        {
            Npos1 = n + 8;
        }
        else
        {
            Npos1 = n - 2;
        }
        if (n+2>9)
        {
            Npos2 = n - 8;
        }
        else
        {
            Npos2 = n + 2;
        }

        for (int i = 0; i < 1000; i++)
        {
            if (n == 0 || n == 1)
            {
                fishATK.Play();
            }

            Vector3 pos = new Vector3(m_RedBulletBox.transform.position.x, m_RedBulletBox.transform.position.y, 0);

            bullet = GameObject.Instantiate(m_RedBullet, pos, Quaternion.identity) as GameObject;
            bullet.transform.SetParent(BulletBox.transform);

            Bullet.ChangeDirection(bullet, Mouth91.transform.position);

            bullet = GameObject.Instantiate(m_RedBullet, pos, Quaternion.identity) as GameObject;
            bullet.transform.SetParent(BulletBox.transform);

            Bullet.ChangeDirection(bullet, Mouth92.transform.position);
            yield return new WaitForSeconds(0.125f);
        }
        yield return new WaitForSeconds(0.1f);
    }
}
