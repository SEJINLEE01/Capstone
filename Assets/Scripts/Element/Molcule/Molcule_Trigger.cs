using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class Molcule_Trigger : MonoBehaviour
{
    public GameObject[] Atom;
    int count = 0;
    int count2 = 0;
    public Transform[] ToObj;
    public Transform[] FromObj;
    public float DelayTime;
    List<Vector3> direction;
    float speed=0.025f;
    [HideInInspector]
    public bool isTrigger = false;
    bool isActive = false;
    [HideInInspector]
    public List<GameObject> EnterAtom = new List<GameObject>();

    private float elapsedTime = 0f; // ��� �ð�
    public float duration; // �̵� �ð� (1��)
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
        if (!this.enabled)
        {
            return; // ��ũ��Ʈ�� ��Ȱ��ȭ�� ���¶�� �޼��带 ����
        }


        count2++;
        foreach (var atom in Atom)
        {   
            if (other.CompareTag(atom.name))
            {
                EnterAtom.Add(other.gameObject);
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
        if (!this.enabled)
        {
            return; // ��ũ��Ʈ�� ��Ȱ��ȭ�� ���¶�� �޼��带 ����
        }

        count2--;
        foreach (var atom in Atom)
        {
            if (atom == null)
                return;
            if (other.CompareTag(atom.name))
            {
                EnterAtom.Remove(other.gameObject);
                if (atom.activeSelf)
                {
                    atom.SetActive(false);
                    count--;
                    break;
                }
            }
        }
        elapsedTime = 0f;
    }

    private void Update()
    {
        if (count == Atom.Length && isActive && count2 == Atom.Length)
        {
            if (EnterAtom.Count > 0)
            {
                foreach (GameObject atom in EnterAtom)
                {
                    Destroy(atom);
                }
            }
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
                    FromObj[i].Translate(direction[i] * speed * Time.deltaTime, Space.World);
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
        yield return new WaitForSeconds(DelayTime);
        isActive = true;
    }
}
