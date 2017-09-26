using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject m_Bullet;


    // Use this for initialization
    void Start () {

        

    }
	
	// Update is called once per frame
	void Update () {

        this.transform.Translate(new Vector2(1, 0) * Time.deltaTime * 2f, Space.Self);

        if (m_Bullet.transform.position.x > 3.5 || m_Bullet.transform.position.x < -3.5 || m_Bullet.transform.position.y < -4 || m_Bullet.transform.position.y > 4)
        {
            MyDestroy();
        }

    }

    public void MyDestroy()
    {
        Destroy(m_Bullet);
    }



    /// <summary>
    /// 改变子弹朝向
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="pos"></param>
    public static void ChangeDirection(GameObject obj,Vector3 pos)
    {
        if (obj.transform.position.x == pos.x)
        {
            if (obj.transform.position.y > pos.y)
            {
                obj.transform.Rotate(new Vector3(0, 0, -90));
            }
            else obj.transform.Rotate(new Vector3(0, 0, 90));
        }
        else
        {
            obj.transform.LookAt(pos);
            obj.transform.Rotate(new Vector3(0, -90));
        }
    }

    /// <summary>
    /// 改变子弹朝向(向下运动版本)
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="pos"></param>
    public static void ChangeDirectionDown(GameObject obj, Vector3 pos)
    {
        if (obj.transform.position.x == pos.x)
        {
            if (obj.transform.position.y > pos.y)
            {
                obj.transform.Rotate(new Vector3(0, 0, -180));
            }
        }
        else
        {
            obj.transform.LookAt(pos);
            obj.transform.Rotate(new Vector3(0, -90,90));
        }
    }
}
