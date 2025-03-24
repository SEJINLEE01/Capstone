using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element_Select : MonoBehaviour
{
    public void OnSelectExited()
    {
        GetComponent<Rigidbody>().useGravity = true;
    }
}
