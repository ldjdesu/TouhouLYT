using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Qruno : MonoBehaviour
{

    public GameObject m_Qruno;

    private float m_Time;

    private GameObject m_Ice;
    private GameObject m_IceBullet;
    private GameObject m_IceNeedle;
    private GameObject m_Needle;
    private GameObject m_Pill;
    private GameObject m_IceMouth;
    private GameObject m_IceRotation;
    private GameObject m_RedBullet;
    private GameObject m_RedBulletBox;
    private GameObject m_RedBulletBoxRotation;
    private GameObject m_RedBulletBoxRotationAll;
    private GameObject m_RedRedBullet;
    private GameObject m_PillAndNeedleP;
    private GameObject RedBulletBoxRotationAll;



    private GameObject BulletBox;

    private AudioSource fishATK;
    private AudioSource allATK;
    private AudioSource charge;
    private AudioSource bossDie;
    private AudioSource F;
    private AudioSource Yuki;
    private AudioSource fishDie;
    private AudioSource fishATKBig;

    //琪露诺的状态 -1为无 0为运行 123456为状态
    public int Qflg;


    //状态时间
    float Boss_Time;

    // ParticleSystem component instead
    //符卡时期的背景和粒子效果
    public GameObject F_BG;
    public GameObject IceLeft;
    public GameObject IceRight;
    public GameObject IceDownLeft;
    public GameObject IceDownRight;
    public GameObject IceUpLeft;
    public GameObject IceUpRight;
    public GameObject BG_Rotation;
    private ParticleSystem m_FParticle;
    private SpriteRenderer m_MagicZ;
    private Image m_BoosHpBg;
    private Image m_BoosHp;

    //显示特效
    private Color colorAUp = new Color(0, 0, 0, 2 / 255f);


    private SpriteRenderer BGRenderer;
    private GameObject Snow;

    private float Hp;

    //分别对应5个状态
    private float Hp1 = 4000;
    private float Hp2 = 4000;
    private float Hp3 = 6000;
    private float Hp4 = 10000;
    private float Hp5 = 14000;
    public Image BossHp;

    private GameObject m_Power;
    private GameObject m_Point;

    private GameObject PowerAndPointBox;


    // Use this for initialization
    void Start()
    {

        m_Time = Time.time;

        m_Ice = Resources.Load("Ice") as GameObject;
        m_IceBullet = Resources.Load("IceBullet") as GameObject;
        m_IceNeedle = Resources.Load("IceNeedle") as GameObject;
        m_Needle = Resources.Load("Needle") as GameObject;
        m_Pill = Resources.Load("Pill") as GameObject;
        m_IceMouth = Resources.Load("IceMouth") as GameObject;
        m_IceRotation = Resources.Load("IceRotation") as GameObject;
        m_RedBullet = Resources.Load("RedBullet") as GameObject;
        m_RedBulletBox = Resources.Load("RedBulletBox") as GameObject;
        m_RedBulletBoxRotation = Resources.Load("RedBulletBoxRotation") as GameObject;
        m_RedBulletBoxRotationAll = Resources.Load("RedBulletBoxRotationAll") as GameObject;
        m_RedRedBullet = Resources.Load("RedRedBullet") as GameObject;
        m_PillAndNeedleP = Resources.Load("PillAndNeedleP") as GameObject;

        BulletBox = GameObject.Find("BulletBox");
        BGRenderer = GameObject.Find("BG").GetComponent<SpriteRenderer>();
        Snow = GameObject.Find("Snow");

        fishATK = GameObject.Find("AudioBox").GetComponent<Audio>().m_FishATK;
        allATK = GameObject.Find("AudioBox").GetComponent<Audio>().m_AllATK;
        charge = GameObject.Find("AudioBox").GetComponent<Audio>().m_Charge;
        bossDie = GameObject.Find("AudioBox").GetComponent<Audio>().m_BossDie;
        F = GameObject.Find("AudioBox").GetComponent<Audio>().m_F;
        Yuki = GameObject.Find("AudioBox").GetComponent<Audio>().m_Yuki;
        fishDie = GameObject.Find("AudioBox").GetComponent<Audio>().m_FishDie;
        fishATKBig = GameObject.Find("AudioBox").GetComponent<Audio>().m_FishATKBig;

        PowerAndPointBox = GameObject.Find("PowerAndPointBox");

        m_FParticle = GameObject.Find("FParticle").GetComponent<ParticleSystem>();
        m_MagicZ = GameObject.Find("MagicZ").GetComponent<SpriteRenderer>();
        m_BoosHpBg = GameObject.Find("BoosHpBg").GetComponent<Image>();
        m_BoosHp = GameObject.Find("BoosHp").GetComponent<Image>();


        m_Power = Resources.Load("Power") as GameObject;
        m_Point = Resources.Load("Point") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time - m_Time < 1.2)
        {
            m_Qruno.transform.position = Vector2.Lerp(m_Qruno.transform.position, new Vector3(0.8f, 1f, 0.1f), Time.deltaTime * 1.25f);
        }
        if (Qflg == 0)
        {
            StartCoroutine("QrunoATK");
            Qflg = 1;
        }
        if (Qflg == 1)
        {

            //移动
            if (Time.time - Boss_Time > 7 && Time.time - Boss_Time < 11)
            {
                m_Qruno.transform.Translate(Vector2.left * Time.deltaTime * 0.3f, Space.Self);
                Left();
            }
            if (Time.time - Boss_Time > 15 && Time.time - Boss_Time < 19)
            {
                m_Qruno.transform.Translate(Vector2.right * Time.deltaTime * 0.6f, Space.Self);
                Right();
            }
            if (Time.time - Boss_Time > 22 && Time.time - Boss_Time < 26)
            {
                m_Qruno.transform.Translate(Vector2.left * Time.deltaTime * 0.3f, Space.Self);
                Left();
            }
            //特效
            if (Time.time-Boss_Time>0&& Time.time - Boss_Time < 3)
            {
                if (m_MagicZ.color.a < 200 / 255f)
                {
                    m_MagicZ.color += colorAUp;
                }
                m_BoosHpBg.color += colorAUp;
                m_BoosHp.color += colorAUp;
                m_FParticle.startColor += colorAUp * 2;
            }

            //血量
            BossHp.fillAmount = Hp / Hp1;



        }
        if (Qflg==2)
        {
            BossHp.fillAmount = Hp / Hp2;

        }
        if (Qflg == 3)
        {

            if (Time.time - Boss_Time > 6 && Time.time - Boss_Time < 10)
            {
                m_Qruno.transform.Translate(Vector2.right * Time.deltaTime * 0.3f, Space.Self);
                Right();
            }
            if (Time.time - Boss_Time > 14 && Time.time - Boss_Time < 22)
            {
                m_Qruno.transform.Translate(Vector2.left * Time.deltaTime * 0.3f, Space.Self);
                Left();
            }
            if (Time.time - Boss_Time > 26 && Time.time - Boss_Time < 30)
            {
                m_Qruno.transform.Translate(Vector2.right * Time.deltaTime * 0.3f, Space.Self);
                Right();
            }

            BossHp.fillAmount = Hp / Hp3;
        }

        if (Qflg == 4)
        {
            m_Qruno.transform.position = Vector3.MoveTowards(m_Qruno.transform.position, new Vector3(0, 0.6f, 0.1f), Time.deltaTime * 2);
            Right();

            if (Time.time - Boss_Time > 0.3f && BGRenderer.color.r > 20 / 255f)
            {
                BGRenderer.color = new Color(BGRenderer.color.r - 0.05f, BGRenderer.color.g - 0.05f, BGRenderer.color.b - 0.05f);
            }

            BossHp.fillAmount = Hp / Hp4;
        }
        if (Qflg == 5)
        {
            Left();

            BossHp.fillAmount = Hp / Hp5;
        }
    }
    /// <summary>
    /// 右移动动画
    /// </summary>
    private void Right()
    {
        m_Qruno.GetComponent<Animator>().Play("RightAndLive");
    }
    /// <summary>
    /// 左移动动画
    /// </summary>
    private void Left()
    {
        m_Qruno.GetComponent<Animator>().Play("Left");
    }

    /// <summary>
    /// 一符,雪崩
    /// </summary>
    /// <returns></returns>
    private IEnumerator YukiSlide()
    {
        GameObject bullet;
        Vector3 bulletPosDown = new Vector2(-2.1f, -3);
        Vector3 bulletPosUp = new Vector2(-1.7f, 3);
        Vector3 bulletPosLeft = new Vector2(-2.5f, -2.7f);
        Vector3 bulletPosRight = new Vector2(2.5f, -2.3f);

        while (true)
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    bullet = GameObject.Instantiate(m_Pill, bulletPosDown + new Vector3(j * 1.1f, 0), Quaternion.identity) as GameObject;
                    bullet.transform.SetParent(BulletBox.transform);
                    Bullet.ChangeDirection(bullet, bullet.transform.position + new Vector3(0, 1, 0));

                    bullet = GameObject.Instantiate(m_Pill, bulletPosUp + new Vector3(j * 1.1f, 0), Quaternion.identity) as GameObject;
                    bullet.transform.SetParent(BulletBox.transform);
                    Bullet.ChangeDirection(bullet, bullet.transform.position + new Vector3(0, -1, 0));
                }
                yield return new WaitForSeconds(0.3f);
            }
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    bullet = GameObject.Instantiate(m_Pill, bulletPosRight + new Vector3(0, j * 1.1f), Quaternion.identity) as GameObject;
                    bullet.transform.SetParent(BulletBox.transform);
                    Bullet.ChangeDirection(bullet, bullet.transform.position + new Vector3(-1, 0, 0));

                    bullet = GameObject.Instantiate(m_Pill, bulletPosLeft + new Vector3(0, j * 1.1f), Quaternion.identity) as GameObject;
                    bullet.transform.SetParent(BulletBox.transform);
                    Bullet.ChangeDirection(bullet, bullet.transform.position + new Vector3(1, 0, 0));
                }
                yield return new WaitForSeconds(0.3f);
            }
        }
    }
    /// <summary>
    /// 一符,设置雪风的位置
    /// </summary>
    /// <returns></returns>
    private IEnumerator YukiPlay()
    {
        int flg = 0;
        while (true)
        {
            for (int i = 0; i < 4; i++)
            {
                if (i == 0 && flg == 1)
                {
                    IceLeft.transform.Rotate(new Vector3(0, 0, -45));
                    IceRight.transform.Rotate(new Vector3(0, 0, 45));
                }
                if (i >= 1 && i <= 2)
                {
                    IceLeft.transform.Rotate(new Vector3(0, 0, 45));
                    IceRight.transform.Rotate(new Vector3(0, 0, -45));
                }
                if (i == 3)
                {
                    IceLeft.transform.Rotate(new Vector3(0, 0, -45));
                    IceRight.transform.Rotate(new Vector3(0, 0, 45));
                    flg = 1;
                }
                Yuki.Play();
                yield return new WaitForSeconds(4);
            }
        }
    }



    private IEnumerator IceRotationATK()
    {
        GameObject bullet;
        Vector3 bulletRightUp = new Vector2(2.3f, 2.71f);
        Vector3 bulletRightDown = new Vector2(2.3f, -2.71f);
        Vector3 bulletLeftUp = new Vector2(-2.3f, 2.71f);
        Vector3 bulletLeftDown = new Vector2(-2.3f, -2.71f);

        for (int i = 0; i < 30; i++)
        {
            if (i % 2 == 1)
            {
                bullet = GameObject.Instantiate(m_IceRotation, bulletRightUp, Quaternion.identity) as GameObject;
                bullet.transform.SetParent(BulletBox.transform);
                Bullet.ChangeDirection(bullet, bullet.transform.position + new Vector3(Random.Range(-1f, 0), Random.Range(-1f, 0), 0));

                bullet = GameObject.Instantiate(m_IceRotation, bulletRightDown, Quaternion.identity) as GameObject;
                bullet.transform.SetParent(BulletBox.transform);
                Bullet.ChangeDirection(bullet, bullet.transform.position + new Vector3(Random.Range(-1f, 0), Random.Range(0, 1f), 0));

                bullet = GameObject.Instantiate(m_IceRotation, bulletLeftUp, Quaternion.identity) as GameObject;
                bullet.transform.SetParent(BulletBox.transform);
                Bullet.ChangeDirection(bullet, bullet.transform.position + new Vector3(Random.Range(0, 1f), Random.Range(-1f, 0), 0));

                bullet = GameObject.Instantiate(m_IceRotation, bulletLeftDown, Quaternion.identity) as GameObject;
                bullet.transform.SetParent(BulletBox.transform);
                Bullet.ChangeDirection(bullet, bullet.transform.position + new Vector3(Random.Range(0, 1f), Random.Range(0, 1f), 0));
            }
            bullet = GameObject.Instantiate(m_IceRotation, bulletRightUp, Quaternion.identity) as GameObject;
            bullet.transform.SetParent(BulletBox.transform);
            Bullet.ChangeDirection(bullet, bullet.transform.position + new Vector3(Random.Range(-1f, 0), Random.Range(-1f, 0), 0));

            bullet = GameObject.Instantiate(m_IceRotation, bulletRightDown, Quaternion.identity) as GameObject;
            bullet.transform.SetParent(BulletBox.transform);
            Bullet.ChangeDirection(bullet, bullet.transform.position + new Vector3(Random.Range(-1f, 0), Random.Range(0, 1f), 0));

            bullet = GameObject.Instantiate(m_IceRotation, bulletLeftUp, Quaternion.identity) as GameObject;
            bullet.transform.SetParent(BulletBox.transform);
            Bullet.ChangeDirection(bullet, bullet.transform.position + new Vector3(Random.Range(0, 1f), Random.Range(-1f, 0), 0));

            bullet = GameObject.Instantiate(m_IceRotation, bulletLeftDown, Quaternion.identity) as GameObject;
            bullet.transform.SetParent(BulletBox.transform);
            Bullet.ChangeDirection(bullet, bullet.transform.position + new Vector3(Random.Range(0, 1f), Random.Range(0, 1f), 0));

            yield return new WaitForSeconds(3.5f);
        }

    }

    //⑨重冰冻阵:散
    private IEnumerator Star9()
    {
        GameObject bullet;
        GameObject RedBulletBoxRotatio;
        Vector3 bulletPos = new Vector3(0, 0, 0);

        //带动弹幕旋转的父物体
        RedBulletBoxRotatio = GameObject.Instantiate(m_RedBulletBoxRotation, m_Qruno.transform.position, Quaternion.identity) as GameObject;
        RedBulletBoxRotatio.transform.SetParent(BulletBox.transform);
        //9个发射点
        for (int i = 0; i < 9; i++)
        {
            bulletPos.x = m_Qruno.transform.position.x + 1.3f * Mathf.Cos(40 * i * 3.14159f / 180f);
            bulletPos.y = m_Qruno.transform.position.y + 1.3f * Mathf.Sin(40 * i * 3.14159f / 180f);

            bullet = GameObject.Instantiate(m_RedBulletBox, bulletPos, Quaternion.identity) as GameObject;
            bullet.transform.GetComponent<RedBulletBox>().n = i;
            bullet.transform.SetParent(RedBulletBoxRotatio.transform);
        }
        yield return new WaitForSeconds(1f);
    }

    //⑨重冰冻阵:集
    private IEnumerator Star9All()
    {

        Vector3 bulletPos = new Vector3(0, 0, 0);

        RedBulletBoxRotationAll = GameObject.Instantiate(m_RedBulletBoxRotationAll, m_Qruno.transform.position+new Vector3(0,0,-0.1f), Quaternion.Euler(0, 0, 8.5f)) as GameObject;
        RedBulletBoxRotationAll.transform.SetParent(BulletBox.transform);

        yield return new WaitForSeconds(1f);
    }
    //⑨重冰冻阵:集:雪变针
    private IEnumerator PillAndNeedle()
    {
        GameObject bullet;
        Vector3 bulletPos = new Vector3(0, 0, 0);
        int k = 0;

        yield return new WaitForSeconds(3f);
        while (true)
        {
            //生成7层雪 
            for (int i = 0; i < 7; i ++)
            {
                fishATKBig.Play();
                
                for (int j = i + k; j < 360 + i + k; j += 10+i)
                {
                    bulletPos.x = m_Qruno.transform.position.x + Mathf.Cos(j * 3.14159f / 180f);
                    bulletPos.y = m_Qruno.transform.position.y + Mathf.Sin(j * 3.14159f / 180f);

                    bullet = GameObject.Instantiate(m_PillAndNeedleP,m_Qruno.transform.position + new Vector3(0, 0, -0.1f), Quaternion.identity) as GameObject;
                    bullet.transform.GetComponent<PillAndNeedleP>().n = i;
                    bullet.transform.SetParent(BulletBox.transform);
                    Bullet.ChangeDirection(bullet, bulletPos);

                }
                yield return new WaitForSeconds(0.07f);
            }
            k += 4;
            bullet = GameObject.Instantiate(m_IceMouth, m_Qruno.transform.position + new Vector3(0, 0, +0.1f), Quaternion.identity) as GameObject;
            bullet.transform.SetParent(BulletBox.transform);
            bullet = GameObject.Instantiate(m_IceMouth, m_Qruno.transform.position + new Vector3(0, 0, +0.1f), Quaternion.identity) as GameObject;
            bullet.transform.SetParent(BulletBox.transform);
            yield return new WaitForSeconds(1.5f);
        }
    }

    //被击中扣血
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ReimuBullet")
        {
            Hp -= 6;
        }
        if ( other.tag == "ReimuBulletTracking")
        {
            Hp -= 4;
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

        Vector3 objPos = m_Qruno.transform.position + new Vector3(Random.Range(0, 0.2f), Random.Range(0, 0.2f), -0.1f);

        for (int i = 0; i < 3; i++)
        {
            objPos = m_Qruno.transform.position + new Vector3(Random.Range(0, 0.2f), Random.Range(0, 0.2f), 0);
            obj = GameObject.Instantiate(m_Power, objPos, Quaternion.identity) as GameObject;
            obj.transform.SetParent(PowerAndPointBox.transform);
        }

        for (int i = 0; i < 5; i++)
        {
            objPos = m_Qruno.transform.position + new Vector3(Random.Range(0, 0.2f), Random.Range(0, 0.2f), 0);
            obj = GameObject.Instantiate(m_Point, objPos, Quaternion.identity) as GameObject;
            obj.transform.SetParent(PowerAndPointBox.transform);
        }

    }


    private IEnumerator QrunoATK()
    {
        GameObject bullet;
        //收集需要销毁的子弹
        GameObject[] bullets;
        Vector3 bulletPos = new Vector2(0, 0);
        m_FParticle.Play();
        yield return new WaitForSeconds(1.2f);

        //一非 4波循环
        Boss_Time = Time.time;
        Hp = Hp1;

       
        while (Time.time - Boss_Time < 30&&Hp>0)
        {
            yield return new WaitForSeconds(0.1f);
            //圆冰阵
            for (int i = 0; i < 32; i++)
            {
                if (i % 2 == 0)
                {
                    fishATK.Play();
                }
                for (int j = 0; j < 16; j++)
                {

                    if (j == 0)
                    {
                        bullet = GameObject.Instantiate(m_IceBullet, m_Qruno.transform.position, Quaternion.identity) as GameObject;
                        bullet.transform.SetParent(BulletBox.transform);
                        Bullet.ChangeDirection(bullet, bullet.transform.position + new Vector3(-1, 0, 0));

                        bullet = GameObject.Instantiate(m_IceBullet, m_Qruno.transform.position, Quaternion.identity) as GameObject;
                        bullet.transform.SetParent(BulletBox.transform);
                        Bullet.ChangeDirection(bullet, bullet.transform.position + new Vector3(1, 0, 0));
                    }
                    else
                    {
                        if (j < 9)
                        {
                            bullet = GameObject.Instantiate(m_IceBullet, m_Qruno.transform.position, Quaternion.identity) as GameObject;
                            bullet.transform.SetParent(BulletBox.transform);
                            Bullet.ChangeDirection(bullet, bullet.transform.position + new Vector3((j - 8) * 0.125f, j * 0.125f, 0));

                            bullet = GameObject.Instantiate(m_IceBullet, m_Qruno.transform.position, Quaternion.identity) as GameObject;
                            bullet.transform.SetParent(BulletBox.transform);
                            Bullet.ChangeDirection(bullet, bullet.transform.position + new Vector3((j - 8) * 0.125f, -j * 0.125f, 0));
                        }
                        else
                        {
                            bullet = GameObject.Instantiate(m_IceBullet, m_Qruno.transform.position, Quaternion.identity) as GameObject;
                            bullet.transform.SetParent(BulletBox.transform);
                            Bullet.ChangeDirection(bullet, bullet.transform.position + new Vector3((j - 8) * 0.125f, (16 - j) * 0.125f, 0));

                            bullet = GameObject.Instantiate(m_IceBullet, m_Qruno.transform.position, Quaternion.identity) as GameObject;
                            bullet.transform.SetParent(BulletBox.transform);
                            Bullet.ChangeDirection(bullet, bullet.transform.position + new Vector3((j - 8) * 0.125f, -(16 - j) * 0.125f, 0));
                        }
                    }
                }
                yield return new WaitForSeconds(0.08f);
            }

            //冰针攻击
            charge.Play();
            yield return new WaitForSeconds(2.2f);
            fishATK.Play();
            for (int i = 0; i < 2500; i += 17)
            {
                bulletPos.x = m_Qruno.transform.position.x + (0.5f + i * 0.00015f) * Mathf.Cos(i * 3.14159f / 180f);
                bulletPos.y = m_Qruno.transform.position.y + (0.5f + i * 0.00015f) * Mathf.Sin(i * 3.14159f / 180f);

                bullet = GameObject.Instantiate(m_Needle, bulletPos, Quaternion.identity) as GameObject;
                bullet.transform.SetParent(BulletBox.transform);
                Bullet.ChangeDirection(bullet, bulletPos + bulletPos - m_Qruno.transform.position);
            }
            yield return new WaitForSeconds(0.3f);
            for (int i = 2495; i > 0; i -= 17)
            {
                fishATK.Play();
                bulletPos.x = m_Qruno.transform.position.x + (0.1f + i * 0.00018f) * Mathf.Cos(i * 3.14159f / 180f);
                bulletPos.y = m_Qruno.transform.position.y + (0.1f + i * 0.00018f) * Mathf.Sin(i * 3.14159f / 180f);

                bullet = GameObject.Instantiate(m_Needle, bulletPos, Quaternion.identity) as GameObject;
                bullet.transform.SetParent(BulletBox.transform);
                Bullet.ChangeDirection(bullet, bulletPos + bulletPos - m_Qruno.transform.position);
                yield return new WaitForSeconds(0.012f);
            }
            yield return new WaitForSeconds(0.3f);
            allATK.Play();
        }




        //一符
        Qflg = 2;
        Vector3 YukiPosLeft = new Vector2(0, 0);
        Vector3 YukiPosRight = new Vector2(0, 0);
        //需要区分子弹类型来引用方法
        bullets = GameObject.FindGameObjectsWithTag("Needle");
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].GetComponent<Needle>().MyDestroy();
        }
        bullets = GameObject.FindGameObjectsWithTag("Bullet");
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].GetComponent<Bullet>().MyDestroy();
        }

        PowerAndPoint();
        allATK.Stop();
        F.Play();
        F_BG.GetComponent<EllipsoidParticleEmitter>().emit = true;
        Snow.GetComponent<EllipsoidParticleEmitter>().emit = false;
        BG_Rotation.GetComponent<EllipsoidParticleEmitter>().emit = true;
        Boss_Time = Time.time;
        yield return new WaitForSeconds(0.5f);
        IceLeft.GetComponent<EllipsoidParticleEmitter>().emit = true;
        IceRight.GetComponent<EllipsoidParticleEmitter>().emit = true;

        StartCoroutine("YukiPlay");
        StartCoroutine("YukiSlide");

        yield return new WaitForSeconds(0.3f);
        Hp = Hp2;
        while (Time.time - Boss_Time < 40&&Hp>0)
        {
            for (int i = 0; i < 4 && Hp > 0; i++)
            {
                for (int j = 0; j < 8 && Hp > 0; j++)
                {
                    if (i == 0)
                    {
                        YukiPosLeft = m_Qruno.transform.position + new Vector3(-0.15f * (j + 4), 0.15f * (j + 2), -0.1f);
                        YukiPosRight = m_Qruno.transform.position + new Vector3(0.15f * (j + 4), 0.15f * (j + 2), -0.1f);

                    }
                    if (i == 1 || i == 3)
                    {
                        YukiPosLeft = m_Qruno.transform.position + new Vector3(-0.17f * (j + 4), 0, -0.1f);
                        YukiPosRight = m_Qruno.transform.position + new Vector3(0.17f * (j + 4), 0, -0.1f);

                    }
                    if (i == 2)
                    {
                        YukiPosLeft = m_Qruno.transform.position + new Vector3(-0.15f * (j + 4), -0.15f * (j + 2), -0.1f);
                        YukiPosRight = m_Qruno.transform.position + new Vector3(0.15f * (j + 4), -0.15f * (j + 2), -0.1f);

                    }
                    bullet = GameObject.Instantiate(m_IceMouth, YukiPosLeft, Quaternion.identity) as GameObject;
                    bullet.transform.SetParent(BulletBox.transform);
                    bullet = GameObject.Instantiate(m_IceMouth, YukiPosRight, Quaternion.identity) as GameObject;
                    bullet.transform.SetParent(BulletBox.transform);
                    yield return new WaitForSeconds(0.2f);

                    if (j == 7) yield return new WaitForSeconds(2.4f);
                }

            }
        }

        //一符结束
        PowerAndPoint();
        fishDie.Play();
        Qflg = 3;
        F_BG.GetComponent<EllipsoidParticleEmitter>().emit = false;
        Snow.GetComponent<EllipsoidParticleEmitter>().emit = true;
        BG_Rotation.GetComponent<EllipsoidParticleEmitter>().emit = false;
        IceLeft.GetComponent<EllipsoidParticleEmitter>().emit = false;
        IceRight.GetComponent<EllipsoidParticleEmitter>().emit = false;
        IceLeft.SetActive(false);
        IceRight.SetActive(false);

        StopCoroutine("YukiPlay");
        StopCoroutine("YukiSlide");

        //二非开始

        Boss_Time = Time.time;

        //需要区分子弹类型来引用方法
        bullets = GameObject.FindGameObjectsWithTag("Pill");
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].GetComponent<Pill>().MyDestroy();
        }
        bullets = GameObject.FindGameObjectsWithTag("IceNeedle");
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].GetComponent<IceNeedle>().MyDestroy();
        }

        yield return new WaitForSeconds(0.8f);
        StartCoroutine("IceRotationATK");
        Hp = Hp3;
        for (int i = 0; Time.time - Boss_Time < 36&&Hp>0; i += 7)
        {
            if (i % 21 == 0)
            {
                fishATK.Play();
            }
            bulletPos.x = m_Qruno.transform.position.x + (0.4f) * Mathf.Cos(i * 3.14159f / 180f);
            bulletPos.y = m_Qruno.transform.position.y + (0.4f) * Mathf.Sin(i * 3.14159f / 180f);

            bullet = GameObject.Instantiate(m_Ice, bulletPos, Quaternion.identity) as GameObject;
            bullet.transform.SetParent(BulletBox.transform);
            Bullet.ChangeDirection(bullet, bulletPos + bulletPos - m_Qruno.transform.position);
            yield return new WaitForSeconds(0.005f);
        }

        Qflg = 4;
        //二非结束二符开始
        PowerAndPoint();
        StopCoroutine("IceRotationATK");
        //需要区分子弹类型来引用消除方法
        bullets = GameObject.FindGameObjectsWithTag("Ice");
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].GetComponent<Ice>().MyDestroy();
        }
        bullets = GameObject.FindGameObjectsWithTag("IceRotation");
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].GetComponent<IceRotationMove>().MyDestroy();
        }
        //时间重置
        Boss_Time = Time.time;
        yield return new WaitForSeconds(0.3f);
        F.Play();
        //各种粒子效果
        F_BG.GetComponent<EllipsoidParticleEmitter>().emit = true;
        Snow.GetComponent<EllipsoidParticleEmitter>().emit = false;
        BG_Rotation.GetComponent<EllipsoidParticleEmitter>().emit = true;
        IceDownLeft.GetComponent<EllipsoidParticleEmitter>().emit = true;
        IceDownRight.GetComponent<EllipsoidParticleEmitter>().emit = true;
        IceUpLeft.GetComponent<EllipsoidParticleEmitter>().emit = true;
        IceUpRight.GetComponent<EllipsoidParticleEmitter>().emit = true;

        StartCoroutine("Star9");
        //Ice发射口
        Vector3 MouthPosUpLeft = new Vector3(0.7f, 1.4f, 0);
        Vector3 MouthPosUpRight = new Vector3(-0.7f, 1.4f, 0);
        Vector3 MouthPosDownLeft = new Vector3(0.7f, -0.2f, 0);
        Vector3 MouthPosDownRight = new Vector3(-0.7f, -0.2f, 0);
        Hp = Hp4;
        while (Time.time - Boss_Time < 46&&Hp>0)
        {
            bullet = GameObject.Instantiate(m_IceMouth, MouthPosUpLeft, Quaternion.identity) as GameObject;
            bullet.transform.SetParent(BulletBox.transform);
            bullet = GameObject.Instantiate(m_IceMouth, MouthPosUpRight, Quaternion.identity) as GameObject;
            bullet.transform.SetParent(BulletBox.transform);

            bullet = GameObject.Instantiate(m_IceMouth, MouthPosDownLeft, Quaternion.identity) as GameObject;
            bullet.transform.SetParent(BulletBox.transform);
            bullet = GameObject.Instantiate(m_IceMouth, MouthPosDownRight, Quaternion.identity) as GameObject;
            bullet.transform.SetParent(BulletBox.transform);

            yield return new WaitForSeconds(3);
        }

        //终符
        Qflg = 5;
        PowerAndPoint();
        StopCoroutine("Star9");

        bullets = GameObject.FindGameObjectsWithTag("RedBullet");
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].GetComponent<RedBullet>().MyDestroy();
        }
        bullets = GameObject.FindGameObjectsWithTag("IceNeedle");
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].GetComponent<IceNeedle>().MyDestroy();
        }
        bullets = GameObject.FindGameObjectsWithTag("RedBulletBoxRotation");
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].GetComponent<RedBulletBoxRotation>().MyDestroy();
        }
        bullets = GameObject.FindGameObjectsWithTag("IceNeedle");
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].GetComponent<IceNeedle>().MyDestroy();
        }
        bullets = GameObject.FindGameObjectsWithTag("IceMouth");
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].GetComponent<IceMouth>().MyDestroy();
        }

        fishDie.Play();

        IceDownLeft.GetComponent<EllipsoidParticleEmitter>().emit = false;
        IceDownRight.GetComponent<EllipsoidParticleEmitter>().emit = false;
        IceUpLeft.GetComponent<EllipsoidParticleEmitter>().emit = false;
        IceUpRight.GetComponent<EllipsoidParticleEmitter>().emit = false;


        StartCoroutine("Star9All");
        StartCoroutine("PillAndNeedle");

        //生成弹幕朝向点
        Vector3 RedRedPos = new Vector3(0, 0, 0);
        GameObject[] RedRedMouth = new GameObject[18];
        for (int i = 0; i < 18; i++)
        {

            RedRedPos.x = m_Qruno.transform.position.x + Mathf.Cos(i * 20 * 3.14159f / 180f);
            RedRedPos.y = m_Qruno.transform.position.y + Mathf.Sin(i * 20 * 3.14159f / 180f);

            RedRedMouth[i] = GameObject.Instantiate(new GameObject(), RedRedPos, Quaternion.identity) as GameObject;
            RedRedMouth[i].transform.SetParent(RedBulletBoxRotationAll.transform);
        }
        Boss_Time = Time.time;
        yield return new WaitForSeconds(1);

        F.Play();

        Hp = Hp5;
        //18向红弹
        while (Time.time - Boss_Time < 46&&Hp>0)
        {

            for (int i = 0; i < 18; i++)
            {
                bullet = GameObject.Instantiate(m_RedRedBullet, m_Qruno.transform.position + new Vector3(0, 0, -0.1f), Quaternion.identity) as GameObject;
                bullet.transform.SetParent(BulletBox.transform);
                Bullet.ChangeDirection(bullet, RedRedMouth[i].transform.position);

            }
            yield return new WaitForSeconds(0.07f);
        }

        //结束
        Qflg = 6;
        F_BG.GetComponent<EllipsoidParticleEmitter>().emit = false;
        Snow.GetComponent<EllipsoidParticleEmitter>().emit = true;
        BG_Rotation.GetComponent<EllipsoidParticleEmitter>().emit = false;

        StopCoroutine("Star9All");
        StopCoroutine("PillAndNeedle");

        bossDie.Play();
        yield return new WaitForSeconds(1);

        //消除
        bullets = GameObject.FindGameObjectsWithTag("RedBulletBoxRotationAll");
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].GetComponent<RedBulletBoxRotationAll>().MyDestroy();
        }
        bullets = GameObject.FindGameObjectsWithTag("RedBullet");
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].GetComponent<RedBullet>().MyDestroy();
        }
        bullets = GameObject.FindGameObjectsWithTag("PillAndNeedleP");
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].GetComponent<PillAndNeedleP>().MyDestroy();
        }
        bullets = GameObject.FindGameObjectsWithTag("PillAndNeedleN");
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].GetComponent<PillAndNeedleN>().MyDestroy();
        }
        bullets = GameObject.FindGameObjectsWithTag("RedRedBullet");
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].GetComponent<RedRedBullet>().MyDestroy();
        }

        //结束放出对话ui
        GameObject.Find("BG").GetComponent<MapManager>().UiRun = 1;
        GameObject.Find("BG").GetComponent<MapManager>().UiFlg = 21;



        GameObject.Find("Qruno(Clone)").GetComponent<Qruno>().MyDestroy();


    }



    public void MyDestroy()
    {
        Destroy(m_Qruno);
    }

}
