using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImove : MonoBehaviour
{
    public GameObject MainUI;
    public GameObject NextUI;
    public GameObject[] ScaleBtn1;
    public GameObject[] ScaleBtn2;
    public GameObject[] ScaleBtn3;
    public void goNext()
    {
        MainUI.SetActive(false);
        NextUI.SetActive(true);
        foreach (GameObject obj in ScaleBtn1)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in ScaleBtn2)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in ScaleBtn3)
        {
            obj.SetActive(false);
        }
    }

    
}

