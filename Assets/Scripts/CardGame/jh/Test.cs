using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject Molo;


    public void btntest()
    {
        if (Molo.tag == "H2O")
        {
            Debug.Log("Hello");
        }
        if(Molo.tag == "CH4")
        {
            Debug.Log ("bye");
        }
    }

}
