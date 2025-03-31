using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshCheckAtom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject canvasPrefab; // �ν����Ϳ��� �Ҵ��� Canvas ������
    private GameObject spawnedCanvas; // ������ ĵ������ �����ϱ� ���� ����

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("H"))
        {
            InstantiateCanvas(); // ĵ���� ����
        }
    }

    void OnCollisionExit(Collision coll)
    {
        if (coll.gameObject.CompareTag("H"))
        {
            DestroyCanvas(); // ĵ���� ����
        }
    }

    void InstantiateCanvas()
    {
        if (canvasPrefab != null)
        {
            spawnedCanvas = Instantiate(canvasPrefab); // �������� ����
            Debug.Log("Canvas ������ ���� �Ϸ�!");
        }
        else
        {
            Debug.LogWarning("canvasPrefab�� �Ҵ���� �ʾҽ��ϴ�!");
        }
    }

    void DestroyCanvas()
    {
        if (spawnedCanvas != null)
        {
            Destroy(spawnedCanvas); // ������ ĵ������ ����
            spawnedCanvas = null; // ���� �ʱ�ȭ
            Debug.Log("Canvas ���� �Ϸ�!");
        }
    }

}
