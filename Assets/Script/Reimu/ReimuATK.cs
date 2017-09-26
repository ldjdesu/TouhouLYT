using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReimuATK : MonoBehaviour {

    public GameObject m_Reimu;

    private GameObject m_BulletMouthLeft;
    private GameObject m_BulletMouthUp;
    private GameObject m_BulletMouthRight;
    private GameObject m_BulletTrackingRightUp;
    private GameObject m_BulletTrackingRightDown;
    private GameObject m_BulletTrackingLeftUp;
    private GameObject m_BulletTrackingLeftDown;

    private GameObject m_ReimuBulletFixation;
    private GameObject m_ReimuBulletTracking;

    //符卡粒子效果
    private ParticleSystem m_Enchantment;
    private ParticleSystem m_FireLight;
    private ParticleSystem m_Fire;
    private ParticleSystem m_Boom;
    private GameObject m_FFlower;

    private SphereCollider m_EnchantmentTigger;
    private SphereCollider m_FireLightTigger;
    private SphereCollider m_FireTigger;


    private GameObject bullet;
    private GameObject bulletBox;

    private Vector3 BulletPos;

    private AudioSource ATK;
    private AudioSource Die;
    private AudioSource ReimuF;

    private DataManager m_DataManager;
    private MapManager m_MapManager;

    public bool ReimuLife = true;

    //是否正在使用符卡
    private bool onBoob = false;

    //灵梦的无敌效果
    private SpriteRenderer m_ReimuSprite;
    private bool ifUpColor = false;
    private Color colorChange = new Color(0, 20 / 255f, 20 / 255f, 0);


    // Use this for initialization
    void Start () {

        m_ReimuBulletFixation = Resources.Load("ReimuBulletFixation") as GameObject;
        m_ReimuBulletTracking = Resources.Load("ReimuBulletTracking") as GameObject;

        bulletBox = GameObject.Find("BulletBox");

        m_BulletMouthLeft = GameObject.Find("BulletMouthLeft");
        m_BulletMouthUp = GameObject.Find("BulletMouthUp");
        m_BulletMouthRight = GameObject.Find("BulletMouthRight");
        m_BulletTrackingRightUp = GameObject.Find("BulletTrackingRightUp");
        m_BulletTrackingRightDown = GameObject.Find("BulletTrackingRightDown");
        m_BulletTrackingLeftUp = GameObject.Find("BulletTrackingLeftUp");
        m_BulletTrackingLeftDown = GameObject.Find("BulletTrackingLeftDown");

        m_Enchantment = GameObject.Find("Enchantment").GetComponent<ParticleSystem>();
        m_FireLight = GameObject.Find("FireLight").GetComponent<ParticleSystem>();
        m_Fire = GameObject.Find("Fire").GetComponent<ParticleSystem>();
        m_Boom = GameObject.Find("Boom").GetComponent<ParticleSystem>();
        m_FFlower = GameObject.Find("FFlower");
        m_EnchantmentTigger = GameObject.FindGameObjectWithTag("EnchantmentTigger").GetComponent<SphereCollider>();
        m_FireLightTigger = GameObject.FindGameObjectWithTag("FireLightTigger").GetComponent<SphereCollider>();
        m_FireTigger = GameObject.FindGameObjectWithTag("FireTigger").GetComponent<SphereCollider>();


        ATK = GameObject.Find("AudioBox").GetComponent<Audio>().m_ATK;
        Die = GameObject.Find("AudioBox").GetComponent<Audio>().m_Die;
        ReimuF = GameObject.Find("AudioBox").GetComponent<Audio>().m_ReimuF;

        m_DataManager = GameObject.Find("BG").GetComponent<DataManager>();
        m_MapManager = GameObject.Find("BG").GetComponent<MapManager>();

        m_ReimuSprite = m_Reimu.GetComponent<SpriteRenderer>();


        StartCoroutine("ReimuAtkBullet");
        StartCoroutine("ReimuAtkTracking");
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.X)&&onBoob==false&&m_DataManager.Boob>0)
        {
            StartCoroutine("Enchantment16");
            m_DataManager.ifBoob = true;
        }

        if (onBoob)
        {
            if (m_ReimuSprite.color.g>250/255f)
            {
                ifUpColor =  false;
            }
            if (m_ReimuSprite.color.g < 100/255f)
            {
                ifUpColor = true;
            }
            if (ifUpColor)
            {
                m_ReimuSprite.color += colorChange;
            }
            else
            {
                m_ReimuSprite.color -= colorChange;
            }
        }

        //上线收点
        if (m_Reimu.transform.position.y>1.5f)
        {
            ChangeAllPoint();
        }

		
	}

    /// <summary>
    /// 改变全图点数的朝向
    /// </summary>
    /// <param name="other"></param>
    private void ChangeAllPoint()
    {
        GameObject[] AllPoint;
        AllPoint = GameObject.FindGameObjectsWithTag("Point");
        for (int i = 0; i < AllPoint.Length; i++)
        {
            Bullet.ChangeDirectionDown(AllPoint[i], m_Reimu.transform.position);
            AllPoint[i].GetComponent<Point>().speed += 1f;
        }
        AllPoint = GameObject.FindGameObjectsWithTag("Power");
        for (int i = 0; i < AllPoint.Length; i++)
        {
            Bullet.ChangeDirectionDown(AllPoint[i], m_Reimu.transform.position);
            AllPoint[i].GetComponent<Power>().speed += 1f;
        }
    }

    //触发
    private void OnTriggerEnter(Collider other)
    {
        if (ReimuLife && onBoob == false && other.tag != "ReimuBullet" && other.tag != "ReimuBulletTracking" && other.tag != "Power" &&other.tag != "Point" &&
            other.tag != "EnchantmentTigger" && other.tag != "FireLightTigger" && other.tag != "FireTigger"&&other.tag!= "DecisionPoint")
        {
            ReimuLife = false;
            StartCoroutine("ReimuDie");
        }

    }

    /// <summary>
    /// 自机死亡
    /// </summary>
    /// <returns></returns>
    private IEnumerator  ReimuDie()
    {
        
        m_DataManager.ifReimuLife = false;

        Die.Play();
        for (int i = 0; i < 20; i++)
        {
            m_Reimu.transform.localScale -= new Vector3(0.05f, 0, 0);
            yield return new WaitForSeconds(0.001f);
        }
        m_MapManager.UseStartClean();
        MyDestroy();
        StopCoroutine("ReimuDie");

    }

    private void MyDestroy()
    {
        Destroy(m_Reimu);
    }
    
    //符卡效果
    private IEnumerator Enchantment16()
    {
        ReimuF.Play();
        onBoob = true;
        m_Enchantment.Play();
        m_FireLight.Play();
        m_Fire.Play();
        m_EnchantmentTigger.enabled = true;
        m_FireLightTigger.enabled = true;
        m_FireTigger.enabled = true;

        m_MapManager.UseStartClean();
        yield return new WaitForSeconds(2.1f);
        m_MapManager.UseStartClean();
        m_Enchantment.Stop();
        m_FireLight.Stop();
        yield return new WaitForSeconds(0.3f);
        m_Fire.Stop();
        yield return new WaitForSeconds(0.6f);
        m_Boom.Play();
        m_FFlower.transform.position = m_Reimu.transform.position;
        m_FFlower.GetComponent<ParticleSystem>().Play();

        onBoob = false;
        m_EnchantmentTigger.enabled = false;
        m_FireLightTigger.enabled = false;
        m_FireTigger.enabled = false;
        m_ReimuSprite.color = new Color(1, 1, 1, 1);
        StopCoroutine("Enchantment16");
    }



    //发射普通
    private IEnumerator ReimuAtkBullet()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                BulletPos = new Vector3(m_Reimu.transform.position.x, m_Reimu.transform.position.y, -0.1f);

                ATK.Play();

                bullet = GameObject.Instantiate(m_ReimuBulletFixation, BulletPos, Quaternion.identity);
                bullet.transform.SetParent(bulletBox.transform);
                Bullet.ChangeDirection(bullet, m_BulletMouthUp.transform.position);

                if (m_DataManager.Power>=64)
                {
                    bullet = GameObject.Instantiate(m_ReimuBulletFixation, BulletPos, Quaternion.identity);
                    bullet.transform.SetParent(bulletBox.transform);
                    Bullet.ChangeDirection(bullet, m_BulletMouthLeft.transform.position);

                    bullet = GameObject.Instantiate(m_ReimuBulletFixation, BulletPos, Quaternion.identity);
                    bullet.transform.SetParent(bulletBox.transform);
                    Bullet.ChangeDirection(bullet, m_BulletMouthRight.transform.position);
                }

            }
            yield return new WaitForSeconds(0.07f);
        }
    }
    //发射跟踪
    private IEnumerator ReimuAtkTracking()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                for (int i = 0; i < 2; i++)
                {
                    if (m_DataManager.Power >= 16)
                    {
                        bullet = GameObject.Instantiate(m_ReimuBulletTracking, BulletPos, Quaternion.identity);
                        bullet.transform.SetParent(bulletBox.transform);
                        Bullet.ChangeDirection(bullet, m_BulletTrackingRightDown.transform.position);

                        bullet = GameObject.Instantiate(m_ReimuBulletTracking, BulletPos, Quaternion.identity);
                        bullet.transform.SetParent(bulletBox.transform);
                        Bullet.ChangeDirection(bullet, m_BulletTrackingLeftDown.transform.position);
                    }
                    if (m_DataManager.Power >= 128)
                    {
                        bullet = GameObject.Instantiate(m_ReimuBulletTracking, BulletPos, Quaternion.identity);
                        bullet.transform.SetParent(bulletBox.transform);
                        Bullet.ChangeDirection(bullet, m_BulletTrackingRightUp.transform.position);

                        bullet = GameObject.Instantiate(m_ReimuBulletTracking, BulletPos, Quaternion.identity);
                        bullet.transform.SetParent(bulletBox.transform);
                        Bullet.ChangeDirection(bullet, m_BulletTrackingLeftUp.transform.position);
                    }

                    if (i == 0)
                    {
                        yield return new WaitForSeconds(0.05f);
                    }
                }
            }
            yield return new WaitForSeconds(0.12f);

        }
    }




}
