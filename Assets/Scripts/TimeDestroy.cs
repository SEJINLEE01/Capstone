using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimeDestroy : MonoBehaviour
{
    public float DestroyTime;

    private void Start()
    {
        Destroy(gameObject,DestroyTime);
    }
}
