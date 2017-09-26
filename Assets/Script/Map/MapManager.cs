using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MapManager : MonoBehaviour
{

    private GameObject m_Fish1;
    private GameObject m_Fish1_Right;
    private GameObject m_Fish1_Left;
    private GameObject m_Fish1_Fixation_Right;
    private GameObject m_Fish1_Fixation_Left;

    private GameObject m_Fish2_Right;
    private GameObject m_Fish2_Left;
    private GameObject m_Fish2_Fixation;

    private GameObject m_Fish_Rotation_Right;
    private GameObject m_Fish_Rotation_Left;

    private GameObject m_Qruno;

    private GameObject FishBox;
    private GameObject BossBox;

    private GameObject obj;

    //旋转移动杂鱼的出生位置
    public Vector2 posR_R;
    public Vector2 posR_L;

    //对话框与立绘
    public GameObject m_Dialogue;
    public GameObject m_ReimuFace;
    public GameObject m_Dialogue_Text;
    public GameObject m_Reimu_Painting;
    public GameObject m_Qruno_Painting;


    private SpriteRenderer BGRenderer;

    //颜色
    private Color Blue_Color = new Color(88 / 255f, 180 / 255f, 230 / 255f, 200 / 255f);
    private Color Red_Color = new Color(238 / 255f, 90 / 255f, 90 / 255f, 200 / 255f);

    //说话时立绘的偏移角度
    private Vector2 LeftUp = new Vector2(-1, 0.7f);
    private Vector2 LeftDown = new Vector2(-1, -0.7f);
    private Vector2 RightUp = new Vector2(1, 0.7f);
    private Vector2 RightDown = new Vector2(1, -0.7f);

    //灵梦的立绘2
    public Sprite ReimuQuery;
    public Sprite ReimuSpeechless;
    public Sprite ReimuBother;

    //开启某个对话ui 0为否 0几为初始对话,十几位数为符卡对话,二十几为战斗结束对话
    public int UiFlg = 0;

    //ui是否运行
    public int UiRun = 1;

    //escui
    public GameObject EscUI;
    //能否开启ui
    public bool ifEscUi = true;
    private AudioSource Esc;

    //结束ui
    public GameObject GameOverUiWin;

    //琪露诺的bgm
    public AudioClip PowerAndWisdom;




    // Use this for initialization
    void Start()
    {
        //Screen.SetResolution(1024, 768, true);
        //加载杂鱼
        m_Fish1 = Resources.Load("Fish1") as GameObject;
        m_Fish1_Right = Resources.Load("Fish1_Right") as GameObject;
        m_Fish1_Left = Resources.Load("Fish1_Left") as GameObject;
        m_Fish1_Fixation_Right = Resources.Load("Fish1_Fixation_Right") as GameObject;
        m_Fish1_Fixation_Left = Resources.Load("Fish1_Fixation_Left") as GameObject;

        m_Fish2_Right = Resources.Load("Fish2_Right") as GameObject;
        m_Fish2_Left = Resources.Load("Fish2_Left") as GameObject;
        m_Fish2_Fixation = Resources.Load("Fish2_Fixation") as GameObject;

        m_Fish_Rotation_Right = Resources.Load("Fish_Rotation_Right") as GameObject;
        m_Fish_Rotation_Left = Resources.Load("Fish_Rotation_Left") as GameObject;

        m_Qruno = Resources.Load("Qruno") as GameObject;
        //修改bg颜色
        BGRenderer = GameObject.Find("BG").GetComponent<SpriteRenderer>();

        //杂鱼盒子
        FishBox = GameObject.Find("FishBox");
        BossBox = GameObject.Find("BossBox");

        //音效
        Esc = GameObject.Find("AudioBox").GetComponent<Audio>().m_ESC;

        //开启携程
        StartCoroutine("CreateFish");



    }

    private IEnumerator CreateFish()
    {

        //保存杂鱼到FishBox

        //等待8.5s
        yield return new WaitForSeconds(6f);

        //Fish1的出生位置
        Vector2 pos1_R1 = new Vector2(1, 3);
        Vector2 pos1_R2 = new Vector2(1.5f, 3);
        Vector2 pos1_L1 = new Vector2(-1.5f, 3);
        Vector2 pos1_L2 = new Vector2(-1, 3);


        //生成Fish1
        for (int i = 0; i < 3; i++)
         {
            //生成右边杂鱼
            for (int j = 0; j < 4; j++)
            {
                if (j == 2)
                {
                    yield return new WaitForSeconds(0.2f);
                }
                obj = GameObject.Instantiate(m_Fish1_Right, pos1_R1 + new Vector2(Random.Range(-0.2f, 0.2f), 0), Quaternion.identity) as GameObject;
                obj.transform.SetParent(FishBox.transform);
                obj = GameObject.Instantiate(m_Fish1_Right, pos1_R2 + new Vector2(Random.Range(-0.2f, 0.2f), 0), Quaternion.identity) as GameObject;
                obj.transform.SetParent(FishBox.transform);
                yield return new WaitForSeconds(0.25f);
            }
            yield return new WaitForSeconds(2.5f);
             //生成左边杂鱼
             for (int j = 0; j < 4; j++)
             {
                 if (j == 2)
                 {
                     yield return new WaitForSeconds(0.2f);
                 }
                 obj = GameObject.Instantiate(m_Fish1_Left, pos1_L1 + new Vector2(Random.Range(-0.2f, 0.2f), 0), Quaternion.identity) as GameObject;
                 obj.transform.SetParent(FishBox.transform);
                 obj = GameObject.Instantiate(m_Fish1_Left, pos1_L2 + new Vector2(Random.Range(-0.2f, 0.2f), 0), Quaternion.identity) as GameObject;
                 obj.transform.SetParent(FishBox.transform);
                 yield return new WaitForSeconds(0.25f);
             }
             yield return new WaitForSeconds(2.5f);
         }
         yield return new WaitForSeconds(1);
         
         //Fish2的出生位置
         Vector2 pos2_R1 = new Vector2(0.5f, 3.5f);
         Vector2 pos2_R2 = new Vector2(1.5f, 3.5f);
         Vector2 pos2_L1 = new Vector2(-1.5f, 3.5f);
         Vector2 pos2_L2 = new Vector2(-0.5f, 3.5f);

         //生成Fish2
         for (int i = 0; i < 2; i++)
         {
            obj = GameObject.Instantiate(m_Fish2_Right, pos2_R1, Quaternion.identity) as GameObject;
            obj.transform.SetParent(FishBox.transform);
            yield return new WaitForSeconds(1f);
            obj = GameObject.Instantiate(m_Fish2_Left, pos2_L1, Quaternion.identity) as GameObject;
            obj.transform.SetParent(FishBox.transform);
            yield return new WaitForSeconds(1f);
            obj = GameObject.Instantiate(m_Fish2_Right, pos2_R2, Quaternion.identity) as GameObject;
            obj.transform.SetParent(FishBox.transform);
            yield return new WaitForSeconds(1f);
            obj = GameObject.Instantiate(m_Fish2_Left, pos2_L2, Quaternion.identity) as GameObject;
            obj.transform.SetParent(FishBox.transform);
            yield return new WaitForSeconds(1f);
         }
         yield return new WaitForSeconds(2);
         
         //混合出场位置
         Vector2 pos1_FR1 = new Vector2(0.8f, 3);
         Vector2 pos1_FR2 = new Vector2(1.4f, 3);
         Vector2 pos1_FR3 = new Vector2(2, 3);
         Vector2 pos2_FR = new Vector2(1.1f, 3.6f);

         Vector2 pos1_FL1 = new Vector2(-2, 3);
         Vector2 pos1_FL2 = new Vector2(-1.4f, 3);
         Vector2 pos1_FL3 = new Vector2(-0.8f, 3);
         Vector2 pos2_FL = new Vector2(-1.1f, 3.6f);

    
        //Fish1和Fish2混合出场
        for (int i = 0; i < 4; i++)
        {
            obj = GameObject.Instantiate(m_Fish1_Fixation_Left, pos1_FL1 + new Vector2(i % 2 * 0.3f, i * 0.3f), Quaternion.identity) as GameObject;
            obj.transform.SetParent(FishBox.transform);
            obj = GameObject.Instantiate(m_Fish1_Fixation_Right, pos1_FR1 + new Vector2(i % 2 * 0.3f, i * 0.3f), Quaternion.identity) as GameObject;
            obj.transform.SetParent(FishBox.transform);
            yield return new WaitForSeconds(0.3f);
            obj = GameObject.Instantiate(m_Fish1_Fixation_Left, pos1_FL2 + new Vector2(i % 2 * 0.3f, i * 0.3f), Quaternion.identity) as GameObject;
            obj.transform.SetParent(FishBox.transform);
            obj = GameObject.Instantiate(m_Fish1_Fixation_Right, pos1_FR2 + new Vector2(i % 2 * 0.3f, i * 0.3f), Quaternion.identity) as GameObject;
            obj.transform.SetParent(FishBox.transform);
            yield return new WaitForSeconds(0.3f);
            if (i == 0 || i == 2)
            {
                obj = GameObject.Instantiate(m_Fish1_Fixation_Left, pos1_FL3 + new Vector2(i % 2 * 0.3f, i * 0.3f), Quaternion.identity) as GameObject;
                obj.transform.SetParent(FishBox.transform);
                obj = GameObject.Instantiate(m_Fish1_Fixation_Right, pos1_FR3 + new Vector2(i % 2 * 0.3f, i * 0.3f), Quaternion.identity) as GameObject;
                obj.transform.SetParent(FishBox.transform);
            }
            if (i == 2)
            {
                obj = GameObject.Instantiate(m_Fish2_Fixation, pos2_FL, Quaternion.identity) as GameObject;
                obj.transform.SetParent(FishBox.transform);
                obj = GameObject.Instantiate(m_Fish2_Fixation, pos2_FR, Quaternion.identity) as GameObject;
                obj.transform.SetParent(FishBox.transform);
            }
        }
         yield return new WaitForSeconds(12);

         //跟前4波相同的生成但同时进行
         for (int j = 0; j < 6; j++)
         {
             if (j == 3)
             {
                 yield return new WaitForSeconds(0.15f);
             }
             //右边杂鱼
             obj = GameObject.Instantiate(m_Fish1_Right, pos1_R1 + new Vector2(Random.Range(-0.2f, 0.2f) - 0.3f, 0), Quaternion.identity) as GameObject;
             obj.transform.SetParent(FishBox.transform);
             obj = GameObject.Instantiate(m_Fish1_Right, pos1_R2 + new Vector2(Random.Range(-0.2f, 0.2f) - 0.3f, 0), Quaternion.identity) as GameObject;
             obj.transform.SetParent(FishBox.transform);
             //左边杂鱼
             obj = GameObject.Instantiate(m_Fish1_Left, pos1_L1 + new Vector2(Random.Range(-0.2f, 0.2f) + 0.3f, 0), Quaternion.identity) as GameObject;
             obj.transform.SetParent(FishBox.transform);
             obj = GameObject.Instantiate(m_Fish1_Left, pos1_L2 + new Vector2(Random.Range(-0.2f, 0.2f) + 0.3f, 0), Quaternion.identity) as GameObject;
             obj.transform.SetParent(FishBox.transform);
             yield return new WaitForSeconds(1f);
         }

         yield return new WaitForSeconds(0.5f);

        //开启携程
        StartCoroutine("CreateFish2");
        //旋转杂鱼
        for (int i = 0; i < 9; i++)
        {
            obj = GameObject.Instantiate(m_Fish_Rotation_Right, posR_R, Quaternion.identity) as GameObject;
            obj.transform.SetParent(FishBox.transform);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 9; i++)
        {
            obj = GameObject.Instantiate(m_Fish_Rotation_Left, posR_L, Quaternion.identity) as GameObject;
            obj.transform.SetParent(FishBox.transform);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.2f);

        
        posR_R = new Vector2(2.5f, 0.6f);
        posR_L = new Vector2(-2.5f, 1f);
        
        for (int i = 0; i < 7; i++)
        {
            obj = GameObject.Instantiate(m_Fish_Rotation_Right, posR_R, Quaternion.identity) as GameObject;
            obj.transform.SetParent(FishBox.transform);
            yield return new WaitForSeconds(0.1f);
        }
        for (int i = 0; i < 7; i++)
        {
            obj = GameObject.Instantiate(m_Fish_Rotation_Left, posR_L, Quaternion.identity) as GameObject;
            obj.transform.SetParent(FishBox.transform);
            yield return new WaitForSeconds(0.1f);
        }
        
        yield return new WaitForSeconds(0.2f);

        posR_R = new Vector2(2.5f, 0.8f);
        posR_L = new Vector2(-2.5f, 0.8f);

        for (int i = 0; i < 4; i++)
        {
            if (i == 3)
            {
                obj = GameObject.Instantiate(m_Fish_Rotation_Right, posR_R, Quaternion.identity) as GameObject;
                obj.transform.SetParent(FishBox.transform);
            }
            else
            {
                obj = GameObject.Instantiate(m_Fish_Rotation_Right, posR_R, Quaternion.identity) as GameObject;
                obj.transform.SetParent(FishBox.transform);
                obj = GameObject.Instantiate(m_Fish_Rotation_Left, posR_L, Quaternion.identity) as GameObject;
                obj.transform.SetParent(FishBox.transform);
            }
            yield return new WaitForSeconds(0.1f);
        }
        StopCoroutine("CreateFish2");

        yield return new WaitForSeconds(5f);

        GameObject.Find("Cameranear").GetComponent<CameraMove>().Speed = 16;
        GameObject.Find("Cameranear").GetComponent<CameraMove>().ifRotate = true;


        yield return new WaitForSeconds(3f);

        GameObject.Find("Cameranear").GetComponent<CameraMove>().Speed = 8;
        GameObject.Find("Cameranear").GetComponent<CameraMove>().ifRotate = false;

        obj = GameObject.Instantiate(m_Qruno, new Vector2(-2.5f,2), Quaternion.identity) as GameObject;
        obj.transform.SetParent(BossBox.transform);
        
        yield return new WaitForSeconds(1.5f);
        
        //开启对话ui
        UiFlg = 1;
    }




    /// <summary>
    /// 旋转杂鱼的时候生成的f2
    /// </summary>
    /// <returns></returns>
    private IEnumerator CreateFish2()
    {
        //Fish2的出生位置
        Vector2 pos2_R1 = new Vector2(0.5f, 3.5f);
        Vector2 pos2_R2 = new Vector2(1.5f, 3.5f);
        Vector2 pos2_L1 = new Vector2(-1.5f, 3.5f);
        Vector2 pos2_L2 = new Vector2(-0.5f, 3.5f);

        //生成Fish2
        for (int i = 0; i < 2; i++)
        {
            obj = GameObject.Instantiate(m_Fish2_Right, pos2_R1, Quaternion.identity) as GameObject;
            obj.transform.SetParent(FishBox.transform);
            yield return new WaitForSeconds(1);
            obj = GameObject.Instantiate(m_Fish2_Left, pos2_L1, Quaternion.identity) as GameObject;
            obj.transform.SetParent(FishBox.transform);
            yield return new WaitForSeconds(1);
            obj = GameObject.Instantiate(m_Fish2_Right, pos2_R2, Quaternion.identity) as GameObject;
            obj.transform.SetParent(FishBox.transform);
            yield return new WaitForSeconds(1);
            obj = GameObject.Instantiate(m_Fish2_Left, pos2_L2, Quaternion.identity) as GameObject;
            obj.transform.SetParent(FishBox.transform);
            yield return new WaitForSeconds(1);
        }
    }


    private void Ui21()
    {
        m_Dialogue.SetActive(true);
        m_ReimuFace.GetComponent<Image>().sprite = ReimuBother;
        m_Qruno_Painting.SetActive(false);
        m_Dialogue_Text.GetComponent<Text>().text = "看来得继续前进了...";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (UiFlg > 0)
            {
                if (m_Dialogue.activeSelf && UiFlg !=4&&UiFlg!=22)
                {
                    UiFlg++;
                    UiRun = 1;
                }
                if(UiFlg==4)
                {
                    m_Dialogue.SetActive(false);
                    //开启琪露诺的攻击并切换bgm
                    FishBox.GetComponent<AudioSource>().clip = PowerAndWisdom;
                    FishBox.GetComponent<AudioSource>().Play();
                    GameObject.Find("Qruno(Clone)").GetComponent<Qruno>().Qflg = 0;
                    UiFlg=10;
                }
            }
        }

        if (UiFlg == 1&&UiRun==1)
        {
            UiRun = 0;
            m_Dialogue.SetActive(true);
            m_Dialogue_Text.GetComponent<Text>().color = Red_Color;
            m_Dialogue_Text.GetComponent<Text>().text = "欸欸,这里可是博丽神社啊,怎么会有冰之妖精在这里?";
            m_Reimu_Painting.transform.Translate(RightUp * 20);
        }
        if (UiFlg==2 && UiRun == 1)
        {
            UiRun = 0;
            m_Dialogue_Text.GetComponent<Text>().color = Blue_Color;
            m_Dialogue_Text.GetComponent<Text>().text = "...呜哇,灵梦回来啦,我该怎么办啊..啊啊,不管了那我就先发制人吧!";
            m_Reimu_Painting.transform.Translate(LeftDown * 20);
            m_Qruno_Painting.transform.Translate(LeftUp * 20);
        }
        if (UiFlg == 3 && UiRun == 1)
        {
            UiRun = 0;
            m_ReimuFace.GetComponent<Image>().sprite = ReimuSpeechless;
            m_Dialogue_Text.GetComponent<Text>().color = Red_Color;
            m_Dialogue_Text.GetComponent<Text>().text = "等,等等啊喂!";
            m_Reimu_Painting.transform.Translate(RightUp * 20);
            m_Qruno_Painting.transform.Translate(RightDown * 20);
        }
        if (UiFlg==21)
        {
            if (UiRun==1)
            {
                UiRun = 0;

                Invoke("Ui21", 1.5f);
            }

            if (BGRenderer.color.r < 1)
            {
                BGRenderer.color = new Color(BGRenderer.color.r + 0.01f, BGRenderer.color.g + 0.01f, BGRenderer.color.b + 0.01f);
            }

        }
        if (UiFlg == 22&&UiRun==1)
        {
            //结算界面
            GameOverUiWin.SetActive(true);
            UiRun = 0;
            Debug.Log("5555555");
        }

        if (ifEscUi)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {   
                ifEscUi = false;
                Esc.Play();
                FishBox.GetComponent<AudioSource>().Pause();
                Time.timeScale = 0;
                EscUI.SetActive(true);
            }
        }


    }
     public void UseStartClean()
    {
        StartCoroutine("CleanAllBullet");
    }



    private IEnumerator CleanAllBullet()
    {

        GameObject[] bullets;

        float m_Time = Time.time;
        while (Time.time - m_Time < 2f)
        {

            bullets = GameObject.FindGameObjectsWithTag("RedRedBullet");
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i].GetComponent<RedRedBullet>().MyDestroy();
            }
            bullets = GameObject.FindGameObjectsWithTag("RedNeedle");
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i].GetComponent<RedNeedle>().MyDestroy();
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
            bullets = GameObject.FindGameObjectsWithTag("Bullet");
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i].GetComponent<Bullet>().MyDestroy();
            }
            bullets = GameObject.FindGameObjectsWithTag("Needle");
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i].GetComponent<Needle>().MyDestroy();
            }
            bullets = GameObject.FindGameObjectsWithTag("IceRotation");
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i].GetComponent<IceRotationMove>().MyDestroy();
            }
            bullets = GameObject.FindGameObjectsWithTag("IceNeedle");
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i].GetComponent<IceNeedle>().MyDestroy();
            }
            bullets = GameObject.FindGameObjectsWithTag("Ice");
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i].GetComponent<Ice>().MyDestroy();
            }
            bullets = GameObject.FindGameObjectsWithTag("Pill");
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i].GetComponent<Pill>().MyDestroy();
            }
            yield return new WaitForSeconds(0.125f);
        }
        StopCoroutine("CleanAllBullet");

    }

}



