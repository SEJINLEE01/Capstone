using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Molcule_Trigger : MonoBehaviour
{
    public GameObject[] Atom;
    int count = 0;
    public Transform[] ToObj;
    public Transform[] FromObj;
    List<Vector3> direction;
    private float speed=0.25f;
    [HideInInspector]
    public bool isTrigger = false;
    bool isActive = false;

    private float elapsedTime = 0f; // 경과 시간
    public float duration; // 이동 시간 (1초)
    bool isMoving = true;
    private void Start()
    {
        direction = new List<Vector3>();
        for(int i =0; i<ToObj.Length; i++)
        {
            direction.Add((ToObj[i].position - FromObj[i].position).normalized);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        foreach (var atom in Atom)
        {
            if (other.CompareTag(atom.name))
            {
                if (!atom.activeSelf)
                {
                    if(count == Atom.Length-1)
                    {
                        StartCoroutine(DelayRoutine());
                    }
                    atom.SetActive(true);
                    count++;
                    break;
                }
            }
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (var atom in Atom)
        {
            if (other.CompareTag(atom.name))
            {
                if (atom.activeSelf)
                {
                    atom.SetActive(false);
                    count--;
                    break;
                }
            }
        }
    }

    private void Update()
    {
        if (count == Atom.Length && isActive)
        {
            if (isMoving)
            {
                // 경과 시간 업데이트
                elapsedTime += Time.deltaTime;

                if (elapsedTime >= duration)
                {
                    isMoving = false;
                }
                for (int i = 0; i < ToObj.Length; i++)
                {
                    FromObj[i].Translate(direction[i] * speed * Time.deltaTime);
                }
            }
            else
            {
                isTrigger = true;
            }
        }
    }

    IEnumerator DelayRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        isActive = true;
    }
}
