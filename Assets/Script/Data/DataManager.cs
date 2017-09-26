using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DataManager : MonoBehaviour {

    public int HiScore;
    public int Score;
    public int player;
    public int Boob;
    public int Power;

    public Image[] playerNum = new Image[8];
    public Image[] BoobNum = new Image[8];
    private GameObject m_Reimu;

    private Vector3 reimuPos=new Vector3(0,-2,0.1f);

    //灵梦是否存活
    public bool ifReimuLife = true;

    public bool AddReimuLife = false;

    //是否用了炸弹
    public bool ifBoob = false;

    public bool ifAddBoob = false;

    //游戏结束的ui
    public GameObject GameOverUi;
    private GameObject FishBox;
    public AudioClip GameOverAudio;

    // Use this for initialization
    void Start () {

        m_Reimu = Resources.Load("Reimu")as GameObject;
        FishBox = GameObject.Find("FishBox");

        //初始化残机和炸弹
        SetPlayer();
        SetBoob();

	}
	
	// Update is called once per frame
	void Update () {

        //自机死亡
        if (ifReimuLife==false)
        {
            if (player>0)
            {
                DeletePlayer();
                Boob = 3;
                SetBoob();
                ifReimuLife = true;
                Invoke("CreateReimu", 1);
            }
            else
            {
                //gameover
                Invoke("GameOver", 1f);
            }
        }

        //增加残机
        if (AddReimuLife)
        {
            AddReimuLife = false;
            AddPlayer();
        }

        //使用了Boob
        if (ifBoob)
        {
            ifBoob = false;
            UseBoob();
        }
		
	}

    /// <summary>
    /// 初始化残机
    /// </summary>
    private void SetPlayer()
    {
        for (int i = 0; i < player; i++)
        {
            playerNum[i].enabled = true;
        }
    }

    /// <summary>
    /// 残机-1
    /// </summary>
    private void DeletePlayer()
    {
        player--;
        playerNum[player].enabled = false;
    }

    /// <summary>
    /// 残机+1
    /// </summary>
    private void AddPlayer()
    {
        player++;
        playerNum[player-1].enabled = true;
    }

    /// <summary>
    /// 初始化Boob
    /// </summary>
    private void SetBoob()
    {
        for (int i = 0; i < Boob; i++)
        {
            BoobNum[i].enabled = true;
        }
    }

    /// <summary>
    ///  使用Boob
    /// </summary>
    private void UseBoob()
    {
        Boob--;
        BoobNum[Boob].enabled = false;
    }

    /// <summary>
    /// Boob+1
    /// </summary>
    private void AddBoob()
    {
        Boob++;
        playerNum[Boob - 1].enabled = true;
    }
    //游戏结束
    private void GameOver()
    {
        Time.timeScale = 0;
        FishBox.GetComponent<AudioSource>().clip = GameOverAudio;
        FishBox.GetComponent<AudioSource>().Play();
        GameOverUi.SetActive(true);
    }




    private void CreateReimu()
    {
        GameObject.Instantiate(m_Reimu, reimuPos, Quaternion.identity);
    }
}
