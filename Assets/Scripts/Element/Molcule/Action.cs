using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    public Transform ToObj;
    public Transform FromObj;
    public Molcule_Trigger Trigger;
    public GameObject[] electrons;
    public float Degree;
    Vector3 direction;
    Vector3 direction2;
    bool action = false;
    public bool OnTarget = false;
    private void Update()
    {
        action = Trigger.isTrigger;
        direction = (ToObj.position - FromObj.position).normalized;
        direction2 = (transform.position - FromObj.position).normalized;
        float dt = Vector3.Dot(direction, direction2);
        if(dt<Mathf.Cos((Degree-1f) * Mathf.Deg2Rad) && dt>Mathf.Cos((Degree+1f) * Mathf.Deg2Rad) && action)
        {
            if(!OnTarget && direction.y > direction2.y)
            {
                if (electrons.Length > 0)
                {
                    foreach (var electron in electrons)
                    {
                        electron.GetComponent<cshRotate>().enabled = false;
                    }
                }
            }

            if (OnTarget && direction.y < direction2.y)
            {
                if (electrons.Length > 0)
                {
                    foreach (var electron in electrons)
                    {
                        electron.GetComponent<cshRotate>().enabled = false;
                    }
                }
            }

            
        }
    }
}
