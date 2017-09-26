using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish_Rotation_Left : MonoBehaviour
{

    public GameObject Fish_Rotation;

    private MapManager m_MapManager;

    private int Hp = 24;

    int i = 0;
    int flg = 0;

    //曲线上的位置
    Vector2[] path1;
    Vector2[] path2;

    //出生位置
    Vector2 pos;
    private AudioSource FishDie;

    private GameObject m_Point;

    private GameObject PowerAndPointBox;

    public ParticleSystem m_FishDieBlue;

    private bool life = true;
    //碰撞器
    private SphereCollider m_Collider;


    // Use this for initialization
    void Start()
    {
        FishDie = GameObject.Find("AudioBox").GetComponent<Audio>().m_FishDie;


        m_MapManager = GameObject.Find("BG").GetComponent<MapManager>();
        pos = m_MapManager.posR_L;

        PowerAndPointBox = GameObject.Find("PowerAndPointBox");

        m_Point = Resources.Load("Point") as GameObject;

        
        m_Collider = Fish_Rotation.transform.GetComponent<SphereCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        //第一次曲线运动
        if (flg == 0)
        {
            Fish_Rotation.transform.position = Vector2.MoveTowards(Fish_Rotation.transform.position, new Vector2(0, Fish_Rotation.transform.position.y), Time.deltaTime * 3.5f);

            if (Fish_Rotation.transform.position.x == 0 && Fish_Rotation.transform.position.y == pos.y)
            {
                flg = 1;
                path1 = Bezier3D.GetBeizerList(Fish_Rotation.transform.position, new Vector2(Fish_Rotation.transform.position.x + 1.3333f, Fish_Rotation.transform.position.y), new Vector2(Fish_Rotation.transform.position.x + 1.3333f, Fish_Rotation.transform.position.y - 2), new Vector2(Fish_Rotation.transform.position.x, Fish_Rotation.transform.position.y - 2), 10);
            }
        }
        if (flg == 1)
        {
            if (Fish_Rotation.transform.position.x == path1[i].x && Fish_Rotation.transform.position.y == path1[i].y)
            {

                if (i == 9)
                {
                    i = 0;
                    flg = 2;
                    path2 = Bezier3D.GetBeizerList(Fish_Rotation.transform.position, new Vector2(Fish_Rotation.transform.position.x - 1.3333f, Fish_Rotation.transform.position.y), new Vector2(Fish_Rotation.transform.position.x - 1.3333f, Fish_Rotation.transform.position.y + 2), new Vector2(Fish_Rotation.transform.position.x, Fish_Rotation.transform.position.y + 2), 10);
                }
                else i++;
            }
            Fish_Rotation.transform.position = Vector2.MoveTowards(Fish_Rotation.transform.position, path1[i], Time.deltaTime * 3.5f);
        }
        if (flg == 2)
        {
            if (Fish_Rotation.transform.position.x == path2[i].x && Fish_Rotation.transform.position.y == path2[i].y)
            {
                if (i == 9)
                {
                    i = 0;
                    flg = 3;
                }
                else i++;
            }
            Fish_Rotation.transform.position = Vector2.MoveTowards(Fish_Rotation.transform.position, path2[i], Time.deltaTime * 3.5f);
        }
        if (flg == 3)
        {
            Fish_Rotation.transform.position = Vector2.MoveTowards(Fish_Rotation.transform.position, new Vector2(3.6f, Fish_Rotation.transform.position.y), Time.deltaTime * 3.5f);
        }

        Fish_Rotation.transform.Rotate(new Vector3(0, 0, -1), 10);

        //自我销毁
        if (Fish_Rotation.transform.position.x > 3.5 || Fish_Rotation.transform.position.x < -3.5 || Fish_Rotation.transform.position.y < -4 || Fish_Rotation.transform.position.y > 4)
        {
            MyDestroy();
        }

        //死亡
        if (Hp < 0&&life)
        {
            life = false;
            PowerAndPoint();
            FishDie.Play();
            StartCoroutine("OnAtkDie");
        }
    }

    //被击中扣血
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ReimuBullet")
        {
            Hp -= 5;
        }
        if (other.tag == "ReimuBulletTracking")
        {
            Hp -= 3;
        }

    }
    //被符卡击中
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "EnchantmentTigger")
        {
            Hp -= 1;
        }
        if (other.tag == "FireLightTigger")
        {
            Hp -= 2;
        }
        if (other.tag == "FireTigger")
        {
            Hp -= 3;
        }
    }

    //爆点
    private void PowerAndPoint()
    {
        GameObject obj;

        Vector3 objPos = Fish_Rotation.transform.position + new Vector3(Random.Range(0, 0.4f), Random.Range(0, 0.4f), 0);

        for (int i = 0; i < 1; i++)
        {
            obj = GameObject.Instantiate(m_Point, objPos, Quaternion.identity) as GameObject;
            obj.transform.SetParent(PowerAndPointBox.transform);
        }

    }


    //被攻击死亡
    private IEnumerator OnAtkDie()
    {
        m_Collider.enabled = false;
        Fish_Rotation.GetComponent<SpriteRenderer>().enabled = false;
        m_FishDieBlue.Play();
        yield return new WaitForSeconds(0.5f);
        MyDestroy();
        StopCoroutine("OnAtkDie");

    }

    public void MyDestroy()
    {
        Destroy(Fish_Rotation);
    }
}
