using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIButtonListerner2 : MonoBehaviour {


    public Text[] mytext;
    [Range(0, 8)] public int nowposition = 0;

    public AudioSource aduio01;
    public AudioSource aduio02;

    private AsyncOperation async;

    public Image m_Loading;

    public GameObject EscUI;

    private GameObject FishBox;


    private bool onMenu = true;
    // Use this for initialization
    void Start()
    {
        HighlightButton(0);
        FishBox = GameObject.Find("FishBox");

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
                FishBox.GetComponent<AudioSource>().Play();
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
                else if (nowposition == 2)
                {
                    //返回
                    aduio02.Play();
                    Time.timeScale = 1;
                    GameObject.Find("BG").GetComponent<MapManager>().ifEscUi = true;
                    FishBox.GetComponent<AudioSource>().Play();
                    EscUI.SetActive(false);
                }

            }

            if (nowposition < 2)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    nowposition += 1;
                    aduio01.Play();

                    if (nowposition == 0)
                    {
                        //开始按钮

                        UnHighlightButton(1);
                        UnHighlightButton(2);
                        HighlightButton(0);

                    }
                    else if (nowposition == 1)
                    {
                        //选项按钮
                        UnHighlightButton(0);
                        UnHighlightButton(2);
                        HighlightButton(1);


                    }
                    else if (nowposition == 2)
                    {
                        //退出按钮
                        UnHighlightButton(1);
                        UnHighlightButton(0);
                        HighlightButton(2);
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
                        UnHighlightButton(2);
                        HighlightButton(0);

                    }
                    else if (nowposition == 1)
                    {
                        //选项按钮
                        UnHighlightButton(0);
                        UnHighlightButton(2);
                        HighlightButton(1);


                    }
                    else if (nowposition == 2)
                    {
                        //退出按钮
                        UnHighlightButton(1);
                        UnHighlightButton(0);
                        HighlightButton(2);
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

    //注意这里返回值一定是 IEnumerator
    IEnumerator loadScene(string Name)
    {

        m_Loading.enabled = true;
        onMenu = false;
        yield return new WaitForSeconds(2f);
        //异步读取场景。
        //Globe.loadName 就是A场景中需要读取的C场景名称。
        async = SceneManager.LoadSceneAsync(Name);

        //读取完毕后返回， 系统会自动进入C场景
        yield return async;
    }


}
