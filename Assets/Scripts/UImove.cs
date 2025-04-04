using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImove : MonoBehaviour
{
    public GameObject MainUI;
    public GameObject NextUI;

    public void goNext()
    {
        MainUI.SetActive(false);
        NextUI.SetActive(true);
    }

    
}

