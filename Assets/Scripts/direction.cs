using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class direction : MonoBehaviour
{
    public Transform H;
    public Transform C;
    public Vector3 D;
    

    void Start()
    {
        D = H.position - C.position;
        D = D.normalized;
        transform.rotation = Quaternion.LookRotation(D);
    }
}
