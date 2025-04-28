using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;


public class Molcule_Ionic_Trigger : MonoBehaviour
{
    public GameObject[] Atom;
    int count = 0;
    public Transform[] ToObj;
    public Transform[] FromObj;
    public float DelayTime;
    
    public float speed;
    [HideInInspector]
    public bool isTrigger = false;
    [HideInInspector]
    public bool isActive = false;

    public Ionic_Action[] action;
    public eMove_Trigger eMove_Trigger;
    int isEnd = 0;
    
    private float elapsedTime = 0f; // ��� �ð�
    public float duration; // �̵� �ð� (1��)
    bool isMoving = true;
    
    private void OnTriggerEnter(Collider other)
    {
        foreach (var atom in Atom)
        {
            if (other.CompareTag(atom.name))
            {
                if (!atom.activeSelf)
                {
                    if (count == Atom.Length - 1)
                    {
                        isTrigger = true;
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
                // ��� �ð� ������Ʈ
                elapsedTime += Time.deltaTime;

                if (elapsedTime >= duration)
                {
                    isMoving = false;
                }
                for (int i = 0; i < ToObj.Length; i++)
                {
                    Vector3 direction = ToObj[i].position - FromObj[i].position;
                    float distance = direction.magnitude;
                    direction.Normalize();

                    float Strength = speed / (distance * distance);
                    FromObj[i].Translate(direction* Strength * Time.deltaTime, Space.World);
                }
            }
            else
            {
                
            }
        }
    }

    IEnumerator DelayRoutine()
    {
        yield return new WaitForSeconds(DelayTime);
        eMove_Trigger.active = true;
    }

    public void IsEnd()
    {
        isEnd++;
        if (action.Length == isEnd)
        {
            StartCoroutine(DelayRoutine());
        }
    }
}

