using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour {


    public Text[] mytext;
    [Range(0, 8)] public int nowposition = 0;

    public AudioSource aduio01;
    public AudioSource aduio02;

    private AsyncOperation async;


    public GameObject EscUI;


    private bool onMenu = true;
    // Use this for initialization
    void Start()
    {
        HighlightButton(0);

    }

    // Update is called once per frame
    void Update()
    {
        if (onMenu)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //返回
                aduio02.Play();
                Time.timeScale = 1;
                GameObject.Find("BG").GetComponent<MapManager>().ifEscUi = true;
                EscUI.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {

                if (nowposition == 0)
                {
                    //重新开始
                    aduio02.Play();
                    Time.timeScale = 1;
                    SceneManager.LoadScene("1");
                }
                else if (nowposition == 1)
                {
                    //返回主菜单
                    aduio02.Play();
                    Time.timeScale = 1;
                    SceneManager.LoadScene("2DUI");
                    //StartCoroutine("loadScene", "2DUI");

                }

            }

            if (nowposition < 1)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    nowposition += 1;
                    aduio01.Play();

                    if (nowposition == 0)
                    {
                        //开始按钮

                        UnHighlightButton(1);
                        HighlightButton(0);

                    }
                    else if (nowposition == 1)
                    {
                        //选项按钮
                        UnHighlightButton(0);
                        HighlightButton(1);


                    }
                }
            }
            if (nowposition > 0)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    aduio01.Play();
                    nowposition -= 1;

                    if (nowposition == 0)
                    {
                        //开始按钮
                        UnHighlightButton(1);
                        HighlightButton(0);

                    }
                    else if (nowposition == 1)
                    {
                        //选项按钮
                        UnHighlightButton(0);
                        HighlightButton(1);


                    }
                }
            }
        }

    }
    void UnHighlightButton(int x)
    {
        if (nowposition != x)
        {

            mytext[x].fontSize = 24;
        }
    }
    void HighlightButton(int x)
    {
        if (nowposition == x)
        {

            mytext[x].fontSize = 32;
        }
    }
}
