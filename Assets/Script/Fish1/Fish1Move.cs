using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish1Move : MonoBehaviour {

    public GameObject Fish1;

    private int Hp = 24;

    private AudioSource FishDie;

    private GameObject m_Power;
    private GameObject m_Point;

    private GameObject PowerAndPointBox;

    public ParticleSystem m_FishDieGreen;

    private bool life = true;
    //碰撞器
    private SphereCollider m_Collider;





    // Use this for initialization
    void Start()
    {
        FishDie = GameObject.Find("AudioBox").GetComponent<Audio>().m_FishDie;

        PowerAndPointBox = GameObject.Find("PowerAndPointBox");


        m_Collider = Fish1.transform.GetComponent<SphereCollider>();

        m_Power = Resources.Load("Power") as GameObject;
        m_Point = Resources.Load("Point") as GameObject;
    }

    /// <summary>
    /// 自我销毁
    /// </summary>
    private void Update()
    {
        //出界
        if (Fish1.transform.position.x>3.5||Fish1.transform.position.x<-3.5||Fish1.transform.position.y<-4|| Fish1.transform.position.y >4)
        {
            Destroy(Fish1);
        }

        //死亡
        if (Hp < 0 && life)
        {
            life = false;
            PowerAndPoint();
            FishDie.Play();
            StartCoroutine("OnAtkDie");
        }
    }

    /// <summary>
    /// 左移动动画
    /// </summary>
    public void Left()
    {
        Fish1.transform.GetComponent<Animator>().Play("Left");
    }

    /// <summary>
    /// 左移动结束动画
    /// </summary>
    public void LeftDown()
    {
        Fish1.transform.GetComponent<Animator>().Play("LeftDown");
    }

    /// <summary>
    /// 右移动动画
    /// </summary>
    public void Right()
    {
        Fish1.transform.GetComponent<Animator>().Play("Right");
    }

    /// <summary>
    /// 右移动结束动画
    /// </summary>
    public void RightDown()
    {
        Fish1.transform.GetComponent<Animator>().Play("RightDown");
    }

    //被击中扣血
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ReimuBullet")
        {
            Hp -= 6;
        }
        if (other.tag == "ReimuBulletTracking")
        {
            Hp -= 2;
        }

    }

    //被符卡击中
    private void OnTriggerStay(Collider other)
    {
        if (other.tag== "EnchantmentTigger")
        {
            Hp -= 1;
        }
        if (other.tag== "FireLightTigger")
        {
            Hp -= 2;
        }
        if (other.tag== "FireTigger")
        {
            Hp -= 3;
        }
    }


    //爆点
    private void PowerAndPoint()
    {
        GameObject obj;

        Vector3 objPos = Fish1.transform.position + new Vector3(Random.Range(0, 0.4f), Random.Range(0, 0.4f), 0);

        obj = GameObject.Instantiate(m_Power, objPos, Quaternion.identity) as GameObject;
        obj.transform.SetParent(PowerAndPointBox.transform);

        for (int i = 0; i < 4; i++)
        {
            objPos = Fish1.transform.position + new Vector3(Random.Range(0, 0.4f), Random.Range(0, 0.4f), 0);
            obj = GameObject.Instantiate(m_Point, objPos, Quaternion.identity) as GameObject;
            obj.transform.SetParent(PowerAndPointBox.transform);
        }

    }

    //被攻击死亡
    private IEnumerator OnAtkDie()
    {
        m_Collider.enabled = false;
        Fish1.GetComponent<SpriteRenderer>().enabled = false;
        m_FishDieGreen.Play();
        yield return new WaitForSeconds(0.5f);
        MyDestroy();
        StopCoroutine("OnAtkDie");

    }

    public void MyDestroy()
    {
        Destroy(Fish1);
    }


}
