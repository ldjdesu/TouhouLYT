using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBulletBox : MonoBehaviour {

    public GameObject m_RedBulletBox;

    private GameObject m_RedBullet;

    private AudioSource fishATK;


    //用于区分发射角度
    public int n;



    // Use this for initialization
    void Start () {


        fishATK = GameObject.Find("AudioBox").GetComponent<Audio>().m_FishATK;

        m_RedBullet = Resources.Load("RedBullet") as GameObject;

        StartCoroutine("RedBulletBoxATK");
    }
	
	// Update is called once per frame
	void Update () {


		
	}

    public void MyDestroy()
    {
        Destroy(m_RedBulletBox);
    }

    private IEnumerator RedBulletBoxATK()
    {
        GameObject bullet;
        Vector3 bulletPos1 = new Vector3(0, 0, 0);
        Vector3 bulletPos2 = new Vector3(0, 0, 0);

        Vector3 pos = new Vector3(m_RedBulletBox.transform.position.x, m_RedBulletBox.transform.position.y, 0);

        for (int i = 0; i < 1000; i++)
        {
            if (n == 0||n==1)
            {
                fishATK.Play();
            }

            bulletPos1.x = m_RedBulletBox.transform.position.x + Mathf.Cos((n + 2) * 40 * 3.14f / 180f);
            bulletPos1.y = m_RedBulletBox.transform.position.y + Mathf.Sin((n + 2) * 40 * 3.14f / 180f);
            bulletPos2.x = m_RedBulletBox.transform.position.x + Mathf.Cos((n - 2) * 40 * 3.14f / 180f);
            bulletPos2.y = m_RedBulletBox.transform.position.y + Mathf.Sin((n - 2) * 40 * 3.14f / 180f);


            bullet = GameObject.Instantiate(m_RedBullet, pos, Quaternion.identity) as GameObject;
            bullet.transform.SetParent(m_RedBulletBox.transform);

            Bullet.ChangeDirection(bullet, bulletPos1);

            bullet = GameObject.Instantiate(m_RedBullet, pos, Quaternion.identity) as GameObject;
            bullet.transform.SetParent(m_RedBulletBox.transform);

            Bullet.ChangeDirection(bullet, bulletPos2);
            yield return new WaitForSeconds(0.18f);
        }
        yield return new WaitForSeconds(0.1f);
    }
}
