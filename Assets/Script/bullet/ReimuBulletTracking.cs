using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReimuBulletTracking : MonoBehaviour {

    public GameObject m_ReimuBulletTracking;

    private GameObject[] fishs;
    private GameObject fish;

    private bool notFist = false;

    private Vector3 NullFish = new Vector3(10, 10, 10);


    // Use this for initialization
    void Start()
    {


        //跟踪
        StartTracking();

    }

    void Update()
    {

        m_ReimuBulletTracking.transform.Translate(new Vector2(1, 0) * Time.deltaTime * 7f, Space.Self);

        if (m_ReimuBulletTracking.transform.position.x > 3.5 || m_ReimuBulletTracking.transform.position.x < -3.5 || m_ReimuBulletTracking.transform.position.y < -4 || m_ReimuBulletTracking.transform.position.y > 4)
        {
            MyDestroy();
        }

        if (fish==null)
        {
            StartTracking();
        }
        else
        {
            Bullet.ChangeDirection(m_ReimuBulletTracking, fish.transform.position);
        }


    }

    public void MyDestroy()
    {
        Destroy(m_ReimuBulletTracking);
    }

    /// <summary>
    /// 开启跟踪
    /// </summary>
    private void StartTracking()
    {
        Vector3 pos= Tracking();
        if (pos!=NullFish)
        {
            Bullet.ChangeDirection(m_ReimuBulletTracking, pos);
        }
    }

    //跟踪
    private Vector3 Tracking()
    {
        fishs = GameObject.FindGameObjectsWithTag("Fish");

        if (fishs.Length<1)
        {
            return NullFish;
        }
        //距离和最小距离
        float L;
        float Lmin;

        Vector3 minPosintion = new Vector3(0, 0, 0);
        Vector3 Posintion = new Vector3(0, 0, 0);

        minPosintion = fishs[0].transform.position - m_ReimuBulletTracking.transform.position;
        Lmin = minPosintion.magnitude;
        fish = fishs[0];
        for (int i = 0; i < fishs.Length; i++)
        {
            Posintion = fishs[i].transform.position - m_ReimuBulletTracking.transform.position;
            L = minPosintion.magnitude;
            if (L<Lmin)
            {
                Lmin = L;
                minPosintion = Posintion;
                fish = fishs[i];
            }
        }

        if (notFist && Lmin > 0.5f)
        {
            return NullFish;
        }

        notFist = true;
        return minPosintion;



    }


    //击中敌人
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fish" || other.tag == "Qruno")
        {
            MyDestroy();
        }
    }
}
