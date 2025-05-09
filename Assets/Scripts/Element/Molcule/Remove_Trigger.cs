using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove_Trigger : MonoBehaviour
{
    public Spawn_Trigger trigger;

    public void Remove_trigger()
    {
        Destroy(trigger.t);
    }
}
