using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshRotate : MonoBehaviour
{
    public Transform Element;
    public float speed;

    private void Update()
    {
        transform.RotateAround(Element.position, Element.up, speed * Time.deltaTime);
    }
}
