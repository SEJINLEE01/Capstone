using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    public Transform ToObj;
    public Transform FromObj;
    public Molcule_Trigger Trigger;
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
        if(dt<Mathf.Cos(29f * Mathf.Deg2Rad) && dt>Mathf.Cos(31f * Mathf.Deg2Rad) && action)
        {
            if(!OnTarget && direction.y > direction2.y)
                GetComponent<cshRotate>().enabled = false;
            if (OnTarget && direction.y < direction2.y)
                GetComponent<cshRotate>().enabled = false;
        }
    }
}
