using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleMove : MonoBehaviour
{
    public GameObject Scale1;






    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "H")
        {
            Scale1.transform.position = new Vector3(Scale1.transform.position.x, 0.5f, Scale1.transform.position.z);
        }
    }

}
