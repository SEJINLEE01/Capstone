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
    public Transform CanvasPos;//canvas ���� ��ġ

    public GameObject PeriodPrefab; // �ν����Ϳ��� �Ҵ��� Period ������
    private GameObject spawnedPeriod; // ������ Period�� �����ϱ� ���� ����
    public Transform PeriodPos; // Period ���� ��ġ

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("H"))
        {
            InstantiateCanvas(); // ĵ���� ����
            InstantiatePeriod(); // PeriodPrefab ����
        }
    }

    void OnCollisionExit(Collision coll)
    {
        if (coll.gameObject.CompareTag("H"))
        {
            DestroyCanvas(); // ĵ���� ����
            DestroyPeriod(); // PeriodPrefab ����
        }
    }

    void InstantiateCanvas()
    {
        if (canvasPrefab != null)
        {
            spawnedCanvas = Instantiate(canvasPrefab,CanvasPos.position, CanvasPos.rotation); // �������� ����
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

    void InstantiatePeriod()
    {
        if (PeriodPrefab != null && PeriodPos != null)
        {
            spawnedPeriod = Instantiate(PeriodPrefab, PeriodPos.position, PeriodPos.rotation);
            Debug.Log("PeriodPrefab ���� �Ϸ�!");
        }
        else
        {
            Debug.LogWarning("PeriodPrefab �Ǵ� PeriodPos�� �Ҵ���� �ʾҽ��ϴ�!");
        }
    }

    void DestroyPeriod()
    {
        if (spawnedPeriod != null)
        {
            Destroy(spawnedPeriod);
            spawnedPeriod = null;
            Debug.Log("PeriodPrefab ���� �Ϸ�!");
        }
    }

}
