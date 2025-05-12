using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnScale : MonoBehaviour
{
    public GameObject scale1;
    public GameObject scale2;
    public ScaleMove ScaleMove;
    public ScaleMove2 ScaleMove2;

   public void cmpScale()
    {
         if (ScaleMove.isScale == true && ScaleMove2.isScale2 == true)
        {
            scale1.transform.position = new Vector3(scale1.transform.position.x, 1.5f, scale1.transform.position.z);
            scale2.transform.position = new Vector3(scale2.transform.position.x, 1.5f, scale2.transform.position.z);

        }
        else if (ScaleMove.isScale == true)
        {
            scale1.transform.position = new Vector3(scale1.transform.position.x, 1.5f, scale1.transform.position.z);
          
        }
        else if (ScaleMove2.isScale2 == true) {

            scale2.transform.position = new Vector3(scale2.transform.position.x,1.5f, scale2.transform.position.z); 

          }
       
        else
        {
           ScaleMove.isScale = false;
            ScaleMove2.isScale2 = false;
            scale1.transform.position = new Vector3(scale1.transform.position.x, 1.6f, scale1.transform.position.z);
            scale2.transform.position = new Vector3(scale2.transform.position.x, 1.6f, scale2.transform.position.z);
        }
    }



}
