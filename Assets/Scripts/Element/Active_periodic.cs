using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_periodic : MonoBehaviour
{
    public GameObject table;

    public void ButtonClick(){
        if(!table.activeSelf)
            table.SetActive(true);
        else
            table.SetActive(false);
    }
}
