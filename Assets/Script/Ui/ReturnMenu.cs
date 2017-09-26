using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnMenu : MonoBehaviour {

    public GameObject m_Help;
    public AudioSource audio1;
    public GameObject P04;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            BackMenu();
        }
    }


    public void BackMenu()
    {
        audio1.Play();
        GameObject.Find("Menu").GetComponent<UIButtonListerner>().onMenu = true;
        P04.SetActive(false);
        m_Help.SetActive(false);
    }
}
