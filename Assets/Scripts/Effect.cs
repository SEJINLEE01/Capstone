using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public float time;
    void Start()
    {
        Destroy(gameObject,time);
    }

}
