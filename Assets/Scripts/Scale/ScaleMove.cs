using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleMove : MonoBehaviour
{
    public GameObject scale;
    // Start is called before the first frame update
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "H")
        {
            scale.transform.position=new Vector3(scale.transform.position.x,0.8f,scale.transform.position.z);   
        }
    }
   


}
