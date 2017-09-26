using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIButtonListerner : MonoBehaviour
{
    //enum UIbutton{START,OPTION,QUIT};
    //UIbutton mybutton = 0;

    public Text[] mytext;
    public GameObject[] Particles;
    public GameObject HelpUi;
    [Range(0, 8)] public int nowposition = 0;

    public AudioSource aduio01;
    public AudioSource aduio02;

    private AsyncOperation async;

    public Image m_Loading;

    public bool onMenu = true;
    public GameObject P04;
    // Use this for initialization
    void Start()
    {
        //Screen.SetResolution(1024, 768, true);
        HighlightButton(0);
        for (int i = 1; i <= 2; i++)
        {
            Particles[i].SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (onMenu)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {

                if (nowposition == 0)
                {
                    //开始按钮
                    StartCoroutine("loadScene","1");

                    aduio02.Play();
                }
                else if (nowposition == 1)
                {
                    //帮助
                    aduio02.Play();
                    onMenu = false;
                    HelpUi.SetActive(true);
                    P04.SetActive(true);

                }
                else if (nowposition == 2)
                {
                    //退出按钮
                    Application.Quit();
                    aduio02.Play();
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
                    nowposition -= 1;
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
                        //帮助
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
            Particles[x].SetActive(false);
        }
    }
    void HighlightButton(int x)
    {
        if (nowposition == x)
        {

            mytext[x].fontSize = 32;
            Particles[x].SetActive(true);
        }
    }

    //注意这里返回值一定是 IEnumerator
    IEnumerator loadScene(string Name)
    {

        yield return new WaitForEndOfFrame();//加上这么一句就可以先显示加载画面然后再进行加载 
        m_Loading.enabled = true;
        onMenu = false;
        yield return new WaitForSeconds(2f);
        async = SceneManager.LoadSceneAsync(Name);

        //读取完毕后返回， 系统会自动进入C场景    
        yield return async;


    }


}
