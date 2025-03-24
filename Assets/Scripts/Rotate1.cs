using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate1 : MonoBehaviour
{
    public Transform Element;
    public float speed;

    private void Update()
    {
        transform.RotateAround(Element.position, Vector3.up, speed * Time.deltaTime);
    }


}
