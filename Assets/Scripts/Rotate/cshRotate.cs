using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshRotate : MonoBehaviour
{
    public Vector3 direction;
    public Transform Element;
    public float speed;

    private void Update()
    {
        transform.RotateAround(Element.position,direction , speed * Time.deltaTime);
    }

}
