using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Trigger : MonoBehaviour
{
    public GameObject Trigger;
    public Transform SpawnPoint;
    [HideInInspector]
    public GameObject t;
    public void trigger_spawn()
    {
        t = Instantiate(Trigger,SpawnPoint.position,Quaternion.identity);
    }
}
