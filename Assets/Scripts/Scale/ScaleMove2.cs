using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleMove2 : MonoBehaviour
{
    public GameObject scale2;
    public bool isScale2 = false;
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "He")
        {
            isScale2 = true;
          
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        isScale2=false;
    }
}
