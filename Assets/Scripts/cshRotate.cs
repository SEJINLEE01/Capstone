using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshRotate : MonoBehaviour
{
    public Transform Element;
    public float speed;
    public Vector3 direction;

    private void Update()
    {
        transform.RotateAround(Element.position, direction, speed * Time.deltaTime);
    }
}
