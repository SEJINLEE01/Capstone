using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleMove : MonoBehaviour
{
    public GameObject scale;
    public bool isScale = false;
    // Start is called before the first frame update
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "H")
        {
           
            isScale = true;
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        isScale = false;
    }


}
