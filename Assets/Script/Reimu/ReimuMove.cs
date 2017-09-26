using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReimuMove : MonoBehaviour {

    Transform Reimu;

    public GameObject DecisionPoint;

    float leftNoMove = -2.2f;
    float RightNoMove = 2.2f;
    float UpNoMove = 2.6f;
    float DownNoMove = -2.6f;

    private int hMove_Flg;
    private int vMove_Flg;

    // Use this for initialization
    void Start()
    {
        //默认站立动画
        Reimu = this.transform;

    }

    /// <summary>
    /// 左移动动画
    /// </summary>
    void Left()
    {
        Reimu.GetComponent<Animator>().Play("left");
    }

    /// <summary>
    /// 左移动结束动画
    /// </summary>
    void LeftDown()
    {
        Reimu.GetComponent<Animator>().Play("leftDown");
    }

    /// <summary>
    /// 右移动动画
    /// </summary>
    void Right()
    {
        Reimu.GetComponent<Animator>().Play("right");
    }

    /// <summary>
    /// 右移动结束动画
    /// </summary>
    void RightDown()
    {
        Reimu.GetComponent<Animator>().Play("rightDown");
    }
    // Update is ca{lled once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            DecisionPoint.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            DecisionPoint.GetComponent<SpriteRenderer>().enabled = false;
        }

        //通过状态实现移动的切换
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            hMove_Flg = 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            hMove_Flg = 2;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            vMove_Flg = 1;

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            vMove_Flg = 2;

        }


        if (hMove_Flg==1)
        {
            //左移动
            if (Input.GetKey(KeyCode.LeftArrow)&& Reimu.position.x>leftNoMove)
            {
                Left();
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    Reimu.Translate(Vector2.left * Time.deltaTime * 1.5f);
                }
                else
                {
                    Reimu.Translate(Vector2.left * Time.deltaTime * 3);
                }
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                LeftDown();

                if (Input.GetKey(KeyCode.RightArrow))
                {
                    hMove_Flg = 2;
                }
            }

        }
        if (hMove_Flg == 2)
        {
            //右移动
            if (Input.GetKey(KeyCode.RightArrow)&&Reimu.position.x<RightNoMove)
            {
                Right();
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    Reimu.Translate(Vector2.right * Time.deltaTime * 1.5f);
                }
                else
                {
                    Reimu.Translate(Vector2.right * Time.deltaTime * 3);
                }
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                RightDown();

                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    hMove_Flg = 1;
                }
            }
        }
        if (vMove_Flg == 1)
        {
            //上移动
            if (Input.GetKey(KeyCode.UpArrow) && Reimu.position.y<UpNoMove)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    Reimu.Translate(Vector2.up * Time.deltaTime * 1.5f);
                }
                else
                {
                    Reimu.Translate(Vector2.up * Time.deltaTime * 3);
                }

            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {

                if (Input.GetKey(KeyCode.DownArrow))
                {
                    vMove_Flg = 2;
                }
            }

        }
        if (vMove_Flg == 2)
        {
            //下移动
            if (Input.GetKey(KeyCode.DownArrow) && Reimu.position.y>DownNoMove)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    Reimu.Translate(Vector2.down * Time.deltaTime * 1.5f);
                }
                else
                {
                    Reimu.Translate(Vector2.down * Time.deltaTime * 3);
                }
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {

                if (Input.GetKey(KeyCode.UpArrow))
                {
                    vMove_Flg = 1;
                }
            }
        }










    }
}
