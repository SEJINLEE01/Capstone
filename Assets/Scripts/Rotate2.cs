using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Element;
    public float speed;

    private void Update()
    {
        transform.RotateAround(Element.position, Vector3.left, speed * Time.deltaTime);
    }
}
