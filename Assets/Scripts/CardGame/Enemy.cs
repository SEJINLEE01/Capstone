using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 1f;      // 속도
    public float move = 0.3f; // 위아래 움직이는 거리

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * Speed) * move;
        transform.position = startPos + new Vector3(0, newY, 0);
    }
}
